using ExpenseAnalysis.Common.Model;

namespace ExpenseAnalysis.Api.Features;


public class MonthlyReportFileSystemRepository : IMonthlyReportRepository
{
    public T GetWithProjection<T>(int year, int month) where T : IMapFrom<MonthlyReport>
    {
        throw new NotImplementedException();
    }

    public IList<T> GetAllWithProjection<T>() where T : IMapFrom<MonthlyReport>
    {
        throw new NotImplementedException();
    }
}



public interface IMonthlyReportRepository
{
    public T GetWithProjection<T>(int year, int month) where T : IMapFrom<MonthlyReport>;

    public IList<T> GetAllWithProjection<T>() where T : IMapFrom<MonthlyReport>;
}