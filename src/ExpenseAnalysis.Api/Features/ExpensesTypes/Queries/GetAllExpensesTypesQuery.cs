using AutoMapper;
using ExpenseAnalysis.Api.Dtos;
using ExpenseAnalysis.Api.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ExpenseAnalysis.Api.Features.ExpensesTypes.Queries;

public class GetAllExpensesTypesQuery : IRequest<List<ExpenseTypeClassDto>>
{
    public class GetAllExpensesTypesHandler : IRequestHandler<GetAllExpensesTypesQuery, List<ExpenseTypeClassDto>>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
            
        public GetAllExpensesTypesHandler(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }
            
        public async Task<List<ExpenseTypeClassDto>> Handle(GetAllExpensesTypesQuery request, CancellationToken cancellationToken)
        {
            var query = _applicationDbContext.ExpenseTypeClasses;
                
            return await _mapper.ProjectTo<ExpenseTypeClassDto>(query).ToListAsync(cancellationToken: cancellationToken);
        }
    }
}