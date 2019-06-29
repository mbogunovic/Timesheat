using System.Collections.Generic;
using RestSharp;
using TimeshEAT.Business.API.Models;
using TimeshEAT.Business.Models;

namespace TimeshEAT.Business.API
{
    public partial class ApiClient
    {
        public ApiResponseModel<List<T>> GetAllUsers<T>() where T : new()
        {
            RestRequest request = new RestRequest("/api/user");

            return ExecuteList<List<T>>(request);
        }

		public ApiResponseModel<T> GetUserByEmail<T>(string email) where T : new()
		{
			RestRequest request = new RestRequest("/api/user");
			request.AddParameter("email", email);

			return Execute<T>(request, true);
		}

		public ApiResponseModel<T> GetUserById<T>(int id) where T : new()
        {
            RestRequest request = new RestRequest("/api/user");
            request.AddParameter("id", id);

            return Execute<T>(request);
        }

        public ApiResponseModel<T> AddUser<T>(UserModel model) where T : new()
        {
            RestRequest request = new RestRequest("/api/user");
            request.Method = Method.POST;
            request.AddParameter("user", model);

            return Execute<T>(request);
        }

        public ApiResponseModel<T> UpdateUser<T>(UserModel model) where T : new()
        {
            RestRequest request = new RestRequest("/api/user/put");
            request.Method = Method.POST;
			request.AddJsonBody(model);

            return Execute<T>(request);
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
