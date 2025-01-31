List.init<int> 10 (fun i -> i)
List.init<int> 10 (fun i -> i * 2)

[ 1; 2; 3; 4; 5; 6; 7; 8; 9; 10 ]
[ 1..10 ]

Array.init<int> 4 (fun i -> i)
Array2D.init<int> 3 3 (fun x y -> x + y)
Array3D.init<int> 3 3 3 (fun x y z -> x + y + z)

[| 1; 2; 3; 4; 5 |]
[| 1..10 |]

Seq.init<int> 10 (fun i -> i)
Seq.initInfinite<int> (fun i -> i)

seq {
    1
    1
    3
    4
    5
    6
    6
    8
}

seq { 1..10 }

open System


type Transaction =
    { Date: DateTime
      CustomerId: string
      Amount: double }

let transactions: list<Transaction> =
    [ { Date = new DateTime(2021, 1, 1)
        CustomerId = "1"
        Amount = 200.29 }
      { Date = new DateTime(2021, 05, 15)
        CustomerId = "2"
        Amount = 48.51 }
      { Date = new DateTime(2021, 12, 30)
        CustomerId = "3"
        Amount = 20.90 } ]

transactions.Head
transactions.Tail

transactions.[0]
transactions.[1..]

transactions |> List.where (fun transaction -> transaction.CustomerId = "1")


transactions |> List.tryFind (fun transaction -> transaction.CustomerId = "4")
transactions |> List.tryFind (fun transaction -> transaction.CustomerId = "3")


let todoList = [ "Learn F#"; "Create app"; "Profit!" ]

[ "Repeat" ] |> List.append todoList

todoList |> List.append [ "Make coffee" ]

let transactionsArray = transactions |> Array.ofList
let transactionsSeq = transactions |> Seq.ofList

transactions
|> List.map (fun transaction ->
    let taxRate = 0.03

    {| PreTax = transaction.Amount
       Tax = transaction.Amount * taxRate
       Total = transaction.Amount * (1.0 + taxRate) |})

transactions
|> List.iter (fun transaction -> printfn $"{transaction.CustomerId} paid {transaction.Amount} on {transaction.Date}")

transactions |> List.sumBy (fun transaction -> transaction.Amount)

transactions
|> List.map (fun transaction ->
    let taxRate = 0.03

    {| PreTax = transaction.Amount
       Tax = transaction.Amount * taxRate
       Total = transaction.Amount * (1.0 + taxRate) |})
|> List.sumBy (fun item -> item.Total)

transactions |> List.averageBy (fun transaction -> transaction.Amount)

transactions
|> List.filter (fun transaction -> transaction.Date > DateTime(2021, 1, 21))


transactions |> List.sortBy (fun transaction -> transaction.Amount)
