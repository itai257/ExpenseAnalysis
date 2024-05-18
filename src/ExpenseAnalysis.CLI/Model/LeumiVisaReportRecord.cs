using System.ComponentModel;

namespace ExpenseAnalysis.CLI.Model;


public class LeumiVisaReportRecord
{
    public LeumiVisaReportRecord(DateTime? date, string businessPlaceName, Price dealAmount, string dealKind, string notes, Price chargeCost)
    {
        Date = date;
        BusinessPlaceName = businessPlaceName;
        DealAmount = dealAmount;
        ChargeCost = chargeCost;
        DealKind = dealKind;
        Notes = notes;
    }

    [DisplayName("תאריך")]
    public DateTime? Date { get; private set; }

    [DisplayName("שם עסק")]
    public string BusinessPlaceName { get; private set; }

    [DisplayName("מחיר עסקה")]
    public Price DealAmount { get; private set; }

    [DisplayName("מחיר חיוב")]
    public Price ChargeCost { get; private set; }

    [DisplayName("סוג עסקה")]
    public string DealKind { get; private set; }

    [DisplayName("הערות")]
    public string Notes { get; private set; }

    public override string ToString()
    {
        return $"{Date} {BusinessPlaceName} {DealAmount} {DealKind} {Notes} {ChargeCost}";
    }
}