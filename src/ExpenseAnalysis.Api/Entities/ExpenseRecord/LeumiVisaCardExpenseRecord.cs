using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace ExpenseAnalysis.Api.Entities.ExpenseRecord;

[Table("LeumiVisaCardExpenseRecords")]
public class LeumiVisaCardExpenseRecord : BaseCardExpenseRecord
{
    /// <summary>
    /// Additional details (corresponds to "פרטים").
    /// </summary>
    [StringLength(500)]
    public string Details { get; set; } = string.Empty; // TODO: Can fit Note from baseclass?

    public sealed class CsvMap : ClassMap<LeumiVisaCardExpenseRecord>
    {
        public CsvMap()
        {
            Map(m => m.TransactionDate).Index(0).Convert(x =>
            {
                var value = x.Row.GetField(0) ?? string.Empty;
                return string.IsNullOrEmpty(value) ? null : DateTime.Parse(value);
            });
            
            Map(m => m.BusinessName).Index(1);
            Map(m => m.TransactionAmount).Index(2).Convert(x => MoneyConverter(x, 2));
            Map(m => m.TransactionType).Index(3);
            Map(m => m.Details).Index(4);
            Map(m => m.ChargeAmount).Index(5).Convert(x => MoneyConverter(x, 5));
        }

        private Money? MoneyConverter(ConvertFromStringArgs args, int fieldNumber)
        {
            var value = args.Row.GetField(fieldNumber) ?? string.Empty;
            
            var currencySymbol = value.FirstOrDefault(x => Money.SymbolTypesConstants.Currencies.Keys.Contains(x));
            
            var digitsOnly = new string(value.Where(c => 
                char.IsDigit(c) || 
                c == '.' || 
                c == '-').ToArray());

            if (decimal.TryParse(digitsOnly, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal result))
            {
                return new Money()
                {
                    Value = result,
                    CurrencyString = currencySymbol != default? new string(new[] { currencySymbol }) : string.Empty,
                    Currency = currencySymbol != default
                        ? Money.SymbolTypesConstants.Currencies[currencySymbol]
                        : Money.CurrencySymbol.None,
                    OriginalString = value
                };
            }
            
            return null;
        }
    }
}