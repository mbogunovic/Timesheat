using System.Collections.Generic;
using System.Web.Http;
using TimeshEAT.Business.Interfaces;
using TimeshEAT.Business.Models;

namespace TimeshEAT.API.Controllers
{
    public class RoleController : ApiController
    {
        private readonly IServiceContext _serviceContext;

        public RoleController(IServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }

        // GET api/<controller>
        public IEnumerable<RoleModel> Get() => _serviceContext.Roles.Get();


        // GET api/<controller>/5
        public RoleModel Get(int id) => _serviceContext.Roles.GetBy(id);

        // POST api/<controller>
        public void Post([FromBody]RoleModel role)
        {
            _serviceContext.Roles.Add(role);
        }

        // PUT api/<controller>/5
        public void Put([FromBody]RoleModel role)
        {
            _serviceContext.Roles.Save(role);
        }

        // DELETE api/<controller>/5
        public void Delete([FromBody]RoleModel role)
        {
            _serviceContext.Roles.Remove(role);
        }
    }
}