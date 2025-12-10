namespace WebApi.Models;

/// <summary>
/// Standart hata yanıt modeli
/// </summary>
public class ErrorResponse
{
    public string Message { get; set; } = string.Empty;
    public string? Details { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    public string? StackTrace { get; set; }
}

