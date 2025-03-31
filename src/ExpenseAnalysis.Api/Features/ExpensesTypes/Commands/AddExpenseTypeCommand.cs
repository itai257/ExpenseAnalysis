using AutoMapper;
using ExpenseAnalysis.Api.Entities;
using ExpenseAnalysis.Api.Infrastructure;
using ExpenseAnalysis.Common.Api.Dtos;
using MediatR;

namespace ExpenseAnalysis.Api.Features.ExpensesTypes.Commands;

public class AddExpenseTypeCommand : IRequest<ExpenseTypeClassDto>
{
    public ExpenseTypeClassDto request { get; set; }

    public class AddExpenseTypeCommandHandler : IRequestHandler<AddExpenseTypeCommand, ExpenseTypeClassDto>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public AddExpenseTypeCommandHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
            
        public async Task<ExpenseTypeClassDto> Handle(AddExpenseTypeCommand cmd, CancellationToken cancellationToken)
        {
            if (cmd.request.Name.Length < 2 || cmd.request.Name.Length > 100) // TODO: extract to fluent validation
            {
                throw new ArgumentException("Name must be between 2 and 100 characters"); // TODO: to bad request
            }

            if (_context.ExpenseTypeClasses.Any(c => c.Name == cmd.request.Name))
            {
                throw new ArgumentException("Name already exists"); // TODO: to already exists
            }

            var newExpenseTypeClass = new ExpenseTypeClass(cmd.request.Name);
            await _context.ExpenseTypeClasses.AddAsync(newExpenseTypeClass, cancellationToken);
                
            await _context.SaveChangesAsync(cancellationToken);
                
            return _mapper.Map<ExpenseTypeClassDto>(newExpenseTypeClass);
        }
    }
}