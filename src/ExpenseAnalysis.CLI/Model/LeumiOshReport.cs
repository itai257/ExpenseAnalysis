namespace ExpenseAnalysis.CLI.Model;

public class LeumiOshReport : ITableViewModelApplicable<LeumiOshReportRecord>
{
    public LeumiOshReport(List<LeumiOshReportRecord> reports, string from, string to)
    {
        Reports = reports;
        From = from;
        To = to;
    }

    public string To { get; }

    public string From { get; }

    public List<LeumiOshReportRecord> Reports { get; }

    public double TotalIncome => Reports.Sum(x => x.Credit.Value);

    public double TotalExpenses => Reports.Sum(x => x.Debit.Value);
    public string Title => $"Leumi Osh - {From} - {To}";
    public List<LeumiOshReportRecord> Rows => Reports;
}