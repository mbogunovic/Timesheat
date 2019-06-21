using System.Collections.Generic;
using System.Web.Http;
using TimeshEAT.Business.Interfaces;
using TimeshEAT.Business.Models;

namespace TimeshEAT.API.Controllers
{
	public class MealController : ApiController
	{
		private readonly IServiceContext _serviceContext;

		public MealController(IServiceContext serviceContext)
		{
			_serviceContext = serviceContext;
		}

		// GET api/<controller>
		public IEnumerable<MealModel> Get() => _serviceContext.Meals.Get();
		

		// GET api/<controller>/5
		public MealModel Get(int id) => _serviceContext.Meals.GetBy(id);

		// POST api/<controller>
		public void Post([FromBody]MealModel mealModel)
		{
			_serviceContext.Meals.Add(mealModel);
		}

		// PUT api/<controller>/5
		public void Put([FromBody]MealModel mealModel)
		{
			_serviceContext.Meals.Save(mealModel);
		}

		// DELETE api/<controller>/5
		public void Delete(MealModel mealModel)
		{
			_serviceContext.Meals.Remove(mealModel);
		}
	}
}