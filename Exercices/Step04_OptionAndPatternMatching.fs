module Step04_OptionAndPatternMatching

(***
STEP 4 — Option and pattern matching
- Option<'T> is a safe way to represent presence (Some x) or absence (None).
- Pattern matching unpacks the value and forces you to handle both cases.
***)

let tryHead list =
    match list with
    | [] -> None
    | x :: _ -> Some x

let explain (xs: int list) =
    match tryHead xs with
    | Some h -> sprintf "Head is %d" h
    | None -> "List was empty"

let run () =
    printfn "[STEP 4: Option & Pattern Matching]"
    printfn "%s" (explain [1;2;3])
    printfn "%s" (explain [])
    printfn "Option removes many null-related errors by design.\n"