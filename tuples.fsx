let point1 = (1.0, 2.0)

let gitHubStars = ("dotnet/fsharp", 200)

fst gitHubStars
snd gitHubStars

let projectName, stars = gitHubStars

printfn $"{projectName}: {stars}"

let projectName2, _ = gitHubStars
