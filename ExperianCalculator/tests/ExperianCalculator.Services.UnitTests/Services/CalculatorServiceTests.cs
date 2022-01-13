namespace ExperianCalculator.Services.UnitTests
{
    using ExperianCalculator.Services.Interfaces;
    using Moq;
    using System;
    using System.Collections.Generic;
    using Xunit;
    public class CalculatorServiceTests
    {

        private readonly Mock<ILogger> _logger;
        private readonly ICalculatorHelperService _calculatorHelperService;
        private readonly Mock<ICalculatorHelperService> _mockCalculatorHelperService;
        private readonly ICommonService _commonService;
        private static ICalculatorService _calculatorService;

        public CalculatorServiceTests(ICalculatorHelperService calculatorHelperService, ICommonService commonService)
        {
            _logger = new Mock<ILogger>(MockBehavior.Strict);
            _mockCalculatorHelperService = new Mock<ICalculatorHelperService>();
            _calculatorHelperService = calculatorHelperService;
            _commonService = commonService;
        }

        private void SetupMockingBehaviourForServices()
        {
            _logger.Setup(e => e.Info(It.IsAny<string>())).Verifiable();
            _logger.Setup(e => e.Error(It.IsAny<string>())).Verifiable();
        }


        [Theory]
        [InlineData(4, 5)]
        [InlineData(4, 4)]
        public void CalculateReturnAmountIntoDenominationsShouldHaveCalledLoggerInfoMethod(decimal amount, decimal productPrice)
        {
            // arrange
            SetupMockingBehaviourForServices();
            _calculatorService = new CalculatorService(_logger.Object, _calculatorHelperService, _commonService);

            // act
            _calculatorService.CalculateReturnAmountIntoDenominations(amount, productPrice);

            // assert
            _logger.Verify(e => e.Info(It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public void CalculateReturnAmountIntoDenominationsShouldReturnValidDenominationValues()
        {
            // arrange
            SetupMockingBehaviourForServices();
            _calculatorService = new CalculatorService(_logger.Object, _calculatorHelperService, _commonService);
            List<string> expectedDenominations = new List<string>() { "£10", "£2", "£2", "50p" };

            // act
            List<string> actualDenominations = _calculatorService.CalculateReturnAmountIntoDenominations(20m, 5.50m);

            // assert
            _logger.Verify(e => e.Info(It.IsAny<string>()), Times.Once());
            Assert.Equal(expectedDenominations, actualDenominations);
        }

        [Fact]
        public void CalculateReturnAmountIntoDenominationsShouldHaveCalledLoggerErrorMethod()
        {
            // arrange
            SetupMockingBehaviourForServices();
            _mockCalculatorHelperService.Setup(e => e.Denominations).Returns(new decimal[] { 500m, 200m, 100m, 50m, 20m, 10m, 5m, 2m, 1m, 0.5m, 0.2m, 0.1m, 0.05m, 0.02m, 0.01m });
            _mockCalculatorHelperService.Setup(e => e.UnitCurrencySymbol).Returns("p");
            _mockCalculatorHelperService.Setup(e => e.CurrencySymbol).Returns("£");
            _mockCalculatorHelperService.Setup(e => e.FormatAmountToCurrenyNotation(It.IsAny<decimal>())).Throws(new NullReferenceException());
            _calculatorService = new CalculatorService(_logger.Object, _mockCalculatorHelperService.Object, _commonService);

            // act
            _calculatorService.CalculateReturnAmountIntoDenominations(20m, 5.50m);

            // assert
            _logger.Verify(e => e.Error(It.IsAny<string>()), Times.Once());
        }
    }
}
