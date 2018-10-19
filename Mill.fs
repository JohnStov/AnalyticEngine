module Analytic.Mill

open Analytic.Types

type IngressSelect =
    | Ingress1
    | Ingress2

type Mill = {
    ingress1 : Value
    ingress2 : Value
    egress : Value
    ingressSelect : IngressSelect
}

let init () = {
    ingress1 = 0
    ingress2 = 0
    egress = 0
    ingressSelect = Ingress1
}

let performOp mill =
    { mill with egress = mill.ingress1 + mill.ingress2}

let load value mill =
    match mill.ingressSelect with
    | Ingress1 -> 
        { mill with ingress1 = value; ingress2 = 0; egress = 0; ingressSelect = Ingress2 }
    | Ingress2 ->
        performOp { mill with ingress2 = value; ingressSelect = Ingress1 }
