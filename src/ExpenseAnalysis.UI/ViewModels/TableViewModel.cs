using System.ComponentModel;
using ExpenseAnalysis.CLI.Model;

namespace ExpenseAnalysis.UI.ViewModels;

public class TableViewModel
{

    public string Title { get; set; }

    public List<string> Headers { get; } = new();

    public List<List<string>> Rows { get; } = new();

    public static TableViewModel Create<T>(ITableViewModelApplicable<T> tableViewModelApplicable)
    {
        var tableViewModel = CreateRows(tableViewModelApplicable.Rows);
        tableViewModel.Title = tableViewModelApplicable.Title;
        return tableViewModel;
    }

    private static TableViewModel CreateRows<T>(List<T> rows)
    {
        var tableViewModel = new TableViewModel();
        var type = typeof(T);
        var properties = type.GetProperties();
        tableViewModel.Headers.AddRange(properties.Select(p =>
            ((DisplayNameAttribute)p.GetCustomAttributes(false).First(x => x.GetType() == typeof(DisplayNameAttribute))).DisplayName));

        foreach (var row in rows)
        {
            var stringsRow = new List<string>();
            foreach (var property in properties)
            {
                if (property.PropertyType.Name == "DateTime" || (property.PropertyType.IsGenericType && property.PropertyType.GenericTypeArguments.Any(x => x.Name == "DateTime")))
                {
                    var propValue = property.GetValue(row);
                    string val = "";
                    if (propValue is not null)
                    {
                        val = ((DateTime)propValue).ToString("dd/MM/yyyy");
                    }

                    stringsRow.Add(val);
                }
                else
                {
                    stringsRow.Add(property.GetValue(row)?.ToString() ?? "");
                }
            }

            tableViewModel.Rows.Add(stringsRow);
        }

        return tableViewModel;
    }
}