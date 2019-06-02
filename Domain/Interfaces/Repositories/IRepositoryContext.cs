using System;

namespace TimeshEAT.Domain.Interfaces.Repositories
{
	public interface IRepositoryContext : IDisposable
	{
		IUserRepository UserRepository { get; }
	}
}
