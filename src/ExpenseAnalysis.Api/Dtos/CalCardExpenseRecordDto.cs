using System.ComponentModel.DataAnnotations;
using ExpenseAnalysis.Api.Entities.ExpenseRecord;

namespace ExpenseAnalysis.Api.Dtos;

public class CalCardExpenseRecordDto : IMapFrom<CalCardExpenseRecord>
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
    
    [StringLength(100)]
    public string Branch { get; set; } = string.Empty;
} 