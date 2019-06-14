using System.Data.SqlClient;
using TimeshEAT.Domain.Interfaces.Repositories;
using TimeshEAT.Domain.Models;

namespace TimeshEAT.DataAccess.SQLAccess.Providers
{
	public class CompanyProvider : BaseProvider<Company>, ICompanyRepository
	{
		protected override string _getAllProcedure { get; } = "CompanyGetAll";
		protected override string _getByIdProcedure { get; } = "CompanyGetById";
		protected override string _insertProcedure { get; } = "CompanyInsert";
		protected override string _updateProcedure { get; } = "CompanyUpdate";
		protected override string _deleteProcedure { get; } = "CompanyDelete";

		protected override void AddInsertParams(ref SqlCommand sqlCommand, Company company)
		{
			sqlCommand.Parameters.AddWithValue("@Name", company.Name);
			sqlCommand.Parameters.AddWithValue("@Email", company.Email);
			sqlCommand.Parameters.AddWithValue("@DailyDiscount", company.DailyDiscount);
		}

		protected override void AddUpdateParams(ref SqlCommand sqlCommand, Company company)
		{
			sqlCommand.Parameters.AddWithValue("@Id", company.Id);
			sqlCommand.Parameters.AddWithValue("@Name", company.Name);
			sqlCommand.Parameters.AddWithValue("@Email", company.Email);
			sqlCommand.Parameters.AddWithValue("@DailyDiscount", company.DailyDiscount);
		}
	}
}
