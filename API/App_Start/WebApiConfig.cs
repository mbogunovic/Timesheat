using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using TimeshEAT.API.Handlers;

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
            
            // register global error handler because Application_Error isn't triggered
            config.Services.Replace(typeof(IExceptionHandler), new ErrorHandler());

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
