using System.Collections.Generic;
using RestSharp;
using TimeshEAT.Business.API.Models;
using TimeshEAT.Business.Models;

namespace TimeshEAT.Business.API
{
    public partial class ApiClient
    {
        public ApiResponseModel<List<T>> GetAllRoles<T>() where T : new()
        {
            RestRequest request = new RestRequest("/api/role");

            return ExecuteList<List<T>>(request);
        }

        public ApiResponseModel<T> GetRoleById<T>(int id) where T : new()
        {
            RestRequest request = new RestRequest("/api/role");
            request.AddParameter("id", id);

            return Execute<T>(request);
        }

        public ApiResponseModel<T> AddRole<T>(RoleModel model) where T : new()
        {
            RestRequest request = new RestRequest("/api/role");
            request.Method = Method.POST;
            request.AddParameter("role", model);

            return Execute<T>(request);
        }

        public ApiResponseModel<T> UpdateRole<T>(RoleModel model) where T : new()
        {
            RestRequest request = new RestRequest("/api/role");
            request.Method = Method.PUT;
            request.AddParameter("role", model);

            return Execute<T>(request);
        }

        public void DeleteRole(RoleModel model)
        {
            RestRequest request = new RestRequest("/api/role");
            request.Method = Method.DELETE;
            request.AddParameter("role", model);

            Execute<RoleModel>(request);
        }
    }
}