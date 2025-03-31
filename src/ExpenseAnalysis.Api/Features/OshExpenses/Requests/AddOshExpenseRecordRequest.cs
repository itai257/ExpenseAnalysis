namespace ExpenseAnalysis.Api.Features.OshExpenses.Requests;

public class AddOshExpenseRecordRequest
{
    public DateTime Date { get; set; }
    public DateTime ValueDate { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Reference { get; set; } = string.Empty;
    public decimal Debit { get; set; }
    public decimal Credit { get; set; }
    public decimal Balance { get; set; }
    public string Note { get; set; } = string.Empty;
}