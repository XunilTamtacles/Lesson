using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts;
using System;
using System.Linq;

namespace Lesson.Utils
{
    // Customize Attribute
    // Usage as needed, for example, you can specify that this attribute can only be applied to classes or methods.

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyClassAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<ApiKeyClassAuthorizeAttribute>>();
            var configuration = context.HttpContext.RequestServices.GetService(typeof(IConfiguration)) as IConfiguration;

            if (!context.HttpContext.Request.Headers.TryGetValue("X-API-KEY", out var extractedAPIKey))
            {
                logger.LogWarning("Invalid API key attempt");

                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "API Key was not provided."
                };
                return;
            }
            if (configuration == null)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 500,
                    Content = "Configuration error."
                };
                return;
            }

            var validkeys = configuration.GetSection("Security:ApiKeyExpiration").Get<string[]>();

            var matchingKey = validkeys.FirstOrDefault(x => x.key == extractedAPIKey);

            if (matchingKey == null)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Invalid API Key"
                };
                return;
            }

            if (matchingKey.ExpiredAt < DateTime.UtcNow)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 403,
                    Content = "API Key has Expired"
                };
                return;
            }

            //var validKeys = configuration.GetSection("Security:ApiKey").Get<string[]>();

            //if (validKeys == null || validKeys.Count == 0)
            //{
            //    context.Result = new ContentResult()
            //    {
            //        StatusCode = 500,
            //        Content = "Configuration error."
            //    };
            //    return;
            //}

            //if (!validKeys.Contains(extractedAPIKey))
            //{
            //    context.Result = new ContentResult()
            //    {
            //        StatusCode = 401,
            //        Content = "Invalid API KEY"
            //    };
            //    return;
            //}

            // last lesson, we will use the above code to check if the API key is valid, but for now, we will just check if the API key is "
            //    if (extractedAPIKey == "MYAPIKEY")
            //    {
            //        context.Result = new ContentResult()
            //        {
            //            StatusCode = 401,
            //            Content = "Invalid API KEY"
            //        };
            //        return;
            //    }

            //    if (extractedAPIKey == "MYAPIKEY")
            //    {
            //        context.Result = new ContentResult()
            //        {
            //            StatusCode = 401,
            //            Content = " API key is Disabled"
            //        };
            //        return;
            //    }

            //    if (configuration == null || configuration["Security:ApiKey"] == null)
            //    {
            //      context.Result = new ContentResult()
            //      {
            //          StatusCode = 500,
            //           Content = "Configuration error."
            //       };
            //            return;
            //       }

            //      var apiKey = configuration["Security:ApiKey"];
            //      if (apiKey == null)
            //     {
            //       context.Result = new ContentResult()
            //       {
            //           StatusCode = 500,
            //            Content = "Configuration error."
            //       };
            //         return;
            //}
        }
    }
}
