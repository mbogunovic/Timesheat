using TimeshEAT.Business.Interfaces;
using TimeshEAT.Domain.Interfaces.Repositories;
using TimeshEAT.Repository;

namespace TimeshEAT.Business.Services
{
	public class ServiceContext : IServiceContext
	{
		private readonly IRepositoryContext _repositoryContext = new DbRepositoryContext();

		private IUserService userService = null;
		public IUserService Users => userService ?? (userService = new UserService(_repositoryContext));

		public void Dispose(){}
	}
}
