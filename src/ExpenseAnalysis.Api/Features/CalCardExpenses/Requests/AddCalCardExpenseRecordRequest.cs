using System.ComponentModel.DataAnnotations;

namespace ExpenseAnalysis.Api.Features.CalCardExpenses.Requests;

public class AddCalCardExpenseRecordRequest
{
    [Required]
    public DateTime TransactionDate { get; set; }
    
    [StringLength(255)]
    public string BusinessName { get; set; } = string.Empty;
    
    public decimal? TransactionAmount { get; set; }
    
    public decimal? ChargeAmount { get; set; }
    
    [StringLength(100)]
    public string TransactionType { get; set; } = string.Empty;
    
    [StringLength(500)]
    public string Note { get; set; } = string.Empty;
    
    [StringLength(100)]
    public string Branch { get; set; } = string.Empty;
} 