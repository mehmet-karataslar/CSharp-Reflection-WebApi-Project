using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApi.Models;

namespace WebApi.Filters;

/// <summary>
/// Global exception filter - Tüm beklenmeyen hataları yakalar
/// </summary>
public class GlobalExceptionFilter : IExceptionFilter
{
    private readonly ILogger<GlobalExceptionFilter> _logger;

    public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
    {
        _logger = logger;
    }

    public void OnException(ExceptionContext context)
    {
        _logger.LogError(context.Exception, "Beklenmeyen hata oluştu");

        var errorResponse = new ErrorResponse
        {
            Message = "Bir hata oluştu. Lütfen daha sonra tekrar deneyin.",
            Details = context.Exception.Message,
            StackTrace = context.HttpContext.RequestServices.GetService<IWebHostEnvironment>()?.IsDevelopment() == true
                ? context.Exception.StackTrace
                : null
        };

        context.Result = new ObjectResult(errorResponse)
        {
            StatusCode = 500
        };

        context.ExceptionHandled = true;
    }
}

