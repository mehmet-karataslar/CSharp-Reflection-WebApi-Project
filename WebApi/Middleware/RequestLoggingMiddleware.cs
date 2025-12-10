namespace WebApi.Middleware;

/// <summary>
/// Request ve Response loglama için custom middleware
/// </summary>
public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Request bilgilerini logla
        var requestMethod = context.Request.Method;
        var requestPath = context.Request.Path;
        var requestTime = DateTime.Now;

        _logger.LogInformation(
            ">>> GELEN İSTEK - Metod: {Method}, URL: {Path}, Zaman: {Time}",
            requestMethod, requestPath, requestTime.ToString("yyyy-MM-dd HH:mm:ss.fff"));

        // Response'u yakalamak için stream'i sakla
        var originalBodyStream = context.Response.Body;

        using var responseBody = new MemoryStream();
        context.Response.Body = responseBody;

        // Sonraki middleware'i çağır
        await _next(context);

        // Response bilgilerini logla
        var statusCode = context.Response.StatusCode;
        var responseTime = DateTime.Now;

        _logger.LogInformation(
            "<<< DÖNEN YANIT - Status Code: {StatusCode}, Zaman: {Time}",
            statusCode, responseTime.ToString("yyyy-MM-dd HH:mm:ss.fff"));

        // Response body'yi geri kopyala
        await responseBody.CopyToAsync(originalBodyStream);
    }
}

