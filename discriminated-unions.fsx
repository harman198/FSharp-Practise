type StringGitHubProject =
    { ProjectName: string
      Stars: int
      State: string }

let fakeProject =
    { ProjectName = "Amazing Project"
      Stars = 0
      State = "ashwed" }

type ProjectState =
    | Archived
    | Active of {| Maintainer: string |}

type GitHubProject =
    { ProjectName: string
      Stars: int
      State: ProjectState }

// let anotherFakeProject =
//     { ProjectName = "Other amazing project"
//       Stars = 1000
//       State = "adfsadf" }

let corefxlab =
    { ProjectName = "corefxlab"
      Stars = 1500
      State = Archived }

let fsharp =
    { ProjectName = "dotnet/fsharp"
      Stars = 2400
      State = Active {| Maintainer = "harman" |} }
