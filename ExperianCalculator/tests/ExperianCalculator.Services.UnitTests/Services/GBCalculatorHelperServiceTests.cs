namespace ExperianCalculator.Services.UnitTests
{
    using ExperianCalculator.Services.Interfaces;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class GBCalculatorHelperServiceTests
    {
        private readonly ICalculatorHelperService _calculatorHelperService;

        public GBCalculatorHelperServiceTests(ICalculatorHelperService calculatorHelperService)
        {
            _calculatorHelperService = calculatorHelperService;
        }

        [Fact]
        public void DenominationsShouldReturnValidCount()
        {
            // arrange
            int expectedDenominationsCount = 15;

            // act
            int actualDenominationsCount = _calculatorHelperService.Denominations.Count();

            // assert
            Assert.Equal(expectedDenominationsCount, actualDenominationsCount);
        }

        [Fact]
        public void DenominationsShouldContainValues()
        {
            // arrange
            decimal[] expectedGBDenominations = new decimal[] { 500m, 200m, 100m, 50m, 20m, 10m, 5m, 2m, 1m, 0.5m, 0.2m, 0.1m, 0.05m, 0.02m, 0.01m };

            // act
            decimal[] actualGBDenominations = _calculatorHelperService.Denominations;

            // assert
            Assert.Equal(expectedGBDenominations, actualGBDenominations);
        }

        [Fact]
        public void CurrencySymbolShouldReturnValidValue()
        {
            // arrange
            string expectedCurrency = "£";

            // act
            string actualCurrency = _calculatorHelperService.CurrencySymbol;

            // assert
            Assert.Equal(expectedCurrency, actualCurrency);
        }

        [Fact]
        public void UnitCurrencySymbolShouldReturnValidValue()
        {
            // arrange
            string expectedCurrency = "p";

            // act
            string actualCurrency = _calculatorHelperService.UnitCurrencySymbol;

            // assert
            Assert.Equal(expectedCurrency, actualCurrency);
        }

        [Theory]
        [ClassData(typeof(CalculatorTestDataForCalculatorHelperService))]
        public void FormatAmountToCurrenyNotationShouldReturnValidValues(decimal amount, string expectedFormattedAmount)
        {
            // act
            string actualFormattedAmount = _calculatorHelperService.FormatAmountToCurrenyNotation(amount);

            // assert
            Assert.Equal(expectedFormattedAmount, actualFormattedAmount);
        }
    }

    public class CalculatorTestDataForCalculatorHelperService : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
           new object[] { 10, "£10" }, new object[] { 0.5, "50p" }, new object[] { 0.05, "5p" },  new object[] { 1, "£1" }
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
