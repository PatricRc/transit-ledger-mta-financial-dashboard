# Power BI build kit — Transit Ledger

Start here to recreate the three approved HTML pages in Power BI Desktop. Includes **80 DAX measures**, calculated helper tables, two Power Query loaders, six Deneb Vega-Lite charts, HTML/SVG cards and panels, a theme, vector page backgrounds and icons. Source: the CSV snapshots already in this repository. No `.pbix`, installed custom visuals, report bookmarks or connected semantic model is shipped. This is authored build code; DAX execution and final layout still require verification in Desktop.

## 1. Create the source queries

Use a new Import-mode report initially, so existing gold-model relationships do not interfere. In Power Query create a Text parameter named **pRawFolder**, pointing to your local `data/raw` folder (no trailing slash). Create two blank queries named **tl_operations** and **tl_subsidies**. Paste the respective `.pq` code from `power-query/` into Advanced Editor. Apply changes.

These loaders retain raw field names, select NYCT, match fiscal year to plan year, and preserve all scenarios/bases until the DAX scopes them. Amounts stay in **original USD**; measures suffixed M divide by one million. The current kit intentionally does not import ridership because none of the three HTML pages uses it.

**Existing gold model:** your earlier `gold_fact_operations` had fields such as Month, Scenario, AgencyCode, AccountType, AccountSubtype, GeneralLedger, ReimbursementType and Amount. Those are not the raw schema used here. Do not paste the measures unchanged onto that table. Either use the isolated `tl_` setup, or explicitly map the raw names and ensure equivalent scope and one-to-many relationships. No AccountKey or SubsidyAccountKey is assumed by this kit.

## 2. Create the tables and relationships

In Modeling → New table, paste each file under `dax/00-tables`. Create tl_date, tl_account, tl_cost_view, tl_funding_view, tl_bridge and tl_measures. Mark **tl_date** as the date table using Date. Set MonthName to sort by MonthNo and Quarter to sort by QuarterNo. Hide the Placeholder column in tl_measures.

Create these active, single-direction relationships:

| One side | Many side |
| --- | --- |
| tl_date[Date] | tl_operations[month] |
| tl_date[Date] | tl_subsidies[month] |
| tl_account[Account] | tl_operations[general_ledger] |

Leave tl_bridge, tl_cost_view and tl_funding_view **disconnected**. No fact-to-fact relationships. Account uses general ledger within the fixed operations category; do not reuse this account dimension for other statement categories without a composite key.

Add a single-select slicer **tl_date[Year]**, select 2025, disable Select all, and sync it across all pages. Hide or disable month/date and agency/scenario slicers for this version. Headlines, account ranks and annual cards intentionally summarize the full selected year. This report is fixed to NYCT; it is not an all-agency template. Do not connect these queries to a second calendar or the existing gold dimensions.

## 3. Import the measures

Option A: create each file under `dax/01-base` through `06-text` as **New measure**, in dependency order (base → performance annual measures → account drivers → bridge → funding → text → HTML). Forward dependencies may need the dependent measure pasted afterward.

Option B: after creating the tables, launch Tabular Editor from Desktop and run `scripts/import-measures.cs` in Advanced Scripting. It adds or updates only the named measures in tl_measures and applies display folders/format strings. Save back to Desktop. Review any engine errors before continuing. It does not create tables or relationships.

All definitions and display formats are also recorded in `measures.json`. The measures override source scenario/basis filters to enforce the stated comparisons. They are designed for a single selected year, with no account slicer. Positive expense variance means overspend. Funding gap is accrual minus cash; negative means more cash than accrual, not a missing record.

## 4. Add visuals and styling

Import `theme/transit-ledger.json` via View → Themes → Browse. Add **Deneb** and **HTML Content** from the Power BI visual marketplace. No third-party visual binary is vendored here. Your tenant must permit those visuals. If the HTML edition you use restricts inline SVG, use native Cards with native sparklines or an edition supporting the required tags; test export behavior in your target environment.

For every Deneb visual: choose **Vega-Lite**, start with an empty specification, paste the matching JSON under `visuals/deneb/`, and add exactly the columns and measures listed below to Values. Keep their displayed field names unchanged. MonthNo, QuarterNo and Step are **Do not summarize** grouping fields. Do not use auto date hierarchies. The code binds to Deneb's named `dataset`.

For HTML Content: add only the named HTML measure to its values field. No JavaScript, browser DOM, HTML button handlers or dialogs are used in these components. Data changes come from native Power BI slicers; HTML does not create native report navigation. All HTML is generated from live measures, not pasted static screenshots.

### Page 1 — Performance

| Element | Visual/code | Fields or measures |
| --- | --- | --- |
| Header | HTML Content | TL Performance Header HTML |
| Expenses KPI + trend | HTML Content | TL Expense Card HTML |
| Budget KPI + mini variance bars | HTML Content | TL Budget Card HTML |
| December KPI + mini variance bars | HTML Content | TL December Card HTML |
| Actual vs budget line | Deneb `01-monthly-expenses.json` | tl_date[MonthName], tl_date[MonthNo], TL Actual M, TL Budget M |
| Monthly table alternative | HTML Content | TL Monthly Table HTML |
| Variance bridge | Deneb `02-variance-bridge.json` | tl_bridge[Step], TL Bridge Label, TL Bridge Value M |
| Investigation strip | HTML Content | TL Investigation Note HTML |

Line-chart y-axis is intentionally truncated and labeled. Waterfall bars float between cumulative values; the final bar is a zero-based total. Driver ranking is annual upward variance, with alphabetical tie-breaking; Other net includes all remaining accounts, including offsets. Never sum the final total bar into the first four steps.

### Page 2 — Cost pressure

| Element | Visual/code | Fields or measures |
| --- | --- | --- |
| Header | HTML Content | TL Cost Header HTML |
| Driver cards | two HTML Content visuals | TL Driver 1 Card HTML; TL Driver 2 Card HTML |
| Driver mini-charts | two HTML Content visuals | TL Driver 1 Spark HTML; TL Driver 2 Spark HTML |
| Actual/plan values under cards | native Cards or Multi-row cards | TL Driver 1 Actual, TL Driver 1 Budget; TL Driver 2 Actual, TL Driver 2 Budget |
| Narrative | HTML Content | TL Investigation Note HTML |
| Budget-marker bars | Deneb `03-budget-marker-bars.json` | tl_account[Account], TL Account Rank, TL Cost Actual Display, TL Cost Budget Display, TL Actual M, TL Budget M, TL Variance M, TL Account Index, TL Top Five |
| Monthly heatmap | Deneb `04-monthly-heatmap.json` | tl_account[Account], tl_date[MonthName], tl_date[MonthNo], TL Variance M, TL Account Rank, TL Heatmap Account |

**Mandatory visual filters:** bars: TL Top Five = 1. Heatmap: TL Heatmap Account = 1. Rank remains annual when MonthName is in the visual. Set chart title using fx → TL Cost Chart Title and heatmap title using TL Heatmap Title. Bar x-axis says USD millions; index mode changes numbers to ratios where **1.0 = 100%** of budget, not dollar values. Tick mark is adopted budget. Heatmap labels are rounded; tooltips retain decimals; color intensity caps at ±$100M. The kit dynamically shows the top three accounts plus Payroll; this matches the approved 2025 view and avoids hardcoding Claims into 2023.

Add a single-select **tl_cost_view[View]** slicer styled as horizontal tiles for $ Amount / % Index. Leave it disconnected. Default $ Amount.

### Page 3 — Funding

| Element | Visual/code | Fields or measures |
| --- | --- | --- |
| Header | HTML Content | TL Funding Header HTML |
| Funding gap + cash trend | HTML Content | TL Funding Card HTML |
| Cash and accrual tiles | two HTML Content visuals | TL Cash Card HTML; TL Accrual Card HTML |
| Narrative | HTML Content | TL Funding Note HTML |
| Quarterly coverage | Deneb `05-quarterly-coverage.json` | tl_date[Quarter], tl_date[QuarterNo], TL Cash M, TL Accrual M, TL Coverage Pct, TL Funding Gap M, TL Funding Label |
| Monthly receipts | Deneb `06-monthly-cash.json` | tl_date[MonthName], tl_date[MonthNo], TL Cash M |

Set quarterly chart title with TL Coverage Title and monthly receipts title with TL Cash Chart Title. Coverage tracks end at 100%, while tooltip and explicit `Cash exceeds accrual` labels show values above 100%. This replaces the browser-only stripe styling with a portable text cue. Annual coverage must be **annual cash / annual accrual**, not the average of quarterly percentages.

Add a single-select **tl_funding_view[View]** slicer for $ Gap / % Coverage. Default $ Gap. It changes the direct labels while the tracks always encode coverage.

## 5. Canvas, navigation and toggles

Use a **1920 × 1080 custom page**. Optional original editable SVG shells are in `visuals/assets/*-background.svg`; apply them as canvas backgrounds at 0% transparency. They contain only card surfaces and identity, never data. Icons are separate SVG files for native navigation buttons. Layout reference:

| Page | X / Y / width / height |
| --- | --- |
| All headers | 140 / 125 / 1450 / 105 |
| Year slicer (all pages) | 1560 / 25 / 220 / 65 |
| Performance KPI row | 140 / 250 / 560 / 180; 720 / 250 / 520 / 180; 1260 / 250 / 520 / 180 |
| Performance line or table | 140 / 455 / 1000 / 480 |
| Performance waterfall | 1160 / 455 / 620 / 480 |
| Cost left story column | 140 / 250 / 320 / 685 |
| Cost bars | 480 / 250 / 1300 / 360 |
| Cost heatmap | 480 / 630 / 1300 / 305 |
| Funding left story column | 140 / 250 / 320 / 685 |
| Funding coverage | 480 / 250 / 1300 / 330 |
| Funding cash columns | 480 / 600 / 1300 / 335 |

Disable native visual backgrounds/borders where a background shell supplies the card surface. Reduce Deneb internal chart height as necessary to leave room for its native title within the mapped container. Do not stretch the source screenshots behind visuals. SVG shell and cards can be resized independently to accommodate your display scale. Segoe UI is used for portability; browser typography is a design reference, not an exact Power BI font rendering guarantee.

Create native page navigation buttons in the left rail for Performance / Cost pressure / Funding. Use a **Selection pane group** for the chart and a second group for the table, then create Chart/Table bookmarks with **Display on, Data off, Selected visuals only**; attach them to native buttons. Do not use those bookmarks to reset filters.

For Reset create a separate bookmark with **Data on**, Year=2025, $ Amount and $ Gap selected, and chart view visible. For Help create a native overlay group (text box based on the reading guide in index.html) and Show/Close bookmarks with Data off. Buttons, slicers, bookmarks and page navigation need to be wired in Desktop; the SVG and HTML components cannot create those report objects.

Bind each page's **TL Performance Alt Text**, **TL Cost Alt Text** or **TL Funding Alt Text** using conditional formatting of visual Alt text where supported, and add specific static chart descriptions for units, scale and reading direction. Tab order should follow header → year → KPIs → primary chart → supporting chart → navigation.

## 6. Validation before publishing

`validation/verify-source.py` independently compared the fixed filters with the reviewed HTML dataset: **171 source comparisons passed**, including monthly values across all three years and top-account ordering. `source-results.json` records the evidence. DAX dependencies and measure-name uniqueness were checked. Six Vega-Lite specifications compiled, executed through Vega and rendered to SVG with the 2025 fixture data (see `validation/*-preview.svg`). Reproduce from the repository root with `npm --prefix powerbi/validation install` and `node powerbi/validation/render-charts.cjs`. These rendered fixtures are previews, not actual Power BI report screenshots. These checks do **not** execute DAX or prove Power BI integration.

Run `validation/check-model.dax` in Desktop DAX Query View. With year=2025 and no account filter, expect:

| Metric | Expected original USD |
| --- | ---: |
| TL Annual Actual | 10,967,556,596.33 |
| TL Annual Budget | 10,603,852,205.84 |
| TL Annual Variance | 363,704,390.49 |
| TL Driver 1 Name | Claims |
| TL Driver 1 Variance | 409,274,543.96 |
| TL Driver 2 Variance | 257,938,616.51 |
| TL Annual Cash | 933,145,188.36 |
| TL Annual Accrual | 947,583,413.20 |
| TL Annual Funding Gap | 14,438,224.84 |

Also check 2023 expenses below plan and 2024 cash above accrual. Verify all slicers, rank persistence across months, native bookmark scope, Deneb field aliases, readable labels at final sizes, keyboard focus, and SVG rendering/export in your chosen HTML edition. A month filter changes monthly charts but full-year cards intentionally remain annual; the provided UI therefore exposes only Year. DAX Studio cannot create measures by running the standalone New measure definitions as queries.

## Sources and technical references

- [City Sustainability Scorecard](https://github.com/gusbavia/city-sustainability-scorecard): architectural reference for grouped DAX and model-bound HTML components. No reference-project source or binary is copied into this kit.
- [Microsoft: CALCULATE](https://learn.microsoft.com/en-us/dax/calculate-function-dax) and [REMOVEFILTERS](https://learn.microsoft.com/en-us/dax/removefilters-function-dax): filter-context behavior.
- [Deneb dataset contract](https://deneb.guide/docs/dataset): named dataset and field grain.
- [HTML Content limitations](https://html-content.com/docs/limitations): sandbox, SVG/edition and export considerations.

This is a fixed-scope financial reporting starter, not an audited reconciliation, all-agency semantic model, production refresh pipeline or finished PBIX report.
