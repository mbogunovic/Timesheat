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
    /// <summary>
    /// Endpoints for authorization
    /// </summary>
    public class AuthorizationController : ApiController
    {
        private readonly IServiceContext _serviceContext;

        public AuthorizationController(IServiceContext context)
        {
            _serviceContext = context;
        }

        /// <summary>
        /// Authorizes provided user for API endpoints usage
        /// </summary>
        /// <param name="model">The authorization model with user information</param>
        /// <returns>Token used for API endpoint authorization</returns>
        public AuthorizationResponseModel Post([FromBody]AuthorizationModel model)
        {
            LoginResultModel loginResult = _serviceContext.Users.Login(model.Email, model.PasswordHash);
            if (loginResult.IsAuthenticated)
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
                return new AuthorizationResponseModel
                {
                    User = loginResult.User,
                    Token = token
                };
            }

            if (!loginResult.IsActive)
				throw new HttpResponseException(HttpStatusCode.Forbidden);
            else
				throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }

		[HttpGet]
		[Route("api/authorization/lockout")]
		public void Lockout(string email) =>
			_serviceContext.Users.Lockout(email);
    }
}
