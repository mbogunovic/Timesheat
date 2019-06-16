using System.Data.SqlClient;
using TimeshEAT.Domain.Interfaces.Repositories;
using TimeshEAT.Domain.Models;

namespace TimeshEAT.DataAccess.SQLAccess.Providers
{
	public class MealProvider : BaseProvider<Meal>, IMealRepository
	{
		protected override string _getAllView { get; } = "MealsGetAll";
		protected override string _getByIdProcedure { get; } = "MealGestById";
		protected override string _insertProcedure { get; } = "MealInsert";
		protected override string _updateProcedure { get; } = "MealUpdate";
		protected override string _deleteProcedure { get; } = "MealDelete";

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
	}
}
