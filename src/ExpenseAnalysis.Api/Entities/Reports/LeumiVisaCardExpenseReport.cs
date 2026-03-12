using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ExpenseAnalysis.Api.Entities.ExpenseRecord;
using ExpenseAnalysis.Api.Entities.Monthly;

namespace ExpenseAnalysis.Api.Entities.Reports;

[Table("LeumiVisaCardExpenseReports")]
public class LeumiVisaCardExpenseReport
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    [Required]
    public DateTime DebitDate { get; set; }
    
    [Required]
    [StringLength(500)]
    public string ReportFilePath { get; set; } = string.Empty;
    
    public virtual ICollection<LeumiVisaCardExpenseRecord> Records { get; set; } = new List<LeumiVisaCardExpenseRecord>();

    public Guid? MonthlyReportId { get; set; }

    [ForeignKey(nameof(MonthlyReportId))]
    public virtual MonthlyReport? MonthlyReport { get; set; }
} 