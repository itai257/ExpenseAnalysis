using ExpenseAnalysis.Api.Infrastructure;

namespace ExpenseAnalysis.Api.Features;

public class MonthlyReportModule : IModule
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<IMonthlyReportRepository, MonthlyReportFileSystemRepository>();
    }
}