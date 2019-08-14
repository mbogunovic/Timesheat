﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using TimeshEAT.Domain.Models;

namespace TimeshEAT.Business.Models
{
	public class MealModel : Entity
	{
		private string _name;
		private int _categoryId;
		
		public MealModel()
		{
			
		}

		public MealModel(string name, int categoryId, int id = 0, Int64 version = 0) : base(id, version)
		{
			Id = id;
			Name = name;
			CategoryId = categoryId;
			Version = version;
		}

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
					throw new ArgumentNullException(nameof(Name), "Valid full name is mandatory!");
				}

				_name = value;
			}
		}

		public int CategoryId
		{
			get
			{
				Debug.Assert(_categoryId > 0);

				return _categoryId;
			}
			set
			{
				if (value <= 0)
				{
					throw new ArgumentNullException(nameof(CategoryId), "Valid category id is mandatory!");
				}

				_categoryId = value;
			}
		}

        public IEnumerable<MealPortionModel> MealPortions { get; set; }
		public IEnumerable<KeyValuePair<int, int>> SelectedMealPortions { get; set; }
        public CategoryModel Category { get; set; }

        #region [Implicit Operators]

		public static implicit operator Meal(MealModel mealModel)
		{
			if (mealModel == null)
			{
				throw new NullReferenceException("Meal cannot be null!");
			}

			return new Meal(mealModel.Id, mealModel.Name, mealModel.CategoryId, mealModel.Version);
		}

		public static implicit operator MealModel(Meal dbMeal)
		{
			if (dbMeal == null)
			{
				throw new NullReferenceException("Meal cannot be null!");
			}

			return new MealModel(dbMeal.Name, dbMeal.CategoryId, dbMeal.Id, dbMeal.Version);
		}

		#endregion
	}
}
