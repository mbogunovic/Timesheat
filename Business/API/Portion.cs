using System.Collections.Generic;
using RestSharp;
using TimeshEAT.Business.API.Models;
using TimeshEAT.Business.Models;

namespace TimeshEAT.Business.API
{
    public partial class ApiClient
    {
        public ApiResponseModel<List<T>> GetAllPortions<T>() where T : new()
        {
            RestRequest request = new RestRequest("/api/portion");

            return ExecuteList<List<T>>(request);
        }

        public ApiResponseModel<T> GetPortionById<T>(int id) where T : new()
        {
            RestRequest request = new RestRequest("/api/portion");
            request.AddParameter("id", id);

            return Execute<T>(request);
        }

        public ApiResponseModel<T> AddPortion<T>(PortionModel model) where T : new()
        {
            RestRequest request = new RestRequest("/api/portion");
            request.Method = Method.POST;
            request.AddObject(model);

            return Execute<T>(request);
        }

        public ApiResponseModel<T> UpdatePortion<T>(PortionModel model) where T : new()
        {
            RestRequest request = new RestRequest("/api/portion");
            request.Method = Method.PUT;
            request.AddObject(model);

            return Execute<T>(request);
        }

        public void DeletePortion(PortionModel model)
        {
            RestRequest request = new RestRequest("/api/portion");
            request.Method = Method.DELETE;
            request.AddObject(model);

            Execute<PortionModel>(request);
        }
    }
}