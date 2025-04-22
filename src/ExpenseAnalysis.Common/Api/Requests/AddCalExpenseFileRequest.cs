using Microsoft.AspNetCore.Http;

namespace ExpenseAnalysis.Common.Api.Requests;

public class AddCalExpenseFileRequest
{
    public IFormFile File { get; set; } = null!;
    
    public DateTime DebitDate { get; set; }
}