using System.Collections.Generic;
using System.Web.Http;
using TimeshEAT.API.Attributes;
using TimeshEAT.Business.Interfaces;
using TimeshEAT.Business.Models;

namespace TimeshEAT.API.Controllers
{
    /// <summary>
    /// Endpoints for companies, requires token authorization
    /// </summary>
    [TokenAuthorize]
    public class CompanyController : ApiController
    {
        private readonly IServiceContext _serviceContext;

        public CompanyController(IServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }

        /// <summary>
        /// Endpoint for obtaining all companies
        /// </summary>
        /// <returns>Enumerable with all companies</returns>
        public IEnumerable<CompanyModel> Get() => _serviceContext.Companies.Get();


        /// <summary>
        /// Endpoint for obtaining single company
        /// </summary>
        /// <param name="id">Id of the company to obtain</param>
        /// <returns>Company with provided Id</returns>
        public CompanyModel Get(int id) => _serviceContext.Companies.GetBy(id);

        /// <summary>
        /// Endpoint for adding company
        /// </summary>
        /// <param name="company">New company</param>
        /// <returns>Added company</returns>
        public CompanyModel Post([FromBody]CompanyModel company) => _serviceContext.Companies.Add(company);

        /// <summary>
        /// Endpoint for updating company
        /// </summary>
        /// <param name="company">Updated company</param>
        /// <returns>Updated company</returns>
        public CompanyModel Put([FromBody]CompanyModel company) => _serviceContext.Companies.Save(company);

        /// <summary>
        /// Endpoint for deleting company
        /// </summary>
        /// <param name="company">Company to delete</param>
        public void Delete([FromBody]CompanyModel company) => _serviceContext.Companies.Remove(company);
    }
}