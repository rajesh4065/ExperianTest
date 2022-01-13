namespace ExperianCalculator.Services
{
    using ExperianCalculator.Domain;
    using ExperianCalculator.Services.Interfaces;
    public class GBCalculatorHelperService : ICalculatorHelperService
    {
        public decimal[] Denominations { get; set; } = CurrencyConstants.GBDenominations;
        public string CurrencySymbol { get; set; } = CurrencyConstants.PoundCurrency;
        public string UnitCurrencySymbol { get; set; } = CurrencyConstants.PennyCurrency;

        public string FormatAmountToCurrenyNotation(decimal amount)
        {
            if (amount >= 1)
                return $"{CurrencySymbol}{amount}";
            return $"{(int)(amount * 100)}{UnitCurrencySymbol}";
        }
    }
}
