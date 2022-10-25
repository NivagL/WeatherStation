namespace WebApplication1;

public interface IWeatherForecastService
{
    Task<IEnumerable<WeatherForecast>> Get();
}
