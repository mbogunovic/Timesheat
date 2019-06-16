using System.Data.SqlClient;
using TimeshEAT.Domain.Interfaces.Repositories;
using TimeshEAT.Domain.Models;

namespace TimeshEAT.DataAccess.SQLAccess.Providers
{
	public class RoleProvider : BaseProvider<Role>, IRoleRepository
	{
		protected override string _getAllView { get; } = "RolesGetAll";
		protected override string _getByIdProcedure { get; } = "RolesGetById";
		protected override string _insertProcedure { get; } = "RoleInsert";
		protected override string _updateProcedure { get; } = "RoleUpdate";
		protected override string _deleteProcedure { get; } = "RoleDelete";

		protected override void AddInsertParams(SqlCommand sqlCommand, Role role)
		{
			sqlCommand.Parameters.AddWithValue("@Name", role.Name);
		}

		protected override void AddUpdateParams(SqlCommand sqlCommand, Role user)
		{
			sqlCommand.Parameters.AddWithValue("@Id", user.Id);
			sqlCommand.Parameters.AddWithValue("@Name", user.Name);
		}
	}
}
