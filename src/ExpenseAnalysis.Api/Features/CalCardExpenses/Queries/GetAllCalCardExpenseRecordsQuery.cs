using AutoMapper;
using ExpenseAnalysis.Api.Dtos;
using ExpenseAnalysis.Api.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ExpenseAnalysis.Api.Features.CalCardExpenses.Queries;

public class GetAllCalCardExpenseRecordsQuery : IRequest<List<CalCardExpenseRecordDto>>
{
    public class GetAllCalCardExpenseRecordsQueryHandler : IRequestHandler<GetAllCalCardExpenseRecordsQuery, List<CalCardExpenseRecordDto>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllCalCardExpenseRecordsQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CalCardExpenseRecordDto>> Handle(GetAllCalCardExpenseRecordsQuery request, CancellationToken cancellationToken)
        {
            var query = _context.CalCardExpenseRecords
                .Include(r => r.TypeClass);

            return await _mapper.ProjectTo<CalCardExpenseRecordDto>(query).ToListAsync(cancellationToken: cancellationToken);
        }
    }
} 