using System.Data;

namespace TimeshEAT.RepositoryLayer.Interfaces
{
	public interface ITransaction
    {
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }

        void Begin();
        void Commit();
        void Rollback();
    }
}
