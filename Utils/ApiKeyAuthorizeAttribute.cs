using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts;

namespace Lesson.Utils
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    [ApiController]
    [ApiKeyAuthorize]
    
    public class ApiKeyAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var configuration = context.HttpContext.RequestServices.GetService(typeof(IConfiguration)) as IConfiguration;

            if (!context.HttpContext.Request.Headers.TryGetValue("X-API-KEY", out var extractedApiKey))
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
                    Content = "Configuration Error"
                };
                return;
            }

            var apikey = configuration["Security:ApiKey"];
               if (apikey == null)
               {
                 context.Result = new ContentResult()
                 {
                  StatusCode = 401,
                  Content = "Unauthorized client."
                 };
                  return;
               }
               
        }
    }
}
