open System.Text
open System.Net
open System.Net.Http
open System.Net.Http.Headers
open System
open System.IO
open System.Text.Encodings.Web
open System.Text.Json
open System.Text.Unicode

// if SSL error: dotnet dev-certs https --trust

type Book = {
    author: string
    title: string
    publisher: string
    yearofpublication: string
    ISBN: string
}

let PrintResponse (resp:HttpResponseMessage) = 
    async{
        let! response_content = resp.Content.ReadAsByteArrayAsync() |> Async.AwaitTask
        printfn "Status Code: %d" (int resp.StatusCode) 
        (*printfn "Headers: "
        for elem in resp.Content.Headers do 
            printf "  %s: " elem.Key 
            for el in elem.Value do
                printf "%s, " el
            printf "\n"
            for elem in resp.Headers do 
                printf "  %s: " elem.Key 
                for el in elem.Value do
                    printf "%s, " el
                printf "\n"*)
        printf "Content:\n %s" (Encoding.UTF8.GetString(response_content))
    }

let DeleteByID (id:int) = 
    async{
        let client = new HttpClient()
        let! response = (sprintf "http://localhost:5000/bookshelf/delete/%d" id) |> client.DeleteAsync |> Async.AwaitTask
        PrintResponse response |> Async.RunSynchronously
    }


let PostNewBook book = 
    async{
        let client = new HttpClient()
        let! response = client.PostAsync("https://localhost:5001/bookshelf/addbody", new StringContent(book, Encoding.UTF8, "application/json")) |> Async.AwaitTask
        PrintResponse response |> Async.RunSynchronously
    }

// DELETE some book
let Delete nr = 
    DeleteByID nr |> Async.RunSynchronously

// Add new book
let Post ksiazka = 
    let options = new JsonSerializerOptions()
    options.Encoder <- JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Latin1Supplement, UnicodeRanges.LatinExtendedA)
    //options.WriteIndented <- true // only if want to printf serialized msg
    let msg = Encoding.UTF8.GetString(Json.JsonSerializer.SerializeToUtf8Bytes(ksiazka, options))
    printfn "%s" msg
    PostNewBook msg |> Async.RunSynchronously


// Odkomentuj poniższe linie aby wykonać odpowiednie funkcje 

//Delete 5

let ksiazka = { author = "Autor"; title="Tytul"; publisher="Wydawca"; yearofpublication="2020"; ISBN=null}
Post ksiazka