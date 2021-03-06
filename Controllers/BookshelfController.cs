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
            
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Add([FromForm] BookModel model)
        {   
            
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult AddBody([FromBody] BookModel model)
        {   
            
        }

        [HttpDelete]
        [Route("[action]/{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {   
            
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult Update([FromQuery] int id)
        {
            
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update([FromForm] BookModel model)
        {
            
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult ListFilter([FromQuery] int year)
        {   
            
        }
    }


    /* --------------------------------< ZADANIA >------------------------------

    0.  Opcjonalnie przed rozpocz??ciem prac mo??na skompilowa?? projekt i sprawdzi?? czy endpoint 
        '/bookshelf/test' dzia??a. Mo??na sprawdzi?? w przegl??darce.

    1.  Stworzy?? endpoint 'List' zwracaj??cy stron?? WWW wy??wietlaj??c?? wszystkie ksi????ki z tabeli 'Books'  

    2.1 Stworzy?? endpoint 'Add' typu 'HttpGet' zwracaj??cy stron?? WWW wy??wietlaj??c?? formularz do wype??nienia.
    2.2 Stworzy?? endpoint 'Add' typu 'HttpPost' obs??uguj??cy podane dane przes??ane przyciskiem na stronie WWW.
        Zapis do bazy danych:  

        // _dbContext.Books.Add(model);
        // _dbContext.SaveChanges();

        2.2.1 Opcjonalnie doda?? wy??wietlanie b????d??w poprzez przekazanie odpowiedniej informacji. 
            Nale??y pami??ta?? o sprawdzaniu poprawno??ci przes??anego formularza (w??a??ciwo????: ModelState.IsValid)
            
            // ViewData["success"] = "Succesfully added new item";
            // ViewData["error"] = "Invalid data";

    3.1 Stworzy?? endpoint 'Update' typu 'HttpGet' zwracaj??cy stron?? WWW wy??wietlaj??c?? formularz wype??niony 
        danymi o konkretnej ksi????ce. Dane s?? przekazywane poprzez link dost??pny na stronie 'List' w tabeli, w miejscu ID.
        Link ten wygl??da: "/bookshelf/update/{id}"
        Nale??y pobra?? informacje o ksi????ce o podanym ID i przekaza?? do odpowiedniego widoku.

        // var model = <ksi????ka o id ...>
        // return View(model); 

    3.2 Stworzy?? endpoint 'Update' typu 'HttpPost' wprowadzaj??c?? zmiany w ksi????ce i zapisuj??ce do BD.

    4.  Stworzy?? endpoint 'Delete' typu 'HttpDelete' usuwaj??cy ksi????k?? o podanym ID.
        Endpoint powinien mie?? budow?? '/bookshelf/delete/{id}'
        Poprawno???? dzia??ania mo??na sprawdzi?? poprzez do????czony skrypt TestClient.fsx.
        Uruchamia si?? go: 'dotnet fsi TestClient.fsx', nale??y w tym pliku jedynie odkomentowa?? wybran?? funkcj?? (tutaj: Delete).
        Je??li podczas uruchomienia poka??e si?? komunikat: 'SSL error', nale??y wpisa??: 'dotnet dev-certs https --trust'.

        // var item = _dbContext.Books.Find(id);
        // _dbContext.Remove(item);

        Nale??y sprawdzi?? czy 'item' o podanym ID istnieje, bowiem funkcja 'Find' zwr??ci typ 'BookModel?' czyli 
        dopuszczaj??cy warto???? null.

    5.  Stworzy?? endpoint 'ListFilter' typu 'HttpGet' wy??wietlaj??cy ksi????ki, kt??rych rok wydania jest p????niejszy,
        ni?? podany w parametrze z atrybutem 'FromQuery'

    6.v1 [Jak starczy czasu na zajeciach] Doda?? do endpointu 'List' parametr wskazuj??cy, 
        wed??ug jakiej kolumny ma by?? sortowana zawarto???? listy. 
        Parametr jako 'FromQuery', oraz powinien dopuszcza?? warto???? null.
       
    6.v2 [??atwiejsza wersja wzgl??dem v1] Zrobienie flagi kt??ra wskazuje czy powinno si?? sortowa?? zawarto????, 
        kolumn?? mo??na wybra?? na sztywno. 

    7.  [Jak starczy czasu na zajeciach] Stworzy?? endpoint 'AddBody' typu 'HttpPost', 
        kt??ry przyjmuje tym razem obiekt w formacie JSON w ciele rz??dania HTTP ('FromBody'). 
        Do test??w mo??na u??y?? r??wnie?? skryptu 'TestClient.fsx', wystarczy odpowiednio usun???? komentarze. 

    */
}
