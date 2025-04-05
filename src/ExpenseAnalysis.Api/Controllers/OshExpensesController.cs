using ExpenseAnalysis.Api.Features.OshExpenses.Commands;
using ExpenseAnalysis.Api.Features.OshExpenses.Queries;
using ExpenseAnalysis.Api.Features.OshExpenses.Requests;
using ExpenseAnalysis.Common.Api.Dtos;
using ExpenseAnalysis.Common.Api.Requests;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ExpenseAnalysis.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OshExpensesController : ControllerBase
{
    private readonly IMediator _mediator;

    public OshExpensesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<List<OshExpenseRecordDto>> GetAll()
    {
        return await _mediator.Send(new GetAllOshExpenseRecordsQuery());
    }

    [HttpPost]
    public async Task<OshExpenseRecordDto> Add([FromBody] AddOshExpenseRecordRequest request)
    {
        return await _mediator.Send(new AddOshExpenseRecordCommand { Request = request });
    }
    
    [HttpPost("Upload")]
    public async Task UploadFile([FromForm] AddOshExpenseFileRequest request)
    {
        await _mediator.Send(new AddOshExpenseFileCommand { Request = request });
    }
}