using System.Collections.Generic;
using RestSharp;
using TimeshEAT.Business.Models;

namespace TimeshEAT.Business.API
{
    public partial class ApiClient
    {
        public IEnumerable<PortionModel> GetAllPortions()
        {
            RestRequest request = new RestRequest("/api/portion");

            return ExecuteList<List<PortionModel>>(request);
        }

        public PortionModel GetPortionById(int id)
        {
            RestRequest request = new RestRequest("/api/portion");
            request.AddParameter("id", id);

            return Execute<PortionModel>(request);
        }

        public PortionModel AddPortion(PortionModel model)
        {
            RestRequest request = new RestRequest("/api/portion");
            request.Method = Method.POST;
            request.AddParameter("portion", model);

            return Execute<PortionModel>(request);
        }

        public PortionModel UpdatePortion(PortionModel model)
        {
            RestRequest request = new RestRequest("/api/portion");
            request.Method = Method.PUT;
            request.AddParameter("portion", model);

            return Execute<PortionModel>(request);
        }

        public void DeletePortion(PortionModel model)
        {
            RestRequest request = new RestRequest("/api/portion");
            request.Method = Method.DELETE;
            request.AddParameter("portion", model);

            Execute<PortionModel>(request);
        }
    }
}