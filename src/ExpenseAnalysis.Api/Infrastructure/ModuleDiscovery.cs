using System.Reflection;

namespace ExpenseAnalysis.Api.Infrastructure;


public static class ModuleDiscovery
{
    private static readonly Type ModuleType = typeof(IModule);

    public static void ConfigureModules(this IServiceCollection services)
    {
        var moduleTypes = GetModuleTypes();

        foreach (var type in moduleTypes)
        {
            if (Activator.CreateInstance(type) is IModule instance)
            {
                instance.ConfigureServices(services);
            }
        }
    }

    private static IEnumerable<Type> GetModuleTypes()
    {
        return Assembly.GetExecutingAssembly().GetTypes()
            .Where(x => ModuleType.IsAssignableFrom(x) &&
                        x is { IsInterface: false, IsAbstract: false });
    }
}