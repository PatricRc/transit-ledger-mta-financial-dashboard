// Run from repository root after npm --prefix powerbi/validation install.
const fs=require('fs'),vl=require('vega-lite'),vega=require('vega');
const base='powerbi/visuals/deneb/', d=JSON.parse(fs.readFileSync('data/dashboard-data.json'))['2025'];const months=['Jan','Feb','Mar','Apr','May','Jun','Jul','Aug','Sep','Oct','Nov','Dec'];
const top=d.costs.slice(0,3).map(c=>c.actual-c.budget); const delta=d.actual-d.budget,vs=[...top,delta-top.reduce((a,b)=>a+b,0),delta];
let rows={
'01-monthly-expenses':d.monthly.map((r,i)=>({MonthName:months[i],MonthNo:i+1,'TL Actual M':r.actual,'TL Budget M':r.budget})),
'02-variance-bridge':vs.map((v,i)=>({Step:i+1,'TL Bridge Label':i<3?d.costs[i].name:i===3?'Other net':'Net variance','TL Bridge Value M':v})),
'03-budget-marker-bars':d.costs.slice(0,5).map((c,i)=>({Account:c.name,'TL Account Rank':i+1,'TL Cost Actual Display':c.actual,'TL Cost Budget Display':c.budget,'TL Actual M':c.actual,'TL Budget M':c.budget,'TL Variance M':c.actual-c.budget,'TL Account Index':c.actual/c.budget})),
'04-monthly-heatmap':d.costs.filter((c,i)=>i<3||c.name==='Payroll').flatMap(c=>c.months.map((v,i)=>({Account:c.name,MonthName:months[i],MonthNo:i+1,'TL Variance M':v,'TL Account Rank':d.costs.indexOf(c)+1}))),
'05-quarterly-coverage':[0,1,2,3].map(i=>{let a=d.funding.slice(i*3,i*3+3),cash=a.reduce((s,r)=>s+r.cash,0),accrual=a.reduce((s,r)=>s+r.accrual,0);return{Quarter:'Q'+(i+1),QuarterNo:i+1,'TL Cash M':cash,'TL Accrual M':accrual,'TL Coverage Pct':cash/accrual,'TL Funding Gap M':accrual-cash,'TL Funding Label':(accrual-cash).toFixed(1)+'M'}}),
'06-monthly-cash':d.funding.map((r,i)=>({MonthName:months[i],MonthNo:i+1,'TL Cash M':r.cash}))};
(async()=>{for(const name of Object.keys(rows)){
 let file=base+name+'.json',s=JSON.parse(fs.readFileSync(file));
 if(name==='03-budget-marker-bars'){s.transform=[{calculate:'datum["TL Account Rank"] + " · " + datum.Account',as:'AccountOrder'}];s.encoding.y={field:'AccountOrder',type:'nominal',sort:'ascending',axis:{title:null,labelLimit:210}};}
 if(name==='05-quarterly-coverage')s.encoding.y.sort='ascending';
 if(name==='06-monthly-cash')s.encoding.x={field:'MonthNo',type:'ordinal',sort:'ascending',axis:{title:null,labelAngle:0,labelExpr:'["Jan","Feb","Mar","Apr","May","Jun","Jul","Aug","Sep","Oct","Nov","Dec"][datum.value - 1]'}};
 fs.writeFileSync(file,JSON.stringify(s,null,2));s.width=800;s.data={values:rows[name]};
 const compiled=vl.compile(s).spec,view=new vega.View(vega.parse(compiled),{renderer:'none'});await view.runAsync();const out=await view.toSVG();fs.writeFileSync('powerbi/validation/'+name+'-preview.svg',out);view.finalize();console.log('Compiled, executed Vega and rendered SVG:',name);
}})().catch(e=>{console.error(e);process.exit(1)});
