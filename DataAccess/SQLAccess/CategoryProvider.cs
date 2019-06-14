using System.Data.SqlClient;
using TimeshEAT.Domain.Interfaces.Repositories;
using TimeshEAT.Domain.Models;

namespace TimeshEAT.DataAccess.SQLAccess.Providers
{
	public class CategoryProvider : BaseProvider<Category>, ICategoryRepository
	{
		protected override string _getAllProcedure { get; } = "CategoryGetAll";
		protected override string _getByIdProcedure { get; } = "CategoryGetById";
		protected override string _insertProcedure { get; } = "CategoryInsert";
		protected override string _updateProcedure { get; } = "CategoryUpdate";
		protected override string _deleteProcedure { get; } = "CategoryDelete";

		protected override void AddInsertParams(ref SqlCommand sqlCommand, Category category)
		{
			sqlCommand.Parameters.AddWithValue("@Name", category.Name);
		}

		protected override void AddUpdateParams(ref SqlCommand sqlCommand, Category category)
		{
			sqlCommand.Parameters.AddWithValue("@Id", category.Id);
			sqlCommand.Parameters.AddWithValue("@Name", category.Name);
		}
	}
}
