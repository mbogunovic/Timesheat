using System.Collections.Generic;
using RestSharp;
using TimeshEAT.Business.Models;

namespace TimeshEAT.Business.API
{
    public partial class ApiClient
    {
        public IEnumerable<OrderModel> GetAllOrders()
        {
            RestRequest request = new RestRequest("/api/order");

            return ExecuteList<List<OrderModel>>(request);
        }

        public OrderModel GetOrderById(int id)
        {
            RestRequest request = new RestRequest("/api/order");
            request.AddParameter("id", id);

            return Execute<OrderModel>(request);
        }

        public OrderModel AddOrder(OrderModel model)
        {
            RestRequest request = new RestRequest("/api/order");
            request.Method = Method.POST;
            request.AddParameter("order", model);

            return Execute<OrderModel>(request);
        }

        public OrderModel UpdateOrder(OrderModel model)
        {
            RestRequest request = new RestRequest("/api/order");
            request.Method = Method.PUT;
            request.AddParameter("order", model);

            return Execute<OrderModel>(request);
        }

        public void DeleteOrder(OrderModel model)
        {
            RestRequest request = new RestRequest("/api/order");
            request.Method = Method.DELETE;
            request.AddParameter("order", model);

            Execute<OrderModel>(request);
        }
    }
}