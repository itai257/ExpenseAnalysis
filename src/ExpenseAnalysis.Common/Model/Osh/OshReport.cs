using System.ComponentModel;
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

    [DisplayName("תאריך התחלה")]
    public DateTime StartDate { get; set; }

    [DisplayName("תאריך סוף")]
    public DateTime EndDate { get; set; } 

    public List<OshRecord> Records { get; set; }

    [DisplayName("סהכ חיוב")]
    public double TotalCharge => Records.Sum(x => x.Debit.Value);

    [DisplayName("סהכ הכנסה")]
    public double TotalIncome => Records.Sum(x => x.Credit.Value);

    [DisplayName("מאזן")]
    public double Difference => TotalIncome - TotalCharge;
}