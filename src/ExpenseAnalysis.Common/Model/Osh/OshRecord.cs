using System;

namespace ExpenseAnalysis.Common.Model.Osh;

public class OshRecord
{
    public DateTime Date { get; set; }
    public DateTime ValueDate { get; set; }
    public string Description { get; set; }
    public int ReferenceNumber { get; set; }
    public Price Debit { get; set; }
    public Price  Credit { get; set; }

    public double BalanceInShekels => Credit.Value - Debit.Value;
}