using System;

namespace TimeshEAT.Business.Interfaces
{
	public interface IServiceContext : IDisposable
	{
		IUserService Users { get; }
		IRoleService Roles { get; }
		IPortionService Portions { get; }
		IOrderService Orders { get; }
		IMealService Meals { get; }
		ICompanyService Companies { get; }
		ICategoryService Categories { get; }
	}
}
