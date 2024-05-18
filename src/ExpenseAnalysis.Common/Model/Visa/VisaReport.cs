namespace ExpenseAnalysis.Common.Model.Visa;

public class VisaReport
{
    public CardType CardType { get; set; }
    public int MonthNumber { get; set; }
    public int LastDigits { get; set; }

    public List<VisaRecord> Records {get; set; }

    public double TotalCharge => Records.Sum(x => x.ChargeCost.Value);
}