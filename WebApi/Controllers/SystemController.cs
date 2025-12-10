using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using WebApi.Models;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SystemController : ControllerBase
{
    /// <summary>
    /// Reflection kullanarak tüm controller'ları ve HTTP attribute'larını analiz eden endpoint
    /// </summary>
    [HttpGet("attribute-map")]
    public ActionResult<Dictionary<string, object>> GetAttributeMap()
    {
        var assembly = Assembly.GetExecutingAssembly();
        var controllers = new List<ControllerMetadata>();

        // Tüm tipleri al ve ControllerBase'den türeyenleri filtrele
        var controllerTypes = assembly.GetTypes()
            .Where(t => t.IsSubclassOf(typeof(ControllerBase)) && !t.IsAbstract)
            .ToList();

        foreach (var controllerType in controllerTypes)
        {
            var controllerMetadata = new ControllerMetadata
            {
                ControllerName = controllerType.Name.Replace("Controller", ""),
                FullName = controllerType.FullName ?? controllerType.Name,
                Actions = new List<ActionMetadata>()
            };

            // Controller'daki public metotları al (action'lar)
            var methods = controllerType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                .Where(m => !m.IsSpecialName && !m.GetCustomAttributes<NonActionAttribute>().Any())
                .ToList();

            foreach (var method in methods)
            {
                var actionMetadata = new ActionMetadata
                {
                    ActionName = method.Name,
                    ReturnType = GetReturnTypeName(method.ReturnType),
                    HttpMethods = new List<string>(),
                    Attributes = new List<string>(),
                    Parameters = method.GetParameters()
                        .Select(p => new ParameterMetadata
                        {
                            Name = p.Name ?? "unknown",
                            Type = GetTypeName(p.ParameterType)
                        })
                        .ToList()
                };

                // HTTP method attribute'larını bul
                var httpMethodAttributes = method.GetCustomAttributes()
                    .Where(attr => attr.GetType().Name.StartsWith("Http"))
                    .ToList();

                foreach (var attr in httpMethodAttributes)
                {
                    var attrName = attr.GetType().Name;
                    actionMetadata.Attributes.Add(attrName);

                    // HTTP method'u çıkar
                    if (attrName == "HttpGetAttribute")
                    {
                        actionMetadata.HttpMethods.Add("GET");
                    }
                    else if (attrName == "HttpPostAttribute")
                    {
                        actionMetadata.HttpMethods.Add("POST");
                    }
                    else if (attrName == "HttpPutAttribute")
                    {
                        actionMetadata.HttpMethods.Add("PUT");
                    }
                    else if (attrName == "HttpDeleteAttribute")
                    {
                        actionMetadata.HttpMethods.Add("DELETE");
                    }
                    else if (attrName == "HttpPatchAttribute")
                    {
                        actionMetadata.HttpMethods.Add("PATCH");
                    }
                }

                // Diğer önemli attribute'ları ekle
                var otherAttributes = method.GetCustomAttributes()
                    .Where(attr => !attr.GetType().Name.StartsWith("Http") && 
                                   attr.GetType().Name != "NonActionAttribute")
                    .Select(attr => attr.GetType().Name)
                    .ToList();

                actionMetadata.Attributes.AddRange(otherAttributes);

                // Eğer hiç HTTP method attribute'u yoksa, varsayılan olarak GET ekle
                if (!actionMetadata.HttpMethods.Any())
                {
                    actionMetadata.HttpMethods.Add("GET");
                }

                controllerMetadata.Actions.Add(actionMetadata);
            }

            controllers.Add(controllerMetadata);
        }

        var result = new Dictionary<string, object>
        {
            ["timestamp"] = DateTime.UtcNow,
            ["total_controllers"] = controllers.Count,
            ["controllers"] = controllers
        };

        return Ok(result);
    }

    private string GetReturnTypeName(Type returnType)
    {
        if (returnType == typeof(void))
            return "void";

        if (returnType.IsGenericType)
        {
            var genericArgs = returnType.GetGenericArguments()
                .Select(GetTypeName)
                .ToArray();
            var baseName = returnType.Name.Split('`')[0];
            return $"{baseName}<{string.Join(", ", genericArgs)}>";
        }

        return GetTypeName(returnType);
    }

    private string GetTypeName(Type type)
    {
        if (type.IsGenericType)
        {
            var genericArgs = type.GetGenericArguments()
                .Select(GetTypeName)
                .ToArray();
            var baseName = type.Name.Split('`')[0];
            return $"{baseName}<{string.Join(", ", genericArgs)}>";
        }

        // Nullable type kontrolü
        if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
        {
            return $"{GetTypeName(type.GetGenericArguments()[0])}?";
        }

        return type.Name;
    }
}

