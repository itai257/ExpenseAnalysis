using ExpenseAnalysis.Api.Dtos;
using ExpenseAnalysis.Api.Features.CalCardExpenses.Commands;
using ExpenseAnalysis.Api.Features.CalCardExpenses.Queries;
using ExpenseAnalysis.Api.Features.CalCardExpenses.Requests;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace ExpenseAnalysis.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CalCardExpensesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CalCardExpensesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<List<CalCardExpenseRecordDto>> GetAll()
    {
        return await _mediator.Send(new GetAllCalCardExpenseRecordsQuery());
    }

    [HttpPost]
    public async Task<CalCardExpenseRecordDto> Add([FromBody] AddCalCardExpenseRecordRequest request)
    {
        return await _mediator.Send(new AddCalCardExpenseRecordCommand { Request = request });
    }
} 