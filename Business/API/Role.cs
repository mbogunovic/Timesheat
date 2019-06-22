using System.Collections.Generic;
using RestSharp;
using TimeshEAT.Business.Models;

namespace TimeshEAT.Business.API
{
    public partial class ApiClient
    {
        public IEnumerable<RoleModel> GetAllRoles()
        {
            RestRequest request = new RestRequest("/api/role");

            return ExecuteList<List<RoleModel>>(request);
        }

        public RoleModel GetRoleById(int id)
        {
            RestRequest request = new RestRequest("/api/role");
            request.AddParameter("id", id);

            return Execute<RoleModel>(request);
        }

        public RoleModel AddRole(RoleModel model)
        {
            RestRequest request = new RestRequest("/api/role");
            request.Method = Method.POST;
            request.AddParameter("role", model);

            return Execute<RoleModel>(request);
        }

        public RoleModel UpdateRole(RoleModel model)
        {
            RestRequest request = new RestRequest("/api/role");
            request.Method = Method.PUT;
            request.AddParameter("role", model);

            return Execute<RoleModel>(request);
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