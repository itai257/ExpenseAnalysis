using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ExpenseAnalysis.Api.Entities.Reports;

namespace ExpenseAnalysis.Api.Entities.Monthly;

[Table("MonthlyReports")]
public class MonthlyReport
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    [Required]
    [Range(1, 12)]
    public int Month { get; set; }
    
    [Required]
    [Range(2000, 2100)]
    public int Year { get; set; }
    
    public ICollection<CalCardExpenseReport> CalCardExpenseReports { get; set; } = new List<CalCardExpenseReport>();
    
    public ICollection<LeumiVisaCardExpenseReport> LeumiVisaCardExpenseReports { get; set; } = new List<LeumiVisaCardExpenseReport>();
    
    public Guid? OshExpenseReportId { get; set; }
    [ForeignKey(nameof(OshExpenseReportId))]
    public OshExpenseReport? OshExpenseReport { get; set; }
}