# ASP.NET-TIwPR-Lab
Materiały na zajęcia z Technologii Internetowych w Przetwarzaniu Rozproszonym.
Zajęcia z technologii ASP.NET 5.0 MVC.

### Przygotowanie środowiska
0. Zadanie można realizować na komputerach z Windows i Linux.
1. Należy pobrać SDK .NET w wersji 5.0. Link: <https://dotnet.microsoft.com/download/dotnet/5.0>.   
2. Pobrać ten projekt lokalnie na komputer.
3. Serwer uruchamia się komendą: `dotnet run`,  
   Do samej kompilacji, można wykorzystać komendę `dotnet build`.
4. W przypadku problemów z uruchomieniem, najprostszym rozwiązaniem będzie utworzenie nowego   
projektu `dotnet new mvc -uld` i przekopiowanie plików z folderów __Controllers__, __Views__ i __Models__ z tego projektu.  
Konieczne będzie również zamiana kodu w pliku _Startup.cs_ .
Możliwe że będzie potrzeba doinstalować pakiet __Nuget__ umożliwiający korzystanie z _Entity Framework_ w wersji _In Memory_.  
`dotnet add package Microsoft.EntityFrameworkCore.InMemory`

### Zajęcia
Umieszczony w repozytorium projekt wymaga uzupełnienia kodu do poprawnego działania.  
W kodzie umieszczone są komentarze, mogące pomóc w poprawnym uzupełnieniu brakujących elementów.  

W repozytorium znajduje się również prezentacja (_.pdf_ lub _.pptx_) przedstawiona na zajęciach; może się okazać pomocna.

#### Zadania
1. Stworzenie endpointu __List__ do wyświetlania zawartości tabeli _Books_.
2. Stworzenie endpointu __Add__ do dodawania nowych książek.
3. Stworzenie endpointu __Update__ do aktualizowania danych o książkach.
4. Stworzenie endpointu __Delete__ do usuwania książek, podając _Id_ książki.
4. Stworzenie endpointu __ListFilter__ do wyświetlania książek, których rok wydania jest późniejszy niż podany w rządaniu. 
6. (Dodatkowe) Rozbudowa endpointu __List__ o mozliwość sortowania.


Szczegóły i wskazówki dot. tych zadań znajdują się w pliku __BookshelfController.cs__.


