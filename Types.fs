module Analytic.Types

type Value = int

type Index = int

type SaveData = {
    Value : Value
    Index : Index
}

type StoreInstruction =
    | Save of SaveData
    | Load of Index

type MillInstruction =
    | Add
    | Subtract

type Instruction =
    | StoreInstruction of StoreInstruction
    | MillInstruction of MillInstruction
