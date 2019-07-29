﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using TimeshEAT.Domain.Models;

namespace TimeshEAT.Business.Models
{
	public class CompanyModel : Entity
	{
		private string _name;
		private string _email;

        public CompanyModel()
        {
            
        }

		public CompanyModel(string name, string email, int dailyDiscount, int id = 0, long version = 0) : base(id, version)
		{
			Id = id;
			Name = name;
			Email = email;
			DailyDiscount = dailyDiscount;
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
					throw new ArgumentNullException(nameof(Name), "Valid name is mandatory!");
				}

				_name = value;
			}
		}
		public string Email
		{
			get
			{
				Debug.Assert(_email != null);
				return _email;
			}
			set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentNullException(nameof(Email), "Valid email is mandatory!");
				}

				_email = value;
			}
		}
		
		public int DailyDiscount { get; set; }

        public IList<MealModel> Meals { get; set; }

		#region [Implicit Operators]

		public static implicit operator Company(CompanyModel companyModel)
		{
			if (companyModel == null)
			{
				throw new NullReferenceException("Company cannot be null!");
			}

			return new Company(companyModel.Id, companyModel.Name, companyModel.Email, companyModel.DailyDiscount, companyModel.Version);
		}

		public static implicit operator CompanyModel(Company dbCompany)
		{
			if (dbCompany == null)
			{
				throw new NullReferenceException("Company cannot be null!");
			}

			return new CompanyModel(dbCompany.Name, dbCompany.Email, dbCompany.DailyDiscount, dbCompany.Id, dbCompany.Version);
		}

		#endregion
	}
}
