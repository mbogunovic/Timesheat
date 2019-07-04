using System;
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
        public ApiResponseModel<List<T>> GetAllOrdersBy<T>(int userId, DateTime date) where T : new()
        {
	        RestRequest request = new RestRequest("/api/order");
	        request.AddParameter("userId", userId);
	        request.AddParameter("date", date);

	        return Execute<List<T>>(request);
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
            request.AddObject(model);

            return Execute<T>(request);
        }

        public ApiResponseModel<T> UpdateOrder<T>(OrderModel model) where T : new()
        {
            RestRequest request = new RestRequest("/api/order");
            request.Method = Method.PUT;
            request.AddObject(model);

            return Execute<T>(request);
        }

        public void DeleteOrder(OrderModel model)
        {
            RestRequest request = new RestRequest("/api/order");
            request.Method = Method.DELETE;
            request.AddObject(model);

            Execute<OrderModel>(request);
        }
    }
}