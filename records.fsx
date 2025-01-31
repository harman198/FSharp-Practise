type GitHubProject = { ProjectName: string; Stars: int }

let fsharp =
    { ProjectName = "dotnet/fsharp"
      Stars = 2500 }

printfn $"{fsharp.ProjectName} has {fsharp.Stars} stars"

let updatedFSharp = { fsharp with Stars = 2801 }

printfn $"{updatedFSharp.ProjectName} has {updatedFSharp.Stars} stars"


type GitHubProjectsWithMember =
    { ProjectName: string
      Stars: int }

    member this.GetUrl() =
        $"https://github.com/{this.ProjectName}"

    member _.GetCodeOwner() = "dotnet"

let fsharpProj =
    { ProjectName = "dotnet/fsharp"
      Stars = 2801 }

fsharpProj.GetUrl()
fsharpProj.GetCodeOwner()
