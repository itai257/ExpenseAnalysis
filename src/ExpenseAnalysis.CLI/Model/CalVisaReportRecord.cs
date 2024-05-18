using System.ComponentModel;

namespace ExpenseAnalysis.CLI.Model;

public class CalVisaReportRecord
{
    public CalVisaReportRecord(DateTime date, string businessPlaceName, Price dealAmount, Price chargeCost, string dealKind, string category, string notes)
    {
        Date = date;
        BusinessPlaceName = businessPlaceName;
        DealAmount = dealAmount;
        ChargeCost = chargeCost;
        DealKind = dealKind;
        Category = category;
        Notes = notes;
    }

    [DisplayName("תאריך")]
    public DateTime Date { get; private set; }

    [DisplayName("שם בית עסק")]
    public string BusinessPlaceName { get; private set; }

    [DisplayName("מחיר עסקה")]
    public Price DealAmount { get; private set; }

    [DisplayName("מחיר חיוב")]
    public Price ChargeCost { get; private set; }

    [DisplayName("סוג עסקה")]
    public string DealKind { get; private set; }

    [DisplayName("קטגוריה")]
    public string Category { get; private set; }

    [DisplayName("הערות")]
    public string Notes { get; private set; }

    public override string ToString()
    {
        return $"{Date} {BusinessPlaceName} {DealAmount} {ChargeCost} {DealKind} {Category} {Notes}";
    }
}