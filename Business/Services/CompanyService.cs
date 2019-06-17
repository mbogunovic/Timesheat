using System;
using System.Collections.Generic;
using System.Linq;
using TimeshEAT.Business.Models;
using TimeshEAT.Domain.Interfaces.Repositories;
using TimeshEAT.Business.Interfaces;

namespace TimeshEAT.Business.Services
{
	public class CompanyService : BaseService, ICompanyService
	{
		public CompanyService(IRepositoryContext context) : base(context) { }

		public IEnumerable<CompanyModel> Get()
		{
			var result = _context.CompanyRepository.GetAll()
				.Select(x => (CompanyModel)x);

			return result;
		}

		public CompanyModel GetBy(int id)
		{
			if (id <= 0) throw new ArgumentNullException(nameof(id), "Id cannot be null!");

			var result = _context.CompanyRepository.GetById(id);

			return result;
		}

		public CompanyModel Add(CompanyModel company)
		{
			if (company == null) throw new ArgumentNullException(nameof(company), "Company cannot be null!");

			var result = _context.CompanyRepository.Insert(company);

			return result;
		}

		public CompanyModel Save(CompanyModel company)
		{
			if (company == null) throw new ArgumentNullException(nameof(company), "Company cannot be null!");

			var result = _context.CompanyRepository.Update(company);

			return result;
		}

		public void Remove(CompanyModel company)
		{
			if (company == null) throw new ArgumentNullException(nameof(company), "Company cannot be null!");

			_context.CompanyRepository.Delete(company);
		}
	}
}
