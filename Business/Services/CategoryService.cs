using System;
using System.Collections.Generic;
using System.Linq;
using TimeshEAT.Business.Models;
using TimeshEAT.Domain.Interfaces.Repositories;
using TimeshEAT.Business.Interfaces;

namespace TimeshEAT.Business.Services
{
	public class CategoryService : BaseService, ICategoryService
	{
		public CategoryService(IRepositoryContext context) : base(context) { }

		public IEnumerable<CategoryModel> Get() => 
			_context.CategoryRepository.GetAll()
				.Select(x => (CategoryModel)x);

		public CategoryModel GetBy(int id)
		{
			if (id <= 0) throw new ArgumentNullException(nameof(id), "Id cannot be null!");

			return _context.CategoryRepository.GetById(id);
		}

		public CategoryModel Add(CategoryModel category)
		{
			if (category == null) throw new ArgumentNullException(nameof(category), "Category cannot be null!");

			return _context.CategoryRepository.Insert(category);
		}

		public CategoryModel Save(CategoryModel category)
		{
			if (category == null) throw new ArgumentNullException(nameof(category), "Category cannot be null!");

			return _context.CategoryRepository.Update(category);
		}

		public void Remove(CategoryModel category)
		{
			if (category == null) throw new ArgumentNullException(nameof(category), "Category cannot be null!");

			_context.CategoryRepository.Delete(category);
		}
	}
}
