module StoreTests 

open NUnit.Framework
open FsUnit
open Analytic.Store

[<Test>]
let ``Initial state of store is as expected`` () =
    let store = init 10
    store |> Array.length |> should equal 10
    store |> Array.forall (fun x -> x = 0) |> should equal true 

[<Test>]
let ``Can store value in store`` () =
    let store = init 10
    let store' = store |> save 2 15
    store'.[2] |> should equal 15

[<Test>]
let ``Can retreive value from store`` () =
    let store = init 10
    store.[2] <- 15 
    store |> retrieve 2 |> should equal 15

