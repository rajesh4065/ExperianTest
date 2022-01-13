namespace ExperianCalculator.Services.Interfaces
{
    public interface ICalculatorHelperService
    {
        decimal[] Denominations { get; set; }
        string CurrencySymbol { get; set; }
        string UnitCurrencySymbol { get; set; }
        string FormatAmountToCurrenyNotation(decimal amount);
    }
}
