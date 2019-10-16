using TimeshEAT.Domain.Interfaces.Repositories;
using TimeshEAT.Repository.Repositories;

namespace TimeshEAT.Repository
{
	public class DbRepositoryContext : IRepositoryContext
	{
		private IUserRepository userRepository = null;
		public IUserRepository UserRepository => userRepository ?? (userRepository = new UserRepository());

		private ICategoryRepository categoryRepository = null;
		public ICategoryRepository CategoryRepository => categoryRepository ?? (categoryRepository = new CategoryRepository());

		private ICompanyRepository companyRepository = null;
		public ICompanyRepository CompanyRepository => companyRepository ?? (companyRepository = new CompanyRepository());

		private IMealRepository mealRepository = null;
		public IMealRepository MealRepository => mealRepository ?? (mealRepository = new MealRepository());

		private IOrderRepository orderRepository = null;
		public IOrderRepository OrderRepository => orderRepository ?? (orderRepository = new OrderRepository());

		private IPortionRepository portionRepository = null;
		public IPortionRepository PortionRepository => portionRepository ?? (portionRepository = new PortionRepository());
		 
		private IRoleRepository roleRepository = null;
		public IRoleRepository RoleRepository => roleRepository ?? (roleRepository = new RoleRepository());
        
        private IReportsRepository reportsRepository = null;
        public IReportsRepository ReportsRepository => reportsRepository ?? (reportsRepository = new ReportsRepository());
        public void Dispose(){}
	}

}
