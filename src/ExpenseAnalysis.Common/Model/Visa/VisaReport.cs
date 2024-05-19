using System.Text.Json.Serialization;

namespace ExpenseAnalysis.Common.Model.Visa;

public class VisaReport
{
    [JsonConstructor]
    private VisaReport()
    {
    }

    public VisaReport(CardType cardType, int monthNumber, int lastDigits, IList<VisaRecord> records, int year = 0)
    {
        if (year == 0)
        {
            year = 2024;
        }

        CardType = cardType;
        Month = monthNumber;
        LastDigits = lastDigits;
        Year = year;
        Records = new List<VisaRecord>(records);
    }

    public CardType CardType { get; set; }

    public int Month { get; set; }

    public int Year { get; set; }

    public int LastDigits { get; set; }

    public List<VisaRecord> Records {get; set; }

    public double TotalCharge => Records.Sum(x => x.ChargeCost.Value);
}