using System.Collections.Generic;
using System.Web.Http;
using TimeshEAT.API.Attributes;
using TimeshEAT.Business.Interfaces;
using TimeshEAT.Business.Models;

namespace TimeshEAT.API.Controllers
{
    /// <summary>
    /// Endpoints for roles, requires token authorization
    /// </summary>
    [TokenAuthorize]
    public class RoleController : ApiController
    {
        private readonly IServiceContext _serviceContext;

        public RoleController(IServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }

        /// <summary>
        /// Endpoint for obtaining all roles
        /// </summary>
        /// <returns>Enumerable with all roles</returns>
        public IEnumerable<RoleModel> Get() => _serviceContext.Roles.Get();


        /// <summary>
        /// Endpoint for obtaining single role
        /// </summary>
        /// <param name="id">Id of the role to obtain</param>
        /// <returns>Role with provided Id</returns>
        public RoleModel Get(int id) => _serviceContext.Roles.GetBy(id);

        /// <summary>
        /// Endpoint for adding role
        /// </summary>
        /// <param name="role">New role</param>
        /// <returns>Added role</returns>
        public RoleModel Post([FromBody]RoleModel role) => _serviceContext.Roles.Add(role);

        /// <summary>
        /// Endpoint for updating role
        /// </summary>
        /// <param name="role">Updated role</param>
        /// <returns>Updated role</returns>
        public void Put([FromBody]RoleModel role) => _serviceContext.Roles.Save(role);

        /// <summary>
        /// Endpoint for deleting role
        /// </summary>
        /// <param name="role">Role to delete</param>
        public void Delete([FromBody]RoleModel role) => _serviceContext.Roles.Remove(role);
    }
}