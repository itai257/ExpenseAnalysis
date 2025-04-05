using System.ComponentModel;
using ExpenseAnalysis.Common.Model;

namespace ExpenseAnalysis.Client.ViewModels;

public class MonthlyExpenseViewModel
{

    public MonthlyExpenseViewModel(MonthlyReport monthlyExpenses)
    {
        Year = monthlyExpenses.Year;
        Month = monthlyExpenses.Month;
        TotalIncomeInShekels = new MoneyViewModel(monthlyExpenses.TotalIncomeInShekels);
        TotalChargesInShekels = new MoneyViewModel(monthlyExpenses.TotalChargesInShekels);
        Difference = new MoneyViewModel(monthlyExpenses.Difference);
        Notes = monthlyExpenses.Notes;
    }

    public List<string> Headers => new()
    {
        GetType().GetDisplayName(nameof(Year)),
        GetType().GetDisplayName(nameof(Month)),
        GetType().GetDisplayName(nameof(TotalIncomeInShekels)),
        GetType().GetDisplayName(nameof(TotalChargesInShekels)),
        GetType().GetDisplayName(nameof(Difference)),
        GetType().GetDisplayName(nameof(Notes)),
    };

    [DisplayName("שנה")]
    public int Year { get; set; }

    [DisplayName("חודש")]
    public int Month { get; set; }

    [DisplayName("סהכ הכנסה")]
    public MoneyViewModel TotalIncomeInShekels { get; set; }

    [DisplayName("סהכ הוצאות")]
    public MoneyViewModel TotalChargesInShekels { get; set; }

    [DisplayName("מאזן")]
    public MoneyViewModel Difference { get; set; }

    [DisplayName("הערות")]
    public string Notes { get; set; }
}