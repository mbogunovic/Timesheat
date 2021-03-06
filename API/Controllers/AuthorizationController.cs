﻿using System;
using System.Collections;
using System.Net;
using System.Web;
using System.Web.Caching;
using System.Web.Http;
using TimeshEAT.API.Attributes;
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

        /// <summary>
        /// Locks out a user with given email
        /// </summary>
        /// <param name="email">Email of the user to lockout</param>
		[HttpGet]
		[Route("api/authorization/lockout")]
		[TokenAuthorize]
		public void Lockout(string email) =>
			_serviceContext.Users.Lockout(email);

		/// <summary>
		/// Updates password for user
		/// </summary>
		/// <param name="password">New user password</param>
		/// <param name="userId">User id</param>
		[HttpGet]
		[Route("api/authorization/update_password")]
		[TokenAuthorize]
		public void UpdatePassword(int userId, string password) =>
			_serviceContext.Users.UpdatePassword(userId, password);
	}
}
