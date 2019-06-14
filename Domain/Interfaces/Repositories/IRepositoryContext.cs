using System;

namespace TimeshEAT.Domain.Interfaces.Repositories
{
	public interface IRepositoryContext : IDisposable
	{
		IUserRepository UserRepository { get; }
		ICategoryRepository CategoryRepository { get; }
		ICompanyRepository CompanyRepository { get; }
		IMealRepository MealRepository { get; }
		IOrderRepository OrderRepository { get; }
		IPortionRepository PortionRepository { get; }
		IRoleRepository RoleRepository { get; }
	}
}
