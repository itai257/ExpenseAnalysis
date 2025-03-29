namespace ExpenseAnalysis.Api.Entities.ExpenseRecord;

public class OshExpenseRecord
{
    /// <summary>
    /// The date of the transaction.
    /// For Cal and Leumi Visa this corresponds to the provided date field.
    /// For Osh, this is the primary transaction date.
    /// </summary>
    public DateTime Date { get; set; }
    
    /// <summary>
    /// The value date (corresponds to "תאריך ערך").
    /// </summary>
    public DateTime ValueDate { get; set; }

    /// <summary>
    /// A description of the transaction (corresponds to "תיאור").
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// A reference or voucher number (corresponds to "אסמכתא").
    /// </summary>
    public string Reference { get; set; }

    /// <summary>
    /// Debit amount (corresponds to "בחובה").
    /// </summary>
    public decimal Debit { get; set; }

    /// <summary>
    /// Credit amount (corresponds to "בזכות").
    /// </summary>
    public decimal Credit { get; set; }

    /// <summary>
    /// The balance in NIS (corresponds to "היתרה בש"ח").
    /// </summary>
    public decimal Balance { get; set; }
    
    /// <summary>
    /// A note or remark (e.g. "הערות"/"הערה").
    /// </summary>
    public string Note { get; set; }
    
    public ExpenseTypeClass TypeClass { get; set; }
}