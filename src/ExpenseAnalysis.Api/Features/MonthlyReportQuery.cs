using ExpenseAnalysis.Api.Infrastructure;
using ExpenseAnalysis.Common.Model;
using ExpenseAnalysis.Common.Model.Osh;
using ExpenseAnalysis.Common.Model.Visa;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseAnalysis.Api.Features;

public class MonthlyReportQueryEndpoint : Endpoint<MonthlyReportQuery.Query, MonthlyReportSummaryDto>
{
    public override void MapEndpoint(IEndpointRouteBuilder builder)
    {
        builder
            .MapGet("/api/MonthlyReports/{year}/{month}", Handle)
            .WithTags("MonthlyReports");
    }
}

public class MonthlyReportQuery
{
    public class Query : IRequest<MonthlyReportSummaryDto>
    {
        [FromRoute]
        public int Year { get; set; }

        [FromRoute]
        public int Month { get; set; }
    }

    public class Handler : IRequestHandler<Query, MonthlyReportSummaryDto>
    {
        private readonly IMonthlyReportRepository _repository;

        public Handler(IMonthlyReportRepository repository)
        {
            _repository = repository;
        }
        public Task<MonthlyReportSummaryDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var monthSummary = _repository.GetWithProjection<MonthlyReportSummaryDto>(request.Year, request.Month);

            Console.WriteLine($"{request.Year}/{request.Month}");
            return Task.FromResult(new MonthlyReportSummaryDto());
        }
    }

}

public class MonthlyReportSummaryDto : IMapFrom<MonthlyReport>
{
    public int Year { get; set; }

    public int Month { get; set; }

    public double TotalIncomeInShekels { get; set; }

    public double TotalChargesInShekels { get; set; }

    public double BalanceInShekels { get; set; }

    public string Notes { get; set; }
}