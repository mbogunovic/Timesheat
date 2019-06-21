using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TimeshEAT.API.Controllers
{
    public class AuthorizationController : ApiController
    {
        [AllowAnonymous]
        [HttpPost]
        public string Authorize(string email, string password)
        {
            
            return ""; //token
        }
    }
}
