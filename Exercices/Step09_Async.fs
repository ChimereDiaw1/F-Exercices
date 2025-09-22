module Step09_Async

open System

(***
STEP 9 — Async (non-blocking workflows)
- async { ... } describes an asynchronous workflow.
- Use do! to await operations, return to yield a value.
- Run with Async.RunSynchronously (or start with Async.Start in real apps).
***)

let asyncWork (name: string) = async {
    do! Async.Sleep 50
    return sprintf "Work done for %s" name
}

let run () =
    printfn "[STEP 9: Async]"
    let result = asyncWork "demo" |> Async.RunSynchronously
    printfn "%s" result
    printfn "Async workflows enable non-blocking operations.\n"