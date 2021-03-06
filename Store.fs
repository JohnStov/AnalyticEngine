module Analytic.Store

open Analytic.Types

type Store = Value array

type ValueResult = Result<Value, string list>
type StoreResult = Result<Store, string list>

let init size =
    Array.init size (fun _ -> 0)

let save index value (store : Store) =
    if index < 0 || index >= (store |> Array.length)
    then
        Error ["Store index out of range"]
    else
        store.[index] <- value
        Ok store

let retrieve index (store : Store) =
    if index < 0 || index >= (store |> Array.length)
    then
        Error ["Store index out of range"]
    else
        Ok store.[index]