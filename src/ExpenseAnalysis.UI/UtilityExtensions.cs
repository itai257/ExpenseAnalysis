using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using AutoMapper.Internal;

namespace ExpenseAnalysis.UI;

public static class UtilityExtensions
{
    public static string GetDisplayName(this Type type, string propertyName)
    {
        var prop = type.GetProperty(propertyName);
        return prop.GetDisplayName();
    }

    public static string GetDisplayName(this PropertyInfo prop)
    {
        var attr = prop?.GetCustomAttribute(typeof(DisplayNameAttribute)) as DisplayNameAttribute;
        return attr == null ? string.Empty : attr.DisplayName;
    }

    public static string GetDisplayName(this MemberInfo member)
    {
        var attr = member?.GetCustomAttribute(typeof(DisplayNameAttribute)) as DisplayNameAttribute;
        return attr == null ? string.Empty : attr.DisplayName;
    }

    public static string GetDisplayName<T, TMember>(this T obj, Expression<Func<T, TMember>> selector)
    {
        var member = ReflectionHelper.FindProperty(selector);
        return member.GetDisplayName();
    }
}