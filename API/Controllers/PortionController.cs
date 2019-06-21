using System.Collections.Generic;
using System.Web.Http;
using TimeshEAT.Business.Interfaces;
using TimeshEAT.Business.Models;

namespace TimeshEAT.API.Controllers
{
    public class PortionController : ApiController
    {
        private readonly IServiceContext _serviceContext;

        public PortionController(IServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }

        // GET api/<controller>
        public IEnumerable<PortionModel> Get() => _serviceContext.Portions.Get();


        // GET api/<controller>/5
        public PortionModel Get(int id) => _serviceContext.Portions.GetBy(id);

        // POST api/<controller>
        public void Post([FromBody]PortionModel portion)
        {
            _serviceContext.Portions.Add(portion);
        }

        // PUT api/<controller>/5
        public void Put([FromBody]PortionModel portion)
        {
            _serviceContext.Portions.Save(portion);
        }

        // DELETE api/<controller>/5
        public void Delete([FromBody]PortionModel portion)
        {
            _serviceContext.Portions.Remove(portion);
        }
    }
}