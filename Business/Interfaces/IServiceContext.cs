using System;

namespace TimeshEAT.Business.Interfaces
{
	public interface IServiceContext : IDisposable
	{
		IUserService Users { get; }
	}
}
