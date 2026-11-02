"""Reconcile the kit's fixed source scope with the reviewed HTML aggregates.
This checks source arithmetic, not execution of DAX by a Power BI engine.
Run from repository root: python3 powerbi/validation/verify-source.py
"""
import csv,json,math
from pathlib import Path
from collections import defaultdict
p=Path(__file__).resolve().parents[2]
expected=json.loads((p/'data/dashboard-data.json').read_text())
ops=list(csv.DictReader((p/'data/raw/operations_2023_2025.csv').open()))
subs=list(csv.DictReader((p/'data/raw/subsidies_2023_2025.csv').open()))
checks=[]
def check(label,a,b):
 assert math.isclose(a,b,abs_tol=.00001),(label,a,b)
 checks.append({'check':label,'source':a,'expected':b,'status':'pass'})
for year,d in expected.items():
 o=[r for r in ops if r['agency']=='NYCT' and r['fiscal_year']==year and r['financial_plan_year']==year and r['expense_type']=='NREIMB' and r['type']=='Total Expenses Before Non-Cash Liability Adjs.']
 for sc,key in [('Actual','actual'),('Adopted Budget','budget')]:
  check(year+' '+sc,sum(float(r['amount']) for r in o if r['scenario']==sc)/1e6,d[key])
  for m in range(1,13): check(f'{year} {sc} month {m}',sum(float(r['amount']) for r in o if r['scenario']==sc and int(r['month'][5:7])==m)/1e6,d['monthly'][m-1][key])
 a=defaultdict(float)
 for r in o:
  if r['scenario'] in ['Actual','Adopted Budget']:a[r['general_ledger']]+=float(r['amount'])*(1 if r['scenario']=='Actual' else -1)/1e6
 top=sorted(a,key=lambda n:(-a[n],n))[:5]
 assert top==[x['name'] for x in d['costs'][:5]],(year,top)
 for n in top:check(year+' '+n+' variance',a[n],next(c['actual']-c['budget'] for c in d['costs'] if c['name']==n))
 s=[r for r in subs if r['agency']=='NYCT' and r['fiscal_year']==year and r['financial_plan_year']==year and r['scenario']=='Actual' and r['type']=='Total Dedicated Taxes & State and Local Subsidies']
 for basis,key in [('Cash','cash'),('NREIMB','accrual')]:
  check(year+' '+key,sum(float(r['amount']) for r in s if r['expense_type']==basis)/1e6,d[key])
  for m in range(1,13):check(f'{year} {key} month {m}',sum(float(r['amount']) for r in s if r['expense_type']==basis and int(r['month'][5:7])==m)/1e6,d['funding'][m-1][key])
measures=json.loads((p/'powerbi/measures.json').read_text())
assert len({m['name'] for m in measures})==len(measures)
import re
names={m['name'] for m in measures}
for m in measures:
 for dep in re.findall(r'\[(TL [^\]]+)\]',m['expression']):assert dep in names,(m['name'],dep)
report={'source_checks':len(checks),'measure_count':len(measures),'checks':checks,'dax_engine_validation':'Not executed; requires Power BI Desktop or a connected Analysis Services model.'}
(p/'powerbi/validation/source-results.json').write_text(json.dumps(report,indent=2))
print(len(checks),'source comparisons passed;',len(measures),'measure names and dependencies checked.')
