namespace ExperianCalculator.DI
{
    using ExperianCalculator.Services;
    using ExperianCalculator.Services.Interfaces;
    using Microsoft.Extensions.DependencyInjection;

    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddLoggerService(this IServiceCollection services)
        {
            services.AddScoped<ILogger, ConsoleLogger>();
            return services;
        }

        public static IServiceCollection AddCalculatorService(this IServiceCollection services)
        {
            services.AddScoped<ICalculatorService, CalculatorService>();
            return services;
        }

        public static IServiceCollection AddCalculatorHelperService(this IServiceCollection services)
        {
            services.AddScoped<ICalculatorHelperService, GBCalculatorHelperService>();
            return services;
        }

        public static IServiceCollection AddCommonService(this IServiceCollection services)
        {
            services.AddScoped<ICommonService, CommonService>();
            return services;
        }
    }
}
