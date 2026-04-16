using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts;

namespace Lesson.Utils
{
    // Customize Attribute
    // Usage as needed, for example, you can specify that this attribute can only be applied to classes or methods.

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyClassAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var configuration = context.HttpContext.RequestServices.GetService(typeof(IConfiguration)) as IConfiguration;

            if (!context.HttpContext.Request.Headers.TryGetValue("X-API-KEY", out var extractedAPIKey))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "API Key was not provided."
                };
                return;
            }

            if (configuration == null || configuration["Security:ApiKey"] == null)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 500,
                    Content = "Configuration error."
                };
                return;
            }

            var apiKey = configuration["Security:ApiKey"];
            if (apiKey == null)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 500,
                    Content = "Configuration error."
                };
                return;
            }
        }
    }
}
