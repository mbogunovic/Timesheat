using System.Collections.Generic;
using System.Web.Http;
using TimeshEAT.Business.Interfaces;
using TimeshEAT.Business.Models;

namespace TimeshEAT.API.Controllers
{
    public class CompanyController : ApiController
    {
        private readonly IServiceContext _serviceContext;

        public CompanyController(IServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }

        // GET api/<controller>
        public IEnumerable<CompanyModel> Get() => _serviceContext.Companies.Get();


        // GET api/<controller>/5
        public CompanyModel Get(int id) => _serviceContext.Companies.GetBy(id);

        // POST api/<controller>
        public void Post([FromBody]CompanyModel company)
        {
            _serviceContext.Companies.Add(company);
        }

        // PUT api/<controller>/5
        public void Put([FromBody]CompanyModel company)
        {
            _serviceContext.Companies.Save(company);
        }

        // DELETE api/<controller>/5
        public void Delete([FromBody]CompanyModel company)
        {
            _serviceContext.Companies.Remove(company);
        }
    }
}