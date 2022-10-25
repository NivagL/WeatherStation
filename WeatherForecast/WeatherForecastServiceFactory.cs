namespace WebApplication1;

public static class WeatherForecastServiceFactory
{
    public static IServiceCollection AddWeatherForecastService(this IServiceCollection services)
    {
        services.AddTransient<IWeatherForecastService>(provider =>
        {
            var loggerFactory = provider.GetRequiredService<ILoggerFactory>();
            var logger = loggerFactory.CreateLogger<WeatherForecastService>();
            //Do your DI stuff here
            return new WeatherForecastService(logger);
        });
        return services;
    }
}
