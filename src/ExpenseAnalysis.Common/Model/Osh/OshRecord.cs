using System;

namespace ExpenseAnalysis.Common.Model.Osh;


public class OshRecord
{
    public DateTime? Date { get; set; }

    public DateTime? ValueDate { get; set; }
    
    public string Description { get; set; }
    public int ReferenceNumber { get; set; }
    public Price Debit { get; set; } = Price.Empty;
    public Price Credit { get; set; } = Price.Empty;

    public double Balance { get; set; }
    public string Notes { get; set; } = string.Empty;
}