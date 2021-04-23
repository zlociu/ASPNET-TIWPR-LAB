# ASP.NET-TIwPR-Lab
Materiały na zajęcia z Technologii Internetowych w Przetwarzaniu Rozproszonym.
Zajęcia z technologii ASP.NET 5.0 MVC.
Zadanie można zrealizować na komputerach z Windows i Linux.

### Przygotowanie środowiska
1. Należy pobrać SDK .NET w wersji 5.0. Link: <https://dotnet.microsoft.com/download/dotnet/5.0>.  
   Na systemie Linux można spróbować pobrać, wykorzystując dostarczony menedżer pakietów.  
   Lista wspieranych dystrybucji linuxa: <https://docs.microsoft.com/pl-pl/dotnet/core/install/linux>. 
2. Sklonować ten projekt na komputer.
3. Serwer uruchamia się komendą: `dotnet run`;  
   do samej kompilacji, można wykorzystać komendę `dotnet build`.
4. Możliwe że będzie potrzeba doinstalować pakiet __Nuget__ umożliwiający korzystanie z _Entity Framework_ w wersji _In Memory_.  
`dotnet add package Microsoft.EntityFrameworkCore.InMemory`

### Zajęcia
Umieszczony w repozytorium projekt wymaga uzupełnienia kodu do poprawnego działania.  
W kodzie umieszczone są komentarze, mogące pomóc w poprawnym uzupełnieniu brakujących elementów.  
<!-- W repozytorium znajduje się również prezentacja (_.pdf_ lub _.pptx_) przedstawiona na zajęciach; może się okazać pomocna. -->

#### Zadania
1. Stworzenie endpointu __List__ do wyświetlania zawartości tabeli _Books_.
2. Stworzenie endpointu __Add__ do dodawania nowych książek.
3. Stworzenie endpointu __Update__ do aktualizowania danych o książkach.
4. Stworzenie endpointu __Delete__ do usuwania książek, podając _Id_ książki.
4. Stworzenie endpointu __ListFilter__ do wyświetlania książek, których rok wydania jest późniejszy niż podany w rządaniu. 
6. (Dodatkowe) Rozbudowa endpointu __List__ o mozliwość sortowania.

Szczegóły i wskazówki dot. tych zadań znajdują się w pliku __BookshelfController.cs__.


