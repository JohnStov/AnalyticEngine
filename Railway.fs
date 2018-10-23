module Railway

let succeed x =
    Ok x

let fail x =
    Error x

let either successFunc failureFunc result =
    match result with
    | Ok s -> successFunc s
    | Error f -> failureFunc f

let bind f =
    either f fail

