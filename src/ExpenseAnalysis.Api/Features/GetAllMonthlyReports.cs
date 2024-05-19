using ExpenseAnalysis.Api.Infrastructure;
using MediatR;

namespace ExpenseAnalysis.Api.Features;

public class GetAllMonthlyReportsEndpoint : Endpoint<GetAllMonthlyReports.GetAllMonthlyReportsQuery, IList<MonthlyReportSummaryDto>>
{
    public override void MapEndpoint(IEndpointRouteBuilder builder)
    {
        builder
            .MapGet("/api/MonthlyReports", Handle)
            .WithTags("MonthlyReports");
    }
}

public class GetAllMonthlyReports
{
    public class GetAllMonthlyReportsQuery : IRequest<IList<MonthlyReportSummaryDto>>
    {
    }

    public class Handler : IRequestHandler<GetAllMonthlyReportsQuery, IList<MonthlyReportSummaryDto>>
    {
        private IMonthlyReportRepository _repository;

        public Handler(IMonthlyReportRepository repository)
        {
            _repository = repository;
        }

        public Task<IList<MonthlyReportSummaryDto>> Handle(GetAllMonthlyReportsQuery request, CancellationToken cancellationToken)
        {
            var allSummaryDtos = _repository.GetAllWithProjection<MonthlyReportSummaryDto>();

            return Task.FromResult(allSummaryDtos);
        }
    }
}