using ExpenseAnalysis.Api.Features.MonthlyReports.Commands;
using ExpenseAnalysis.Api.Features.MonthlyReports.Requests;
using ExpenseAnalysis.Common.Api.Dtos;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace ExpenseAnalysis.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MonthlyReportsController : ControllerBase
{
    private readonly IMediator _mediator;

    public MonthlyReportsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<MonthlyReportDto> Create([FromBody] CreateMonthlyReportRequest request)
    {
        return await _mediator.Send(new CreateMonthlyReportCommand { Request = request });
    }

    [HttpDelete("{id}")]
    public async Task Delete(Guid id)
    {
        await _mediator.Send(new DeleteMonthlyReportCommand { Id = id });
    }
} 