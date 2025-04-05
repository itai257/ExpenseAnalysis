using Microsoft.AspNetCore.Http;

namespace ExpenseAnalysis.Common.Api.Requests;

public class AddOshExpenseFileRequest
{
    public IFormFile File { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
} 