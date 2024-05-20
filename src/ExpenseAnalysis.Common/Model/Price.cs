using System.Globalization;
using System.Text.Json.Serialization;
using OfficeOpenXml;

namespace ExpenseAnalysis.Common.Model;

public class Price
{

    public double Value { get; set; }

    public Currency Currency { get; set; }

    public Price(double value)
    {
        Value = value;
        Currency = Currency.Shekel;
    }

    public Price(double value, Currency currency)
    {
        Value = value;
        Currency = currency;
    }

    [JsonConstructor]
    private Price()
    {
    }

    public override string ToString()
    {
        return $"{Value} {GetCurrencyString(Currency)}";
    }

    public string GetCurrencyString()
    {
        return Currency switch
        {
            Currency.Dollar => "$",
            Currency.Euro => "€",
            Currency.Shekel => "₪",
            Currency.None => "₪"
        };
    }

    private string GetCurrencyString(Currency currency)
    {
        return currency switch
        {
            Currency.Dollar => "$",
            Currency.Euro => "€",
            Currency.Shekel => "₪",
            Currency.None => "₪"
        };
    }

    public static Price FromExcelCell(ExcelRange worksheetCell)
    {
        try
        {
            var doubleValue = worksheetCell.GetValue<double>();
            return new Price(doubleValue);
        }
        catch (Exception)
        {
        }

        var (shekelNumberFormat, dollarNumberFormat, euroNumberFormat) = GetNumbersFormats();

        if (decimal.TryParse(worksheetCell.Text, NumberStyles.Currency, shekelNumberFormat, out decimal decValue))
        {
            return new Price((double)decValue, Currency.Shekel);
        }

        if (decimal.TryParse(worksheetCell.Text, NumberStyles.Currency, dollarNumberFormat, out decimal decValue2))
        {
            return new Price((double)decValue2, Currency.Dollar);
        }

        if (decimal.TryParse(worksheetCell.Text, NumberStyles.Currency, euroNumberFormat, out decimal decValue3))
        {
            return new Price((double)decValue3, Currency.Euro);
        }

        return Price.Empty;
    }

    public static Price Empty => new Price() { };

    private static (NumberFormatInfo shekelNumberFormat, NumberFormatInfo dollarNumberFormat, NumberFormatInfo euroNumberFormat) GetNumbersFormats()
    {
        var shekelNumberFormat = new NumberFormatInfo()
        {
            NegativeSign = "-",
            NumberDecimalSeparator = ".",
            NumberGroupSeparator = ",",
            CurrencySymbol = "₪"
        };

        var dollarNumberFormat = new NumberFormatInfo()
        {
            NegativeSign = "-",
            NumberDecimalSeparator = ".",
            NumberGroupSeparator = ",",
            CurrencySymbol = "$"
        };

        var euroNumberFormat = new NumberFormatInfo()
        {
            NegativeSign = "-",
            NumberDecimalSeparator = ".",
            NumberGroupSeparator = ",",
            CurrencySymbol = "€"
        };

        return (shekelNumberFormat, dollarNumberFormat, euroNumberFormat);
    }
}