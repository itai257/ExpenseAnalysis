namespace ExpenseAnalysis.Common.Model.Osh;

public class OshReport
{
    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; } 

    public List<OshRecord> Records { get; set; }

    public double TotalCharge => Records.Sum(x => x.Debit.Value);
    public double TotalIncome => Records.Sum(x => x.Credit.Value);
    public double Balance => TotalIncome - TotalCharge;
}