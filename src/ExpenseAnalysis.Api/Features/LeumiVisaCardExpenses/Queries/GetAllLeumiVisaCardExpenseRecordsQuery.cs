using AutoMapper;
using ExpenseAnalysis.Api.Infrastructure;
using ExpenseAnalysis.Common.Api.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ExpenseAnalysis.Api.Features.LeumiVisaCardExpenses.Queries;

public class GetAllLeumiVisaCardExpenseRecordsQuery : IRequest<List<LeumiVisaCardExpenseRecordDto>>
{
    public class GetAllLeumiVisaCardExpenseRecordsQueryHandler : IRequestHandler<GetAllLeumiVisaCardExpenseRecordsQuery, List<LeumiVisaCardExpenseRecordDto>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllLeumiVisaCardExpenseRecordsQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<LeumiVisaCardExpenseRecordDto>> Handle(GetAllLeumiVisaCardExpenseRecordsQuery request, CancellationToken cancellationToken)
        {
            var query = _context.LeumiVisaCardExpenseRecords
                .Include(r => r.TypeClass);
            var res = await query.ToListAsync(cancellationToken: cancellationToken);
            return _mapper.Map<List<LeumiVisaCardExpenseRecordDto>>(res);
        }
    }
} 