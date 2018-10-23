module Analytic.Engine

open Railway

open Analytic.Types
open Analytic.Store
open Analytic.Mill

type Engine = {
    store : Store
    mill : Mill
}

type EngineResult = Result<Engine, string list>

let init storeSize = {
    store = Store.init storeSize
    mill = Mill.init ()
}

let private processInstruction instruction index engine : EngineResult =
    match instruction with 
    | MillInstruction i ->
        succeed { engine with mill = engine.mill |> Mill.setInstruction i }
    | StoreInstruction i ->
        match i with 
        | Save d -> 
            let result = engine.store |> Store.save d.Index d.Value
            result |> either (fun s -> Ok {engine with store = s}) (fun e -> Error (sprintf "Error at card %d" index :: e))
        | Load index ->
            let result = engine.store |> Store.retrieve index
            result |> either (fun s -> Ok {engine with mill = engine.mill |> Mill.load s}) (fun e -> Error (sprintf "Error at card %d" index :: e))

let runProgram (instructions : Instruction list) engine : EngineResult =
    let indices = [1 .. instructions.Length]
    let boundProcessInstruction result instruction index =
        result |> bind (fun engine -> processInstruction instruction index engine) 
    
    List.fold2 boundProcessInstruction (Ok engine) instructions indices