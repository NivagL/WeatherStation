namespace WebApplication1;

public class WeatherForecastService : IWeatherForecastService
{
    private readonly ILogger<WeatherForecastService> Logger;

    public WeatherForecastService(ILogger<WeatherForecastService> logger)
    {
        Logger = logger;
    }

    private string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        Logger.LogInformation("Called WeatherForecastService.Get");

        await Task.Delay(1);
        var forecast = Enumerable.Range(1, 5).Select(index =>
            new WeatherForecast
            (
                DateTime.Now.AddDays(index),
                Random.Shared.Next(-20, 55),
                Summaries[Random.Shared.Next(Summaries.Length)]
            ))
            .ToArray();
        return forecast;
    }
}
