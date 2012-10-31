using System.Web.Http;

namespace CacheCowAndBrowser
{
    using System;
    using System.Net.Http.Headers;

    using CacheCow.Server;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}");

            //config.MessageHandlers.Add(new CachingHandler());

            // Comment this in to make IE work correctly

            config.MessageHandlers.Add(
                 new CachingHandler
                 {
                     CacheControlHeaderProvider = message => new CacheControlHeaderValue
                     {
                         Private = true,
                         MustRevalidate = true,
                         NoTransform = true,
                         MaxAge = TimeSpan.Zero
                     }
                 });
        }
    }
}
