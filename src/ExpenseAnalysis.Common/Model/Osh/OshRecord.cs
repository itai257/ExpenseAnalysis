using System;
using System.ComponentModel;

namespace ExpenseAnalysis.Common.Model.Osh;


public class OshRecord
{
    [DisplayName("תאריך")]
    public DateTime? Date { get; set; }

    [DisplayName("תאריך ערך")]
    public DateTime? ValueDate { get; set; }

    [DisplayName("תיאור")]
    public string Description { get; set; }

    [DisplayName("אסמכתא")]
    public int ReferenceNumber { get; set; }

    [DisplayName("חובה")]
    public Price Debit { get; set; } = Price.Empty;

    [DisplayName("זכות")]
    public Price Credit { get; set; } = Price.Empty;

    [DisplayName("יתרה")]
    public double Balance { get; set; }

    [DisplayName("הערות")]
    public string Notes { get; set; } = string.Empty;
}