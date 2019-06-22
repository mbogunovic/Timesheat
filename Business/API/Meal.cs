using System.Collections.Generic;
using RestSharp;
using TimeshEAT.Business.Models;

namespace TimeshEAT.Business.API
{
    public partial class ApiClient
    {
        public IEnumerable<MealModel> GetAllMeals()
        {
            RestRequest request = new RestRequest("/api/meal");

            return ExecuteList<List<MealModel>>(request);
        }

        public MealModel GetMealById(int id)
        {
            RestRequest request = new RestRequest("/api/meal");
            request.AddParameter("id", id);

            return Execute<MealModel>(request);
        }

        public MealModel AddMeal(MealModel model)
        {
            RestRequest request = new RestRequest("/api/meal");
            request.Method = Method.POST;
            request.AddParameter("meal", model);

            return Execute<MealModel>(request);
        }

        public MealModel UpdateMeal(MealModel model)
        {
            RestRequest request = new RestRequest("/api/meal");
            request.Method = Method.PUT;
            request.AddParameter("meal", model);

            return Execute<MealModel>(request);
        }

        public void DeleteMeal(MealModel model)
        {
            RestRequest request = new RestRequest("/api/meal");
            request.Method = Method.DELETE;
            request.AddParameter("meal", model);

           Execute<MealModel>(request);
        }
    }
}
