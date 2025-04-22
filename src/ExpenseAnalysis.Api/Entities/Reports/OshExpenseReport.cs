using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ExpenseAnalysis.Api.Entities.ExpenseRecord;

namespace ExpenseAnalysis.Api.Entities.Reports;

public class OshExpenseReport
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    [Required]
    public DateTime StartDate { get; set; }
    
    [Required]
    public DateTime EndDateTime { get; set; }
    
    [Required]
    public string ReportFilePath { get; set; }
    
    public ICollection<OshExpenseRecord> Records { get; set; }
}