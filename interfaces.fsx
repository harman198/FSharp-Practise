#r "nuget:FSharp.Data"

open FSharp.Data
open System.IO

type IHtmlParser =
    abstract member ParseHtml: string -> HtmlDocument

type WebParser() =
    interface IHtmlParser with
        member this.ParseHtml(url: string) : HtmlDocument = HtmlDocument.Load(url)

    member this.ParseHtml url = (this :> IHtmlParser).ParseHtml(url)

type FileParser() =
    interface IHtmlParser with
        member this.ParseHtml(filePath: string) : HtmlDocument =
            filePath
            |> File.ReadAllText
            |> fun fileContents -> HtmlDocument.Parse(fileContents)

    member this.ParseHtml url = (this :> IHtmlParser).ParseHtml(url)

let classWebParser: IHtmlParser = WebParser()
let (classFileParse: IHtmlParser) = FileParser()

let parseHtml (parser: IHtmlParser) (source: string) = parser.ParseHtml(source)

parseHtml classWebParser "https://github.com/dotnet/fsharp"

Path.Join(__SOURCE_DIRECTORY__, "sample.html") |> parseHtml classFileParse


let webParser =
    { new IHtmlParser with
        member this.ParseHtml(url: string) : HtmlDocument = HtmlDocument.Load(url) }

let fileParser =
    { new IHtmlParser with
        member this.ParseHtml(filePath: string) : HtmlDocument =
            filePath
            |> File.ReadAllText
            |> fun fileContents -> HtmlDocument.Parse(fileContents) }

parseHtml webParser "https://github.com"

Path.Join(__SOURCE_DIRECTORY__, "sample.html") |> parseHtml fileParser
