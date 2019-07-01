using System.Collections.Generic;
using RestSharp;
using TimeshEAT.Business.API.Models;
using TimeshEAT.Business.Models;

namespace TimeshEAT.Business.API
{
    public partial class ApiClient
    {
        public ApiResponseModel<List<T>> GetAllMeals<T>() where T : new()
        {
            RestRequest request = new RestRequest("/api/meal");

            return ExecuteList<List<T>>(request);
        }

        public ApiResponseModel<T> GetMealById<T>(int id) where T : new()
        {
            RestRequest request = new RestRequest("/api/meal");
            request.AddParameter("id", id);

            return Execute<T>(request);
        }

        public ApiResponseModel<T> AddMeal<T>(MealModel model) where T : new()
        {
            RestRequest request = new RestRequest("/api/meal");
            request.Method = Method.POST;
            request.AddJsonBody(model);

            return Execute<T>(request);
        }

        public ApiResponseModel<T> UpdateMeal<T>(MealModel model) where T : new()
        {
            RestRequest request = new RestRequest("/api/meal");
            request.Method = Method.PUT;
			request.AddJsonBody(model);

			return Execute<T>(request);
        }

        public void DeleteMeal(MealModel model)
        {
            RestRequest request = new RestRequest("/api/meal");
            request.Method = Method.DELETE;
			request.AddJsonBody(model);

			Execute<MealModel>(request);
        }
    }
}
