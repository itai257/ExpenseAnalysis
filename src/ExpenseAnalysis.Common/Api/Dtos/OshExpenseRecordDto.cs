namespace ExpenseAnalysis.Common.Api.Dtos;

public class OshExpenseRecordDto
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public DateTime ValueDate { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Reference { get; set; } = string.Empty;
    public decimal Debit { get; set; }
    public decimal Credit { get; set; }
    public decimal Balance { get; set; }
    public string Note { get; set; } = string.Empty;
    
    public string? TypeClassName { get; set; } = string.Empty;
} 