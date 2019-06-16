using System;
using System.Diagnostics;
using TimeshEAT.Domain.Models;

namespace TimeshEAT.Business.Models
{
	public class CompanyModel : Entity
	{
		private string _name;
		private string _email;
		private int dailyDiscount;

		public CompanyModel(string name, string email, int dailyDiscount, int id = 0, byte[] version = null) : base(id, version)
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
		
		public int DailyDiscount
		{
			get
			{
				Debug.Assert(dailyDiscount > 0);

				return dailyDiscount;
			}
			set
			{
				if (value > 0)
				{
					throw new ArgumentNullException(nameof(DailyDiscount), "Valid daily discount is mandatory!");
				}

				dailyDiscount = value;
			}
		}

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
