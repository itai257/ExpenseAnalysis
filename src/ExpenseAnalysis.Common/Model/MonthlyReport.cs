using ExpenseAnalysis.Common.Model.Osh;
using ExpenseAnalysis.Common.Model.Visa;

namespace ExpenseAnalysis.Common.Model;

public class MonthlyReport
{
    public int MonthNumber { get; set; }

    public OshReport OshReport { get; set; }
    public List<VisaReport> VisaReports { get; set; }
    public double TotalIncomeInShekels { get; set; }
    public double TotalChargesInShekels { get; set; }
    public double BalanceInShekels { get; set; }
    public string Notes { get; set; }
}