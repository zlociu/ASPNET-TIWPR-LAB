using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Zajecia_ASPNET.Data;
using Zajecia_ASPNET.Models;

namespace Zajecia_ASPNET.Controllers
{   

    [Route("[controller]")]
    //[Route("[controller]/[action]")]
    public class BookshelfController : Controller
    {
        private readonly AppDbContext _dbContext;

        public BookshelfController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Test app <para></para>
        /// Url: /bookshelf/test
        /// </summary>
        /// <returns> 418 I'm a teapot </returns>
        [HttpGet]
        [Route("[action]")]
        public IActionResult Test()
        {
            return StatusCode(418, new { test = "Hello, I'm a teapot!!" });
        }

        [HttpGet]
        [Route("")]
        [Route("[action]")]
        public IActionResult List([FromQuery] int? sort)
        {
            if(sort == 1) ViewData["BookList"] = _dbContext.Books.OrderBy((x) => x.YearOfPublication).ToList();
            else ViewData["BookList"] = _dbContext.Books.ToList();
            return View();
        }

        /*[HttpGet]
        [Route("[action]")]
        public IActionResult List([FromQuery] int year)
        {
            ViewData["BookList"] = _dbContext.Books.ToList();
            return View();
        }
        */

        [HttpGet]
        [Route("[action]")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Add([FromForm] BookModel model)
        {   
            if(ModelState.IsValid)
            {
                _dbContext.Books.Add(model);
                _dbContext.SaveChanges();
                ViewData["success"] = "Succesfully added new item";
                return View();
            }
            else
            {
                ViewData["error"] = "Invalid data";
                return View();
            }
            
        }

        [HttpGet]
        [Route("[action]/{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {   
            if(ModelState.IsValid)
            {
                var item = _dbContext.Books.Find(id);
                if(item != null)
                { 
                    _dbContext.Remove(item);
                    _dbContext.SaveChanges();
                    return Ok(new {status = "Success"});
                }
                else
                {
                   return BadRequest(new {status = "Error - wrong ID"});
                }
            }
            else
            {
                return BadRequest(new {status = "Error - wrong query"});  
            }
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult ListFilter([FromQuery] int year)
        {   
            var yr = year;
            if(yr < 1900 || yr > DateTime.Now.Year) return RedirectToAction("List");
            ViewData["BookList"] = (from book in _dbContext.Books 
                                    where book.YearOfPublication > yr
                                    select book).ToList();

            return View();
        }
    }


    /*
        Add( [FromForm] BookModel )

        Update( [FromForm] BookModel )

        Delete( [FromForm] BookModel )

        List( )

        ListFilter( [FromQuery] int year)

    */
}
