using WebApplication3;
using WebApplication3.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();
builder.Services.AddControllers();
builder.Services.AddDbContext<TaskListDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
