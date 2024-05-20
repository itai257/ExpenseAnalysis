using ExpenseAnalysis.Common.Model;
using System.Text.Json;

namespace ExpenseAnalysis.Api.Features;


public class MonthlyReportFileSystemRepository : IMonthlyReportRepository
{
    private string folderPath = @"C:\\Leumi-To-Program\\monthly_report_jsons";

    public T GetWithProjection<T>(int year, int month) where T : IMapFrom<MonthlyReport>
    {
        throw new NotImplementedException();
    }

    public IList<T> GetAllWithProjection<T>() where T : IMapFrom<MonthlyReport>
    {
        var dirFiles = Directory.GetFiles("C:\\Leumi-To-Program\\monthly_report_jsons");
        var lst = new List<T>();
        foreach (var filePath in dirFiles)
        {
            var text = File.ReadAllText(filePath);
            var deserializedContent = JsonSerializer.Deserialize<T>(text);
            lst.Add(deserializedContent);
        }

        return lst;
    }
}



public interface IMonthlyReportRepository
{
    public T GetWithProjection<T>(int year, int month) where T : IMapFrom<MonthlyReport>;

    public IList<T> GetAllWithProjection<T>() where T : IMapFrom<MonthlyReport>;
}