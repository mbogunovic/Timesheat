using System.Collections.Generic;
using System.Web.Http;
using TimeshEAT.API.Attributes;
using TimeshEAT.Business.Interfaces;
using TimeshEAT.Business.Models;

namespace TimeshEAT.API.Controllers
{
    /// <summary>
    /// Endpoints for meals, requires token authorization
    /// </summary>
    [TokenAuthorize]
	public class MealController : ApiController
	{
		private readonly IServiceContext _serviceContext;

		public MealController(IServiceContext serviceContext)
		{
			_serviceContext = serviceContext;
		}

        /// <summary>
        /// Endpoint for obtaining all meals
        /// </summary>
        /// <returns>Enumerable with all meals</returns>
        public IEnumerable<MealModel> Get() => _serviceContext.Meals.Get();

        /// <summary>
        /// Endpoint for obtaining single meal
        /// </summary>
        /// <param name="id">Id of the meal to obtain</param>
        /// <returns>Meal with provided Id</returns>
        public MealModel Get(int id) => _serviceContext.Meals.GetBy(id);

        /// <summary>
        /// Endpoint for adding meal
        /// </summary>
        /// <param name="meal">New meal</param>
        /// <returns>Added meal</returns>
        public MealModel Post([FromBody]MealModel meal) => _serviceContext.Meals.Add(meal);

        /// <summary>
        /// Endpoint for updating meal
        /// </summary>
        /// <param name="meal">Updated meal</param>
        /// <returns>Updated meal</returns>
        public MealModel Put([FromBody]MealModel meal) => _serviceContext.Meals.Save(meal);

        /// <summary>
        /// Endpoint for deleting meal
        /// </summary>
        /// <param name="meal">Meal to delete</param>
        public void Delete([FromBody]MealModel meal) => _serviceContext.Meals.Remove(meal);
	}
}