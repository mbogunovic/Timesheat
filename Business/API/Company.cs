using System.Collections.Generic;
using RestSharp;
using TimeshEAT.Business.Models;

namespace TimeshEAT.Business.API
{
    public partial class ApiClient
    {
        public IEnumerable<CompanyModel> GetAllCompanies()
        {
            RestRequest request = new RestRequest("/api/company");

            return ExecuteList<List<CompanyModel>>(request);
        }

        public CompanyModel GetCompanyById(int id)
        {
            RestRequest request = new RestRequest("/api/company");
            request.AddParameter("id", id);

            return Execute<CompanyModel>(request);
        }

        public CompanyModel AddCompany(CompanyModel model)
        {
            RestRequest request = new RestRequest("/api/company");
            request.Method = Method.POST;
            request.AddParameter("company", model);

            return Execute<CompanyModel>(request);
        }

        public CompanyModel UpdateCompany(CompanyModel model)
        {
            RestRequest request = new RestRequest("/api/company");
            request.Method = Method.PUT;
            request.AddParameter("company", model);

            return Execute<CompanyModel>(request);
        }

        public void DeleteCompany(CompanyModel model)
        {
            RestRequest request = new RestRequest("/api/company");
            request.Method = Method.DELETE;
            request.AddParameter("company", model);

            Execute<CompanyModel>(request);
        }
    }
}
