using System.Collections;
using System.Collections.Generic;
using RestSharp;
using TimeshEAT.Business.API.Models;
using TimeshEAT.Business.Models;

namespace TimeshEAT.Business.API
{
    public interface IApiClient
    {
        ApiResponseModel<AuthorizationResponseModel> Authorize(AuthorizationModel model);
		void Lockout(string email);
        ApiResponseModel<T> Execute<T>(RestRequest request, bool isMasterTokenRequest) where T : new();
        ApiResponseModel<T> ExecuteList<T>(RestRequest request, bool isMasterTokenRequest) where T : IEnumerable, new();
		void UpdatePassword(int userId, string password);
		ApiResponseModel<List<T>> GetAllCompanies<T>() where T : new();
        ApiResponseModel<T> GetCompanyById<T>(int id) where T : new();
        ApiResponseModel<T> AddCompany<T>(CompanyModel model) where T : new();
        ApiResponseModel<T> UpdateCompany<T>(CompanyModel model) where T : new();
        void DeleteCompany(CompanyModel model);
        ApiResponseModel<List<T>> GetAllUsers<T>() where T : new();
		void SetToken(string token);
		ApiResponseModel<T> GetUserById<T>(int id) where T : new();
		ApiResponseModel<T> GetUserByEmail<T>(string email) where T : new();
		ApiResponseModel<T> AddUser<T>(UserModel model) where T : new();
        ApiResponseModel<T> UpdateUser<T>(UserModel model) where T : new();
        void DeleteUser(UserModel model);
        ApiResponseModel<List<T>> GetAllRoles<T>() where T : new();
        ApiResponseModel<T> GetRoleById<T>(int id) where T : new();
        ApiResponseModel<T> AddRole<T>(RoleModel model) where T : new();
        ApiResponseModel<T> UpdateRole<T>(RoleModel model) where T : new();
		void DeleteRole(RoleModel model);
        ApiResponseModel<List<T>> GetAllOrders<T>() where T : new();
        ApiResponseModel<T> GetOrderById<T>(int id) where T : new();
        ApiResponseModel<T> AddOrder<T>(OrderModel model) where T : new();
        ApiResponseModel<T> UpdateOrder<T>(OrderModel model) where T : new();
        void DeleteOrder(OrderModel model);
        ApiResponseModel<List<T>> GetAllPortions<T>() where T : new();
        ApiResponseModel<T> GetPortionById<T>(int id) where T : new();
        ApiResponseModel<T> AddPortion<T>(PortionModel model) where T : new();
        ApiResponseModel<T> UpdatePortion<T>(PortionModel model) where T : new();
		void DeletePortion(PortionModel model);
        ApiResponseModel<List<T>> GetAllMeals<T>() where T : new();
        ApiResponseModel<T> GetMealById<T>(int id) where T : new();
		ApiResponseModel<T> AddMeal<T>(MealModel model) where T : new();
        ApiResponseModel<T> UpdateMeal<T>(MealModel model) where T : new();
        void DeleteMeal(MealModel model);
        ApiResponseModel<List<T>> GetAllCategories<T>() where T : new();
        ApiResponseModel<T> GetCategoryById<T>(int id) where T : new();
        ApiResponseModel<T> AddCategory<T>(CategoryModel model) where T : new();
        ApiResponseModel<T> UpdateCategory<T>(CategoryModel model) where T : new();
        void DeleteCategory(CategoryModel model);
    }
}