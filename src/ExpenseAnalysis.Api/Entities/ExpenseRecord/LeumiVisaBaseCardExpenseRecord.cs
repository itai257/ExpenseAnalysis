namespace ExpenseAnalysis.Api.Entities.ExpenseRecord;

public class LeumiVisaBaseCardExpenseRecord : BaseCardExpenseRecord
{
    /// <summary>
    /// Additional details (corresponds to "פרטים").
    /// </summary>
    public string Details { get; set; } // TODO: Can fit Note from baseclass?
}