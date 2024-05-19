using System.Globalization;
using ExpenseAnalysis.Common.Model;
using OfficeOpenXml;

namespace ExpenseAnalysis.CLI;

public static class ExcelRangeExtensions
{
    public static Price? ToPrice(this ExcelRange worksheetCell)
    {
        return Price.FromExcelCell(worksheetCell);
    }
    public static DateTime? ToDateTime(this ExcelRange worksheetCell)
    {
        DateTime? date = null;
        
        try
        {
            date = worksheetCell.GetValue<DateTime>();
            
            return date;
        }
        catch (Exception)
        {
            // ignored
        }

        try
        {
            date = DateTime.ParseExact(worksheetCell.Text, "d/M/y", CultureInfo.InvariantCulture);
            return date;
        }
        catch (Exception)
        {
            // ignored
        }

        try
        {
            date = DateTime.ParseExact(worksheetCell.Text, "d/M/yyyy", CultureInfo.InvariantCulture);
            return date;
        }
        catch (Exception)
        {
            // ignored
        }


        return date;
    }
}