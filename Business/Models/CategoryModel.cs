﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using TimeshEAT.Domain.Models;

namespace TimeshEAT.Business.Models
{
	public class CategoryModel : Entity
	{
		private string _name;

        public CategoryModel()
        {
            
        }

		public CategoryModel(string name, bool applicableDailyDiscount, int id = 0, long version = 0) : base(id, version)
		{
			Id = id;
			Name = name;
			ApplicableDailyDiscount = applicableDailyDiscount;
			Version = version;
		}

		public bool ApplicableDailyDiscount { get; set; }

		public string Name
		{
			get
			{
				Debug.Assert(_name != null);
				return _name;
			}
			set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentNullException(nameof(Name), "Valid name is mandatory!");
				}

				_name = value;
			}
		}

		public IEnumerable<MealModel> Meals { get; set; }

		#region [Implicit Operators]

		public static implicit operator Category(CategoryModel categoryModel)
		{
			if (categoryModel == null)
			{
				throw new NullReferenceException("Category cannot be null!");
			}

			return new Category(categoryModel.Id, categoryModel.Name, categoryModel.ApplicableDailyDiscount, categoryModel.Version);
		}

		public static implicit operator CategoryModel(Category dbCategory)
		{
			if (dbCategory == null)
			{
				throw new NullReferenceException("Category cannot be null!");
			}

			return new CategoryModel(dbCategory.Name, dbCategory.ApplicableDailyDiscount, dbCategory.Id, dbCategory.Version);
		}

		#endregion
	}
}
