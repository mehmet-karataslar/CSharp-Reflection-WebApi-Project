using System;

namespace ConsoleApp;

/// <summary>
/// Geliştirici bilgilerini saklayan custom attribute
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
public class DeveloperInfoAttribute : Attribute
{
    public string DeveloperName { get; }
    public string Version { get; }
    public string Description { get; }
    public DateTime CreatedDate { get; }

    public DeveloperInfoAttribute(string developerName, string version, string description = "")
    {
        DeveloperName = developerName;
        Version = version;
        Description = description;
        CreatedDate = DateTime.Now;
    }
}

