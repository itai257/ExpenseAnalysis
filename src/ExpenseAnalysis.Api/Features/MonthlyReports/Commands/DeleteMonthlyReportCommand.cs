using ExpenseAnalysis.Api.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ExpenseAnalysis.Api.Features.MonthlyReports.Commands;

public class DeleteMonthlyReportCommand : IRequest
{
    public Guid Id { get; set; }

    public class DeleteMonthlyReportCommandHandler : IRequestHandler<DeleteMonthlyReportCommand>
    {
        private readonly ApplicationDbContext _dbContext;

        public DeleteMonthlyReportCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(DeleteMonthlyReportCommand command, CancellationToken cancellationToken)
        {
            var report = await _dbContext.MonthlyReports.FindAsync(new object[] { command.Id }, cancellationToken);
            
            if (report == null)
                throw new Exception($"Monthly report with ID {command.Id} not found.");

            _dbContext.MonthlyReports.Remove(report);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
} 