using System.Collections.Generic;
using System.Web.Http;
using TimeshEAT.API.Attributes;
using TimeshEAT.Business.Interfaces;
using TimeshEAT.Business.Models;

namespace TimeshEAT.API.Controllers
{
    [TokenAuthorize]
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
		public MealModel Post([FromBody]MealModel meal) => _serviceContext.Meals.Add(meal);
		

		// PUT api/<controller>/5
		public MealModel Put([FromBody]MealModel meal) => _serviceContext.Meals.Save(meal);
		

		// DELETE api/<controller>/5
		public void Delete([FromBody]MealModel meal) => _serviceContext.Meals.Remove(meal);
	}
}