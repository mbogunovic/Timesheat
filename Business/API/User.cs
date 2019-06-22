using System.Collections.Generic;
using RestSharp;
using TimeshEAT.Business.Models;

namespace TimeshEAT.Business.API
{
    public partial class ApiClient
    {
        public IEnumerable<UserModel> GetAllUsers()
        {
            RestRequest request = new RestRequest("/api/user");

            return ExecuteList<List<UserModel>>(request);
        }

        public UserModel GetUserById(int id)
        {
            RestRequest request = new RestRequest("/api/user");
            request.AddParameter("id", id);

            return Execute<UserModel>(request);
        }

        public UserModel AddUser(UserModel model)
        {
            RestRequest request = new RestRequest("/api/user");
            request.Method = Method.POST;
            request.AddParameter("user", model);

            return Execute<UserModel>(request);
        }

        public UserModel UpdateUser(UserModel model)
        {
            RestRequest request = new RestRequest("/api/user");
            request.Method = Method.PUT;
            request.AddParameter("user", model);

            return Execute<UserModel>(request);
        }

        public void DeleteUser(UserModel model)
        {
            RestRequest request = new RestRequest("/api/user");
            request.Method = Method.DELETE;
            request.AddParameter("user", model);

            Execute<UserModel>(request);
        }
    }
}
