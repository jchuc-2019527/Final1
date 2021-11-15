using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ProyectoAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //tener formato de configuracion global y el formato es Json
            var formaters = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            formaters.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
        }
    }
}
