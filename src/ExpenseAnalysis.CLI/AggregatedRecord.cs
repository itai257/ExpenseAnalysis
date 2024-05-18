
using ExpenseAnalysis.CLI.Model;

namespace ExpenseAnalysis.CLI;

public class AggregatedRecord
{
    public int Month { get; private set; }

    public List<LeumiVisaReport> LeumiVisaReports { get; } = new();
    public List<CalVisaReport> CalVisaReports { get; } = new();
    public List<LeumiOshReport> LeumiOshReports { get; } = new();

    public void AddLeumiVisaReport(LeumiVisaReport leumiVisaReport)
    {
        LeumiVisaReports.Add(leumiVisaReport);
    }

    public void AddCalVisaReport(CalVisaReport calVisaReport)
    {
        CalVisaReports.Add(calVisaReport);
    }

    public void AddLeumiOshReport(LeumiOshReport leumiOshReport)
    {
        LeumiOshReports.Add(leumiOshReport);
    }

    public IEnumerable<LeumiVisaReport> GetAllLeumiVisaReports()
    {
        foreach (var leumiVisaReport in LeumiVisaReports)
        {
            yield return leumiVisaReport;
        }
    }

    public IEnumerable<CalVisaReport> GetAllCalVisaReports()
    {
        foreach (var calVisaReport in CalVisaReports)
        {
            yield return calVisaReport;
        }
    }

    public double TotalChargeCost => LeumiVisaReports.Sum(x => x.TotalChargeCost) + CalVisaReports.Sum(x => x.TotalChargeCost) + LeumiOshReports.Sum(x => x.TotalExpenses);

    public double TotalIncome => LeumiOshReports.Sum(x => x.TotalIncome);
}