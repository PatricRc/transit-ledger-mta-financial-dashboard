# Raw source extracts

Unmodified CSV snapshots downloaded from MTA datasets on New York State Open Data on November 1, 2026. These are filtered 2023–2025 extracts, not full historical datasets. They include broader agency/scenario coverage than the dashboard’s NYCT view.

| File | Rows | Source |
| --- | ---: | --- |
| operations_2023_2025.csv | 37,956 | [Statement of Operations](https://data.ny.gov/Transportation/MTA-Statement-of-Operations-Beginning-2019/yg77-3tkj) |
| subsidies_2023_2025.csv | 8,100 | [Subsidies](https://data.ny.gov/Transportation/MTA-Subsidies-Beginning-2019/dfg9-c5rx) |
| ridership_2023_2025.csv | 8,394 | [Daily Ridership and Traffic](https://data.ny.gov/Transportation/MTA-Daily-Ridership-and-Traffic-Beginning-2020/sayj-mze2) |

Finance extracts filter fiscal_year to 2023–2025 and financial_plan_year = fiscal_year. Ridership filters dates from January 1, 2023 inclusive to January 1, 2026 exclusive. Ridership is retained for the broader project and is not visualized in the current HTML dashboard.

See manifest.json for exact download URLs, filters, column names, byte counts and SHA-256 checksums. Row counts exclude headers. Preserve negative financial amounts; do not combine cash and accrual bases. Source data remains subject to the provider’s applicable terms; no new data license is asserted here.
