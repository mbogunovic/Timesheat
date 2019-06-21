using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using TimeshEAT.API.Areas.HelpPage;
using TimeshEAT.Business.Interfaces;
using TimeshEAT.Business.Services;

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

	        // This is an extension method from the integration package.
	        container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

	        container.Verify();

	        GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
			GlobalConfiguration.Configure(WebApiConfig.Register);
			AreaRegistration.RegisterAllAreas();
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
			
        }
    }
}
