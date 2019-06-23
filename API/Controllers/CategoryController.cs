using System.Collections.Generic;
using System.Web.Http;
using TimeshEAT.API.Attributes;
using TimeshEAT.Business.Interfaces;
using TimeshEAT.Business.Models;

namespace TimeshEAT.API.Controllers
{
    /// <summary>
    /// Endpoints for categories, requires token authorization
    /// </summary>
    [TokenAuthorize]
    public class CategoryController : ApiController
    {
        private readonly IServiceContext _serviceContext;

        public CategoryController(IServiceContext context)
        {
            _serviceContext = context;
        }
        
        /// <summary>
        /// Endpoint for obtaining all categories
        /// </summary>
        /// <returns>Enumerable with all categories</returns>
        public IEnumerable<CategoryModel> Get() => _serviceContext.Categories.Get();

        /// <summary>
        /// Endpoint for obtaining single category
        /// </summary>
        /// <param name="id">Id of the category to obtain</param>
        /// <returns>Category with provided Id</returns>
        public CategoryModel Get(int id) => _serviceContext.Categories.GetBy(id);

        /// <summary>
        /// Endpoint for adding category
        /// </summary>
        /// <param name="category">New category</param>
        /// <returns>Added category</returns>
        public CategoryModel Post([FromBody]CategoryModel category) => _serviceContext.Categories.Add(category);

        /// <summary>
        /// Endpoint for updating category
        /// </summary>
        /// <param name="category">Updated category</param>
        /// <returns>Updated category</returns>
        public CategoryModel Put([FromBody]CategoryModel category) => _serviceContext.Categories.Save(category);

        /// <summary>
        /// Endpoint for deleting category
        /// </summary>
        /// <param name="category">Category to delete</param>
        public void Delete([FromBody]CategoryModel category) => _serviceContext.Categories.Remove(category);
    }
}