using AutoMapper;
using ExpenseAnalysis.Api.Dtos;
using ExpenseAnalysis.Api.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ExpenseAnalysis.Api.Features.ExpensesTypes.Commands;

public class UpdateExpenseTypeCommand : IRequest<ExpenseTypeClassDto>
{
    public string oldName { get; set; }
    public ExpenseTypeClassDto request { get; set; }

    public class UpdateExpenseTypeCommandHandler : IRequestHandler<UpdateExpenseTypeCommand, ExpenseTypeClassDto>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public UpdateExpenseTypeCommandHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
            
        public async Task<ExpenseTypeClassDto> Handle(UpdateExpenseTypeCommand cmd, CancellationToken cancellationToken)
        {
            if (cmd.request.Name.Length < 2 || cmd.request.Name.Length > 100) // TODO: extract to fluent validation
            {
                throw new ArgumentException("Name must be between 2 and 100 characters"); // TODO: to bad request
            }

            var existingExpenseType = await _context.ExpenseTypeClasses.FirstOrDefaultAsync(e => e.Name == cmd.oldName, cancellationToken);
            if (existingExpenseType == null)
            {
                throw new ArgumentException("Name doesnt exist"); // TODO: to not exists
            }

            existingExpenseType.Update(cmd.request.Name);
            
            await _context.SaveChangesAsync(cancellationToken);
                
            return _mapper.Map<ExpenseTypeClassDto>(existingExpenseType);
        }
    }
}