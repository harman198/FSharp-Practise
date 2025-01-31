fun () -> printfn "Hello World"

fun x -> x + 1
fun x y -> x + y

let addOne x = x + 1

addOne 3


let buildUrlNoAnnotations (protocol: string) (baseUrl: string) (path: string) : string =
    $"{protocol}://{baseUrl}/{path}"

buildUrlNoAnnotations "https" "github.com" "harman198"


#r "nuget:FSharp.Data"

open FSharp.Data
open System.IO

let getHtml (htmlFile: string) : HtmlDocument option =
    try
        let html = HtmlDocument.Load(htmlFile)
        Some(html)
    with ex ->
        printfn $"Error: {ex}"
        None

HtmlDocument.Load "doesnotexist"

getHtml "doesnotexist"

let htmlPath = Path.Join(__SOURCE_DIRECTORY__, "sample.html")

getHtml htmlPath


let getLinks (html: HtmlDocument option) =
    match html with
    | Some(x) -> x.Descendants [ "a" ]
    | None -> Seq.empty

getLinks (getHtml htmlPath)

htmlPath |> getHtml |> getLinks

let getLinksFromHtml = getHtml >> getLinks

getLinksFromHtml htmlPath

htmlPath |> getLinksFromHtml |> (fun links -> printfn $"{links}")
