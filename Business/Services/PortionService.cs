using System;
using System.Collections.Generic;
using System.Linq;
using TimeshEAT.Business.Models;
using TimeshEAT.Domain.Interfaces.Repositories;
using TimeshEAT.Business.Interfaces;

namespace TimeshEAT.Business.Services
{
	public class PortionService : BaseService, IPortionService
	{
		public PortionService(IRepositoryContext context) : base(context) { }

		public IEnumerable<PortionModel> Get() => 
			_context.PortionRepository.GetAll()
				.Select(x => (PortionModel)x);

		public PortionModel GetBy(int id)
		{
			if (id <= 0) throw new ArgumentNullException(nameof(id), "Id cannot be null!");

			return _context.PortionRepository.GetById(id);
		}

		public PortionModel Add(PortionModel portion)
		{
			if (portion == null) throw new ArgumentNullException(nameof(portion), "Portion cannot be null!");

			return _context.PortionRepository.Insert(portion);
		}

		public PortionModel Save(PortionModel portion)
		{
			if (portion == null) throw new ArgumentNullException(nameof(portion), "Portion cannot be null!");

			return _context.PortionRepository.Update(portion);
		}

		public void Remove(PortionModel portion)
		{
			if (portion == null) throw new ArgumentNullException(nameof(portion), "Portion cannot be null!");

			_context.PortionRepository.Delete(portion);
		}
	}
}
