using System;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace TimeshEAT.API.Attributes
{
    public class TokenAuthorize : AuthorizeAttribute
    {
        private const string MasterToken = "bd612f529c053304a72e9f4e93ab028c";

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            string token = actionContext.Request.Headers.Authorization?.Parameter;
            if (string.IsNullOrWhiteSpace(token) || token.Equals(MasterToken, StringComparison.OrdinalIgnoreCase) || HttpContext.Current.Cache[token] == null)
                return false;

            return true;
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
        }
    }
}