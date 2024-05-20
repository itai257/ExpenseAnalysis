using System.ComponentModel;
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

    [DisplayName("סוג כרטיס")]
    public CardType CardType { get; set; }

    [DisplayName("חודש")]
    public int Month { get; set; }

    [DisplayName("שנה")]
    public int Year { get; set; }

    [DisplayName("4 ספרות אחרונות")]
    public int LastDigits { get; set; }

    public List<VisaRecord> Records { get; set; }

    [DisplayName("סהכ חיוב")]
    public double TotalCharge => Records.Sum(x => x.ChargeCost.Value);
}