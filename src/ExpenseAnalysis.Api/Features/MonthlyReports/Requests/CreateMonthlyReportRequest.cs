using System.ComponentModel.DataAnnotations;

namespace ExpenseAnalysis.Api.Features.MonthlyReports.Requests;

public class CreateMonthlyReportRequest
{
    [Required]
    [Range(1, 12)]
    public int Month { get; set; }
    
    [Required]
    [Range(2000, 2100)]
    public int Year { get; set; }
} 