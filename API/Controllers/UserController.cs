using System.Collections.Generic;
using System.Web.Http;
using TimeshEAT.Business.Interfaces;
using TimeshEAT.Business.Models;

namespace TimeshEAT.API.Controllers
{
    public class UserController : ApiController
    {
        private readonly IServiceContext _serviceContext;

        public UserController(IServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }

        // GET api/<controller>
        public IEnumerable<UserModel> Get() => _serviceContext.Users.Get();


        // GET api/<controller>/5
        public UserModel Get(int id) => _serviceContext.Users.GetBy(id);

        // POST api/<controller>
        public void Post([FromBody]UserModel user)
        {
            _serviceContext.Users.Add(user);
        }

        // PUT api/<controller>/5
        public void Put([FromBody]UserModel user)
        {
            _serviceContext.Users.Save(user);
        }

        // DELETE api/<controller>/5
        public void Delete([FromBody]UserModel user)
        {
            _serviceContext.Users.Remove(user);
        }
    }
}