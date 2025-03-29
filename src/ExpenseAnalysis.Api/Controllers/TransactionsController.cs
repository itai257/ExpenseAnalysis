using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace ExpenseAnalysis.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Example: var transactions = await _mediator.Send(new GetAllTransactionsQuery());
            // return Ok(transactions);
            return Ok(new { message = "Get all transactions endpoint" });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            // Example: var transaction = await _mediator.Send(new GetTransactionByIdQuery(id));
            // return transaction != null ? Ok(transaction) : NotFound();
            return Ok(new { message = $"Get transaction with ID: {id}" });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] object createTransactionRequest)
        {
            // Example: var result = await _mediator.Send(new CreateTransactionCommand(createTransactionRequest));
            // return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
            return CreatedAtAction(nameof(GetById), new { id = 1 }, new { message = "Transaction created" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] object updateTransactionRequest)
        {
            // Example: var result = await _mediator.Send(new UpdateTransactionCommand(id, updateTransactionRequest));
            // return result != null ? Ok(result) : NotFound();
            return Ok(new { message = $"Updated transaction with ID: {id}" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Example: var result = await _mediator.Send(new DeleteTransactionCommand(id));
            // return result ? NoContent() : NotFound();
            return NoContent();
        }
    }
} 