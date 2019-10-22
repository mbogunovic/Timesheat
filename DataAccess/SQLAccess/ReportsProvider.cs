using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeshEAT.Common;
using TimeshEAT.DataAccess.Extensions;
using TimeshEAT.DataAccess.SQLAccess.Providers;
using TimeshEAT.Domain.Interfaces.Repositories;
using TimeshEAT.Domain.Models;

namespace TimeshEAT.DataAccess.SQLAccess
{
    public class ReportsProvider : IReportsRepository
    {
        private readonly string _connectionString = AppSettings.ConnectionString;
        public IEnumerable<Report> Get(int? userId, int? categoryId, int? companyId, int? mealId, int? portionId, DateTime? startDate, DateTime? endDate)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("ReportGetByIds", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@UserId", userId);
                    sqlCommand.Parameters.AddWithValue("@CategoryId", categoryId);
                    sqlCommand.Parameters.AddWithValue("@MealId", mealId);
                    sqlCommand.Parameters.AddWithValue("@PotionId", portionId);
                    sqlCommand.Parameters.AddWithValue("@CompanyId", companyId);
                    sqlCommand.Parameters.AddWithValue("@StartDate", startDate);
                    sqlCommand.Parameters.AddWithValue("@EndDate", endDate);

                    List<Report> data = new List<Report>();
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                data.Add(DBAccessExtensions.MapTableEntityTo<Report>(reader));
                            }
                        }
                    }

                    return data;
                }
            }
        }
    }
}
