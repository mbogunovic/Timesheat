﻿using System;
using TimeshEAT.Domain.Interfaces.Repositories;

namespace TimeshEAT.Business.Services
{
	public class BaseService
	{
		internal readonly IRepositoryContext _context;

		public BaseService(IRepositoryContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}
	}
}
