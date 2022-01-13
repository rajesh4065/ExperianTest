namespace ExperianCalculator.Services
{
    using ExperianCalculator.Domain;
    using ExperianCalculator.Services.Interfaces;
    using System;
    using System.Collections.Generic;

    public class CalculatorService : ICalculatorService
    {
        private readonly ILogger _logger;
        private readonly ICalculatorHelperService _calculatorHelperService;
        private readonly ICommonService _commonService;

        public CalculatorService(ILogger logger, ICalculatorHelperService calculatorHelperService, ICommonService commonService)
        {
            _logger = logger;
            _calculatorHelperService = calculatorHelperService;
            _commonService = commonService;
        }
        public List<string> CalculateReturnAmountIntoDenominations(decimal amount, decimal productPrice)
        {
            List<string> changeDenominations = new List<string>();
            try
            {
                if (ValidateAmounts(amount, productPrice))
                    return changeDenominations;
                decimal remaining = (amount - productPrice);
                foreach (decimal denomination in _calculatorHelperService.Denominations)
                {
                    while (remaining >= denomination && remaining > 0)
                    {
                        remaining -= denomination;
                        changeDenominations.Add(_calculatorHelperService.FormatAmountToCurrenyNotation(denomination));
                    }
                    if(remaining <= 0)
                        break;
                }

                // display the results to console
                _logger.Info(_commonService.JoinDenominationsToString(changeDenominations));
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }

            return changeDenominations;
        }

        private bool ValidateAmounts(decimal amount, decimal productPrice)
        {
            if (amount < productPrice)
            {
                _logger.Info(ConsoleMessages.AmountShouldBeGreaterThanProductPrice);
                return true;
            }
            if (amount == productPrice)
            {
                _logger.Info(ConsoleMessages.PriceAndAmountMatches);
                return true;
            }
            return false;
        }
    }
}

