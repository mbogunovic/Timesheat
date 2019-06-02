using TimeshEAT.Domain.Interfaces.Repositories;
using TimeshEAT.Repository.Repositories;

namespace TimeshEAT.Repository
{
	public class DbRepositoryContext : IRepositoryContext
	{
		private IUserRepository userRepository = null;
		public IUserRepository UserRepository => userRepository ?? (userRepository = new UserRepository());

		public void Dispose(){}
	}

}
