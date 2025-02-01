for i=1 to 3 do
    printfn $"{i}"

let todoList = ["Learn F#"; "Create app"; "Profit!"]

for todo in todoList do
    printfn $"{todo.ToUpper()}"

[for todo in todoList do todo.ToUpper()]

open System

let mutable input = ""
while (input <> "q") do
    input <- Console.ReadLine()
    printfn $"{input}"
    