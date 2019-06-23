using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TimeshEAT.Business.API;
using TimeshEAT.Business.Interfaces;
using TimeshEAT.Business.Logging.Interfaces;
using TimeshEAT.Business.Logging.Wrappers;
using TimeshEAT.Business.Services;
using TimeshEAT.Web.Injection;
using TimeshEAT.Web.Navigation;
using TimeshEAT.Web.Optimization;

namespace TimeshEAT.Web
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			//FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			//TODO: MAKE WEB CONFIG GETTER SETTER
			string path = ConfigurationManager.AppSettings["path"];

			Container container = new Container();

			// ------------------ Property injection ------------------ \\
			container.Options.PropertySelectionBehavior = new ImportPropertySelectionBehavior();

			// ------------------ WebRequestLifestyle setter ------------------ \\
			container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

			container.Register<ILogger>(() => new SerilogWrapper(path), Lifestyle.Singleton);

			// ------------------ Api ------------------ \\
			container.Register<IApiClient, ApiClient>(Lifestyle.Scoped);

			// ------------------ Navigation Context ------------------ \\
			container.Register<INavigationContext, NavigationContext>(Lifestyle.Scoped);

			// ------------------ Resolver Setter ------------------ \\
			DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

			container.RegisterMvcIntegratedFilterProvider();
		}


	}
}
