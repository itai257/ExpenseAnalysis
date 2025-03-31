using AutoMapper;
using System.Reflection;
using ExpenseAnalysis.Api.Entities;
using ExpenseAnalysis.Api.Entities.ExpenseRecord;
using ExpenseAnalysis.Common.Api.Dtos;

namespace ExpenseAnalysis.Api;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        var types = Assembly.GetExecutingAssembly().GetExportedTypes()
            .Where(t => t.GetInterfaces().Any(i =>
                i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
            .ToList();

        foreach (var type in types)
        {
            ; var instance = Activator.CreateInstance(type);

            var methodInfo = type.GetMethod("Mapping")
                             ?? type.GetInterface("IMapFrom`1")!.GetMethod("Mapping");


            methodInfo?.Invoke(instance, new object[] { this });
        }
        
        ManuallyCreateMaps<CalCardExpenseRecord, CalCardExpenseRecordDto>();
        ManuallyCreateMaps<ExpenseTypeClass, ExpenseTypeClassDto>();
        ManuallyCreateMaps<LeumiVisaCardExpenseRecord, LeumiVisaCardExpenseRecordDto>();
        ManuallyCreateMaps<OshExpenseRecord, OshExpenseRecordDto>();
    }

    private void ManuallyCreateMaps<FromT,ToT>()
    {
        CreateMap(typeof(FromT), typeof(ToT)).ReverseMap();
    }
}

public interface IMapFrom<T>
{
    void Mapping(Profile profile)
    {
        profile.CreateMap(typeof(T), GetType()).ReverseMap();
    }
}