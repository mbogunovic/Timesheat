using System.Collections.Generic;
using RestSharp;
using TimeshEAT.Business.Models;

namespace TimeshEAT.Business.API
{
    public partial class ApiClient
    {
        public IEnumerable<CategoryModel> GetAllCategories()
        {
            RestRequest request = new RestRequest("/api/category");

            return ExecuteList<List<CategoryModel>>(request);
        }

        public CategoryModel GetCategoryById(int id)
        {
            RestRequest request = new RestRequest("/api/category");
            request.AddParameter("id", id);

            return Execute<CategoryModel>(request);
        }

        public CategoryModel AddCategory(CategoryModel model)
        {
            RestRequest request = new RestRequest("/api/category");
            request.Method = Method.POST;
            request.AddParameter("category", model);

            return Execute<CategoryModel>(request);
        }

        public CategoryModel UpdateCategory(CategoryModel model)
        {
            RestRequest request = new RestRequest("/api/category");
            request.Method = Method.PUT;
            request.AddParameter("category", model);

            return Execute<CategoryModel>(request);
        }

        public void DeleteCategory(CategoryModel model)
        {
            RestRequest request = new RestRequest("/api/category");
            request.Method = Method.DELETE;
            request.AddParameter("category", model);

            Execute<CategoryModel>(request);
        }
    }
}
