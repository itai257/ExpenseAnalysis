using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using ExpenseAnalysis.Api.Entities.Reports;

namespace ExpenseAnalysis.Api.Entities.ExpenseRecord;

[Table("CalCardExpenseRecords")]
public class CalCardExpenseRecord : BaseCardExpenseRecord
{
    /// <summary>
    /// The branch or industry (corresponds to "ענף").
    /// </summary>
    [StringLength(100)]
    public string Branch { get; set; } = string.Empty;
    
    public Guid? CalCardReportId { get; set; }
    
    [ForeignKey("CalCardReportId")]
    public CalCardExpenseReport? CalCardReport { get; set; }
    
    public sealed class CsvMap : ClassMap<CalCardExpenseRecord>
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
            Map(m => m.ChargeAmount).Index(3).Convert(x => MoneyConverter(x, 3));
            Map(m => m.TransactionType).Index(4);
            Map(m => m.Branch).Index(5);
            Map(m => m.Note).Index(6);
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
                    CurrencyString = new string(new[] { currencySymbol }),
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