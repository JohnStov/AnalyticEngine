module MillTests 

open NUnit.Framework
open FsUnit
open Analytic.Mill

[<Test>]
let ``Initial state of mill is as expected`` () =
    let mill = init ()
    mill.ingress1 |> should equal 0
    mill.ingress2 |> should equal 0
    mill.egress |> should equal 0
    mill.ingressSelect |> should equal Ingress1

[<Test>]
let ``First load should be stored in Ingress1`` () =
    let mill = init () |> load 3
    mill.ingress1 |> should equal 3
    mill.ingress2 |> should equal 0
    mill.egress |> should equal 0
    mill.ingressSelect |> should equal Ingress2

[<Test>]
let ``Second load should be stored in Ingress2 and should perform op`` () =
    let mill = init () |> load 3 |> load 5
    mill.ingress1 |> should equal 3
    mill.ingress2 |> should equal 5
    mill.egress |> should equal 8
    mill.ingressSelect |> should equal Ingress1
