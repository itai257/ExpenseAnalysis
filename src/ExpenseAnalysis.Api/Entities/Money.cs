using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ExpenseAnalysis.Api.Entities;

[Owned]
public class Money
{
    public decimal Value { get; set; }

    public string CurrencyString { get; set; } = null!;
    
    public CurrencySymbol Currency { get; set; }
    public string OriginalString { get; set; } = null!;

    public enum CurrencySymbol { None = 0, Ils = 10, Usd = 20, Eur = 30 }
    public static class SymbolTypesConstants
    {
        public static readonly Dictionary<char, CurrencySymbol> Currencies = new ()
        {
            { Ils, CurrencySymbol.Ils },
            { Usd, CurrencySymbol.Usd },
            { Eur, CurrencySymbol.Eur }
        };

        public const char Ils = '₪';
        public const char Usd = '$';
        public const char Eur = '€';
    }

    public override string ToString()
    {
        return OriginalString;
    }
}