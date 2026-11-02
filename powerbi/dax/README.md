# DAX inventory

Create the calculated tables in `00-tables` first. Each remaining `.dax` file is one measure, including its name and equals sign, for **New measure**. These files are not DAX Studio queries. Bulk import: `../scripts/import-measures.cs` in Tabular Editor Advanced Scripting after table setup.

| Folder | Measure |
| --- | --- |
| 01-base | [TL Valid Year](01-base/TL-Valid-Year.dax) |
| 01-base | [TL Year](01-base/TL-Year.dax) |
| 01-base | [TL Actual](01-base/TL-Actual.dax) |
| 01-base | [TL Budget](01-base/TL-Budget.dax) |
| 01-base | [TL Variance](01-base/TL-Variance.dax) |
| 01-base | [TL Variance Pct](01-base/TL-Variance-Pct.dax) |
| 01-base | [TL Actual M](01-base/TL-Actual-M.dax) |
| 01-base | [TL Budget M](01-base/TL-Budget-M.dax) |
| 01-base | [TL Variance M](01-base/TL-Variance-M.dax) |
| 02-performance | [TL Annual Actual](02-performance/TL-Annual-Actual.dax) |
| 02-performance | [TL December Actual](02-performance/TL-December-Actual.dax) |
| 02-performance | [TL Annual Budget](02-performance/TL-Annual-Budget.dax) |
| 02-performance | [TL December Budget](02-performance/TL-December-Budget.dax) |
| 02-performance | [TL Annual Variance](02-performance/TL-Annual-Variance.dax) |
| 02-performance | [TL December Variance](02-performance/TL-December-Variance.dax) |
| 02-performance | [TL Annual Variance Pct](02-performance/TL-Annual-Variance-Pct.dax) |
| 03-cost | [TL Account Index](03-cost/TL-Account-Index.dax) |
| 03-cost | [TL Account Rank](03-cost/TL-Account-Rank.dax) |
| 03-cost | [TL Top Five](03-cost/TL-Top-Five.dax) |
| 03-cost | [TL Heatmap Account](03-cost/TL-Heatmap-Account.dax) |
| 03-cost | [TL Cost Actual Display](03-cost/TL-Cost-Actual-Display.dax) |
| 03-cost | [TL Cost Budget Display](03-cost/TL-Cost-Budget-Display.dax) |
| 03-cost | [TL Driver 1 Name](03-cost/TL-Driver-1-Name.dax) |
| 03-cost | [TL Driver 1 Variance](03-cost/TL-Driver-1-Variance.dax) |
| 03-cost | [TL Driver 2 Name](03-cost/TL-Driver-2-Name.dax) |
| 03-cost | [TL Driver 2 Variance](03-cost/TL-Driver-2-Variance.dax) |
| 03-cost | [TL Driver 3 Name](03-cost/TL-Driver-3-Name.dax) |
| 03-cost | [TL Driver 3 Variance](03-cost/TL-Driver-3-Variance.dax) |
| 03-cost | [TL Driver 1 Peak Month](03-cost/TL-Driver-1-Peak-Month.dax) |
| 02-performance | [TL Bridge Value M](02-performance/TL-Bridge-Value-M.dax) |
| 02-performance | [TL Bridge Label](02-performance/TL-Bridge-Label.dax) |
| 04-funding | [TL Cash](04-funding/TL-Cash.dax) |
| 04-funding | [TL Cash M](04-funding/TL-Cash-M.dax) |
| 04-funding | [TL Annual Cash](04-funding/TL-Annual-Cash.dax) |
| 04-funding | [TL Accrual](04-funding/TL-Accrual.dax) |
| 04-funding | [TL Accrual M](04-funding/TL-Accrual-M.dax) |
| 04-funding | [TL Annual Accrual](04-funding/TL-Annual-Accrual.dax) |
| 04-funding | [TL Funding Gap](04-funding/TL-Funding-Gap.dax) |
| 04-funding | [TL Funding Gap M](04-funding/TL-Funding-Gap-M.dax) |
| 04-funding | [TL Coverage Pct](04-funding/TL-Coverage-Pct.dax) |
| 04-funding | [TL Annual Funding Gap](04-funding/TL-Annual-Funding-Gap.dax) |
| 04-funding | [TL Annual Coverage Pct](04-funding/TL-Annual-Coverage-Pct.dax) |
| 04-funding | [TL December Cash Share Pct](04-funding/TL-December-Cash-Share-Pct.dax) |
| 04-funding | [TL Funding Display](04-funding/TL-Funding-Display.dax) |
| 04-funding | [TL Funding Label](04-funding/TL-Funding-Label.dax) |
| 06-text | [TL Performance Title](06-text/TL-Performance-Title.dax) |
| 06-text | [TL Cost Title](06-text/TL-Cost-Title.dax) |
| 06-text | [TL Funding Title](06-text/TL-Funding-Title.dax) |
| 06-text | [TL Context](06-text/TL-Context.dax) |
| 06-text | [TL Source Note](06-text/TL-Source-Note.dax) |
| 06-text | [TL Performance Alt Text](06-text/TL-Performance-Alt-Text.dax) |
| 06-text | [TL Cost Alt Text](06-text/TL-Cost-Alt-Text.dax) |
| 06-text | [TL Funding Alt Text](06-text/TL-Funding-Alt-Text.dax) |
| 05-html | [TL Expenses Spark HTML](05-html/TL-Expenses-Spark-HTML.dax) |
| 05-html | [TL Variance Spark HTML](05-html/TL-Variance-Spark-HTML.dax) |
| 05-html | [TL Cash Spark HTML](05-html/TL-Cash-Spark-HTML.dax) |
| 05-html | [TL Expense Card HTML](05-html/TL-Expense-Card-HTML.dax) |
| 05-html | [TL Budget Card HTML](05-html/TL-Budget-Card-HTML.dax) |
| 05-html | [TL December Card HTML](05-html/TL-December-Card-HTML.dax) |
| 05-html | [TL Driver 1 Card HTML](05-html/TL-Driver-1-Card-HTML.dax) |
| 05-html | [TL Driver 2 Card HTML](05-html/TL-Driver-2-Card-HTML.dax) |
| 05-html | [TL Funding Card HTML](05-html/TL-Funding-Card-HTML.dax) |
| 05-html | [TL Cash Card HTML](05-html/TL-Cash-Card-HTML.dax) |
| 05-html | [TL Accrual Card HTML](05-html/TL-Accrual-Card-HTML.dax) |
| 05-html | [TL Performance Header HTML](05-html/TL-Performance-Header-HTML.dax) |
| 05-html | [TL Cost Header HTML](05-html/TL-Cost-Header-HTML.dax) |
| 05-html | [TL Funding Header HTML](05-html/TL-Funding-Header-HTML.dax) |
| 05-html | [TL Investigation Note HTML](05-html/TL-Investigation-Note-HTML.dax) |
| 05-html | [TL Funding Note HTML](05-html/TL-Funding-Note-HTML.dax) |
| 03-cost | [TL Driver 1 Actual](03-cost/TL-Driver-1-Actual.dax) |
| 03-cost | [TL Driver 1 Budget](03-cost/TL-Driver-1-Budget.dax) |
| 05-html | [TL Driver 1 Spark HTML](05-html/TL-Driver-1-Spark-HTML.dax) |
| 03-cost | [TL Driver 2 Actual](03-cost/TL-Driver-2-Actual.dax) |
| 03-cost | [TL Driver 2 Budget](03-cost/TL-Driver-2-Budget.dax) |
| 05-html | [TL Driver 2 Spark HTML](05-html/TL-Driver-2-Spark-HTML.dax) |
| 05-html | [TL Monthly Table HTML](05-html/TL-Monthly-Table-HTML.dax) |
| 06-text | [TL Cost Chart Title](06-text/TL-Cost-Chart-Title.dax) |
| 06-text | [TL Heatmap Title](06-text/TL-Heatmap-Title.dax) |
| 06-text | [TL Cash Chart Title](06-text/TL-Cash-Chart-Title.dax) |
| 06-text | [TL Coverage Title](06-text/TL-Coverage-Title.dax) |
