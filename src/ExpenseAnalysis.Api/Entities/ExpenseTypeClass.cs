using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using ExpenseAnalysis.Api.Entities.ExpenseRecord;

namespace ExpenseAnalysis.Api.Entities;

[Table("ExpenseTypeClasses")]
public class ExpenseTypeClass
{
    [JsonConstructor]
    private ExpenseTypeClass()
    {
    }
    
    public ExpenseTypeClass(string name)
    {
        Name = name;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    [StringLength(100)]
    [MinLength(2)]
    public string Name { get; set; }
    
    // Navigation properties for relationships
    public virtual ICollection<CalCardExpenseRecord>? CalCardExpenseRecords { get; set; }
    
    public virtual ICollection<LeumiVisaCardExpenseRecord>? LeumiVisaCardExpenseRecords { get; set; }
    
    public virtual ICollection<OshExpenseRecord>? OshExpenseRecords { get; set; }

    public void Update(string newName)
    {
        Name = newName;
    }
}