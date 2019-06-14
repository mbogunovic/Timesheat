using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using TimeshEAT.Business.Interfaces;
using TimeshEAT.Business.Services;
using TimeshEAT.Web.Injection;
using TimeshEAT.Web.Logging.Interfaces;
using TimeshEAT.Web.Logging.Wrappers;

namespace TimeshEAT.Web
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			//FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			//BundleConfig.RegisterBundles(BundleTable.Bundles);

			//TODO: MAKE WEB CONFIG GETTER SETTER
			string path = ConfigurationManager.AppSettings["path"];

			Container container = new Container();

			// ------------------ Property injection ------------------ \\
			container.Options.PropertySelectionBehavior = new ImportPropertySelectionBehavior();

			// ------------------ WebRequestLifestyle setter ------------------ \\
			container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

			container.Register<ILogger>(() => new SerilogWrapper(path), Lifestyle.Singleton);

			// ------------------ Service Context ------------------ \\
			container.Register<IServiceContext, ServiceContext>(Lifestyle.Scoped);

			// ------------------ Resolver Setter ------------------ \\
			DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

			container.RegisterMvcIntegratedFilterProvider();
		}

		protected void Application_Error()
		{
			ILogger log = DependencyResolver.Current.GetService<ILogger>();
			string[] path = Request.Path?.Split('/');
			Exception ex = Server.GetLastError();

			//if controller and action can't be found in path
			if (path == null || path.Count() < 3)
			{
				log.WriteErrorLog($"Unhandled exception occured while executing for user {User.Identity.Name}!", ex);
			}
			else
			{
				log.WriteErrorLog($"Unhandled exception occured while executing {path[1]} in {path[2]} for user {User.Identity.Name}", ex);
			}

			Response.TrySkipIisCustomErrors = true;
		}
	}
}
