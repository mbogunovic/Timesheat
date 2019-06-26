using System;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using TimeshEAT.API.Areas.HelpPage;
using TimeshEAT.Business.Interfaces;
using TimeshEAT.Business.Logging.Interfaces;
using TimeshEAT.Business.Logging.Wrappers;
using TimeshEAT.Business.Services;
using TimeshEAT.Common;

namespace TimeshEAT.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
	        // Create the container as usual.
	        var container = new Container();
	        container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

	        // Register your types, for instance using the scoped lifestyle:
	        container.Register<IServiceContext, ServiceContext>(Lifestyle.Scoped);

			// Registers logger
			container.Register<ILogger>(() => new SerilogWrapper(AppSettings.SerilogPath), Lifestyle.Singleton);

			// This is an extension method from the integration package.
			container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

	        container.Verify();

	        GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
			GlobalConfiguration.Configure(WebApiConfig.Register);
			AreaRegistration.RegisterAllAreas();
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

		protected void Application_Error()
		{
			ILogger log = DependencyResolver.Current.GetService<ILogger>();
			string[] path = Request.Path?.Split('/');
			Exception ex = Server.GetLastError();

			//if controller and action can't be found in path
			if (path == null || path.Count() < 3)
			{
				log.WriteErrorLog($"Unhandled exception occured while executing.", ex);
			}
			else
			{
				log.WriteErrorLog($"Unhandled exception occured while executing {path[1]} in {path[2]}.", ex);
			}

			Response.TrySkipIisCustomErrors = true;
		}
	}
}
