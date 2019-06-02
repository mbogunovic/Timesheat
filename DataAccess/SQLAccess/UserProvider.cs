using System.Data.SqlClient;
using TimeshEAT.Domain.Models;
using TimeshEAT.Domain.Interfaces.Repositories;

namespace TimeshEAT.DataAccess.SQLAccess.Providers
{
	public class UserProvider : BaseProvider<User>, IUserRepository
	{
		internal override string _getAllProcedure { get; } = "UserGetAll";
		internal override string _getByIdProcedure { get; } = "UserGetById";
		internal override string _insertProcedure { get; } = "UserInsert";
		internal override string _updateProcedure { get; } = "UserUpdate";
		internal override string _deleteProcedure { get; } = "UserDelete";

		internal override void AddInsertParams(ref SqlCommand sqlCommand, User user)
		{
			sqlCommand.Parameters.AddWithValue("@FullName", user.FullName);
			sqlCommand.Parameters.AddWithValue("@Email", user.Email);
			sqlCommand.Parameters.AddWithValue("@Password", user.Password);
			sqlCommand.Parameters.AddWithValue("@IsActive", user.IsActive);
			sqlCommand.Parameters.AddWithValue("@CompanyId", user.CompanyId);
		}

		internal override void AddUpdateParams(ref SqlCommand sqlCommand, User user)
		{
			sqlCommand.Parameters.AddWithValue("@Id", user.Id);
			sqlCommand.Parameters.AddWithValue("@FullName", user.FullName);
			sqlCommand.Parameters.AddWithValue("@Email", user.Email);
			sqlCommand.Parameters.AddWithValue("@Password", user.Password);
			sqlCommand.Parameters.AddWithValue("@IsActive", user.IsActive);
			sqlCommand.Parameters.AddWithValue("@CompanyId", user.CompanyId);
		}
	}
}
