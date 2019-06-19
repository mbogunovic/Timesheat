using System;
using System.Diagnostics;
using TimeshEAT.Domain.Models;

namespace TimeshEAT.Business.Models
{
	public class PortionModel : Entity
	{
		private string _name;

		public PortionModel(string name, int id = 0, long version = 0) : base(id, version)
		{
			Id = id;
			Name = name;
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

		#region [Implicit Operators]

		public static implicit operator Portion(PortionModel portionModel)
		{
			if (portionModel == null)
			{
				throw new NullReferenceException("Portion cannot be null!");
			}

			return new Portion(portionModel.Id, portionModel.Name, portionModel.Version);
		}

		public static implicit operator PortionModel(Portion dbPortion)
		{
			if (dbPortion == null)
			{
				throw new NullReferenceException("Portion cannot be null!");
			}

			return new PortionModel(dbPortion.Name, dbPortion.Id, dbPortion.Version);
		}

		#endregion
	}
}
