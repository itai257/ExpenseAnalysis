using System.ComponentModel;

namespace ExpenseAnalysis.Common.Model.Visa;

public class VisaRecord
{
    [DisplayName("תאריך")]
    public DateTime? Date { get; set; }

    [DisplayName("בית עסק")]
    public string BusinessPlaceName { get; set; }

    [DisplayName("סכום עסקה")]
    public Price DealAmount { get; set; }

    [DisplayName("סכום חיוב")]
    public Price ChargeCost { get; set; }

    [DisplayName("סוג עסקה")]
    public string  DealKind { get; set; }

    [DisplayName("קטגוריה")]
    public string Category { get; set; } = string.Empty;

    [DisplayName("הערות")]
    public string Notes { get; set;}
}