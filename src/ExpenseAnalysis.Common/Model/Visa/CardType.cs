using System.Text.Json.Serialization;

namespace ExpenseAnalysis.Common.Model.Visa;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum CardType
{
    None,
    Leumi,
    Cal
}