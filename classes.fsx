type Repo(name: string, stars: int) =
    let baseUrl = "https://github.com"
    let incrementStarsBy stars n = stars + n

    new() = Repo("", 0)

    member this.Name = name
    member val Stars = stars with get, set
    static member PrintHelp() = "Class that contains repo information"

    member _.GetBaseUrl() = $"{baseUrl}"
    member this.GetRepoUrl() = $"{baseUrl}/{this.Name}"

    member this.IncrementStarsBy(n) =
        this.Stars <- incrementStarsBy this.Stars n

Repo.PrintHelp()

let fsharpRepo = Repo("dotnet/fsharp", 1000)
let blankRepo = Repo()

fsharpRepo.GetBaseUrl()
fsharpRepo.Name
fsharpRepo.GetRepoUrl()
fsharpRepo.Stars <- 3000
fsharpRepo.IncrementStarsBy 2
fsharpRepo.Stars
