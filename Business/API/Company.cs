using System.Collections.Generic;
using RestSharp;
using TimeshEAT.Business.API.Models;
using TimeshEAT.Business.Models;

namespace TimeshEAT.Business.API
{
    public partial class ApiClient
    {
        public ApiResponseModel<List<T>> GetAllCompanies<T>() where T : new()
        {
            RestRequest request = new RestRequest("/api/company");

            return ExecuteList<List<T>>(request);
        }

        public ApiResponseModel<T> GetCompanyById<T>(int id) where T : new()
        {
            RestRequest request = new RestRequest("/api/company");
            request.AddParameter("id", id);

            return Execute<T>(request);
        }

        public ApiResponseModel<T> AddCompany<T>(CompanyModel model) where T : new()
        {
            RestRequest request = new RestRequest("/api/company");
            request.Method = Method.POST;
            request.AddObject(model);

            return Execute<T>(request);
        }

        public ApiResponseModel<T> UpdateCompany<T>(CompanyModel model) where T : new()
        {
            RestRequest request = new RestRequest("/api/company");
            request.Method = Method.PUT;
            request.AddObject(model);

            return Execute<T>(request);
        }

        public void DeleteCompany(CompanyModel model)
        {
            RestRequest request = new RestRequest("/api/company");
            request.Method = Method.DELETE;
            request.AddObject(model);

            Execute<CategoryModel>(request);
        }
    }
}
