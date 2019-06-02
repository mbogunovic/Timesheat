using TimeshEAT.Common;
using TimeshEAT.RepositoryLayer.Interfaces;
using TimeshEAT.RepositoryLayer.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using TimeshEAT.DataAccessLayer.Extensions;

namespace TimeshEAT.DataAccessLayer.SQLAccess.Providers
{
	public abstract class BaseProvider<T> where T : Entity
	{
		internal abstract string _getAllProcedure { get; }
		internal abstract string _getByIdProcedure { get; }
		internal abstract string _insertProcedure { get; }
		internal abstract string _updateProcedure { get; }
		internal abstract string _deleteProcedure { get; }

		internal readonly string _connectionString = AppSettings.ConnectionString;
		public ITransaction CreateNewTransaction() =>
			new AdoTransaction(_connectionString);

		#region [Get]

		public IEnumerable<T> GetAll(ITransaction transaction = null)
		{
			if (transaction != null)
			{
				using (SqlCommand sqlCommand = new SqlCommand(_getByIdProcedure, (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
				{
					return GetAllCommand(sqlCommand);
				}
			}
			else
			{
				using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
				{
					sqlConnection.Open();

					using (SqlCommand sqlCommand = new SqlCommand(_getAllProcedure, sqlConnection))
					{
						return GetAllCommand(sqlCommand);
					}
				}
			}
		}

		private IEnumerable<T> GetAllCommand(SqlCommand sqlCommand)
		{
			sqlCommand.CommandType = CommandType.StoredProcedure;

			using (SqlDataReader reader = sqlCommand.ExecuteReader())
			{
				if (reader.HasRows == true)
				{
					while (reader.Read())
					{
						yield return DBAccessExtensions.MapTableEntityTo<T>(reader);
					}
				}
			}
		}

		public T GetById(int id, ITransaction transaction = null)
		{
			if (transaction != null)
			{
				using (SqlCommand sqlCommand = new SqlCommand(_getByIdProcedure, (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
				{
					return GetByIdCommand(sqlCommand, id);
				}
			}
			else
			{
				using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
				{
					sqlConnection.Open();

					using (SqlCommand sqlCommand = new SqlCommand(_getByIdProcedure, sqlConnection))
					{
						return GetByIdCommand(sqlCommand, id);
					}
				}
			}
		}

		private T GetByIdCommand(SqlCommand sqlCommand, int id)
		{
			sqlCommand.CommandType = CommandType.StoredProcedure;

			sqlCommand.Parameters.AddWithValue("@Id", id);

			using (SqlDataReader reader = sqlCommand.ExecuteReader())
			{
				if (reader.HasRows == true)
				{
					while (reader.Read())
					{
						return DBAccessExtensions.MapTableEntityTo<T>(reader);
					}
				}

				return default(T);
			}
		}

		#endregion

		#region [Insert]

		public T Insert(T model, ITransaction transaction = null)
		{
			if (transaction != null)
			{
				using (SqlCommand sqlCommand = new SqlCommand(_insertProcedure, (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
				{
					return InsertSqlCommand(sqlCommand, model);
				}
			}
			else
			{
				using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
				{
					sqlConnection.Open();

					using (SqlCommand sqlCommand = new SqlCommand(_insertProcedure, sqlConnection))
					{
						return InsertSqlCommand(sqlCommand, model);
					}
				}
			}
		}

		private T InsertSqlCommand(SqlCommand sqlCommand, T model)
		{
			sqlCommand.CommandType = CommandType.StoredProcedure;

			AddInsertParams(ref sqlCommand, model);

			SqlParameter outputIdParam = new SqlParameter("@Id", SqlDbType.Int);
			outputIdParam.Direction = ParameterDirection.Output;
			sqlCommand.Parameters.Add(outputIdParam);

			SqlParameter outputVersionParam = new SqlParameter("@Version", SqlDbType.Timestamp);
			outputVersionParam.Direction = ParameterDirection.Output;
			sqlCommand.Parameters.Add(outputVersionParam);

			sqlCommand.ExecuteNonQuery();

			model.Id = Convert.ToInt32(outputIdParam.Value);
			model.Version = (byte[])(outputVersionParam.Value);

			return model;
		}

		internal abstract void AddInsertParams(ref SqlCommand sqlCommand, T model);

		#endregion

		#region [Update]

		public T Update(T model, ITransaction transaction = null)
		{
			if (transaction != null)
			{
				using (SqlCommand sqlCommand = new SqlCommand(_updateProcedure, (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
				{
					return UpdateSqlCommand(sqlCommand, model);
				}
			}
			else
			{
				using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
				{
					sqlConnection.Open();

					using (SqlCommand sqlCommand = new SqlCommand(_updateProcedure, sqlConnection))
					{
						return UpdateSqlCommand(sqlCommand, model);
					}
				}
			}
		}

		public T UpdateSqlCommand(SqlCommand sqlCommand, T model)
		{
			sqlCommand.CommandType = CommandType.StoredProcedure;

			AddUpdateParams(ref sqlCommand, model);

			SqlParameter outputVersionParam = new SqlParameter("@Version", SqlDbType.Timestamp);
			outputVersionParam.Direction = ParameterDirection.InputOutput;
			outputVersionParam.Value = model.Version;
			sqlCommand.Parameters.Add(outputVersionParam);

			int result = sqlCommand.ExecuteNonQuery();
			model.Version = (byte[])(outputVersionParam.Value);

			if (result == 0)
			{
				throw new DBConcurrencyException("The record has been modified by an other user. Please reload the instance before updating.");
			}

			return model;
		}

		internal abstract void AddUpdateParams(ref SqlCommand sqlCommand, T model);

		#endregion

		#region [Delete]

		public void Delete(T model, ITransaction transaction = null)
		{
			if (transaction != null)
			{
				using (SqlCommand sqlCommand = new SqlCommand(_deleteProcedure, (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
				{
					DeleteSqlCommand(sqlCommand, model);
				}
			}
			else
			{
				using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
				{
					sqlConnection.Open();

					using (SqlCommand sqlCommand = new SqlCommand(_deleteProcedure, sqlConnection))
					{
						DeleteSqlCommand(sqlCommand, model);
					}
				}
			}
		}

		public void DeleteSqlCommand(SqlCommand sqlCommand, T model)
		{
			sqlCommand.CommandType = CommandType.StoredProcedure;

			sqlCommand.Parameters.AddWithValue("@Id", model.Id);
			sqlCommand.Parameters.AddWithValue("@Version", model.Version);

			int result = sqlCommand.ExecuteNonQuery();

			if (result == 0)
			{
				throw new DBConcurrencyException("The record has been modified by an other user. Please reload the instance before deleting.");
			}
		}

		#endregion
	}
}
