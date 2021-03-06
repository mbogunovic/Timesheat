﻿using System.Data.SqlClient;
using TimeshEAT.Domain.Models;
using TimeshEAT.Domain.Interfaces.Repositories;

namespace TimeshEAT.DataAccess.SQLAccess.Providers
{
	public class UserProvider : BaseProvider<User>, IUserRepository
	{
		protected override string _getAllView { get; } = "UsersGetAll";
		protected override string _getByIdProcedure { get; } = "UsersGetById";
		protected override string _insertProcedure { get; } = "UserInsert";
		protected override string _updateProcedure { get; } = "UserUpdate";
		protected override string _deleteProcedure { get; } = "UserDelete";

		protected override void AddInsertParams(SqlCommand sqlCommand, User user)
		{
			sqlCommand.Parameters.AddWithValue("@FullName", user.FullName);
			sqlCommand.Parameters.AddWithValue("@Email", user.Email);
			sqlCommand.Parameters.AddWithValue("@Password", user.Password);
			sqlCommand.Parameters.AddWithValue("@IsActive", user.IsActive);
			sqlCommand.Parameters.AddWithValue("@CompanyId", user.CompanyId);
		}

		protected override void AddUpdateParams(SqlCommand sqlCommand, User user)
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
