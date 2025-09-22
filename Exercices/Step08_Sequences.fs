module Step08_Sequences

(***
STEP 8 — Sequences (lazy evaluation)
- seq { ... } creates a lazy sequence; values are produced on demand.
- Useful for potentially large or infinite streams.
***)

let firstSquares n =
    seq { for i in 1 .. n do yield i * i }

let run () =
    printfn "[STEP 8: Sequences (lazy)]"
    firstSquares 5 |> Seq.iter (printf "%d ")
    printfn "\nSequences are evaluated as you iterate them.\n"