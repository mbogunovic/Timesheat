using System;
using System.Collections.Generic;
using System.Web.Http;
using TimeshEAT.API.Attributes;
using TimeshEAT.Business.Interfaces;
using TimeshEAT.Business.Models;

namespace TimeshEAT.API.Controllers
{
    /// <summary>
    /// Endpoints for orders, requires token authorization
    /// </summary>
    [TokenAuthorize]
    public class OrderController : ApiController
    {
        private readonly IServiceContext _serviceContext;

        public OrderController(IServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }

        /// <summary>
        /// Endpoint for obtaining all orders
        /// </summary>
        /// <returns>Enumerable with all orders</returns>
        public IEnumerable<OrderModel> Get() => _serviceContext.Orders.Get();

        /// <summary>
        /// Endpoint for obtaining orders by userId and date
        /// </summary>
        /// <param name="userId">Id of the user for which the orders will be obtained</param>
        /// <param name="date">Date for which the orders will be obtained</param>
        /// <returns>List of filtered orders</returns>
        public IEnumerable<OrderModel> Get(int userId, DateTime date) => _serviceContext.Orders.GetBy(userId, date);

        /// <summary>
        /// Endpoint for obtaining single order
        /// </summary>
        /// <param name="id">Id of the order to obtain</param>
        /// <returns>Order with provided Id</returns>
        public OrderModel Get(int id) => _serviceContext.Orders.GetBy(id);

        /// <summary>
        /// Endpoint for adding order
        /// </summary>
        /// <param name="order">New order</param>
        /// <returns>Added order</returns>
        public OrderModel Post([FromBody]OrderModel order) => _serviceContext.Orders.Add(order);

        /// <summary>
        /// Endpoint for updating order
        /// </summary>
        /// <param name="order">Updated order</param>
        /// <returns>Updated order</returns>
        public OrderModel Put([FromBody]OrderModel order) => _serviceContext.Orders.Save(order);

        /// <summary>
        /// Endpoint for deleting order
        /// </summary>
        /// <param name="order">Order to delete</param>
        public void Delete([FromBody]OrderModel order) => _serviceContext.Orders.Remove(order);
    }
}