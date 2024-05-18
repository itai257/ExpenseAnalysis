namespace ExpenseAnalysis.CLI.Model;

public class LeumiOshReportRecord
{
    public LeumiOshReportRecord(DateTime? date, DateTime? valueDate, string description, int referenceNumber, Price debit, Price credit, double balanceInShekels, string notes)
    {
        Date = date;
        ValueDate = valueDate;
        Description = description;
        ReferenceNumber = referenceNumber;
        Debit = debit;
        Credit = credit;
        BalanceInShekels = balanceInShekels;
        Notes = notes;
    }

    public DateTime? Date { get; private set; }
    public DateTime? ValueDate { get; private set; }
    public string Description { get; private set; }
    public int ReferenceNumber { get; private set; }
    public Price Debit { get; private set; }
    public Price Credit { get; private set; }
    public double BalanceInShekels { get; private set; }
    public string Notes { get; private set; }

    public override string ToString()
    {
        return $" {Date},  {ValueDate},  {Description},  {ReferenceNumber}, {Debit}, {Credit},  {BalanceInShekels}, {Notes}";
    }
}