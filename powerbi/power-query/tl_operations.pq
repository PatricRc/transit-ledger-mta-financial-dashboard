let
    Source = Csv.Document(File.Contents(pRawFolder & "/operations_2023_2025.csv"), [Delimiter=",", Encoding=65001, QuoteStyle=QuoteStyle.Csv]),
    Headers = Table.PromoteHeaders(Source, [PromoteAllScalars=true]),
    Typed = Table.TransformColumnTypes(Headers, {{"fiscal_year", Int64.Type}, {"financial_plan_year", Int64.Type}, {"amount", type number}}, "en-US"),
    Dates = Table.TransformColumns(Typed, {{"month", each Date.From(DateTime.FromText(_, [Culture="en-US"])), type date}}),
    Scope = Table.SelectRows(Dates, each [fiscal_year] = [financial_plan_year] and [agency] = "NYCT" and [fiscal_year] >= 2023 and [fiscal_year] <= 2025)
in
    Scope
