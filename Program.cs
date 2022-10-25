using System;
using WebApplication1;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Register your service types
builder.Services.AddWeatherForecastService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/weatherforecast", () => {
    //Just get the top level service, and amp to the function, let the factory do the rest
    var service = app.Services.GetRequiredService<IWeatherForecastService>();
    return service.Get();
    })
.WithName("GetWeatherForecast");

app.Run();

