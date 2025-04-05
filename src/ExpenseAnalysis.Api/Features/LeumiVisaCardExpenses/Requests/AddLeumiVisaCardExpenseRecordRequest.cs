using System.ComponentModel.DataAnnotations;
using ExpenseAnalysis.Api.Entities;

namespace ExpenseAnalysis.Api.Features.LeumiVisaCardExpenses.Requests;

public class AddLeumiVisaCardExpenseRecordRequest
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
    
    [StringLength(500)]
    public string Details { get; set; } = string.Empty;
} 