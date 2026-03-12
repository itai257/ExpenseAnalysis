using ExpenseAnalysis.Api.Entities.Monthly;
using ExpenseAnalysis.Api.Features.MonthlyReports.Requests;
using ExpenseAnalysis.Api.Infrastructure;
using ExpenseAnalysis.Common.Api.Dtos;
using MediatR;
using AutoMapper;

namespace ExpenseAnalysis.Api.Features.MonthlyReports.Commands;

public class CreateMonthlyReportCommand : IRequest<MonthlyReportDto>
{
    public CreateMonthlyReportRequest Request { get; set; } = null!;

    public class CreateMonthlyReportCommandHandler : IRequestHandler<CreateMonthlyReportCommand, MonthlyReportDto>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateMonthlyReportCommandHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<MonthlyReportDto> Handle(CreateMonthlyReportCommand command, CancellationToken cancellationToken)
        {
            var report = new MonthlyReport
            {
                Month = command.Request.Month,
                Year = command.Request.Year
            };

            _dbContext.MonthlyReports.Add(report);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<MonthlyReportDto>(report);
        }
    }
} 