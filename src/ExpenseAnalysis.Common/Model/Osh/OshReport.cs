using System.Text.Json.Serialization;

namespace ExpenseAnalysis.Common.Model.Osh;

public class OshReport
{
    [JsonConstructor]
    private OshReport()
    {
        
    }

    public OshReport(DateTime startDate, DateTime endDate, IList<OshRecord> records)
    {
        StartDate = startDate;
        EndDate = endDate;
        Records = records.ToList();
    }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; } 

    public List<OshRecord> Records { get; set; }

    public double TotalCharge => Records.Sum(x => x.Debit.Value);

    public double TotalIncome => Records.Sum(x => x.Credit.Value);

    public double Difference => TotalIncome - TotalCharge;
}