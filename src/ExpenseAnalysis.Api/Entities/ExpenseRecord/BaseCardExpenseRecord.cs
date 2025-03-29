namespace ExpenseAnalysis.Api.Entities.ExpenseRecord;

// Base class with common properties for an expense record.
public abstract class BaseCardExpenseRecord
{
    /// <summary>
    /// The date of the transaction.
    /// For Cal and Leumi Visa this corresponds to the provided date field.
    /// For Osh, this is the primary transaction date.
    /// </summary>
    public DateTime TransactionDate { get; set; }

    /// <summary>
    /// Business or vendor name.
    /// For Cal and Leumi Visa, this is the business name.
    /// For Osh, this property may remain unused.
    /// </summary>
    public string BusinessName { get; set; }

    /// <summary>
    /// The amount of the transaction (e.g. "סכום עסקה" or "סכום העסקה").
    /// </summary>
    public decimal? TransactionAmount { get; set; }

    /// <summary>
    /// The charged amount (e.g. "סכום חיוב").
    /// </summary>
    public decimal? ChargeAmount { get; set; }

    /// <summary>
    /// The type of transaction (e.g. "סוג עסקה").
    /// </summary>
    public string TransactionType { get; set; }

    /// <summary>
    /// A note or remark (e.g. "הערות"/"הערה").
    /// </summary>
    public string Note { get; set; }
    
    public ExpenseTypeClass TypeClass { get; set; }
}