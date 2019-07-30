using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TimeshEAT.DataAccess.Extensions;
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

        public IEnumerable<MealPortion> GetPortionsForMeal(Meal meal, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (SqlCommand sqlCommand = new SqlCommand(_getAllMealPortionsProcedure, (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter mealIdParameter = new SqlParameter("@MealId", SqlDbType.Int);
                    mealIdParameter.Value = meal.Id;
                    sqlCommand.Parameters.Add(mealIdParameter);
                    return GetAllPortionsForMeal(sqlCommand);
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
                        return GetAllPortionsForMeal(sqlCommand);
                    }
                }
            }
        }

        public void AddPortionForMeal(MealPortion mealPortion, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (SqlCommand sqlCommand = new SqlCommand(_insertMealPortionProcedure, (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    InsertPortionForMealSqlCommand(sqlCommand, mealPortion);
                }
            }
            else
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(_insertMealPortionProcedure, sqlConnection))
                    {
                        InsertPortionForMealSqlCommand(sqlCommand, mealPortion);
                    }
                }
            }
        }

        protected void InsertPortionForMealSqlCommand(SqlCommand sqlCommand, MealPortion mealPortion)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            AddMealPortionParameters(sqlCommand, mealPortion);
            SqlParameter portionIdParam = new SqlParameter("@Price", SqlDbType.Int);
            portionIdParam.Value = mealPortion.Price;
            sqlCommand.Parameters.Add(portionIdParam);

            sqlCommand.ExecuteNonQuery();
        }

        public void DeletePortionForMeal(MealPortion mealPortion, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (SqlCommand sqlCommand = new SqlCommand(_deleteMealPortionProcedure, (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    DeletePortionForMealSqlCommand(sqlCommand, mealPortion);
                }
            }
            else
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(_deleteMealPortionProcedure, sqlConnection))
                    {
                        DeletePortionForMealSqlCommand(sqlCommand, mealPortion);
                    }
                }
            }
        }

        protected void DeletePortionForMealSqlCommand(SqlCommand sqlCommand, MealPortion mealPortion)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            AddMealPortionParameters(sqlCommand, mealPortion);

            sqlCommand.ExecuteNonQuery();
        }

        protected void AddMealPortionParameters(SqlCommand sqlCommand, MealPortion mealPortion)
        {
            SqlParameter mealIdParameter = new SqlParameter("@MealId", SqlDbType.Int);
            mealIdParameter.Value = mealPortion.MealId;
            sqlCommand.Parameters.Add(mealIdParameter);

            SqlParameter portionIdParam = new SqlParameter("@PortionId", SqlDbType.Int);
            portionIdParam.Value = mealPortion.PortionId;
            sqlCommand.Parameters.Add(portionIdParam);
        }

        protected IEnumerable<MealPortion> GetAllPortionsForMeal(SqlCommand sqlCommand, ITransaction transaction = null)
        {
            List<MealPortion> data = new List<MealPortion>();
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        data.Add(DBAccessExtensions.MapTableEntityTo<MealPortion>(reader));
                    }
                }
            }

            return data;
        }
    }
}
