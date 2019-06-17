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

		private IRoleService roleService = null;
		public IRoleService Roles => roleService ?? (roleService = new RoleService(_repositoryContext));

		private IPortionService portionService = null;
		public IPortionService Portions => portionService ?? (portionService = new PortionService(_repositoryContext));

		private ICategoryService categoryService = null;
		public ICategoryService Categories => categoryService ?? (categoryService = new CategoryService(_repositoryContext));

		private ICompanyService companyService = null;
		public ICompanyService Companies => companyService ?? (companyService = new CompanyService(_repositoryContext));

		private IMealService mealService = null;
		public IMealService Meals => mealService ?? (mealService = new MealService(_repositoryContext));

		private IOrderService orderService = null;
		public IOrderService Orders => orderService ?? (orderService = new OrderService(_repositoryContext));

		public void Dispose(){}
	}
}
