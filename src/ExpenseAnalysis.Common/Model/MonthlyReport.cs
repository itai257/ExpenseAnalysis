using ExpenseAnalysis.Common.Model.Osh;
using ExpenseAnalysis.Common.Model.Visa;

namespace ExpenseAnalysis.Common.Model;

public class MonthlyReport
{
    public int Year { get; set; }

    public int Month { get; set; }

    public OshReport OshReport { get; set; }

    public List<VisaReport> VisaReports { get; set; } = new();

    public double TotalIncomeInShekels { get; set; }

    public double TotalChargesInShekels { get; set; }

    public double BalanceInShekels { get; set; }

    public string Notes { get; set; }

    public void SetOshReport(OshReport oshReport)
    {
        OshReport = oshReport;
    }

    public void AddVisaReport(VisaReport visaReport)
    {
        VisaReports.Add(visaReport);
    }
}