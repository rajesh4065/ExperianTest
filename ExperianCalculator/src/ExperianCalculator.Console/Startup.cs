namespace ExperianCalculator
{
    using ExperianCalculator.DI;
    using ExperianCalculator.Services.Interfaces;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using System;

    public class Startup
    {
        private static IServiceCollection _serviceCollection { get; set; }

        public Startup(string[] args)
        {
            CreateHostBuilder(args).Build();
            var serviceProvider = _serviceCollection.BuildServiceProvider();

            ICalculatorService _calculatorService = serviceProvider.GetService<ICalculatorService>();

            _calculatorService.CalculateReturnAmountIntoDenominations(20m, 5.50m);
            Console.ReadLine();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                _serviceCollection = services;
                services.AddLoggerService();
                services.AddCalculatorService();
                services.AddCalculatorHelperService();
                services.AddCommonService();
            });
    }
}
