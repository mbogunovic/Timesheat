﻿namespace TimeshEAT.Domain.Models
{
	public class Category : Entity
	{
		public Category(int id, string name, byte[] version) : base(id, version)
		{
			Name = name;
		}

		public string Name { get; set; }
	}
}