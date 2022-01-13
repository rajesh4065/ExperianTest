namespace ExperianCalculator.Services.UnitTests
{
    using ExperianCalculator.Services.Interfaces;
    using Microsoft.Extensions.DependencyInjection;
    public class Startup
    {
        /// <summary>
        /// register services
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICalculatorHelperService, GBCalculatorHelperService>();
            services.AddScoped<ICommonService, CommonService>();
            services.AddScoped<ICalculatorService, CalculatorService>();
            services.AddScoped<ILogger, ConsoleLogger>();
        }
    }
}
