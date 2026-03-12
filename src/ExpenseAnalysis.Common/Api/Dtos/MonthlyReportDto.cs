namespace ExpenseAnalysis.Common.Api.Dtos;

public class MonthlyReportDto
{
    public Guid Id { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    public List<Guid> CalCardExpenseReportIds { get; set; } = new();
    public List<Guid> LeumiVisaCardExpenseReportIds { get; set; } = new();
    public Guid? OshExpenseReportId { get; set; }
} 