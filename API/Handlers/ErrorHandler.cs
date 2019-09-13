using System;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using TimeshEAT.Business.Logging.Interfaces;

namespace TimeshEAT.API.Handlers
{
    public class ErrorHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        { 
            ILogger log = GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(ILogger)) as ILogger;
            string[] path = HttpContext.Current.Request.Path?.Split('/');
            Exception ex = context.Exception;

            //if controller and action can't be found in path
            if (path == null || path.Count() < 3)
            {
                log.WriteErrorLog($"Unhandled exception occured while executing.", ex);
            }
            else
            {
                log.WriteErrorLog($"Unhandled exception occured while executing {path[1]} in {path[2]}.", ex);
            }

            HttpContext.Current.Response.TrySkipIisCustomErrors = true;
        }
    }
}