using ExpenseAnalysis.Common.Api.Requests;

namespace ExpenseAnalysis.Api.Features.LeumiVisaCardExpenses.Requests;

public class AddLeumiVisaExpenseFileRequest
{
    public IFormFile? File { get; set; }
    public DateTime DebitDate { get; set; }
} 