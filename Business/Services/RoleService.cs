using System;
using System.Collections.Generic;
using System.Linq;
using TimeshEAT.Business.Models;
using TimeshEAT.Domain.Interfaces.Repositories;
using TimeshEAT.Business.Interfaces;

namespace TimeshEAT.Business.Services
{
	public class RoleService : BaseService, IRoleService
	{
		public RoleService(IRepositoryContext context) : base(context) { }

		public IEnumerable<RoleModel> Get() => 
			_context.RoleRepository.GetAll()
				.Select(x => (RoleModel)x);

		public RoleModel GetBy(int id)
		{
			if (id <= 0) throw new ArgumentNullException(nameof(id), "Id cannot be null!");

			return _context.RoleRepository.GetById(id);
		}

		public RoleModel Add(RoleModel role)
		{
			if (role == null) throw new ArgumentNullException(nameof(role), "Role cannot be null!");

			return _context.RoleRepository.Insert(role);
		}

		public RoleModel Save(RoleModel role)
		{
			if (role == null) throw new ArgumentNullException(nameof(role), "Role cannot be null!");

			return _context.RoleRepository.Update(role);
		}

		public void Remove(RoleModel role)
		{
			if (role == null) throw new ArgumentNullException(nameof(role), "Role cannot be null!");

			_context.RoleRepository.Delete(role);
		}
	}
}
