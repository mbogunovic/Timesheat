using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace TimeshEAT.API.Attributes
{
    public class TokenAuthorize : AuthorizeAttribute
    { 
        //protected override bool AuthorizeCore(HttpContextBase httpContext)
        //{
        //    if (!base.AuthorizeCore(httpContext))
        //        return false;

        //    string token = httpContext.Request.Headers["Authorization"];
        //    if(string.IsNullOrWhiteSpace(token) || httpContext.Cache[token] == null)
        //        return false;

        //    return true;
        //}

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            string token = actionContext.Request.Headers.Authorization?.Parameter;
            if (string.IsNullOrWhiteSpace(token) || HttpContext.Current.Cache[token] == null)
                return false;

            return true;
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
        }

        //protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        //{
        //    filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Unauthorized, "Unauthorized - token not provided");
        //}
    }
}