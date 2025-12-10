using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Filters;

/// <summary>
/// Action çalışma süresini ölçen action filter
/// </summary>
public class PerformanceActionFilter : IActionFilter
{
    private const string ActionStartTimeKey = "ActionStartTime";

    public void OnActionExecuting(ActionExecutingContext context)
    {
        // Action başlangıç zamanını kaydet
        context.HttpContext.Items[ActionStartTimeKey] = DateTime.UtcNow;
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        // Başlangıç zamanını al
        if (context.HttpContext.Items.TryGetValue(ActionStartTimeKey, out var startTimeObj) && startTimeObj is DateTime startTime)
        {
            var endTime = DateTime.UtcNow;
            var duration = endTime - startTime;

            var controllerName = context.RouteData.Values["controller"]?.ToString() ?? "Unknown";
            var actionName = context.RouteData.Values["action"]?.ToString() ?? "Unknown";

            Console.WriteLine(
                $"[PERFORMANCE] Controller: {controllerName}, Action: {actionName}, " +
                $"Süre: {duration.TotalMilliseconds:F2} ms");
        }
    }
}

