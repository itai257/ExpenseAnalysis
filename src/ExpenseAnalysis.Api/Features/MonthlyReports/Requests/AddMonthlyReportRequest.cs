namespace ExpenseAnalysis.Api.Features.MonthlyReports.Requests;

public class AddMonthlyReportRequest
{
    public int Month { get; set; }
    public int Year { get; set; }
}

public class AddReportToMonthlyReportRequest
{
    public Guid ReportId { get; set; }
} 