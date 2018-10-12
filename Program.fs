// Learn more about F# at http://fsharp.org

open Analytic

[<EntryPoint>]
let main argv =
    let mill = Mill.init ()
    let mill' = mill |> Mill.load 1 |> Mill.load 2
    printfn "Result is %d" mill'.egress
    0 // return an integer exit code
