using AutoMapper;
using ExpenseAnalysis.Api.Infrastructure;
using ExpenseAnalysis.Common.Api.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ExpenseAnalysis.Api.Features.OshExpenses.Queries;

public class GetAllOshExpenseRecordsQuery : IRequest<List<OshExpenseRecordDto>>
{
    public class GetAllOshExpenseRecordsQueryHandler : IRequestHandler<GetAllOshExpenseRecordsQuery, List<OshExpenseRecordDto>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllOshExpenseRecordsQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<OshExpenseRecordDto>> Handle(GetAllOshExpenseRecordsQuery request, CancellationToken cancellationToken)
        {
            var query =  _context.OshExpenseRecords
                .Include(r => r.TypeClass);

            return await _mapper.ProjectTo<OshExpenseRecordDto>(query).ToListAsync(cancellationToken: cancellationToken);
        }
    }
} 