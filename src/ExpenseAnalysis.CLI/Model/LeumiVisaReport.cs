namespace ExpenseAnalysis.CLI.Model;

public class LeumiVisaReport : ITableViewModelApplicable<LeumiVisaReportRecord>
{
    public LeumiVisaReport(List<LeumiVisaReportRecord> reports, string month, string cardSuffix)
    {
        Reports = reports;
        Month = month;
        CardSuffix = cardSuffix;
    }

    public string Title => $"לאומי {CardSuffix} - {MonthHebrew}";

    public List<LeumiVisaReportRecord> Rows => Reports;

    public string CardSuffix { get; }

    public string Month { get; }

    public List<LeumiVisaReportRecord> Reports { get; }

    public double TotalChargeCost => Reports.Sum(x => x.ChargeCost.Value);

    public string MonthHebrew => Month.ToLower() switch
    {
        "april" => "אפריל"
    };
}

public interface ITableViewModelApplicable<T>
{
    string Title { get; }

    List<T> Rows { get; }
}