using System.Collections.Generic;
using System.Web.Http;
using System.Web.Routing;
using TimeshEAT.API.Attributes;
using TimeshEAT.Business.Interfaces;
using TimeshEAT.Business.Models;

namespace TimeshEAT.API.Controllers
{
    /// <summary>
    /// Endpoints for users, requires token authorization
    /// </summary>
    [TokenAuthorize]
    public class UserController : ApiController
    {
        private readonly IServiceContext _serviceContext;

        public UserController(IServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }

        /// <summary>
        /// Endpoint for obtaining all users
        /// </summary>
        /// <returns>Enumerable with all users</returns>
        public IEnumerable<UserModel> Get() => _serviceContext.Users.Get();


		/// <summary>
		/// Endpoint for obtaining single user by email
		/// </summary>
		/// <param name="email">Email of the user to obtain</param>
		/// <returns>User with provided email</returns>
		public UserModel Get(string email) => _serviceContext.Users.GetBy(email);

		/// <summary>
		/// Endpoint for obtaining single user
		/// </summary>
		/// <param name="id">Id of the user to obtain</param>
		/// <returns>User with provided Id</returns>
		public UserModel Get(int id) => _serviceContext.Users.GetBy(id);

        /// <summary>
        /// Endpoint for adding user
        /// </summary>
        /// <param name="user">New user</param>
        /// <returns>Added user</returns>
        public UserModel Post([FromBody]UserModel user) => _serviceContext.Users.Add(user);

		/// <summary>
		/// Endpoint for updating user
		/// </summary>
		/// <param name="user">Updated user</param>
		/// <returns>Updated user</returns>
		[HttpPost]
		[Route("api/user/put")]
		public UserModel Put([FromBody]UserModel user) => _serviceContext.Users.Save(user);

        /// <summary>
        /// Endpoint for deleting user
        /// </summary>
        /// <param name="user">User to delete</param>
        public void Delete([FromBody]UserModel user) => _serviceContext.Users.Remove(user);
    }
}