using System.Data.SqlClient;
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
			sqlCommand.Parameters.AddWithValue("@MealId", order.MealId);
			sqlCommand.Parameters.AddWithValue("@LunchTime", order.LunchTime);
			sqlCommand.Parameters.AddWithValue("@OrderDate", order.OrderDate);
			sqlCommand.Parameters.AddWithValue("@Quantity", order.Quantity);
			sqlCommand.Parameters.AddWithValue("@UserId", order.UserId);
			sqlCommand.Parameters.AddWithValue("@Comment", order.Comment);
		}

		protected override void AddUpdateParams(SqlCommand sqlCommand, Order order)
		{
			sqlCommand.Parameters.AddWithValue("@Id", order.Id);
			sqlCommand.Parameters.AddWithValue("@MealId", order.MealId);
			sqlCommand.Parameters.AddWithValue("@LunchTime", order.LunchTime);
			sqlCommand.Parameters.AddWithValue("@OrderDate", order.OrderDate);
			sqlCommand.Parameters.AddWithValue("@Quantity", order.Quantity);
			sqlCommand.Parameters.AddWithValue("@UserId", order.UserId);
			sqlCommand.Parameters.AddWithValue("@Comment", order.Comment);
		}
	}
}
