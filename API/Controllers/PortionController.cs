using System.Collections.Generic;
using System.Web.Http;
using TimeshEAT.API.Attributes;
using TimeshEAT.Business.Interfaces;
using TimeshEAT.Business.Models;

namespace TimeshEAT.API.Controllers
{
    /// <summary>
    /// Endpoints for portions, requires token authorization
    /// </summary>
    [TokenAuthorize]
    public class PortionController : ApiController
    {
        private readonly IServiceContext _serviceContext;

        public PortionController(IServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }

        /// <summary>
        /// Endpoint for obtaining all portions
        /// </summary>
        /// <returns>Enumerable with all portions</returns>
        public IEnumerable<PortionModel> Get() => _serviceContext.Portions.Get();


        /// <summary>
        /// Endpoint for obtaining single portion
        /// </summary>
        /// <param name="id">Id of the portion to obtain</param>
        /// <returns>Portion with provided Id</returns>
        public PortionModel Get(int id) => _serviceContext.Portions.GetBy(id);

        /// <summary>
        /// Endpoint for adding portion
        /// </summary>
        /// <param name="portion">New portion</param>
        /// <returns>Added portion</returns>
        public PortionModel Post([FromBody]PortionModel portion) => _serviceContext.Portions.Add(portion);

        /// <summary>
        /// Endpoint for updating portion
        /// </summary>
        /// <param name="portion">Updated portion</param>
        /// <returns>Updated portion</returns>
        public PortionModel Put([FromBody]PortionModel portion) => _serviceContext.Portions.Save(portion);

        /// <summary>
        /// Endpoint for deleting portion
        /// </summary>
        /// <param name="portion">Portion to delete</param>
        public void Delete([FromBody]PortionModel portion) => _serviceContext.Portions.Remove(portion);
    }
}