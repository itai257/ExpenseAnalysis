using System.ComponentModel.DataAnnotations;
using ExpenseAnalysis.Api.Entities.ExpenseRecord;

namespace ExpenseAnalysis.Api.Dtos;

public class LeumiVisaCardExpenseRecordDto : IMapFrom<LeumiVisaCardExpenseRecord>
{
    public int Id { get; set; }
    
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
    
    public ExpenseTypeClassDto? TypeClass { get; set; }
    
    [StringLength(500)]
    public string Details { get; set; } = string.Empty;
} 