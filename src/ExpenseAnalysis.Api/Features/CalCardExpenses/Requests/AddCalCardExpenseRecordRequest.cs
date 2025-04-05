using System.ComponentModel.DataAnnotations;
using ExpenseAnalysis.Api.Entities;

namespace ExpenseAnalysis.Api.Features.CalCardExpenses.Requests;

public class AddCalCardExpenseRecordRequest
{
    [Required]
    public DateTime TransactionDate { get; set; }
    
    [StringLength(255)]
    public string BusinessName { get; set; } = string.Empty;
    
    public Money? TransactionAmount { get; set; }
    
    public Money? ChargeAmount { get; set; }
    
    [StringLength(100)]
    public string TransactionType { get; set; } = string.Empty;
    
    [StringLength(500)]
    public string Note { get; set; } = string.Empty;
    
    [StringLength(100)]
    public string Branch { get; set; } = string.Empty;
} 