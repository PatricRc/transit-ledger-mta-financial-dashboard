// Tabular Editor Advanced Scripting. Create tl_ tables first.
var table = Model.Tables["tl_measures"];
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Valid Year");
if (m == null) m = table.AddMeasure(@"TL Valid Year", @"INT ( HASONEVALUE(tl_date[Year]) )");
else m.Expression = @"INT ( HASONEVALUE(tl_date[Year]) )";
m.DisplayFolder = @"01-base";
m.FormatString = @"0";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Year");
if (m == null) m = table.AddMeasure(@"TL Year", @"SELECTEDVALUE(tl_date[Year])");
else m.Expression = @"SELECTEDVALUE(tl_date[Year])";
m.DisplayFolder = @"01-base";
m.FormatString = @"0";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Actual");
if (m == null) m = table.AddMeasure(@"TL Actual", @"IF ( [TL Valid Year] = 1,
 CALCULATE ( SUM(tl_operations[amount]),
    tl_operations[scenario] = ""Actual"",
    tl_operations[expense_type] = ""NREIMB"",
    tl_operations[type] = ""Total Expenses Before Non-Cash Liability Adjs.""
 ) )");
else m.Expression = @"IF ( [TL Valid Year] = 1,
 CALCULATE ( SUM(tl_operations[amount]),
    tl_operations[scenario] = ""Actual"",
    tl_operations[expense_type] = ""NREIMB"",
    tl_operations[type] = ""Total Expenses Before Non-Cash Liability Adjs.""
 ) )";
m.DisplayFolder = @"01-base";
m.FormatString = @"#,0.0;−#,0.0;0.0";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Budget");
if (m == null) m = table.AddMeasure(@"TL Budget", @"IF ( [TL Valid Year] = 1,
 CALCULATE ( SUM(tl_operations[amount]),
    tl_operations[scenario] = ""Adopted Budget"",
    tl_operations[expense_type] = ""NREIMB"",
    tl_operations[type] = ""Total Expenses Before Non-Cash Liability Adjs.""
 ) )");
else m.Expression = @"IF ( [TL Valid Year] = 1,
 CALCULATE ( SUM(tl_operations[amount]),
    tl_operations[scenario] = ""Adopted Budget"",
    tl_operations[expense_type] = ""NREIMB"",
    tl_operations[type] = ""Total Expenses Before Non-Cash Liability Adjs.""
 ) )";
m.DisplayFolder = @"01-base";
m.FormatString = @"#,0.0;−#,0.0;0.0";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Variance");
if (m == null) m = table.AddMeasure(@"TL Variance", @"[TL Actual] - [TL Budget]");
else m.Expression = @"[TL Actual] - [TL Budget]";
m.DisplayFolder = @"01-base";
m.FormatString = @"#,0.0;−#,0.0;0.0";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Variance Pct");
if (m == null) m = table.AddMeasure(@"TL Variance Pct", @"DIVIDE([TL Variance], [TL Budget])");
else m.Expression = @"DIVIDE([TL Variance], [TL Budget])";
m.DisplayFolder = @"01-base";
m.FormatString = @"0.0%;-0.0%;0.0%";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Actual M");
if (m == null) m = table.AddMeasure(@"TL Actual M", @"DIVIDE([TL Actual], 1000000)");
else m.Expression = @"DIVIDE([TL Actual], 1000000)";
m.DisplayFolder = @"01-base";
m.FormatString = @"#,0.0;−#,0.0;0.0";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Budget M");
if (m == null) m = table.AddMeasure(@"TL Budget M", @"DIVIDE([TL Budget], 1000000)");
else m.Expression = @"DIVIDE([TL Budget], 1000000)";
m.DisplayFolder = @"01-base";
m.FormatString = @"#,0.0;−#,0.0;0.0";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Variance M");
if (m == null) m = table.AddMeasure(@"TL Variance M", @"DIVIDE([TL Variance], 1000000)");
else m.Expression = @"DIVIDE([TL Variance], 1000000)";
m.DisplayFolder = @"01-base";
m.FormatString = @"#,0.0;−#,0.0;0.0";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Annual Actual");
if (m == null) m = table.AddMeasure(@"TL Annual Actual", @"VAR y = [TL Year]
RETURN IF([TL Valid Year] = 1, CALCULATE([TL Actual], REMOVEFILTERS(tl_date), tl_date[Year] = y))");
else m.Expression = @"VAR y = [TL Year]
RETURN IF([TL Valid Year] = 1, CALCULATE([TL Actual], REMOVEFILTERS(tl_date), tl_date[Year] = y))";
m.DisplayFolder = @"02-performance";
m.FormatString = @"#,0.0;−#,0.0;0.0";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL December Actual");
if (m == null) m = table.AddMeasure(@"TL December Actual", @"VAR y = [TL Year]
RETURN IF([TL Valid Year] = 1, CALCULATE([TL Actual], REMOVEFILTERS(tl_date), tl_date[Year] = y, tl_date[MonthNo] = 12))");
else m.Expression = @"VAR y = [TL Year]
RETURN IF([TL Valid Year] = 1, CALCULATE([TL Actual], REMOVEFILTERS(tl_date), tl_date[Year] = y, tl_date[MonthNo] = 12))";
m.DisplayFolder = @"02-performance";
m.FormatString = @"#,0.0;−#,0.0;0.0";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Annual Budget");
if (m == null) m = table.AddMeasure(@"TL Annual Budget", @"VAR y = [TL Year]
RETURN IF([TL Valid Year] = 1, CALCULATE([TL Budget], REMOVEFILTERS(tl_date), tl_date[Year] = y))");
else m.Expression = @"VAR y = [TL Year]
RETURN IF([TL Valid Year] = 1, CALCULATE([TL Budget], REMOVEFILTERS(tl_date), tl_date[Year] = y))";
m.DisplayFolder = @"02-performance";
m.FormatString = @"#,0.0;−#,0.0;0.0";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL December Budget");
if (m == null) m = table.AddMeasure(@"TL December Budget", @"VAR y = [TL Year]
RETURN IF([TL Valid Year] = 1, CALCULATE([TL Budget], REMOVEFILTERS(tl_date), tl_date[Year] = y, tl_date[MonthNo] = 12))");
else m.Expression = @"VAR y = [TL Year]
RETURN IF([TL Valid Year] = 1, CALCULATE([TL Budget], REMOVEFILTERS(tl_date), tl_date[Year] = y, tl_date[MonthNo] = 12))";
m.DisplayFolder = @"02-performance";
m.FormatString = @"#,0.0;−#,0.0;0.0";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Annual Variance");
if (m == null) m = table.AddMeasure(@"TL Annual Variance", @"VAR y = [TL Year]
RETURN IF([TL Valid Year] = 1, CALCULATE([TL Variance], REMOVEFILTERS(tl_date), tl_date[Year] = y))");
else m.Expression = @"VAR y = [TL Year]
RETURN IF([TL Valid Year] = 1, CALCULATE([TL Variance], REMOVEFILTERS(tl_date), tl_date[Year] = y))";
m.DisplayFolder = @"02-performance";
m.FormatString = @"#,0.0;−#,0.0;0.0";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL December Variance");
if (m == null) m = table.AddMeasure(@"TL December Variance", @"VAR y = [TL Year]
RETURN IF([TL Valid Year] = 1, CALCULATE([TL Variance], REMOVEFILTERS(tl_date), tl_date[Year] = y, tl_date[MonthNo] = 12))");
else m.Expression = @"VAR y = [TL Year]
RETURN IF([TL Valid Year] = 1, CALCULATE([TL Variance], REMOVEFILTERS(tl_date), tl_date[Year] = y, tl_date[MonthNo] = 12))";
m.DisplayFolder = @"02-performance";
m.FormatString = @"#,0.0;−#,0.0;0.0";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Annual Variance Pct");
if (m == null) m = table.AddMeasure(@"TL Annual Variance Pct", @"DIVIDE([TL Annual Variance], [TL Annual Budget])");
else m.Expression = @"DIVIDE([TL Annual Variance], [TL Annual Budget])";
m.DisplayFolder = @"02-performance";
m.FormatString = @"0.0%;-0.0%;0.0%";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Account Index");
if (m == null) m = table.AddMeasure(@"TL Account Index", @"DIVIDE([TL Actual], [TL Budget])");
else m.Expression = @"DIVIDE([TL Actual], [TL Budget])";
m.DisplayFolder = @"03-cost";
m.FormatString = @"0.0%;-0.0%;0.0%";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Account Rank");
if (m == null) m = table.AddMeasure(@"TL Account Rank", @"VAR currentAccount = SELECTEDVALUE(tl_account[Account])
VAR candidates = ADDCOLUMNS(ALL(tl_account[Account]), ""@v"", CALCULATE([TL Annual Variance]))
VAR currentValue = [TL Annual Variance]
RETURN IF(NOT ISBLANK(currentAccount) && NOT ISBLANK([TL Annual Actual]),
  1 + COUNTROWS(FILTER(candidates, [@v] > currentValue || ([@v] = currentValue && tl_account[Account] < currentAccount))))");
else m.Expression = @"VAR currentAccount = SELECTEDVALUE(tl_account[Account])
VAR candidates = ADDCOLUMNS(ALL(tl_account[Account]), ""@v"", CALCULATE([TL Annual Variance]))
VAR currentValue = [TL Annual Variance]
RETURN IF(NOT ISBLANK(currentAccount) && NOT ISBLANK([TL Annual Actual]),
  1 + COUNTROWS(FILTER(candidates, [@v] > currentValue || ([@v] = currentValue && tl_account[Account] < currentAccount))))";
m.DisplayFolder = @"03-cost";
m.FormatString = @"0";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Top Five");
if (m == null) m = table.AddMeasure(@"TL Top Five", @"IF([TL Account Rank] <= 5 && NOT ISBLANK([TL Account Rank]), 1, 0)");
else m.Expression = @"IF([TL Account Rank] <= 5 && NOT ISBLANK([TL Account Rank]), 1, 0)";
m.DisplayFolder = @"03-cost";
m.FormatString = @"0";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Heatmap Account");
if (m == null) m = table.AddMeasure(@"TL Heatmap Account", @"IF([TL Account Rank] <= 3 || SELECTEDVALUE(tl_account[Account]) = ""Payroll"", 1, 0)");
else m.Expression = @"IF([TL Account Rank] <= 3 || SELECTEDVALUE(tl_account[Account]) = ""Payroll"", 1, 0)";
m.DisplayFolder = @"03-cost";
m.FormatString = @"0";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Cost Actual Display");
if (m == null) m = table.AddMeasure(@"TL Cost Actual Display", @"IF(SELECTEDVALUE(tl_cost_view[View], ""$ Amount"") = ""% Index"", [TL Account Index], [TL Actual M])");
else m.Expression = @"IF(SELECTEDVALUE(tl_cost_view[View], ""$ Amount"") = ""% Index"", [TL Account Index], [TL Actual M])";
m.DisplayFolder = @"03-cost";
m.FormatString = @"#,0.0;−#,0.0;0.0";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Cost Budget Display");
if (m == null) m = table.AddMeasure(@"TL Cost Budget Display", @"IF(SELECTEDVALUE(tl_cost_view[View], ""$ Amount"") = ""% Index"", 1, [TL Budget M])");
else m.Expression = @"IF(SELECTEDVALUE(tl_cost_view[View], ""$ Amount"") = ""% Index"", 1, [TL Budget M])";
m.DisplayFolder = @"03-cost";
m.FormatString = @"#,0.0;−#,0.0;0.0";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Driver 1 Name");
if (m == null) m = table.AddMeasure(@"TL Driver 1 Name", @"VAR a = ADDCOLUMNS(ALL(tl_account[Account]), ""@v"", CALCULATE([TL Annual Variance]))
VAR topN = TOPN(1, a, [@v], DESC, tl_account[Account], ASC)
RETURN MAXX(TOPN(1, topN, [@v], ASC, tl_account[Account], DESC), tl_account[Account])");
else m.Expression = @"VAR a = ADDCOLUMNS(ALL(tl_account[Account]), ""@v"", CALCULATE([TL Annual Variance]))
VAR topN = TOPN(1, a, [@v], DESC, tl_account[Account], ASC)
RETURN MAXX(TOPN(1, topN, [@v], ASC, tl_account[Account], DESC), tl_account[Account])";
m.DisplayFolder = @"03-cost";
m.FormatString = @"";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Driver 1 Variance");
if (m == null) m = table.AddMeasure(@"TL Driver 1 Variance", @"VAR a = [TL Driver 1 Name]
RETURN CALCULATE([TL Annual Variance], REMOVEFILTERS(tl_account), tl_account[Account] = a)");
else m.Expression = @"VAR a = [TL Driver 1 Name]
RETURN CALCULATE([TL Annual Variance], REMOVEFILTERS(tl_account), tl_account[Account] = a)";
m.DisplayFolder = @"03-cost";
m.FormatString = @"#,0.0;−#,0.0;0.0";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Driver 2 Name");
if (m == null) m = table.AddMeasure(@"TL Driver 2 Name", @"VAR a = ADDCOLUMNS(ALL(tl_account[Account]), ""@v"", CALCULATE([TL Annual Variance]))
VAR topN = TOPN(2, a, [@v], DESC, tl_account[Account], ASC)
RETURN MAXX(TOPN(1, topN, [@v], ASC, tl_account[Account], DESC), tl_account[Account])");
else m.Expression = @"VAR a = ADDCOLUMNS(ALL(tl_account[Account]), ""@v"", CALCULATE([TL Annual Variance]))
VAR topN = TOPN(2, a, [@v], DESC, tl_account[Account], ASC)
RETURN MAXX(TOPN(1, topN, [@v], ASC, tl_account[Account], DESC), tl_account[Account])";
m.DisplayFolder = @"03-cost";
m.FormatString = @"";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Driver 2 Variance");
if (m == null) m = table.AddMeasure(@"TL Driver 2 Variance", @"VAR a = [TL Driver 2 Name]
RETURN CALCULATE([TL Annual Variance], REMOVEFILTERS(tl_account), tl_account[Account] = a)");
else m.Expression = @"VAR a = [TL Driver 2 Name]
RETURN CALCULATE([TL Annual Variance], REMOVEFILTERS(tl_account), tl_account[Account] = a)";
m.DisplayFolder = @"03-cost";
m.FormatString = @"#,0.0;−#,0.0;0.0";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Driver 3 Name");
if (m == null) m = table.AddMeasure(@"TL Driver 3 Name", @"VAR a = ADDCOLUMNS(ALL(tl_account[Account]), ""@v"", CALCULATE([TL Annual Variance]))
VAR topN = TOPN(3, a, [@v], DESC, tl_account[Account], ASC)
RETURN MAXX(TOPN(1, topN, [@v], ASC, tl_account[Account], DESC), tl_account[Account])");
else m.Expression = @"VAR a = ADDCOLUMNS(ALL(tl_account[Account]), ""@v"", CALCULATE([TL Annual Variance]))
VAR topN = TOPN(3, a, [@v], DESC, tl_account[Account], ASC)
RETURN MAXX(TOPN(1, topN, [@v], ASC, tl_account[Account], DESC), tl_account[Account])";
m.DisplayFolder = @"03-cost";
m.FormatString = @"";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Driver 3 Variance");
if (m == null) m = table.AddMeasure(@"TL Driver 3 Variance", @"VAR a = [TL Driver 3 Name]
RETURN CALCULATE([TL Annual Variance], REMOVEFILTERS(tl_account), tl_account[Account] = a)");
else m.Expression = @"VAR a = [TL Driver 3 Name]
RETURN CALCULATE([TL Annual Variance], REMOVEFILTERS(tl_account), tl_account[Account] = a)";
m.DisplayFolder = @"03-cost";
m.FormatString = @"#,0.0;−#,0.0;0.0";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Driver 1 Peak Month");
if (m == null) m = table.AddMeasure(@"TL Driver 1 Peak Month", @"VAR a = [TL Driver 1 Name]
VAR y = [TL Year]
VAR months = CALCULATETABLE(VALUES(tl_date[MonthNo]), REMOVEFILTERS(tl_date), tl_date[Year] = y)
VAR rows = ADDCOLUMNS(months, ""@v"", VAR m = tl_date[MonthNo] RETURN CALCULATE([TL Variance], REMOVEFILTERS(tl_date), tl_date[Year] = y, tl_date[MonthNo] = m, REMOVEFILTERS(tl_account), tl_account[Account] = a))
RETURN MAXX(TOPN(1, rows, [@v], DESC, tl_date[MonthNo], ASC), tl_date[MonthNo])");
else m.Expression = @"VAR a = [TL Driver 1 Name]
VAR y = [TL Year]
VAR months = CALCULATETABLE(VALUES(tl_date[MonthNo]), REMOVEFILTERS(tl_date), tl_date[Year] = y)
VAR rows = ADDCOLUMNS(months, ""@v"", VAR m = tl_date[MonthNo] RETURN CALCULATE([TL Variance], REMOVEFILTERS(tl_date), tl_date[Year] = y, tl_date[MonthNo] = m, REMOVEFILTERS(tl_account), tl_account[Account] = a))
RETURN MAXX(TOPN(1, rows, [@v], DESC, tl_date[MonthNo], ASC), tl_date[MonthNo])";
m.DisplayFolder = @"03-cost";
m.FormatString = @"0";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Bridge Value M");
if (m == null) m = table.AddMeasure(@"TL Bridge Value M", @"VAR total = CALCULATE([TL Annual Variance], REMOVEFILTERS(tl_account))
RETURN DIVIDE(SWITCH(SELECTEDVALUE(tl_bridge[Step]),
 1, [TL Driver 1 Variance], 2, [TL Driver 2 Variance], 3, [TL Driver 3 Variance],
 4, total - [TL Driver 1 Variance] - [TL Driver 2 Variance] - [TL Driver 3 Variance], 5, total), 1000000)");
else m.Expression = @"VAR total = CALCULATE([TL Annual Variance], REMOVEFILTERS(tl_account))
RETURN DIVIDE(SWITCH(SELECTEDVALUE(tl_bridge[Step]),
 1, [TL Driver 1 Variance], 2, [TL Driver 2 Variance], 3, [TL Driver 3 Variance],
 4, total - [TL Driver 1 Variance] - [TL Driver 2 Variance] - [TL Driver 3 Variance], 5, total), 1000000)";
m.DisplayFolder = @"02-performance";
m.FormatString = @"#,0.0;−#,0.0;0.0";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Bridge Label");
if (m == null) m = table.AddMeasure(@"TL Bridge Label", @"SWITCH(SELECTEDVALUE(tl_bridge[Step]),1,[TL Driver 1 Name],2,[TL Driver 2 Name],3,[TL Driver 3 Name],4,""Other net"",5,""Net variance"")");
else m.Expression = @"SWITCH(SELECTEDVALUE(tl_bridge[Step]),1,[TL Driver 1 Name],2,[TL Driver 2 Name],3,[TL Driver 3 Name],4,""Other net"",5,""Net variance"")";
m.DisplayFolder = @"02-performance";
m.FormatString = @"";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Cash");
if (m == null) m = table.AddMeasure(@"TL Cash", @"IF([TL Valid Year] = 1, CALCULATE(SUM(tl_subsidies[amount]),
 tl_subsidies[scenario] = ""Actual"", tl_subsidies[expense_type] = ""Cash"",
 tl_subsidies[type] = ""Total Dedicated Taxes & State and Local Subsidies""))");
else m.Expression = @"IF([TL Valid Year] = 1, CALCULATE(SUM(tl_subsidies[amount]),
 tl_subsidies[scenario] = ""Actual"", tl_subsidies[expense_type] = ""Cash"",
 tl_subsidies[type] = ""Total Dedicated Taxes & State and Local Subsidies""))";
m.DisplayFolder = @"04-funding";
m.FormatString = @"#,0.0;−#,0.0;0.0";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Cash M");
if (m == null) m = table.AddMeasure(@"TL Cash M", @"DIVIDE([TL Cash],1000000)");
else m.Expression = @"DIVIDE([TL Cash],1000000)";
m.DisplayFolder = @"04-funding";
m.FormatString = @"#,0.0;−#,0.0;0.0";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Annual Cash");
if (m == null) m = table.AddMeasure(@"TL Annual Cash", @"VAR y = [TL Year]
RETURN IF([TL Valid Year] = 1, CALCULATE([TL Cash], REMOVEFILTERS(tl_date), tl_date[Year] = y))");
else m.Expression = @"VAR y = [TL Year]
RETURN IF([TL Valid Year] = 1, CALCULATE([TL Cash], REMOVEFILTERS(tl_date), tl_date[Year] = y))";
m.DisplayFolder = @"04-funding";
m.FormatString = @"#,0.0;−#,0.0;0.0";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Accrual");
if (m == null) m = table.AddMeasure(@"TL Accrual", @"IF([TL Valid Year] = 1, CALCULATE(SUM(tl_subsidies[amount]),
 tl_subsidies[scenario] = ""Actual"", tl_subsidies[expense_type] = ""NREIMB"",
 tl_subsidies[type] = ""Total Dedicated Taxes & State and Local Subsidies""))");
else m.Expression = @"IF([TL Valid Year] = 1, CALCULATE(SUM(tl_subsidies[amount]),
 tl_subsidies[scenario] = ""Actual"", tl_subsidies[expense_type] = ""NREIMB"",
 tl_subsidies[type] = ""Total Dedicated Taxes & State and Local Subsidies""))";
m.DisplayFolder = @"04-funding";
m.FormatString = @"#,0.0;−#,0.0;0.0";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Accrual M");
if (m == null) m = table.AddMeasure(@"TL Accrual M", @"DIVIDE([TL Accrual],1000000)");
else m.Expression = @"DIVIDE([TL Accrual],1000000)";
m.DisplayFolder = @"04-funding";
m.FormatString = @"#,0.0;−#,0.0;0.0";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Annual Accrual");
if (m == null) m = table.AddMeasure(@"TL Annual Accrual", @"VAR y = [TL Year]
RETURN IF([TL Valid Year] = 1, CALCULATE([TL Accrual], REMOVEFILTERS(tl_date), tl_date[Year] = y))");
else m.Expression = @"VAR y = [TL Year]
RETURN IF([TL Valid Year] = 1, CALCULATE([TL Accrual], REMOVEFILTERS(tl_date), tl_date[Year] = y))";
m.DisplayFolder = @"04-funding";
m.FormatString = @"#,0.0;−#,0.0;0.0";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Funding Gap");
if (m == null) m = table.AddMeasure(@"TL Funding Gap", @"[TL Accrual] - [TL Cash]");
else m.Expression = @"[TL Accrual] - [TL Cash]";
m.DisplayFolder = @"04-funding";
m.FormatString = @"#,0.0;−#,0.0;0.0";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Funding Gap M");
if (m == null) m = table.AddMeasure(@"TL Funding Gap M", @"DIVIDE([TL Funding Gap],1000000)");
else m.Expression = @"DIVIDE([TL Funding Gap],1000000)";
m.DisplayFolder = @"04-funding";
m.FormatString = @"#,0.0;−#,0.0;0.0";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Coverage Pct");
if (m == null) m = table.AddMeasure(@"TL Coverage Pct", @"DIVIDE([TL Cash], [TL Accrual])");
else m.Expression = @"DIVIDE([TL Cash], [TL Accrual])";
m.DisplayFolder = @"04-funding";
m.FormatString = @"0.0%;-0.0%;0.0%";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Annual Funding Gap");
if (m == null) m = table.AddMeasure(@"TL Annual Funding Gap", @"[TL Annual Accrual] - [TL Annual Cash]");
else m.Expression = @"[TL Annual Accrual] - [TL Annual Cash]";
m.DisplayFolder = @"04-funding";
m.FormatString = @"#,0.0;−#,0.0;0.0";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Annual Coverage Pct");
if (m == null) m = table.AddMeasure(@"TL Annual Coverage Pct", @"DIVIDE([TL Annual Cash], [TL Annual Accrual])");
else m.Expression = @"DIVIDE([TL Annual Cash], [TL Annual Accrual])";
m.DisplayFolder = @"04-funding";
m.FormatString = @"0.0%;-0.0%;0.0%";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL December Cash Share Pct");
if (m == null) m = table.AddMeasure(@"TL December Cash Share Pct", @"VAR y = [TL Year]
VAR decemberCash = CALCULATE([TL Cash], REMOVEFILTERS(tl_date), tl_date[Year] = y, tl_date[MonthNo] = 12)
RETURN DIVIDE(decemberCash, [TL Annual Cash])");
else m.Expression = @"VAR y = [TL Year]
VAR decemberCash = CALCULATE([TL Cash], REMOVEFILTERS(tl_date), tl_date[Year] = y, tl_date[MonthNo] = 12)
RETURN DIVIDE(decemberCash, [TL Annual Cash])";
m.DisplayFolder = @"04-funding";
m.FormatString = @"0.0%;-0.0%;0.0%";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Funding Display");
if (m == null) m = table.AddMeasure(@"TL Funding Display", @"IF(SELECTEDVALUE(tl_funding_view[View], ""$ Gap"") = ""% Coverage"", [TL Coverage Pct], [TL Funding Gap M])");
else m.Expression = @"IF(SELECTEDVALUE(tl_funding_view[View], ""$ Gap"") = ""% Coverage"", [TL Coverage Pct], [TL Funding Gap M])";
m.DisplayFolder = @"04-funding";
m.FormatString = @"#,0.0;−#,0.0;0.0";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Funding Label");
if (m == null) m = table.AddMeasure(@"TL Funding Label", @"IF(SELECTEDVALUE(tl_funding_view[View], ""$ Gap"") = ""% Coverage"", FORMAT([TL Coverage Pct],""0.0%""), FORMAT([TL Funding Gap M],""0.0;−0.0;0.0"") & ""M"")");
else m.Expression = @"IF(SELECTEDVALUE(tl_funding_view[View], ""$ Gap"") = ""% Coverage"", FORMAT([TL Coverage Pct],""0.0%""), FORMAT([TL Funding Gap M],""0.0;−0.0;0.0"") & ""M"")";
m.DisplayFolder = @"04-funding";
m.FormatString = @"";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Performance Title");
if (m == null) m = table.AddMeasure(@"TL Performance Title", @"IF([TL Valid Year] <> 1, ""Select one reporting year"", ""Expenses finished $"" & FORMAT(ABS([TL Annual Variance])/1000000,""#,0.0"") & ""M "" & IF([TL Annual Variance]>=0,""above"",""below"") & "" adopted budget."")");
else m.Expression = @"IF([TL Valid Year] <> 1, ""Select one reporting year"", ""Expenses finished $"" & FORMAT(ABS([TL Annual Variance])/1000000,""#,0.0"") & ""M "" & IF([TL Annual Variance]>=0,""above"",""below"") & "" adopted budget."")";
m.DisplayFolder = @"06-text";
m.FormatString = @"";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Cost Title");
if (m == null) m = table.AddMeasure(@"TL Cost Title", @"IF([TL Valid Year] <> 1, ""Select one reporting year"", [TL Driver 1 Name] & "" and "" & [TL Driver 2 Name] & "" added $"" & FORMAT(([TL Driver 1 Variance]+[TL Driver 2 Variance])/1000000,""#,0.0"") & ""M above plan."")");
else m.Expression = @"IF([TL Valid Year] <> 1, ""Select one reporting year"", [TL Driver 1 Name] & "" and "" & [TL Driver 2 Name] & "" added $"" & FORMAT(([TL Driver 1 Variance]+[TL Driver 2 Variance])/1000000,""#,0.0"") & ""M above plan."")";
m.DisplayFolder = @"06-text";
m.FormatString = @"";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Funding Title");
if (m == null) m = table.AddMeasure(@"TL Funding Title", @"IF([TL Valid Year] <> 1, ""Select one reporting year"", ""Cash was $"" & FORMAT(ABS([TL Annual Funding Gap])/1000000,""#,0.0"") & ""M "" & IF([TL Annual Funding Gap]>=0,""below"",""above"") & "" accrued subsidies."")");
else m.Expression = @"IF([TL Valid Year] <> 1, ""Select one reporting year"", ""Cash was $"" & FORMAT(ABS([TL Annual Funding Gap])/1000000,""#,0.0"") & ""M "" & IF([TL Annual Funding Gap]>=0,""below"",""above"") & "" accrued subsidies."")";
m.DisplayFolder = @"06-text";
m.FormatString = @"";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Context");
if (m == null) m = table.AddMeasure(@"TL Context", @"""NYCT · "" & FORMAT([TL Year],""0"") & "" · USD · static 2023–2025 snapshot""");
else m.Expression = @"""NYCT · "" & FORMAT([TL Year],""0"") & "" · USD · static 2023–2025 snapshot""";
m.DisplayFolder = @"06-text";
m.FormatString = @"";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Source Note");
if (m == null) m = table.AddMeasure(@"TL Source Note", @"""Source: MTA Open Data. Operations: NYCT / NREIMB / same-year financial plan / before non-cash adjustments. Funding: selected gross subsidy category, not total cash flow. No audited reconciliation or causal inference.""");
else m.Expression = @"""Source: MTA Open Data. Operations: NYCT / NREIMB / same-year financial plan / before non-cash adjustments. Funding: selected gross subsidy category, not total cash flow. No audited reconciliation or causal inference.""";
m.DisplayFolder = @"06-text";
m.FormatString = @"";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Performance Alt Text");
if (m == null) m = table.AddMeasure(@"TL Performance Alt Text", @"[TL Performance Title] & "" "" & [TL Context] & "". "" & [TL Source Note]");
else m.Expression = @"[TL Performance Title] & "" "" & [TL Context] & "". "" & [TL Source Note]";
m.DisplayFolder = @"06-text";
m.FormatString = @"";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Cost Alt Text");
if (m == null) m = table.AddMeasure(@"TL Cost Alt Text", @"[TL Cost Title] & "" "" & [TL Context] & "". "" & [TL Source Note]");
else m.Expression = @"[TL Cost Title] & "" "" & [TL Context] & "". "" & [TL Source Note]";
m.DisplayFolder = @"06-text";
m.FormatString = @"";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Funding Alt Text");
if (m == null) m = table.AddMeasure(@"TL Funding Alt Text", @"[TL Funding Title] & "" "" & [TL Context] & "". "" & [TL Source Note]");
else m.Expression = @"[TL Funding Title] & "" "" & [TL Context] & "". "" & [TL Source Note]";
m.DisplayFolder = @"06-text";
m.FormatString = @"";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Expenses Spark HTML");
if (m == null) m = table.AddMeasure(@"TL Expenses Spark HTML", @"VAR y = [TL Year]
VAR months = CALCULATETABLE(VALUES(tl_date[MonthNo]), REMOVEFILTERS(tl_date), tl_date[Year] = y)
VAR points = ADDCOLUMNS(months, ""@v"", VAR m = tl_date[MonthNo] RETURN CALCULATE([TL Actual M], REMOVEFILTERS(tl_date), tl_date[Year] = y, tl_date[MonthNo] = m))
VAR low = MINX(points, [@v])
VAR high = MAX(0, MAXX(points, [@v]))
VAR span = MAX(high-low, 0.00001)
VAR marks = CONCATENATEX(points,
 FORMAT((tl_date[MonthNo]-1)*14+2,""0"", ""en-US"") & "","" & FORMAT(53-48*DIVIDE([@v]-low,span),""0.0"", ""en-US""), "" "", tl_date[MonthNo], ASC)
RETURN IF([TL Valid Year]=1, ""<svg xmlns='http://www.w3.org/2000/svg' viewBox='0 0 170 60' role='img' aria-label='Monthly trend, separate scale'><polyline points='"" & marks & ""' fill='none' stroke='#778b98' stroke-width='2.5'/></svg>"")");
else m.Expression = @"VAR y = [TL Year]
VAR months = CALCULATETABLE(VALUES(tl_date[MonthNo]), REMOVEFILTERS(tl_date), tl_date[Year] = y)
VAR points = ADDCOLUMNS(months, ""@v"", VAR m = tl_date[MonthNo] RETURN CALCULATE([TL Actual M], REMOVEFILTERS(tl_date), tl_date[Year] = y, tl_date[MonthNo] = m))
VAR low = MINX(points, [@v])
VAR high = MAX(0, MAXX(points, [@v]))
VAR span = MAX(high-low, 0.00001)
VAR marks = CONCATENATEX(points,
 FORMAT((tl_date[MonthNo]-1)*14+2,""0"", ""en-US"") & "","" & FORMAT(53-48*DIVIDE([@v]-low,span),""0.0"", ""en-US""), "" "", tl_date[MonthNo], ASC)
RETURN IF([TL Valid Year]=1, ""<svg xmlns='http://www.w3.org/2000/svg' viewBox='0 0 170 60' role='img' aria-label='Monthly trend, separate scale'><polyline points='"" & marks & ""' fill='none' stroke='#778b98' stroke-width='2.5'/></svg>"")";
m.DisplayFolder = @"05-html";
m.FormatString = @"";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Variance Spark HTML");
if (m == null) m = table.AddMeasure(@"TL Variance Spark HTML", @"VAR y = [TL Year]
VAR months = CALCULATETABLE(VALUES(tl_date[MonthNo]), REMOVEFILTERS(tl_date), tl_date[Year] = y)
VAR points = ADDCOLUMNS(months, ""@v"", VAR m = tl_date[MonthNo] RETURN CALCULATE([TL Variance M], REMOVEFILTERS(tl_date), tl_date[Year] = y, tl_date[MonthNo] = m))
VAR low = MIN(0, MINX(points, [@v]))
VAR high = MAX(0, MAXX(points, [@v]))
VAR span = MAX(high-low, 0.00001)
VAR marks = CONCATENATEX(points,
 VAR yy = 53 - 48 * DIVIDE([@v]-low,span)
 VAR zeroY = 53 - 48 * DIVIDE(-low,span)
 RETURN ""<rect x='"" & FORMAT((tl_date[MonthNo]-1)*14+2,""0"", ""en-US"") & ""' y='"" & FORMAT(MIN(yy,zeroY),""0.0"", ""en-US"") & ""' width='9' height='"" & FORMAT(MAX(1,ABS(yy-zeroY)),""0.0"", ""en-US"") & ""' fill='"" & IF([@v]>=0,""#cf493a"",""#526b7a"") & ""' />"", """", tl_date[MonthNo], ASC)
RETURN IF([TL Valid Year]=1, ""<svg xmlns='http://www.w3.org/2000/svg' viewBox='0 0 170 60' role='img' aria-label='Monthly variance, separate scale'>"" & marks & ""</svg>"")");
else m.Expression = @"VAR y = [TL Year]
VAR months = CALCULATETABLE(VALUES(tl_date[MonthNo]), REMOVEFILTERS(tl_date), tl_date[Year] = y)
VAR points = ADDCOLUMNS(months, ""@v"", VAR m = tl_date[MonthNo] RETURN CALCULATE([TL Variance M], REMOVEFILTERS(tl_date), tl_date[Year] = y, tl_date[MonthNo] = m))
VAR low = MIN(0, MINX(points, [@v]))
VAR high = MAX(0, MAXX(points, [@v]))
VAR span = MAX(high-low, 0.00001)
VAR marks = CONCATENATEX(points,
 VAR yy = 53 - 48 * DIVIDE([@v]-low,span)
 VAR zeroY = 53 - 48 * DIVIDE(-low,span)
 RETURN ""<rect x='"" & FORMAT((tl_date[MonthNo]-1)*14+2,""0"", ""en-US"") & ""' y='"" & FORMAT(MIN(yy,zeroY),""0.0"", ""en-US"") & ""' width='9' height='"" & FORMAT(MAX(1,ABS(yy-zeroY)),""0.0"", ""en-US"") & ""' fill='"" & IF([@v]>=0,""#cf493a"",""#526b7a"") & ""' />"", """", tl_date[MonthNo], ASC)
RETURN IF([TL Valid Year]=1, ""<svg xmlns='http://www.w3.org/2000/svg' viewBox='0 0 170 60' role='img' aria-label='Monthly variance, separate scale'>"" & marks & ""</svg>"")";
m.DisplayFolder = @"05-html";
m.FormatString = @"";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Cash Spark HTML");
if (m == null) m = table.AddMeasure(@"TL Cash Spark HTML", @"VAR y = [TL Year]
VAR months = CALCULATETABLE(VALUES(tl_date[MonthNo]), REMOVEFILTERS(tl_date), tl_date[Year] = y)
VAR points = ADDCOLUMNS(months, ""@v"", VAR m = tl_date[MonthNo] RETURN CALCULATE([TL Cash M], REMOVEFILTERS(tl_date), tl_date[Year] = y, tl_date[MonthNo] = m))
VAR low = MINX(points, [@v])
VAR high = MAX(0, MAXX(points, [@v]))
VAR span = MAX(high-low, 0.00001)
VAR marks = CONCATENATEX(points,
 FORMAT((tl_date[MonthNo]-1)*14+2,""0"", ""en-US"") & "","" & FORMAT(53-48*DIVIDE([@v]-low,span),""0.0"", ""en-US""), "" "", tl_date[MonthNo], ASC)
RETURN IF([TL Valid Year]=1, ""<svg xmlns='http://www.w3.org/2000/svg' viewBox='0 0 170 60' role='img' aria-label='Monthly trend, separate scale'><polyline points='"" & marks & ""' fill='none' stroke='#778b98' stroke-width='2.5'/></svg>"")");
else m.Expression = @"VAR y = [TL Year]
VAR months = CALCULATETABLE(VALUES(tl_date[MonthNo]), REMOVEFILTERS(tl_date), tl_date[Year] = y)
VAR points = ADDCOLUMNS(months, ""@v"", VAR m = tl_date[MonthNo] RETURN CALCULATE([TL Cash M], REMOVEFILTERS(tl_date), tl_date[Year] = y, tl_date[MonthNo] = m))
VAR low = MINX(points, [@v])
VAR high = MAX(0, MAXX(points, [@v]))
VAR span = MAX(high-low, 0.00001)
VAR marks = CONCATENATEX(points,
 FORMAT((tl_date[MonthNo]-1)*14+2,""0"", ""en-US"") & "","" & FORMAT(53-48*DIVIDE([@v]-low,span),""0.0"", ""en-US""), "" "", tl_date[MonthNo], ASC)
RETURN IF([TL Valid Year]=1, ""<svg xmlns='http://www.w3.org/2000/svg' viewBox='0 0 170 60' role='img' aria-label='Monthly trend, separate scale'><polyline points='"" & marks & ""' fill='none' stroke='#778b98' stroke-width='2.5'/></svg>"")";
m.DisplayFolder = @"05-html";
m.FormatString = @"";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Expense Card HTML");
if (m == null) m = table.AddMeasure(@"TL Expense Card HTML", @"VAR valueText = ""$"" & FORMAT([TL Annual Actual]/1000000000,""0.00"") & ""B""
VAR contextText = ""Actual before non-cash adjustments""
RETURN IF([TL Valid Year] <> 1, ""<p>Select one year.</p>"",
""<div style='box-sizing:border-box;padding:20px;border-radius:15px;font-family:Segoe UI,Arial;background:#ffffff;color:#18232b'><div style='font-size:13px;font-weight:600'>Operating expenses</div><div style='font-size:38px;font-weight:700;margin:8px 0;color:#18232b'>"" & valueText & ""</div><div style='font-size:12px;color:#53616a'>"" & contextText & ""</div>"" & ""<div style='height:55px;width:160px;margin-left:auto'>"" & [TL Expenses Spark HTML] & ""</div>"" & ""</div>"")");
else m.Expression = @"VAR valueText = ""$"" & FORMAT([TL Annual Actual]/1000000000,""0.00"") & ""B""
VAR contextText = ""Actual before non-cash adjustments""
RETURN IF([TL Valid Year] <> 1, ""<p>Select one year.</p>"",
""<div style='box-sizing:border-box;padding:20px;border-radius:15px;font-family:Segoe UI,Arial;background:#ffffff;color:#18232b'><div style='font-size:13px;font-weight:600'>Operating expenses</div><div style='font-size:38px;font-weight:700;margin:8px 0;color:#18232b'>"" & valueText & ""</div><div style='font-size:12px;color:#53616a'>"" & contextText & ""</div>"" & ""<div style='height:55px;width:160px;margin-left:auto'>"" & [TL Expenses Spark HTML] & ""</div>"" & ""</div>"")";
m.DisplayFolder = @"05-html";
m.FormatString = @"";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Budget Card HTML");
if (m == null) m = table.AddMeasure(@"TL Budget Card HTML", @"VAR valueText = ""$"" & FORMAT(ABS([TL Annual Variance])/1000000,""#,0.0"") & ""M""
VAR contextText = FORMAT(ABS([TL Annual Variance Pct]),""0.0%"") & IF([TL Annual Variance]>=0,"" above plan"","" below plan"")
RETURN IF([TL Valid Year] <> 1, ""<p>Select one year.</p>"",
""<div style='box-sizing:border-box;padding:20px;border-radius:15px;font-family:Segoe UI,Arial;background:#faeee9;border-top:3px solid #cf493a;color:#18232b'><div style='font-size:13px;font-weight:600'>Budget variance</div><div style='font-size:38px;font-weight:700;margin:8px 0;color:#cf493a'>"" & valueText & ""</div><div style='font-size:12px;color:#53616a'>"" & contextText & ""</div>"" & ""<div style='height:55px;width:160px;margin-left:auto'>"" & [TL Variance Spark HTML] & ""</div>"" & ""</div>"")");
else m.Expression = @"VAR valueText = ""$"" & FORMAT(ABS([TL Annual Variance])/1000000,""#,0.0"") & ""M""
VAR contextText = FORMAT(ABS([TL Annual Variance Pct]),""0.0%"") & IF([TL Annual Variance]>=0,"" above plan"","" below plan"")
RETURN IF([TL Valid Year] <> 1, ""<p>Select one year.</p>"",
""<div style='box-sizing:border-box;padding:20px;border-radius:15px;font-family:Segoe UI,Arial;background:#faeee9;border-top:3px solid #cf493a;color:#18232b'><div style='font-size:13px;font-weight:600'>Budget variance</div><div style='font-size:38px;font-weight:700;margin:8px 0;color:#cf493a'>"" & valueText & ""</div><div style='font-size:12px;color:#53616a'>"" & contextText & ""</div>"" & ""<div style='height:55px;width:160px;margin-left:auto'>"" & [TL Variance Spark HTML] & ""</div>"" & ""</div>"")";
m.DisplayFolder = @"05-html";
m.FormatString = @"";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL December Card HTML");
if (m == null) m = table.AddMeasure(@"TL December Card HTML", @"VAR valueText = FORMAT([TL December Variance]/1000000,""+$#,0.0;−$#,0.0;$0.0"") & ""M""
VAR contextText = ""Actual $"" & FORMAT([TL December Actual]/1000000,""#,0.0"") & ""M / plan $"" & FORMAT([TL December Budget]/1000000,""#,0.0"") & ""M""
RETURN IF([TL Valid Year] <> 1, ""<p>Select one year.</p>"",
""<div style='box-sizing:border-box;padding:20px;border-radius:15px;font-family:Segoe UI,Arial;background:#ffffff;color:#18232b'><div style='font-size:13px;font-weight:600'>December vs adopted budget</div><div style='font-size:38px;font-weight:700;margin:8px 0;color:#18232b'>"" & valueText & ""</div><div style='font-size:12px;color:#53616a'>"" & contextText & ""</div>"" & ""<div style='height:55px;width:160px;margin-left:auto'>"" & [TL Variance Spark HTML] & ""</div>"" & ""</div>"")");
else m.Expression = @"VAR valueText = FORMAT([TL December Variance]/1000000,""+$#,0.0;−$#,0.0;$0.0"") & ""M""
VAR contextText = ""Actual $"" & FORMAT([TL December Actual]/1000000,""#,0.0"") & ""M / plan $"" & FORMAT([TL December Budget]/1000000,""#,0.0"") & ""M""
RETURN IF([TL Valid Year] <> 1, ""<p>Select one year.</p>"",
""<div style='box-sizing:border-box;padding:20px;border-radius:15px;font-family:Segoe UI,Arial;background:#ffffff;color:#18232b'><div style='font-size:13px;font-weight:600'>December vs adopted budget</div><div style='font-size:38px;font-weight:700;margin:8px 0;color:#18232b'>"" & valueText & ""</div><div style='font-size:12px;color:#53616a'>"" & contextText & ""</div>"" & ""<div style='height:55px;width:160px;margin-left:auto'>"" & [TL Variance Spark HTML] & ""</div>"" & ""</div>"")";
m.DisplayFolder = @"05-html";
m.FormatString = @"";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Driver 1 Card HTML");
if (m == null) m = table.AddMeasure(@"TL Driver 1 Card HTML", @"VAR valueText = FORMAT([TL Driver 1 Variance]/1000000,""+$#,0.0;−$#,0.0;$0.0"") & ""M""
VAR contextText = [TL Driver 1 Name]
RETURN IF([TL Valid Year] <> 1, ""<p>Select one year.</p>"",
""<div style='box-sizing:border-box;padding:20px;border-radius:15px;font-family:Segoe UI,Arial;background:#faeee9;border-top:3px solid #cf493a;color:#18232b'><div style='font-size:13px;font-weight:600'>Driver 1 variance</div><div style='font-size:38px;font-weight:700;margin:8px 0;color:#cf493a'>"" & valueText & ""</div><div style='font-size:12px;color:#53616a'>"" & contextText & ""</div>"" & ""</div>"")");
else m.Expression = @"VAR valueText = FORMAT([TL Driver 1 Variance]/1000000,""+$#,0.0;−$#,0.0;$0.0"") & ""M""
VAR contextText = [TL Driver 1 Name]
RETURN IF([TL Valid Year] <> 1, ""<p>Select one year.</p>"",
""<div style='box-sizing:border-box;padding:20px;border-radius:15px;font-family:Segoe UI,Arial;background:#faeee9;border-top:3px solid #cf493a;color:#18232b'><div style='font-size:13px;font-weight:600'>Driver 1 variance</div><div style='font-size:38px;font-weight:700;margin:8px 0;color:#cf493a'>"" & valueText & ""</div><div style='font-size:12px;color:#53616a'>"" & contextText & ""</div>"" & ""</div>"")";
m.DisplayFolder = @"05-html";
m.FormatString = @"";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Driver 2 Card HTML");
if (m == null) m = table.AddMeasure(@"TL Driver 2 Card HTML", @"VAR valueText = FORMAT([TL Driver 2 Variance]/1000000,""+$#,0.0;−$#,0.0;$0.0"") & ""M""
VAR contextText = [TL Driver 2 Name]
RETURN IF([TL Valid Year] <> 1, ""<p>Select one year.</p>"",
""<div style='box-sizing:border-box;padding:20px;border-radius:15px;font-family:Segoe UI,Arial;background:#ffffff;color:#18232b'><div style='font-size:13px;font-weight:600'>Driver 2 variance</div><div style='font-size:38px;font-weight:700;margin:8px 0;color:#18232b'>"" & valueText & ""</div><div style='font-size:12px;color:#53616a'>"" & contextText & ""</div>"" & ""</div>"")");
else m.Expression = @"VAR valueText = FORMAT([TL Driver 2 Variance]/1000000,""+$#,0.0;−$#,0.0;$0.0"") & ""M""
VAR contextText = [TL Driver 2 Name]
RETURN IF([TL Valid Year] <> 1, ""<p>Select one year.</p>"",
""<div style='box-sizing:border-box;padding:20px;border-radius:15px;font-family:Segoe UI,Arial;background:#ffffff;color:#18232b'><div style='font-size:13px;font-weight:600'>Driver 2 variance</div><div style='font-size:38px;font-weight:700;margin:8px 0;color:#18232b'>"" & valueText & ""</div><div style='font-size:12px;color:#53616a'>"" & contextText & ""</div>"" & ""</div>"")";
m.DisplayFolder = @"05-html";
m.FormatString = @"";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Funding Card HTML");
if (m == null) m = table.AddMeasure(@"TL Funding Card HTML", @"VAR valueText = ""$"" & FORMAT(ABS([TL Annual Funding Gap])/1000000,""#,0.0"") & ""M""
VAR contextText = IF([TL Annual Funding Gap]>=0,""Less cash than accrued"",""More cash than accrued"")
RETURN IF([TL Valid Year] <> 1, ""<p>Select one year.</p>"",
""<div style='box-sizing:border-box;padding:20px;border-radius:15px;font-family:Segoe UI,Arial;background:#ffffff;color:#18232b'><div style='font-size:13px;font-weight:600'>Cash / accrual</div><div style='font-size:38px;font-weight:700;margin:8px 0;color:#18232b'>"" & valueText & ""</div><div style='font-size:12px;color:#53616a'>"" & contextText & ""</div>"" & ""<div style='height:55px;width:160px;margin-left:auto'>"" & [TL Cash Spark HTML] & ""</div>"" & ""</div>"")");
else m.Expression = @"VAR valueText = ""$"" & FORMAT(ABS([TL Annual Funding Gap])/1000000,""#,0.0"") & ""M""
VAR contextText = IF([TL Annual Funding Gap]>=0,""Less cash than accrued"",""More cash than accrued"")
RETURN IF([TL Valid Year] <> 1, ""<p>Select one year.</p>"",
""<div style='box-sizing:border-box;padding:20px;border-radius:15px;font-family:Segoe UI,Arial;background:#ffffff;color:#18232b'><div style='font-size:13px;font-weight:600'>Cash / accrual</div><div style='font-size:38px;font-weight:700;margin:8px 0;color:#18232b'>"" & valueText & ""</div><div style='font-size:12px;color:#53616a'>"" & contextText & ""</div>"" & ""<div style='height:55px;width:160px;margin-left:auto'>"" & [TL Cash Spark HTML] & ""</div>"" & ""</div>"")";
m.DisplayFolder = @"05-html";
m.FormatString = @"";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Cash Card HTML");
if (m == null) m = table.AddMeasure(@"TL Cash Card HTML", @"VAR valueText = ""$"" & FORMAT([TL Annual Cash]/1000000,""#,0.0"") & ""M""
VAR contextText = ""Selected subsidy category""
RETURN IF([TL Valid Year] <> 1, ""<p>Select one year.</p>"",
""<div style='box-sizing:border-box;padding:20px;border-radius:15px;font-family:Segoe UI,Arial;background:#ffffff;color:#18232b'><div style='font-size:13px;font-weight:600'>Cash received</div><div style='font-size:38px;font-weight:700;margin:8px 0;color:#18232b'>"" & valueText & ""</div><div style='font-size:12px;color:#53616a'>"" & contextText & ""</div>"" & ""</div>"")");
else m.Expression = @"VAR valueText = ""$"" & FORMAT([TL Annual Cash]/1000000,""#,0.0"") & ""M""
VAR contextText = ""Selected subsidy category""
RETURN IF([TL Valid Year] <> 1, ""<p>Select one year.</p>"",
""<div style='box-sizing:border-box;padding:20px;border-radius:15px;font-family:Segoe UI,Arial;background:#ffffff;color:#18232b'><div style='font-size:13px;font-weight:600'>Cash received</div><div style='font-size:38px;font-weight:700;margin:8px 0;color:#18232b'>"" & valueText & ""</div><div style='font-size:12px;color:#53616a'>"" & contextText & ""</div>"" & ""</div>"")";
m.DisplayFolder = @"05-html";
m.FormatString = @"";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Accrual Card HTML");
if (m == null) m = table.AddMeasure(@"TL Accrual Card HTML", @"VAR valueText = ""$"" & FORMAT([TL Annual Accrual]/1000000,""#,0.0"") & ""M""
VAR contextText = FORMAT([TL Annual Coverage Pct],""0.0%"") & "" annual cash coverage""
RETURN IF([TL Valid Year] <> 1, ""<p>Select one year.</p>"",
""<div style='box-sizing:border-box;padding:20px;border-radius:15px;font-family:Segoe UI,Arial;background:#ffffff;color:#18232b'><div style='font-size:13px;font-weight:600'>Accrued subsidies</div><div style='font-size:38px;font-weight:700;margin:8px 0;color:#18232b'>"" & valueText & ""</div><div style='font-size:12px;color:#53616a'>"" & contextText & ""</div>"" & ""</div>"")");
else m.Expression = @"VAR valueText = ""$"" & FORMAT([TL Annual Accrual]/1000000,""#,0.0"") & ""M""
VAR contextText = FORMAT([TL Annual Coverage Pct],""0.0%"") & "" annual cash coverage""
RETURN IF([TL Valid Year] <> 1, ""<p>Select one year.</p>"",
""<div style='box-sizing:border-box;padding:20px;border-radius:15px;font-family:Segoe UI,Arial;background:#ffffff;color:#18232b'><div style='font-size:13px;font-weight:600'>Accrued subsidies</div><div style='font-size:38px;font-weight:700;margin:8px 0;color:#18232b'>"" & valueText & ""</div><div style='font-size:12px;color:#53616a'>"" & contextText & ""</div>"" & ""</div>"")";
m.DisplayFolder = @"05-html";
m.FormatString = @"";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Performance Header HTML");
if (m == null) m = table.AddMeasure(@"TL Performance Header HTML", @"VAR safeTitle = SUBSTITUTE(SUBSTITUTE(SUBSTITUTE([TL Performance Title], ""&"", ""&amp;""), ""<"", ""&lt;""), "">"", ""&gt;"")
RETURN ""<div style='font-family:Segoe UI,Arial;color:#18232b'><div style='font-size:12px;letter-spacing:1px'>TRANSIT LEDGER / PERFORMANCE</div><h1 style='font-size:30px;margin:8px 0'>"" & safeTitle & ""</h1><div style='font-size:13px;color:#53616a'>"" & [TL Context] & ""</div></div>""");
else m.Expression = @"VAR safeTitle = SUBSTITUTE(SUBSTITUTE(SUBSTITUTE([TL Performance Title], ""&"", ""&amp;""), ""<"", ""&lt;""), "">"", ""&gt;"")
RETURN ""<div style='font-family:Segoe UI,Arial;color:#18232b'><div style='font-size:12px;letter-spacing:1px'>TRANSIT LEDGER / PERFORMANCE</div><h1 style='font-size:30px;margin:8px 0'>"" & safeTitle & ""</h1><div style='font-size:13px;color:#53616a'>"" & [TL Context] & ""</div></div>""";
m.DisplayFolder = @"05-html";
m.FormatString = @"";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Cost Header HTML");
if (m == null) m = table.AddMeasure(@"TL Cost Header HTML", @"VAR safeTitle = SUBSTITUTE(SUBSTITUTE(SUBSTITUTE([TL Cost Title], ""&"", ""&amp;""), ""<"", ""&lt;""), "">"", ""&gt;"")
RETURN ""<div style='font-family:Segoe UI,Arial;color:#18232b'><div style='font-size:12px;letter-spacing:1px'>TRANSIT LEDGER / COST</div><h1 style='font-size:30px;margin:8px 0'>"" & safeTitle & ""</h1><div style='font-size:13px;color:#53616a'>"" & [TL Context] & ""</div></div>""");
else m.Expression = @"VAR safeTitle = SUBSTITUTE(SUBSTITUTE(SUBSTITUTE([TL Cost Title], ""&"", ""&amp;""), ""<"", ""&lt;""), "">"", ""&gt;"")
RETURN ""<div style='font-family:Segoe UI,Arial;color:#18232b'><div style='font-size:12px;letter-spacing:1px'>TRANSIT LEDGER / COST</div><h1 style='font-size:30px;margin:8px 0'>"" & safeTitle & ""</h1><div style='font-size:13px;color:#53616a'>"" & [TL Context] & ""</div></div>""";
m.DisplayFolder = @"05-html";
m.FormatString = @"";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Funding Header HTML");
if (m == null) m = table.AddMeasure(@"TL Funding Header HTML", @"VAR safeTitle = SUBSTITUTE(SUBSTITUTE(SUBSTITUTE([TL Funding Title], ""&"", ""&amp;""), ""<"", ""&lt;""), "">"", ""&gt;"")
RETURN ""<div style='font-family:Segoe UI,Arial;color:#18232b'><div style='font-size:12px;letter-spacing:1px'>TRANSIT LEDGER / FUNDING</div><h1 style='font-size:30px;margin:8px 0'>"" & safeTitle & ""</h1><div style='font-size:13px;color:#53616a'>"" & [TL Context] & ""</div></div>""");
else m.Expression = @"VAR safeTitle = SUBSTITUTE(SUBSTITUTE(SUBSTITUTE([TL Funding Title], ""&"", ""&amp;""), ""<"", ""&lt;""), "">"", ""&gt;"")
RETURN ""<div style='font-family:Segoe UI,Arial;color:#18232b'><div style='font-size:12px;letter-spacing:1px'>TRANSIT LEDGER / FUNDING</div><h1 style='font-size:30px;margin:8px 0'>"" & safeTitle & ""</h1><div style='font-size:13px;color:#53616a'>"" & [TL Context] & ""</div></div>""";
m.DisplayFolder = @"05-html";
m.FormatString = @"";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Investigation Note HTML");
if (m == null) m = table.AddMeasure(@"TL Investigation Note HTML", @"""<div style='font-family:Segoe UI;color:#53616a;font-size:14px;padding:18px'><b>The next question</b><p>Recurring expense, settlement timing or an accounting adjustment? Variance locates pressure; management commentary is needed to establish cause.</p></div>""");
else m.Expression = @"""<div style='font-family:Segoe UI;color:#53616a;font-size:14px;padding:18px'><b>The next question</b><p>Recurring expense, settlement timing or an accounting adjustment? Variance locates pressure; management commentary is needed to establish cause.</p></div>""";
m.DisplayFolder = @"05-html";
m.FormatString = @"";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Funding Note HTML");
if (m == null) m = table.AddMeasure(@"TL Funding Note HTML", @"""<div style='font-family:Segoe UI;color:#53616a;font-size:14px;padding:18px'><b>Timing matters</b><p>Check settlement timing and reporting adjustments. Cash and accrual are compared separately. This selected subsidy category is not total organizational cash flow.</p></div>""");
else m.Expression = @"""<div style='font-family:Segoe UI;color:#53616a;font-size:14px;padding:18px'><b>Timing matters</b><p>Check settlement timing and reporting adjustments. Cash and accrual are compared separately. This selected subsidy category is not total organizational cash flow.</p></div>""";
m.DisplayFolder = @"05-html";
m.FormatString = @"";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Driver 1 Actual");
if (m == null) m = table.AddMeasure(@"TL Driver 1 Actual", @"VAR a = [TL Driver 1 Name]
RETURN CALCULATE([TL Annual Actual], REMOVEFILTERS(tl_account), tl_account[Account] = a)");
else m.Expression = @"VAR a = [TL Driver 1 Name]
RETURN CALCULATE([TL Annual Actual], REMOVEFILTERS(tl_account), tl_account[Account] = a)";
m.DisplayFolder = @"03-cost";
m.FormatString = @"#,0.0;−#,0.0;0.0";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Driver 1 Budget");
if (m == null) m = table.AddMeasure(@"TL Driver 1 Budget", @"VAR a = [TL Driver 1 Name]
RETURN CALCULATE([TL Annual Budget], REMOVEFILTERS(tl_account), tl_account[Account] = a)");
else m.Expression = @"VAR a = [TL Driver 1 Name]
RETURN CALCULATE([TL Annual Budget], REMOVEFILTERS(tl_account), tl_account[Account] = a)";
m.DisplayFolder = @"03-cost";
m.FormatString = @"#,0.0;−#,0.0;0.0";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Driver 1 Spark HTML");
if (m == null) m = table.AddMeasure(@"TL Driver 1 Spark HTML", @"VAR a = [TL Driver 1 Name]
RETURN CALCULATE([TL Variance Spark HTML], REMOVEFILTERS(tl_account), tl_account[Account] = a)");
else m.Expression = @"VAR a = [TL Driver 1 Name]
RETURN CALCULATE([TL Variance Spark HTML], REMOVEFILTERS(tl_account), tl_account[Account] = a)";
m.DisplayFolder = @"05-html";
m.FormatString = @"";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Driver 2 Actual");
if (m == null) m = table.AddMeasure(@"TL Driver 2 Actual", @"VAR a = [TL Driver 2 Name]
RETURN CALCULATE([TL Annual Actual], REMOVEFILTERS(tl_account), tl_account[Account] = a)");
else m.Expression = @"VAR a = [TL Driver 2 Name]
RETURN CALCULATE([TL Annual Actual], REMOVEFILTERS(tl_account), tl_account[Account] = a)";
m.DisplayFolder = @"03-cost";
m.FormatString = @"#,0.0;−#,0.0;0.0";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Driver 2 Budget");
if (m == null) m = table.AddMeasure(@"TL Driver 2 Budget", @"VAR a = [TL Driver 2 Name]
RETURN CALCULATE([TL Annual Budget], REMOVEFILTERS(tl_account), tl_account[Account] = a)");
else m.Expression = @"VAR a = [TL Driver 2 Name]
RETURN CALCULATE([TL Annual Budget], REMOVEFILTERS(tl_account), tl_account[Account] = a)";
m.DisplayFolder = @"03-cost";
m.FormatString = @"#,0.0;−#,0.0;0.0";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Driver 2 Spark HTML");
if (m == null) m = table.AddMeasure(@"TL Driver 2 Spark HTML", @"VAR a = [TL Driver 2 Name]
RETURN CALCULATE([TL Variance Spark HTML], REMOVEFILTERS(tl_account), tl_account[Account] = a)");
else m.Expression = @"VAR a = [TL Driver 2 Name]
RETURN CALCULATE([TL Variance Spark HTML], REMOVEFILTERS(tl_account), tl_account[Account] = a)";
m.DisplayFolder = @"05-html";
m.FormatString = @"";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Monthly Table HTML");
if (m == null) m = table.AddMeasure(@"TL Monthly Table HTML", @"VAR rows = ADDCOLUMNS(VALUES(tl_date[MonthNo]), ""@a"", [TL Actual M], ""@b"", [TL Budget M], ""@v"", [TL Variance M])
RETURN IF([TL Valid Year] <> 1, ""<p>Select one year.</p>"",
""<table style='width:100%;font-family:Segoe UI;font-size:13px;border-collapse:collapse;color:#18232b'><thead><tr><th>Month</th><th>Actual $M</th><th>Budget $M</th><th>Variance $M</th></tr></thead><tbody>"" &
 CONCATENATEX(rows, ""<tr style='height:30px;border-bottom:1px solid #dde0df'><td>"" & FORMAT(DATE([TL Year],tl_date[MonthNo],1),""MMM"",""en-US"") & ""</td><td style='text-align:right'>"" & FORMAT([@a],""#,0.0"") & ""</td><td style='text-align:right'>"" & FORMAT([@b],""#,0.0"") & ""</td><td style='text-align:right;color:"" & IF([@v]>=0,""#cf493a"",""#526b7a"") & ""'>"" & FORMAT([@v],""+#,0.0;−#,0.0;0.0"") & ""</td></tr>"", """", tl_date[MonthNo], ASC) & ""</tbody></table>"")");
else m.Expression = @"VAR rows = ADDCOLUMNS(VALUES(tl_date[MonthNo]), ""@a"", [TL Actual M], ""@b"", [TL Budget M], ""@v"", [TL Variance M])
RETURN IF([TL Valid Year] <> 1, ""<p>Select one year.</p>"",
""<table style='width:100%;font-family:Segoe UI;font-size:13px;border-collapse:collapse;color:#18232b'><thead><tr><th>Month</th><th>Actual $M</th><th>Budget $M</th><th>Variance $M</th></tr></thead><tbody>"" &
 CONCATENATEX(rows, ""<tr style='height:30px;border-bottom:1px solid #dde0df'><td>"" & FORMAT(DATE([TL Year],tl_date[MonthNo],1),""MMM"",""en-US"") & ""</td><td style='text-align:right'>"" & FORMAT([@a],""#,0.0"") & ""</td><td style='text-align:right'>"" & FORMAT([@b],""#,0.0"") & ""</td><td style='text-align:right;color:"" & IF([@v]>=0,""#cf493a"",""#526b7a"") & ""'>"" & FORMAT([@v],""+#,0.0;−#,0.0;0.0"") & ""</td></tr>"", """", tl_date[MonthNo], ASC) & ""</tbody></table>"")";
m.DisplayFolder = @"05-html";
m.FormatString = @"";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Cost Chart Title");
if (m == null) m = table.AddMeasure(@"TL Cost Chart Title", @"[TL Driver 1 Name] & "" had the largest upward dollar variance""");
else m.Expression = @"[TL Driver 1 Name] & "" had the largest upward dollar variance""";
m.DisplayFolder = @"06-text";
m.FormatString = @"";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Heatmap Title");
if (m == null) m = table.AddMeasure(@"TL Heatmap Title", @"[TL Driver 1 Name] & "" pressure peaked in "" & FORMAT(DATE([TL Year],[TL Driver 1 Peak Month],1),""MMM"",""en-US"")");
else m.Expression = @"[TL Driver 1 Name] & "" pressure peaked in "" & FORMAT(DATE([TL Year],[TL Driver 1 Peak Month],1),""MMM"",""en-US"")";
m.DisplayFolder = @"06-text";
m.FormatString = @"";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Cash Chart Title");
if (m == null) m = table.AddMeasure(@"TL Cash Chart Title", @"""December supplied "" & FORMAT([TL December Cash Share Pct],""0.0%"") & "" of annual cash receipts""");
else m.Expression = @"""December supplied "" & FORMAT([TL December Cash Share Pct],""0.0%"") & "" of annual cash receipts""";
m.DisplayFolder = @"06-text";
m.FormatString = @"";
}
{
var m = table.Measures.FirstOrDefault(x => x.Name == @"TL Coverage Title");
if (m == null) m = table.AddMeasure(@"TL Coverage Title", @"""Cash covered "" & FORMAT([TL Annual Coverage Pct],""0.0%"") & "" of annual accrual""");
else m.Expression = @"""Cash covered "" & FORMAT([TL Annual Coverage Pct],""0.0%"") & "" of annual accrual""";
m.DisplayFolder = @"06-text";
m.FormatString = @"";
}