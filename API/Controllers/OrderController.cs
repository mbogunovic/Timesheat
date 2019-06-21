using System.Collections.Generic;
using System.Web.Http;
using TimeshEAT.Business.Interfaces;
using TimeshEAT.Business.Models;

namespace TimeshEAT.API.Controllers
{
    public class OrderController : ApiController
    {
        private readonly IServiceContext _serviceContext;

        public OrderController(IServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }

        // GET api/<controller>
        public IEnumerable<OrderModel> Get() => _serviceContext.Orders.Get();


        // GET api/<controller>/5
        public OrderModel Get(int id) => _serviceContext.Orders.GetBy(id);

        // POST api/<controller>
        public void Post([FromBody]OrderModel order)
        {
            _serviceContext.Orders.Add(order);
        }

        // PUT api/<controller>/5
        public void Put([FromBody]OrderModel order)
        {
            _serviceContext.Orders.Save(order);
        }

        // DELETE api/<controller>/5
        public void Delete([FromBody]OrderModel order)
        {
            _serviceContext.Orders.Remove(order);
        }
    }
}