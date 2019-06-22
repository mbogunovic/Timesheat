using System;
using System.Collections;
using System.Net;
using System.Web;
using System.Web.Caching;
using System.Web.Http;
using TimeshEAT.Business.Helpers;
using TimeshEAT.Business.Interfaces;
using TimeshEAT.Business.Models;
using TimeshEAT.Common;

namespace TimeshEAT.API.Controllers
{
    public class AuthorizationController : ApiController
    {
        private readonly IServiceContext _serviceContext;

        public AuthorizationController(IServiceContext context)
        {
            _serviceContext = context;
        }

        public string Post([FromBody]AuthorizationModel model)
        {
            if (_serviceContext.Users.Login(model.Email, model.PasswordHash))
            {
                string token = StringHasher.GenerateHash(Guid.NewGuid().ToString());
                foreach (var cacheKey in HttpContext.Current.Cache)
                {
                    DictionaryEntry cacheItem = (DictionaryEntry) cacheKey;
                    if (cacheItem.Value.Equals(model.Email))
                    {
                        HttpContext.Current.Cache.Remove(cacheItem.Key.ToString());
                    }
                }
                HttpContext.Current.Cache.Insert(token, model.Email, null, Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(Constants.SessionExpireInterval));
                return token;
            }

            HttpContext.Current.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            return $"{(int)HttpStatusCode.Unauthorized} - Unauthorized";
        }
    }
}
