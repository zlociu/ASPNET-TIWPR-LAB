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
        public IActionResult List()
        {
            return View(_dbContext.Books.ToList());
        }

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
                ViewData["status"] = "Succesfully added new item";
                return View();
            }
            else
            {
                ViewData["status"] = "Wrong form";
                return View();
            }
            
        }

        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete([FromQuery] int? id, [FromQuery] string? title)
        {   
            if(id is null)
            {
                var item = _dbContext.Books.Find(id);
                if(item != null)
                { 
                    _dbContext.Remove(item);
                    return Ok(new {status = "Success"});
                }
                else
                {
                   return BadRequest(new {status = "Error - wrong input ID"});
                }
            }
            else
            {
                if(title is null)
                {
                    return BadRequest(new {status = "Error - wrong query"});
                }   
                else
                {
                    var item = _dbContext.Books.FirstOrDefault(book => book.Title == title);
                    if(item != null)
                    { 
                        _dbContext.Remove(item);
                        return Ok(new {status = "Success"});
                    }
                    else
                    {
                        return BadRequest(new {status = "Error - no book with input title"});
                    }
                }
            }
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult ListFilter([FromQuery] object year)
        {   
            var yr = (int) year;
            if(yr < 1900 || yr > DateTime.Now.Year) return RedirectToAction("List");


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
