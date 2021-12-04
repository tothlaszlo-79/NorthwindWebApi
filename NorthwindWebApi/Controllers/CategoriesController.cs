using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NorthwindWebApi.Data;
using NorthwindWebApi.DomainModel;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace NorthwindWebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly NorthwindContext _context;

        public CategoriesController(NorthwindContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Első minta lekérdezés
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        //[HttpGet]
        //public IEnumerable<Category> GetAll()
        //{
        //    return _context.Categories;
        //}



        [HttpGet(Name = "GetAllCategory")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<Category>),(int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult GetAll()
        {
            var categories = _context.Categories;

            if (categories == null)
            {
                return NotFound();
            }
            return Ok(categories);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.CategoryId == id);


            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
            //return _context.Categories.FirstOrDefault(c => c.CategoryId == id);
        }

        [HttpGet("count")]
        public int Count() => _context.Categories.Count();


        [HttpGet("{id}/products")]
        public IEnumerable<Product> GetProductByCategoryId(int id)
        {
            return _context.Products.Where(p => p.CategoryId == id).ToList();
        }
    }
}
