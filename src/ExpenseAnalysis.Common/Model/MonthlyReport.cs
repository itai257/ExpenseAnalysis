using ExpenseAnalysis.Common.Model.Osh;
using ExpenseAnalysis.Common.Model.Visa;
using System.ComponentModel;

namespace ExpenseAnalysis.Common.Model;

public class MonthlyReport
{
    [DisplayName("שנה")]
    public int Year { get; set; }

    [DisplayName("חודש")]
    public int Month { get; set; }

    public OshReport OshReport { get; set; }

    public List<VisaReport> VisaReports { get; set; } = new();

    [DisplayName("סהכ הכנסה")]
    public double TotalIncomeInShekels => OshReport.TotalIncome + VisaReports.Where(x => x.TotalCharge < 0).Sum(x => -x.TotalCharge);

    [DisplayName("סהכ הוצאות")]
    public double TotalChargesInShekels => OshReport.TotalCharge + VisaReports.Where(x => x.TotalCharge > 0).Sum(x => x.TotalCharge);

    [DisplayName("מאזן")]
    public double Difference => TotalIncomeInShekels - TotalChargesInShekels;

    [DisplayName("הערות")]
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