namespace ExperianCalculator.Services.Interfaces
{
    using System.Collections.Generic;
    public interface ICalculatorService
    {
        List<string> CalculateReturnAmountIntoDenominations(decimal amount, decimal productPrice);
    }
}
