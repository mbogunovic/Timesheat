using System.Data.SqlClient;
using TimeshEAT.Domain.Interfaces.Repositories;
using TimeshEAT.Domain.Models;

namespace TimeshEAT.DataAccess.SQLAccess.Providers
{
	public class RoleProvider : BaseProvider<Role>, IRoleRepository
	{
		protected override string _getAllProcedure { get; } = "RoleGetAll";
		protected override string _getByIdProcedure { get; } = "RoleGetById";
		protected override string _insertProcedure { get; } = "RoleInsert";
		protected override string _updateProcedure { get; } = "RoleUpdate";
		protected override string _deleteProcedure { get; } = "RoleDelete";

		protected override void AddInsertParams(ref SqlCommand sqlCommand, Role role)
		{
			sqlCommand.Parameters.AddWithValue("@Name", role.Name);
		}

		protected override void AddUpdateParams(ref SqlCommand sqlCommand, Role user)
		{
			sqlCommand.Parameters.AddWithValue("@Id", user.Id);
			sqlCommand.Parameters.AddWithValue("@Name", user.Name);
		}
	}
}
