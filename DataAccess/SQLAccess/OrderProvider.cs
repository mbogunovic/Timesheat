using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TimeshEAT.Domain.Interfaces;
using TimeshEAT.Domain.Models;
using TimeshEAT.Domain.Interfaces.Repositories;

namespace TimeshEAT.DataAccess.SQLAccess.Providers
{
	public class OrderProvider : BaseProvider<Order>, IOrderRepository
	{
		protected override string _getAllView { get; } = "OrdersGetAll";
		protected override string _getByIdProcedure { get; } = "OrdersGetById";
		protected override string _insertProcedure { get; } = "OrderInsert";
		protected override string _updateProcedure { get; } = "OrderUpdate";
		protected override string _deleteProcedure { get; } = "OrderDelete";

		protected override void AddInsertParams(SqlCommand sqlCommand, Order order)
		{
			sqlCommand.Parameters.AddWithValue("@LunchTime", order.LunchTime);
			sqlCommand.Parameters.AddWithValue("@OrderDate", order.OrderDate);
			sqlCommand.Parameters.AddWithValue("@Quantity", order.Quantity);
			sqlCommand.Parameters.AddWithValue("@MealId", order.MealId);
			sqlCommand.Parameters.AddWithValue("@PortionId", order.PortionId);
			sqlCommand.Parameters.AddWithValue("@UserId", order.UserId);
			sqlCommand.Parameters.AddWithValue("@Comment", order.Comment);
		}

		protected override void AddUpdateParams(SqlCommand sqlCommand, Order order)
		{
			sqlCommand.Parameters.AddWithValue("@Id", order.Id);
			sqlCommand.Parameters.AddWithValue("@LunchTime", order.LunchTime);
			sqlCommand.Parameters.AddWithValue("@OrderDate", order.OrderDate);
			sqlCommand.Parameters.AddWithValue("@Quantity", order.Quantity);
			sqlCommand.Parameters.AddWithValue("@MealId", order.MealId);
			sqlCommand.Parameters.AddWithValue("@PortionId", order.PortionId);
			sqlCommand.Parameters.AddWithValue("@UserId", order.UserId);
			sqlCommand.Parameters.AddWithValue("@Comment", order.Comment);
		}

		public IEnumerable<Order> GetByUserIdAndDate(int userId, DateTime date, ITransaction transaction = null)
		{
			if (transaction != null)
			{
				using (SqlCommand sqlCommand = new SqlCommand("OrdersGetByUserIdAndDate", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
				{
					sqlCommand.CommandType = CommandType.StoredProcedure;
					sqlCommand.Parameters.AddWithValue("@UserId", userId);
					sqlCommand.Parameters.AddWithValue("@Date", date);

					return GetAllCommand(sqlCommand);
				}
			}
			else
			{
				using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
				{
					sqlConnection.Open();

					using (SqlCommand sqlCommand = new SqlCommand("OrdersGetByUserIdAndDate", sqlConnection))
					{
						sqlCommand.CommandType = CommandType.StoredProcedure;
						sqlCommand.Parameters.AddWithValue("@UserId", userId);
						sqlCommand.Parameters.AddWithValue("@Date", date);

						return GetAllCommand(sqlCommand);
					}
				}
			}
		}
	}
}
