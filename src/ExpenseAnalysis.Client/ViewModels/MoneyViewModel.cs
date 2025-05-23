﻿using ExpenseAnalysis.Common.Model;

namespace ExpenseAnalysis.Client.ViewModels;

public class MoneyViewModel
{
    public MoneyViewModel(double value)
    {
        NumericValue = value;
        FormattedValue = value == 0? "" : string.Format($"{NumericValue:N}");
    }

    public MoneyViewModel(Price price)
    {
        NumericValue = price.Value;
        FormattedValue = price.Value == 0 ? "" : string.Format($"{NumericValue:N} {price.GetCurrencyString()}");
    }

    public double NumericValue { get; set; }

    public string FormattedValue { get; set; }

    public bool IsZero => NumericValue == 0;

    public bool IsPositive => NumericValue > 0;

    public bool IsNegative => NumericValue < 0;
}