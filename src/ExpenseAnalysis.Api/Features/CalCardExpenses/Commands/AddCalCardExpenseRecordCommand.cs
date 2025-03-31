using AutoMapper;
using ExpenseAnalysis.Api.Entities.ExpenseRecord;
using ExpenseAnalysis.Api.Features.CalCardExpenses.Requests;
using ExpenseAnalysis.Api.Infrastructure;
using ExpenseAnalysis.Common.Api.Dtos;
using MediatR;

namespace ExpenseAnalysis.Api.Features.CalCardExpenses.Commands;

public class AddCalCardExpenseRecordCommand : IRequest<CalCardExpenseRecordDto>
{
    public AddCalCardExpenseRecordRequest Request { get; set; } = null!;

    public class AddCalCardExpenseRecordCommandHandler : IRequestHandler<AddCalCardExpenseRecordCommand, CalCardExpenseRecordDto>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AddCalCardExpenseRecordCommandHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CalCardExpenseRecordDto> Handle(AddCalCardExpenseRecordCommand request, CancellationToken cancellationToken)
        {
            var record = new CalCardExpenseRecord
            {
                TransactionDate = request.Request.TransactionDate,
                BusinessName = request.Request.BusinessName,
                TransactionAmount = request.Request.TransactionAmount,
                ChargeAmount = request.Request.ChargeAmount,
                TransactionType = request.Request.TransactionType,
                Note = request.Request.Note,
                Branch = request.Request.Branch
            };

            await _context.CalCardExpenseRecords.AddAsync(record, cancellationToken);
            
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CalCardExpenseRecordDto>(record);
        }
    }
} 