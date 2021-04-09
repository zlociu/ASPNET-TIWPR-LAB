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

        //[HttpGet]
        //[Route("[action]")]
        /* public IActionResult List([FromQuery] string sortColumn)
        {
            ViewData["BookList"] = _dbContext.Books.OrderBy(<lambda fn>).ToList();
            return View();
        }
        */

        [HttpGet]
        [Route("[action]")]
        public IActionResult Add()
        {
            return View();
        }

        //public IActionResult Add( BookModel model)
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

        [HttpPost]
        [Route("[action]")]
        public IActionResult AddBody([FromBody] BookModel model)
        {   
            if(ModelState.IsValid)
            {
                _dbContext.Books.Add(model);
                _dbContext.SaveChanges();
                
                return Ok(new {status = "success"});
            }
            else
            {
                return BadRequest(new {status="error"});
            }
            
        }

        [HttpDelete]
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
        public IActionResult Update([FromQuery] int id)
        {
            var book = _dbContext.Books.FirstOrDefault((x) => x.BookId == id);
            return View(book);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update([FromForm] BookModel model)
        {
            _dbContext.Books.Update(model);
            _dbContext.SaveChanges();

            return RedirectToAction("List");
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

            return View("List");
        }
    }


    /* --------------------------------< ZADANIA >------------------------------

    0.  Opcjonalnie przed rozpoczęciem prac można skompilować projekt i sprawdzić czy endpoint 
        '/bookshelf/test' działa. Można sprawdzić w przeglądarce.

    1.  Stworzyć endpoint 'List' zwracający stronę WWW wyświetlającą wszystkie książki z tabeli 'Books'  

    2.1 Stworzyć endpoint 'Add' typu 'HttpGet' zwracający stronę WWW wyświetlającą formularz do wypełnienia.
    2.2 Stworzyć endpoint 'Add' typu 'HttpPost' obsługujący podane dane przesłane przyciskiem na stronie WWW.
        Zapis do bazy danych:  

        // _dbContext.Books.Add(model);
        // _dbContext.SaveChanges();

        2.2.1 Opcjonalnie dodać wyświetlanie błędów poprzez przekazanie odpowiedniej informacji. 
            Należy pamiętać o sprawdzaniu poprawności przesłanego formularza (właściwość: ModelState.IsValid)
            
            // ViewData["success"] = "Succesfully added new item";
            // ViewData["error"] = "Invalid data";

    3.1 Stworzyć endpoint 'Update' typu 'HttpGet' zwracający stronę WWW wyświetlającą formularz wypełniony 
        danymi o konkretnej książce. Dane są przekazywane poprzez link dostępny na stronie 'List' w tabeli, w miejscu ID.
        Link ten wygląda: "/bookshelf/update/{id}"
        Należy pobrać informacje o książce o podanym ID i przekazać do odpowiedniego widoku.

        // var model = <książka o id ...>
        // return View(model); 

    3.2 Stworzyć endpoint 'Update' typu 'HttpPost' wprowadzającą zmiany w książce i zapisujące do BD.

    4.  Stworzyć endpoint 'Delete' typu 'HttpDelete' usuwający książkę o podanym ID.
        Endpoint powinien mieć budowę '/bookshelf/delete/{id}'
        Poprawność działania można sprawdzić poprzez dołączony skrypt TestClient.fsx.
        Uruchamia się go: 'dotnet fsi TestClient.fsx', należy w tym pliku jedynie odkomentować wybraną funkcję (tutaj: Delete)

        // var item = _dbContext.Books.Find(id);
        // _dbContext.Remove(item);

        Należy sprawdzić czy 'item' o podanym ID istnieje, bowiem funkcja 'Find' zwróci typ 'BookModel?' czyli 
        dopuszczający wartość null.

    5.  Stworzyć endpoint 'ListFilter' typu 'HttpGet' wyświetlający książki, których rok wydania jest późniejszy,
        niż podany w parametrze z atrybutem 'FromQuery'

    6.v1 [Jak starczy czasu na zajeciach] Dodać do endpointu 'List' parametr wskazujący, 
        według jakiej kolumny ma być sortowana zawartość listy. 
        Parametr jako 'FromQuery', oraz powinien dopuszczać wartość null.
       
    6.v2 [Łatwiejsza wersja względem v1] Zrobienie flagi która wskazuje czy powinno się sortować zawartość, 
        kolumnę można wybrać na sztywno. 

    7.  [Jak starczy czasu na zajeciach] Stworzyć endpoint 'AddBody' typu 'HttpPost', 
        który przyjmuje tym razem obiekt w formacie JSON w ciele rządania HTTP ('FromBody'). 
        Do testów można użyć również skryptu 'TestClient.fsx', wystarczy odpowiednio usunąć komentarze. 

    */
}
