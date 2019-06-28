using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TimeshEAT.DataAccess.Extensions;
using TimeshEAT.Domain.Interfaces;
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

		public IEnumerable<Role> GetAllByUserId(int userId, ITransaction transaction)
		{
			if (transaction != null)
			{
				using (SqlCommand sqlCommand = new SqlCommand("RolesGetByUserId", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
				{
					sqlCommand.CommandType = CommandType.StoredProcedure;
					sqlCommand.Parameters.AddWithValue("@UserId", userId);

					List<Role> data = new List<Role>();
					using (SqlDataReader reader = sqlCommand.ExecuteReader())
					{

						if (reader.HasRows == true)
						{
							while (reader.Read())
							{
								data.Add(DBAccessExtensions.MapTableEntityTo<Role>(reader));
							}
						}
					}

					return data;
				}
			}
			else
			{
				using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
				{
					sqlConnection.Open();

					using (SqlCommand sqlCommand = new SqlCommand("RolesGetByUserId", sqlConnection))
					{
						sqlCommand.CommandType = CommandType.StoredProcedure;
						sqlCommand.Parameters.AddWithValue("@UserId", userId);

						List<Role> data = new List<Role>();
						using (SqlDataReader reader = sqlCommand.ExecuteReader())
						{
							if (reader.HasRows == true)
							{
								while (reader.Read())
								{
									data.Add(DBAccessExtensions.MapTableEntityTo<Role>(reader));
								}
							}
						}

						return data;
					}
				}
			}
		}

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
