using System.Data.SqlClient;
using TimeshEAT.Domain.Interfaces.Repositories;
using TimeshEAT.Domain.Models;

namespace TimeshEAT.DataAccess.SQLAccess.Providers
{
	public class CompanyProvider : BaseProvider<Company>, ICompanyRepository
	{
		protected override string _getAllView { get; } = "CompaniesGetAll";
		protected override string _getByIdProcedure { get; } = "CompaniesGetById";
		protected override string _insertProcedure { get; } = "CompanyInsert";
		protected override string _updateProcedure { get; } = "CompanyUpdate";
		protected override string _deleteProcedure { get; } = "CompanyDelete";

		protected override void AddInsertParams(SqlCommand sqlCommand, Company company)
		{
			sqlCommand.Parameters.AddWithValue("@Name", company.Name);
			sqlCommand.Parameters.AddWithValue("@Email", company.Email);
			sqlCommand.Parameters.AddWithValue("@DailyDiscount", company.DailyDiscount);
		}

		protected override void AddUpdateParams(SqlCommand sqlCommand, Company company)
		{
			sqlCommand.Parameters.AddWithValue("@Id", company.Id);
			sqlCommand.Parameters.AddWithValue("@Name", company.Name);
			sqlCommand.Parameters.AddWithValue("@Email", company.Email);
			sqlCommand.Parameters.AddWithValue("@DailyDiscount", company.DailyDiscount);
		}
	}
}
