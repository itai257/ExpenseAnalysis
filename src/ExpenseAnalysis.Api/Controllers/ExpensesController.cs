using AutoMapper.QueryableExtensions;
using ExpenseAnalysis.Api.Dtos;
using ExpenseAnalysis.Api.Features.Commands;
using ExpenseAnalysis.Api.Features.Queries;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace ExpenseAnalysis.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpensesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExpensesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Types")]
        public async Task<List<ExpenseTypeClassDto>> GetAll()
        {
            return await _mediator.Send(new GetAllExpensesTypesQuery());
        }

        [HttpPost("Types")]
        public async Task<ExpenseTypeClassDto> AddType([FromBody] ExpenseTypeClassDto expenseTypeClassDto)
        {
            return await _mediator.Send(new AddExpenseTypeCommand() { request = expenseTypeClassDto });
        }

        [HttpPut("Types/{name}")]
        public async Task<ExpenseTypeClassDto> AddType([FromRoute] string name, [FromBody] ExpenseTypeClassDto expenseTypeClassDto)
        {
            return await _mediator.Send(new UpdateExpenseTypeCommand() { oldName = name, request = expenseTypeClassDto });
        }
    }
} 