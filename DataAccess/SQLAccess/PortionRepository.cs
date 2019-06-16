using System.Data.SqlClient;
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

		protected override void AddInsertParams(SqlCommand sqlCommand, Portion portion)
		{
			sqlCommand.Parameters.AddWithValue("@Name", portion.Name);
		}

		protected override void AddUpdateParams(SqlCommand sqlCommand, Portion user)
		{
			sqlCommand.Parameters.AddWithValue("@Id", user.Id);
			sqlCommand.Parameters.AddWithValue("@Name", user.Name);
		}
	}
}
