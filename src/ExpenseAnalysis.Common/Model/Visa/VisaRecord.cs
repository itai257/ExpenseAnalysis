namespace ExpenseAnalysis.Common.Model.Visa;

public class VisaRecord
{
    public DateTime? Date { get; set; }

    public string BusinessPlaceName { get; set; }
    
    public Price DealAmount { get; set; }
    
    public Price ChargeCost { get; set; }

    public string  DealKind { get; set; }

    public string Category { get; set; } = string.Empty;
    
    public string Notes { get; set;}
}