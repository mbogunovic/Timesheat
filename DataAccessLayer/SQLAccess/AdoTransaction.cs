using System.Data;
using System.Data.SqlClient;
using TimeshEAT.RepositoryLayer.Interfaces;

namespace TimeshEAT.DataAccessLayer.SQLAccess
{
	public class AdoTransaction : ITransaction
    {
        public IDbConnection Connection { get; private set; }
        public IDbTransaction Transaction { get; private set; }

        public AdoTransaction(string connectionString)
        {
            Connection = new SqlConnection(connectionString);
        }

        public void Begin()
        {
            if (Connection.State == ConnectionState.Closed)
                Connection.Open();

            Transaction = Connection.BeginTransaction();
        }

        public void Commit()
        {
            Transaction.Commit();

            if (Connection.State == ConnectionState.Open)
                Connection.Close();
        }

        public void Rollback()
        {
            Transaction.Rollback();

            if (Connection.State == ConnectionState.Open)
                Connection.Close();
        }
    }
}