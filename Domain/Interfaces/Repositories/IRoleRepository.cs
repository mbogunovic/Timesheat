using System.Collections.Generic;
using TimeshEAT.Domain.Models;

namespace TimeshEAT.Domain.Interfaces.Repositories
{
	public interface IRoleRepository : IRepository<Role>
	{
		IEnumerable<Role> GetAllByUserId(int userId, ITransaction transaction = null);
	}
}
