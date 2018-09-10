using Amaris.DependencyResolver;
using Swashbuckle.Application;
using System.Web.Http;
using Unity;
using Unity.Interception.ContainerIntegration;

namespace Amaris.Web.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            // Web API configuration and services
            var container = new UnityContainer()
          .AddNewExtension<Interception>();
            ComponentLoader.LoadContainer(container, ".\\bin", "Amaris.*.dll");
            config.DependencyResolver = new UnityResolver(container);
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                    name: "swagger_root",
                    routeTemplate: "",
                    defaults: null,
                    constraints: null,
                    handler: new RedirectHandler((message => message.RequestUri.ToString()), "swagger"));

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
