using System.Collections.Generic;
using RestSharp;
using TimeshEAT.Business.API.Models;
using TimeshEAT.Business.Models;

namespace TimeshEAT.Business.API
{
    public partial class ApiClient
    {
        public ApiResponseModel<List<T>> GetAllOrders<T>() where T : new()
        {
            RestRequest request = new RestRequest("/api/order");

            return ExecuteList<List<T>>(request);
        }

        public ApiResponseModel<T> GetOrderById<T>(int id) where T : new()
        {
            RestRequest request = new RestRequest("/api/order");
            request.AddParameter("id", id);

            return Execute<T>(request);
        }

        public ApiResponseModel<T> AddOrder<T>(OrderModel model) where T : new()
        {
            RestRequest request = new RestRequest("/api/order");
            request.Method = Method.POST;
            request.AddParameter("order", model);

            return Execute<T>(request);
        }

        public ApiResponseModel<T> UpdateOrder<T>(OrderModel model) where T : new()
        {
            RestRequest request = new RestRequest("/api/order");
            request.Method = Method.PUT;
            request.AddParameter("order", model);

            return Execute<T>(request);
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