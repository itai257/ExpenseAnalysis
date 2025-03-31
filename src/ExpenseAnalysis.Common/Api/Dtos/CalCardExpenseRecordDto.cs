namespace ExpenseAnalysis.Common.Api.Dtos;

public class CalCardExpenseRecordDto
{
    public int Id { get; set; }
    
    public DateTime TransactionDate { get; set; }
    
    public string BusinessName { get; set; } = string.Empty;
    
    public decimal? TransactionAmount { get; set; }
    
    public decimal? ChargeAmount { get; set; }
    
    public string TransactionType { get; set; } = string.Empty;
    
    public string Note { get; set; } = string.Empty;
    
    public ExpenseTypeClassDto? TypeClass { get; set; }
    
    public string Branch { get; set; } = string.Empty;
} 