using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TimeshEAT.Common;
using TimeshEAT.DataAccessLayer.Extensions;
using TimeshEAT.RepositoryLayer.Interfaces;
using TimeshEAT.RepositoryLayer.Models;

namespace TimeshEAT.DataAccessLayer.SQLAccess.Providers
{
	//TODO: Fix params for each method, try to make more generic and make base class for connectionstring and transaction
	public class UserProvider : IUserRepository
    {
        private readonly string _connectionString = AppSettings.ConnectionString;

		//TODO: MAKE IT TO SUPPORT TRANSACTION
        #region [ReadMethods]

        public IEnumerable<User> GetAll(ITransaction transaction = null)
        {
            List<User> result = new List<User>();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("UserGetAll", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                result.Add(DBAccessExtensions.MapTableEntityTo<User>(reader));
                            }
                        }
                    }
                }
            }

            return result;
        }
        public User GetById(int id, ITransaction transaction = null)
        {
            User result = null;

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("UserGetById", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                result = DBAccessExtensions.MapTableEntityTo<User>(reader);
                            }
                        }
                    }
                }
            }

            return result;
        }

        #endregion

        #region [WriteMethods]

        public User Insert(User user, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("UserInsert", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    return InsertUserSqlCommand(sqlCommand, user);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("UserInsert", sqlConnection))
                    {
                        return InsertUserSqlCommand(sqlCommand, user);
                    }
                }
            }
        }
        public User Update(User user, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("UserUpdate", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    return UpdateUserSqlCommand(sqlCommand, user);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("UserUpdate", sqlConnection))
                    {
                        return UpdateUserSqlCommand(sqlCommand, user);
                    }
                }
            }
        }
        public void Delete(User user, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("UserDelete", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    DeleteUserSqlCommand(sqlCommand, user);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("UserDelete", sqlConnection))
                    {
                        DeleteUserSqlCommand(sqlCommand, user);
                    }
                }
            }
        }

        public ITransaction CreateNewTransaction() =>
			new AdoTransaction(_connectionString);

        #endregion

        #region [SqlCommandMethods]

        public User InsertUserSqlCommand(SqlCommand sqlCommand, User user)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@FullName", user.FullName);
            sqlCommand.Parameters.AddWithValue("@Password", user.Password);
            sqlCommand.Parameters.AddWithValue("@Email", user.Email);

            SqlParameter outputIdParam = new SqlParameter("@Id", SqlDbType.Int);
            outputIdParam.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(outputIdParam);

            SqlParameter outputVersionParam = new SqlParameter("@Version", SqlDbType.Timestamp);
            outputVersionParam.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(outputVersionParam);

            sqlCommand.ExecuteNonQuery();

            user.Id = Convert.ToInt32(outputIdParam.Value);
            //TODO: Discuss with Nemanja to add versioning user.Version = (byte[])(outputVersionParam.Value);

            return user;
        }

        public User UpdateUserSqlCommand(SqlCommand sqlCommand, User user)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@Id", user.Id);
            sqlCommand.Parameters.AddWithValue("@FullName", user.FullName);
            sqlCommand.Parameters.AddWithValue("@Password", user.Password);
            sqlCommand.Parameters.AddWithValue("@Email", user.Email);

            SqlParameter outputVersionParam = new SqlParameter("@Version", SqlDbType.Timestamp);
            outputVersionParam.Direction = ParameterDirection.InputOutput;
			//TODO: Discuss with Nemanja to add versioning  outputVersionParam.Value = user.Version;
			sqlCommand.Parameters.Add(outputVersionParam);

            /*int result = */ sqlCommand.ExecuteNonQuery();
			//TODO: Discuss with Nemanja to add versioning  user.Version = (byte[])(outputVersionParam.Value);

			//if (result == 0)
   //         {
   //             throw new DBConcurrencyException("The record has been modified by an other user. Please reload the instance before updating.");
   //         }

            return user;
        }

        public void DeleteUserSqlCommand(SqlCommand sqlCommand, User user)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@Id", user.Id);
			//TODO: Discuss with Nemanja to add versioning  sqlCommand.Parameters.AddWithValue("@Version", user.Version);

			/*int result = */
			sqlCommand.ExecuteNonQuery();

            //if (result == 0)
            //{
            //    throw new DBConcurrencyException("The record has been modified by an other user. Please reload the instance before deleting.");
            //}
        }
        #endregion
    }
}
