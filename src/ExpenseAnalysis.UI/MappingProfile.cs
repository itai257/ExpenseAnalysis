using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection;
using AutoMapper;

namespace ExpenseAnalysis.UI;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        var types = Assembly.GetExecutingAssembly().GetExportedTypes()
            .Where(t => t.GetInterfaces().Any(i =>
                i == typeof(IHaveMapping)))
            .ToList();

        foreach (var type in types)
        {
            var instance = Activator.CreateInstance(type);

            var methodInfo = type.GetMethod("CreateMap");


            methodInfo?.Invoke(instance, new object[] { this });
        }
    }
}

public interface IHaveMapping
{
    void CreateMap(Profile profile);
}