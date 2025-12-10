namespace WebApi.Models;

/// <summary>
/// Controller metadata modeli - Reflection endpoint için
/// </summary>
public class ControllerMetadata
{
    public string ControllerName { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public List<ActionMetadata> Actions { get; set; } = new();
}

public class ActionMetadata
{
    public string ActionName { get; set; } = string.Empty;
    public string ReturnType { get; set; } = string.Empty;
    public List<string> HttpMethods { get; set; } = new();
    public List<string> Attributes { get; set; } = new();
    public List<ParameterMetadata> Parameters { get; set; } = new();
}

public class ParameterMetadata
{
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
}

