using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ExpenseAnalysis.Api.Entities.ExpenseRecord;

namespace ExpenseAnalysis.Api.Entities.Reports;

public class CalCardExpenseReport
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    [Required]
    public DateTime DebitDate { get; set; }
    
    [Required]
    public string ReportFilePath { get; set; }
    
    public ICollection<CalCardExpenseRecord> Records { get; set; }
}