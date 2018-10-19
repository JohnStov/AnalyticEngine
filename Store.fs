module Analytic.Store

type Value = int

type Index = int

type Store = Value array

let init size =
    Array.init size (fun _ -> 0)

let save index value (store : Store) =
    store.[index] <- value
    store

let retrieve index (store : Store) =
    store.[index]