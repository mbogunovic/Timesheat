using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TimeshEAT.Domain.Interfaces;
using TimeshEAT.Domain.Interfaces.Repositories;
using TimeshEAT.Domain.Models;

namespace TimeshEAT.DataAccess.SQLAccess.Providers
{
	public class MealProvider : BaseProvider<Meal>, IMealRepository
	{
		protected override string _getAllView { get; } = "MealsGetAll";
		protected override string _getByIdProcedure { get; } = "MealsGetById";
		protected override string _insertProcedure { get; } = "MealInsert";
		protected override string _updateProcedure { get; } = "MealUpdate";
		protected override string _deleteProcedure { get; } = "MealDelete";
        protected string _getAllCompanyMealsView { get; } = "MealsCompaniesGetAll";
        protected string _insertCompanyMealProcedure { get; } = "MealCompanyInsert";
        protected string _deleteCompanyMealProcedure { get; } = "MealCompanyDelete";


        protected override void AddInsertParams(SqlCommand sqlCommand, Meal meal)
		{
			sqlCommand.Parameters.AddWithValue("@Name", meal.Name);
			sqlCommand.Parameters.AddWithValue("@Price", meal.Price);
			sqlCommand.Parameters.AddWithValue("@CategoryId", meal.CategoryId);
		}

		protected override void AddUpdateParams(SqlCommand sqlCommand, Meal meal)
		{
			sqlCommand.Parameters.AddWithValue("@Id", meal.Id);
			sqlCommand.Parameters.AddWithValue("@Name", meal.Name);
			sqlCommand.Parameters.AddWithValue("@Price", meal.Price);
			sqlCommand.Parameters.AddWithValue("@CategoryId", meal.CategoryId);
		}

        public IEnumerable<Meal> GetMealsForCompany(Company company, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (SqlCommand sqlCommand = new SqlCommand(GetAllFromView(_getAllCompanyMealsView), (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    return GetAllCommand(sqlCommand);
                }
            }
            else
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(GetAllFromView(_getAllCompanyMealsView), sqlConnection))
                    {
                        return GetAllCommand(sqlCommand);
                    }
                }
            }
        }

        public void AddMealForCompany(Meal meal, Company company, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (SqlCommand sqlCommand = new SqlCommand(_insertCompanyMealProcedure, (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    InsertMealForCompanySqlCommand(sqlCommand, meal, company);
                }
            }
            else
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(_insertCompanyMealProcedure, sqlConnection))
                    {
                        InsertMealForCompanySqlCommand(sqlCommand, meal, company);
                    }
                }
            }
        }

        private void InsertMealForCompanySqlCommand(SqlCommand sqlCommand, Meal meal, Company company)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            AddMealCompanyParameters(sqlCommand, meal, company);

            sqlCommand.ExecuteNonQuery();
        }

        private void AddMealCompanyParameters(SqlCommand sqlCommand, Meal meal, Company company)
        {
            SqlParameter mealIdParameter = new SqlParameter("@MealId", SqlDbType.Int);
            mealIdParameter.Value = meal.Id;
            sqlCommand.Parameters.Add(mealIdParameter);

            SqlParameter portionIdParam = new SqlParameter("@CompanyId", SqlDbType.Int);
            portionIdParam.Value = company.Id;
            sqlCommand.Parameters.Add(portionIdParam);
        }

        public void DeleteMealForCompany(Meal meal, Company company, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (SqlCommand sqlCommand = new SqlCommand(_deleteCompanyMealProcedure, (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    DeleteMealForCompanySqlCommand(sqlCommand, meal, company);
                }
            }
            else
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(_deleteCompanyMealProcedure, sqlConnection))
                    {
                        DeleteMealForCompanySqlCommand(sqlCommand, meal, company);
                    }
                }
            }
        }

        protected void DeleteMealForCompanySqlCommand(SqlCommand sqlCommand, Meal meal, Company company)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            AddMealCompanyParameters(sqlCommand, meal, company);

            sqlCommand.ExecuteNonQuery();
        }
    }
}
