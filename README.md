# Transit Ledger — MTA Financial Dashboard

A five-page Power BI portfolio report using real MTA Open Data for NYC Transit, 2023–2025. Independent portfolio study; no MTA affiliation or measured client savings are claimed.

[Open the public Power BI report](https://app.powerbi.com/view?r=eyJrIjoiMDI0MGVlOGYtYmEyNC00Y2ZkLThhZjItNzE4MzkxNjVkZTg5IiwidCI6ImQxZmYwZmFmLTA5ZWItNDJjZi04MzEzLTA3MzNiM2Y3MDdkNyIsImMiOjR9) · [Download the complete PBIP/PBIR/TMDL source](transit-ledger-powerbi-final.zip) · [Original HTML prototype](index.html)

![Welcome](screenshots/welcome.png)

## Client & context
Finance teams need to see where spending departed from plan and distinguish recognized subsidies from cash receipts. This project demonstrates that workflow with a public, static source snapshot rather than private client data.

## Problem
Annual totals conceal account-level pressure and reporting-period timing. A variance locates a question; it does not establish its cause.

## What I built

| Page | Question | Visuals and controls |
|---|---|---|
| Welcome | Where did NYC Transit’s money go? | Subway photograph, three scoped annual figures, Explore and portfolio links |
| Performance | Where did expenses finish against budget? | Unified KPI strip, actual/budget line, PEAK/LOW and September annotation, variance waterfall, three-year strip, searchable Account selector |
| Cost Pressure | Which accounts drove upward pressure, and when? | Ranked budget-marker bars, monthly heatmap, $ Amount / % Index / Actual / Budget controls |
| Funding | How did cash compare with accrued subsidies? | Quarterly coverage tracks, monthly columns, Gap / Coverage control affecting KPI and chart |
| The Ledger | What are the exact account and month differences? | Monthly variance matrix, annual actual/budget/variance/percent/status, searchable accounts and Top N |

Year is single-select and synchronized, with a saved 2025 starting view. Native page navigation replaces the visible page tabs. A guide explains the comparisons and limitations. The native monthly detail strip on Performance passes real month context to a report-page tooltip with actual, budget, variance and the three largest upward account variances. The larger SVG line is an editorial graphic.

## Results in the 2025 snapshot

- Operating expenses: **$10.97B**, **$363.7M above** same-year adopted budget (**3.4%**).
- Claims and overtime contributed **$667.2M** in upward variance, partly offset by other accounts. This is not the net overspend.
- Selected subsidy cash: **$933.1M** versus **$947.6M** accrued: **98.5% coverage** and a **$14.4M gap**.

All **92 live model measures** were checked for engine errors; none were found. Three-year totals were queried from the Import model. Performance was consolidated from seven HTML visual containers to one HTML container plus a small native monthly chart. Two recorded edit-mode runs measured that HTML visual at 2,521 and 3,340 ms. These are not anonymous end-to-end load-time benchmarks; the raw trace is included in PowerBIPerformanceData.json.

## Design process
Finding-first wireframes → semantic design tokens → reusable HTML/SVG components → native navigation and synchronized filters → model and browser checks. Serif display text, sans labels, cream surfaces and dark navy story cards form the common system. Coral graphics encode upward pressure; accessible darker coral text and selection fills, signs and status labels support interpretation. The World of Peaches by Gus Bavia was a workflow reference; its assets and code were not copied.

## Source and data scope

- [MTA Statement of Operations: Beginning 2019](https://data.ny.gov/Transportation/MTA-Statement-of-Operations-Beginning-2019/yg77-3tkj)
- [MTA Subsidies: Beginning 2019](https://data.ny.gov/Transportation/MTA-Subsidies-Beginning-2019/dfg9-c5rx)
- [MTA Open Data](https://www.mta.info/open-data)

Operations: NYCT, NREIMB, fiscal year equal to financial-plan year, Actual versus Adopted Budget, Total Expenses Before Non-Cash Liability Adjs. Funding: NYCT Actual, matching plan year, selected Total Dedicated Taxes & State and Local Subsidies; Cash and source NREIMB accrual are aggregated separately, excluding interagency eliminations. This is not total organizational cash flow, a consolidated income statement or an audited reconciliation. Values use unrounded source totals; labels are rounded. The 2023–2025 raw snapshot remains under data/raw/.

## Repository and build

- `transit-ledger-powerbi-final.zip`: complete PBIP project, PBIR report/assets, TMDL Import model, all 92 measures, theme, HTML render snapshots and validation.
- `dax/`: current per-page visual measures and controls; dependencies are included in the full TMDL export.
- `src/Model/`: current model source; `src/StaticResources/`: native JSON theme.
- `html-components/`: source-backed 2025 visual render snapshots and shared `tokens.css`.
- `screenshots/`: live Power BI views; `PowerBIPerformanceData.json`: recorded timing evidence.
- `index.html` and `powerbi/`: original three-page HTML prototype and historical build kit. **The full exported model is the current source of truth; legacy raw-table DAX in the historical kit is not the live gold-table implementation.**

Open the ZIP’s `TransitLedger.pbip` in a current Windows Power BI Desktop. The report references the included semantic model by path. Replace `YOUR_SQL_ENDPOINT` in model partition M and configure authorized OAuth credentials. The export contains metadata, not imported rows or credentials. PBIR was successfully imported in the Power BI service; Windows Desktop opening was not validated from macOS. The original Direct Lake report was left intact; the public report uses its Import copy.

## Stack
Power BI/Fabric, Import semantic model, Power Query M, DAX, TMDL/PBIR, Python/pandas, HTML/CSS and SVG.

## How I would adapt this for you
Agree on account mappings, plan vintages and favorable-variance rules; connect governed finance data; reconcile totals with finance; then adapt the semantic model, narrative and deployment to the client’s needs. The portfolio’s figures are data findings, not claimed business outcomes.

Photo: [Zoshua Colah / Unsplash](https://unsplash.com/photos/U7sa3qyocpI), Unsplash License, under a navy overlay. [DataPat.ai](https://data-pat-ai.netlify.app/) · [LinkedIn](https://www.linkedin.com/in/patriciorioscanepa)
