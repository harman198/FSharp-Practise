#r "nuget:FSharp.Data"

open FSharp.Data

let getHtml (source: string) =
    async {
        let! html = HtmlDocument.AsyncLoad(source)
        return html
    }

"https://github.com/harman198"
|> getHtml
|> Async.RunSynchronously

let documents =
    ["https://github.com/harman198";
    "https://github.com/cli/cli#installation";
    "https://github.com/dotnet/fsharp"]


documents
|> List.map getHtml
|> Async.Parallel
|> Async.RunSynchronously

documents
|> List.map getHtml
|> Async.Sequential
|> Async.RunSynchronously

open System.Net.Http

let getHtmlTask (source: string) =
    async {
        use client = new HttpClient()
        let! html = client.GetStringAsync(source) |> Async.AwaitTask
        let parsedHtml = HtmlDocument.Parse html
        return parsedHtml
    }


"https://github.com/harman198"
|> getHtmlTask
|> Async.RunSynchronously
