using AutoMapper;
using ExpenseAnalysis.Api.Entities.ExpenseRecord;
using ExpenseAnalysis.Api.Features.OshExpenses.Requests;
using ExpenseAnalysis.Api.Infrastructure;
using ExpenseAnalysis.Common.Api.Dtos;
using MediatR;

namespace ExpenseAnalysis.Api.Features.OshExpenses.Commands;

public class AddOshExpenseRecordCommand : IRequest<OshExpenseRecordDto>
{
    public AddOshExpenseRecordRequest Request { get; set; } = null!;

    public class AddOshExpenseRecordCommandHandler : IRequestHandler<AddOshExpenseRecordCommand, OshExpenseRecordDto>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AddOshExpenseRecordCommandHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OshExpenseRecordDto> Handle(AddOshExpenseRecordCommand request, CancellationToken cancellationToken)
        {
            var record = new OshExpenseRecord
            {
                Date = request.Request.Date,
                ValueDate = request.Request.ValueDate,
                Description = request.Request.Description,
                Reference = request.Request.Reference,
                Debit = request.Request.Debit,
                Credit = request.Request.Credit,
                Balance = request.Request.Balance,
                Note = request.Request.Note
            };

            await _context.OshExpenseRecords.AddAsync(record, cancellationToken);
            
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<OshExpenseRecordDto>(record);
        }
    }
} 