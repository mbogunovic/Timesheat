using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TimeshEAT.Business.Interfaces;
using TimeshEAT.Business.Models;

namespace TimeshEAT.API.Controllers
{
    public class CategoryController : ApiController
    {
        private readonly IServiceContext _serviceContext;

        public CategoryController(IServiceContext context)
        {
            _serviceContext = context;
        }
        // GET api/<controller>
        public IEnumerable<CategoryModel> Get() => _serviceContext.Categories.Get();

        // GET api/<controller>/5
        public CategoryModel Get(int id) => _serviceContext.Categories.GetBy(id);

        // POST api/<controller>
        public void Post([FromBody]CategoryModel category)
        {
            _serviceContext.Categories.Add(category);
        }

        // PUT api/<controller>/5
        public void Put([FromBody]CategoryModel category)
        {
            _serviceContext.Categories.Save(category);
        }

        // DELETE api/<controller>/5
        public void Delete([FromBody]CategoryModel category)
        {
            _serviceContext.Categories.Remove(category);
        }
    }
}