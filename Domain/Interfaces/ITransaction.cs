using System.Data;

namespace TimeshEAT.Domain.Interfaces
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
