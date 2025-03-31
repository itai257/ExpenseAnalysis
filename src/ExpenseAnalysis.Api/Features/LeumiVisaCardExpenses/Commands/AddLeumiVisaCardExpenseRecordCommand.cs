using AutoMapper;
using ExpenseAnalysis.Api.Dtos;
using ExpenseAnalysis.Api.Entities.ExpenseRecord;
using ExpenseAnalysis.Api.Features.LeumiVisaCardExpenses.Requests;
using ExpenseAnalysis.Api.Infrastructure;
using MediatR;

namespace ExpenseAnalysis.Api.Features.LeumiVisaCardExpenses.Commands;

public class AddLeumiVisaCardExpenseRecordCommand : IRequest<LeumiVisaCardExpenseRecordDto>
{
    public AddLeumiVisaCardExpenseRecordRequest Request { get; set; } = null!;

    public class AddLeumiVisaCardExpenseRecordCommandHandler : IRequestHandler<AddLeumiVisaCardExpenseRecordCommand, LeumiVisaCardExpenseRecordDto>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AddLeumiVisaCardExpenseRecordCommandHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<LeumiVisaCardExpenseRecordDto> Handle(AddLeumiVisaCardExpenseRecordCommand request, CancellationToken cancellationToken)
        {
            var record = new LeumiVisaCardExpenseRecord
            {
                TransactionDate = request.Request.TransactionDate,
                BusinessName = request.Request.BusinessName,
                TransactionAmount = request.Request.TransactionAmount,
                ChargeAmount = request.Request.ChargeAmount,
                TransactionType = request.Request.TransactionType,
                Note = request.Request.Note,
                Details = request.Request.Details
            };

            await _context.LeumiVisaCardExpenseRecords.AddAsync(record, cancellationToken);
            
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<LeumiVisaCardExpenseRecordDto>(record);
        }
    }
} 