module Step01_Immutability

open System

(***
STEP 1 — Immutability

What it is
- In F#, values are immutable by default: once bound to a name, the value does not change.
- Immutability makes code easier to reason about, eliminates a whole class of bugs caused by accidental mutation, and improves safety in concurrent code because data doesn’t change unexpectedly.

How to work with data if it doesn’t change?
- You create new values from old ones, rather than modifying in-place.
- For collections, you create new collections that share structure internally (persistent data structures), so it’s efficient.

When you do need mutation
- F# still allows mutation (mutable variables, arrays, refs) when it’s a clear win, but you opt in explicitly so it’s visible.

Below you’ll see examples of immutable bindings, shadowing, and explicit mutation when needed.
***)

// Immutable binding: the name 'answer' is bound to 42 and cannot be reassigned.
let answer = 42

// Shadowing: We can introduce a new binding with the same name in a narrower scope.
// This is not mutation; it’s a new value that temporarily hides the outer name.
let explainShadowing () =
    let outer = answer
    let answer = 100 // shadows the outer 'answer' within this function
    sprintf "Inner answer is %d, outer answer is still %d" answer outer

// Creating new values from old ones (no in-place change):
let addOne x = x + 1

// Working with lists immutably: building a new list without changing the old one.
let addOneToAll (xs: int list) = xs |> List.map addOne

// When mutation is explicit: 'mutable' keyword, or arrays/refs.
let demonstrateExplicitMutation () =
    let mutable counter = 0 // opt-in mutation
    counter <- counter + 1
    counter <- counter + 1
    // Arrays are mutable too:
    let arr = [|1;2;3|]
    arr[0] <- 10
    counter, arr

let run () =
    printfn "[STEP 1: Immutability]"
    printfn "- A value once defined does not change."
    printfn "answer = %d" answer

    let msg = explainShadowing ()
    printfn "- Shadowing (not mutation): %s" msg

    let original = [1;2;3]
    let updated = addOneToAll original
    printfn "- Original list: %A" original
    printfn "- New list (each +1): %A" updated
    printfn "  Note the original list remains unchanged."

    let counter, arr = demonstrateExplicitMutation ()
    printfn "- Explicit mutation example (mutable/array): counter=%d arr=%A" counter arr
    printfn ""