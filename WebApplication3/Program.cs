using NLog.Web;
using WebApplication3.Entities;
using WebApplication3.Middleware;
using WebApplication3.Services;

var MyAllowSpecificOrigins = "FrontEnd";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => options.AddPolicy(name: MyAllowSpecificOrigins,
    policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
    }
));
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<TaskDbContext>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddSwaggerGen();
// NLog: Setup NLog for Dependency injection
builder.Logging.ClearProviders();
builder.Host.UseNLog();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskList API");
});

app.UseCors(MyAllowSpecificOrigins);
app.MapControllers();

app.Run();
