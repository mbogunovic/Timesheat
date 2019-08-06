using System.Web.Http;

namespace TimeshEAT.API
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
            // Web API configuration and services
            // fix self referencing issue with meals and portions
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling
                = Newtonsoft.Json.ReferenceLoopHandling.Serialize;
            config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling
                = Newtonsoft.Json.PreserveReferencesHandling.Objects;

            // Web API routes
            config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);
		}
	}
}
