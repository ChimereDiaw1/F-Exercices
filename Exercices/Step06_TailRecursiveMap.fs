module Step06_TailRecursiveMap

(***
STEP 6 — Tail-recursive map
- Tail recursion avoids growing the call stack for long lists.
- We accumulate results and reverse at the end for efficiency.
***)

let myMapTailRec (fn: 'T -> 'U) (items: 'T list) : 'U list =
    let rec loop acc rest =
        match rest with
        | [] -> List.rev acc
        | x :: xs -> loop (fn x :: acc) xs
    loop [] items

let run () =
    printfn "[STEP 6: Tail-recursive map]"
    printfn "myMapTailRec (+1) [1;2;3] -> %A" (myMapTailRec ((+) 1) [1;2;3])
    printfn "Tail recursion is stack-safe for large inputs.\n"