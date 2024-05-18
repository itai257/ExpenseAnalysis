namespace ExpenseAnalysis.CLI.Model;

public class CalVisaReport : ITableViewModelApplicable<CalVisaReportRecord>
{
    public CalVisaReport(List<CalVisaReportRecord> reports, string month, string cardSuffix)
    {
        Reports = reports;
        Month = month;
        CardSuffix = cardSuffix;
    }

    public string CardSuffix { get; }

    public string Month { get; }

    public List<CalVisaReportRecord> Reports { get; }

    public double TotalChargeCost => Reports.Sum(x => x.ChargeCost.Value);
    
    public string Title => $"{CardSuffix} - {MonthHebrew} כאל";

    public List<CalVisaReportRecord> Rows => Reports;

    public string MonthHebrew => Month.ToLower() switch
    {
        "april" => "אפריל"
    };
}