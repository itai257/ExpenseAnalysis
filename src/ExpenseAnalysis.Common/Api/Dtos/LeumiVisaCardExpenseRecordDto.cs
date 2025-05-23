using System.ComponentModel.DataAnnotations;

namespace ExpenseAnalysis.Common.Api.Dtos;

public class LeumiVisaCardExpenseRecordDto
{
    public int Id { get; set; }
    
    [Required]
    public DateTime TransactionDate { get; set; }
    
    [StringLength(255)]
    public string BusinessName { get; set; } = string.Empty;
    
    public string? TransactionAmount { get; set; }
    
    public string? ChargeAmount { get; set; }
    
    [StringLength(100)]
    public string TransactionType { get; set; } = string.Empty;
    
    [StringLength(500)]
    public string Note { get; set; } = string.Empty;
    
    public ExpenseTypeClassDto? TypeClass { get; set; }
    
    [StringLength(500)]
    public string Details { get; set; } = string.Empty;
} 