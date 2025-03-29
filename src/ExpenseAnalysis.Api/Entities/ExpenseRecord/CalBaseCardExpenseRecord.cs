namespace ExpenseAnalysis.Api.Entities.ExpenseRecord;

public class CalBaseCardExpenseRecord : BaseCardExpenseRecord
{
    /// <summary>
    /// The branch or industry (corresponds to "ענף").
    /// </summary>
    public string Branch { get; set; }
}