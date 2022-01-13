namespace ExperianCalculator.Services
{
    using ExperianCalculator.Domain;
    using ExperianCalculator.Services.Interfaces;
    using System;

    public class ConsoleLogger : ILogger
    {
        public void Error(string message)
        {
            Console.WriteLine($"{ConsoleMessages.ErrorOccured}{message}");
        }

        public void Info(string message)
        {
            Console.WriteLine(message);
        }
    }
}
