using ExpenseAnalysis.Api.Features.LeumiVisaCardExpenses.Commands;
using ExpenseAnalysis.Api.Features.LeumiVisaCardExpenses.Queries;
using ExpenseAnalysis.Api.Features.LeumiVisaCardExpenses.Requests;
using ExpenseAnalysis.Common.Api.Dtos;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace ExpenseAnalysis.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LeumiVisaCardExpensesController : ControllerBase
{
    private readonly IMediator _mediator;

    public LeumiVisaCardExpensesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<List<LeumiVisaCardExpenseRecordDto>> GetAll()
    {
        return await _mediator.Send(new GetAllLeumiVisaCardExpenseRecordsQuery());
    }

    [HttpPost]
    public async Task<LeumiVisaCardExpenseRecordDto> Add([FromBody] AddLeumiVisaCardExpenseRecordRequest request)
    {
        return await _mediator.Send(new AddLeumiVisaCardExpenseRecordCommand { Request = request });
    }

    [HttpPost("Upload")]
    public async Task UploadFile([FromForm] AddLeumiVisaExpenseFileRequest request)
    {
        await _mediator.Send(new AddLeumiVisaExpenseFileCommand { Request = request });
    }
} 