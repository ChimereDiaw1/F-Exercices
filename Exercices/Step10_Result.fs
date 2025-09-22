module Step10_Result

open System

(***
STEP 10 — Result<'Ok,'Err> for error handling without exceptions
- Use Ok value for success and Error value for failure.
- Compose operations by matching or using helper functions like Result.bind/map.
***)

let tryParseInt (s: string) : Result<int, string> =
    match Int32.TryParse s with
    | true, v -> Ok v
    | false, _ -> Error (sprintf "'%s' is not an int" s)

let sumTwoInts (a: string) (b: string) : Result<int, string> =
    match tryParseInt a, tryParseInt b with
    | Ok x, Ok y -> Ok (x + y)
    | Error e, _ -> Error e
    | _, Error e -> Error e

let run () =
    printfn "[STEP 10: Result]"
    printfn "sumTwoInts '10' '20' -> %A" (sumTwoInts "10" "20")
    printfn "sumTwoInts '10' 'x' -> %A" (sumTwoInts "10" "x")
    printfn "Results make errors explicit and composable.\n"