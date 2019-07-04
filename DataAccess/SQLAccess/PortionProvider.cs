using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TimeshEAT.Domain.Interfaces;
using TimeshEAT.Domain.Interfaces.Repositories;
using TimeshEAT.Domain.Models;

namespace TimeshEAT.DataAccess.SQLAccess.Providers
{
	public class PortionProvider : BaseProvider<Portion>, IPortionRepository
	{
		protected override string _getAllView { get; } = "PortionsGetAll";
		protected override string _getByIdProcedure { get; } = "PortionsGetById";
		protected override string _insertProcedure { get; } = "PortionInsert";
		protected override string _updateProcedure { get; } = "PortionUpdate";
		protected override string _deleteProcedure { get; } = "PortionDelete";
        protected string _getAllMealPortionsProcedure { get; } = "MealsPortionsGetByMealId";
        protected string _insertMealPortionProcedure { get; } = "MealPortionInsert";
        protected string _deleteMealPortionProcedure { get; } = "MealPortionDelete";


        protected override void AddInsertParams(SqlCommand sqlCommand, Portion portion)
		{
			sqlCommand.Parameters.AddWithValue("@Name", portion.Name);
		}

		protected override void AddUpdateParams(SqlCommand sqlCommand, Portion user)
		{
			sqlCommand.Parameters.AddWithValue("@Id", user.Id);
			sqlCommand.Parameters.AddWithValue("@Name", user.Name);
		}

        public IEnumerable<Portion> GetPortionsForMeal(Meal meal, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (SqlCommand sqlCommand = new SqlCommand(_getAllMealPortionsProcedure, (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter mealIdParameter = new SqlParameter("@MealId", SqlDbType.Int);
                    mealIdParameter.Value = meal.Id;
                    sqlCommand.Parameters.Add(mealIdParameter);
                    return GetAllCommand(sqlCommand);
                }
            }
            else
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(_getAllMealPortionsProcedure, sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        SqlParameter mealIdParameter = new SqlParameter("@MealId", SqlDbType.Int);
                        mealIdParameter.Value = meal.Id;
                        sqlCommand.Parameters.Add(mealIdParameter);
                        return GetAllCommand(sqlCommand);
                    }
                }
            }
        }

        public void AddPortionForMeal(Meal meal, Portion portion, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (SqlCommand sqlCommand = new SqlCommand(_insertMealPortionProcedure, (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    InsertPortionForMealSqlCommand(sqlCommand, meal, portion);
                }
            }
            else
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(_insertMealPortionProcedure, sqlConnection))
                    {
                        InsertPortionForMealSqlCommand(sqlCommand, meal, portion);
                    }
                }
            }
        }

        protected void InsertPortionForMealSqlCommand(SqlCommand sqlCommand, Meal meal, Portion portion)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            AddMealPortionParameters(sqlCommand, meal, portion);

            sqlCommand.ExecuteNonQuery();
        }

        public void DeletePortionForMeal(Meal meal, Portion portion, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (SqlCommand sqlCommand = new SqlCommand(_deleteMealPortionProcedure, (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    DeletePortionForMealSqlCommand(sqlCommand, meal, portion);
                }
            }
            else
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(_deleteMealPortionProcedure, sqlConnection))
                    {
                        DeletePortionForMealSqlCommand(sqlCommand, meal, portion);
                    }
                }
            }
        }

        protected void DeletePortionForMealSqlCommand(SqlCommand sqlCommand, Meal meal, Portion portion)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            AddMealPortionParameters(sqlCommand, meal, portion);

            sqlCommand.ExecuteNonQuery();
        }

        protected void AddMealPortionParameters(SqlCommand sqlCommand, Meal meal, Portion portion)
        {
            SqlParameter mealIdParameter = new SqlParameter("@MealId", SqlDbType.Int);
            mealIdParameter.Value = meal.Id;
            sqlCommand.Parameters.Add(mealIdParameter);

            SqlParameter portionIdParam = new SqlParameter("@PortionId", SqlDbType.Int);
            portionIdParam.Value = portion.Id;
            sqlCommand.Parameters.Add(portionIdParam);
        }
    }
}
