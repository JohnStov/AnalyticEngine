module StoreTests 

open NUnit.Framework
open FsUnit
open Analytic.Store
open NUnit.Framework

[<Test>]
let ``Initial state of store is as expected`` () =
    let store = init 10
    store |> Array.length |> should equal 10
    store |> Array.forall (fun x -> x = 0) |> should equal true 

[<Test>]
let ``Can save value in store`` () =
    let store = init 10
    let result = store |> save 2 15
    match result with
    | Ok store' -> store'.[2] |> should equal 15
    | _ -> Assert.Fail()
    
[<Test>]
let ``Save with invalid index fails`` () =
    let store = init 10
    let result = store |> save 15 15
    match result with
    | Error s -> s |> should equal "Store index out of range"
    | _ -> Assert.Fail()
    
[<Test>]
let ``Retrieve with invalid index fails`` () =
    let store = init 10
    let result = store |> retrieve 15
    match result with
    | Error s -> s |> should equal "Store index out of range"
    | _ -> Assert.Fail()
    