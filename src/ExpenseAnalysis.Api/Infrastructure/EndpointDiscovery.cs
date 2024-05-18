using System.Reflection;

namespace ExpenseAnalysis.Api.Infrastructure;

public static class EndpointDiscovery
{
    private static readonly Type[] EndpointTypes = { typeof(Endpoint<>), typeof(Endpoint<,>) };

    public static void RegisterEndpoints(this IEndpointRouteBuilder endpoint)
    {
        var endpointTypes = GetEndpointTypes();

        foreach (var type in endpointTypes)
        {
            var instance = Activator.CreateInstance(type);

            var methodInfo = type.GetMethod("MapEndpoint");

            methodInfo?.Invoke(instance, new object[] { endpoint });
        }
    }
    
    private static IEnumerable<Type> GetEndpointTypes()
    {
        return Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t is { IsInterface: false, IsAbstract: false }
                        && t.BaseType != null
                        && t.BaseType.IsGenericType
                        && EndpointTypes.Contains(t.BaseType.GetGenericTypeDefinition()));
    }
}