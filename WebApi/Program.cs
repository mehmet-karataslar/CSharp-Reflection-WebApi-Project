using WebApi.Filters;
using WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Global Filters kaydı
builder.Services.AddControllers(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
    options.Filters.Add<PerformanceActionFilter>();
});

// Action Filter kaydı (ServiceFilter olarak kullanılabilir)
builder.Services.AddScoped<PerformanceActionFilter>();

var app = builder.Build();

// Configure the HTTP request pipeline.

// Custom Middleware'i pipeline'a ekle (diğer middleware'lerden önce)
app.UseMiddleware<RequestLoggingMiddleware>();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
