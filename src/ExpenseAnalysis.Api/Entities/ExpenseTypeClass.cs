using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ExpenseAnalysis.Api.Entities.ExpenseRecord;

namespace ExpenseAnalysis.Api.Entities;

[Table("ExpenseTypeClasses")]
public class ExpenseTypeClass
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;
    
    // Navigation properties for relationships
    public virtual ICollection<CalCardExpenseRecord>? CalCardExpenseRecords { get; set; }
    public virtual ICollection<LeumiVisaCardExpenseRecord>? LeumiVisaCardExpenseRecords { get; set; }
    public virtual ICollection<OshExpenseRecord>? OshExpenseRecords { get; set; }
}