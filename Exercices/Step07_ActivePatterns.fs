module Step07_ActivePatterns

(***
STEP 7 — Active Patterns
- Active patterns let you name classification/decomposition logic and use it in pattern matching.
***)

let (|Small|Medium|Large|) (n: int) =
    if n < 10 then Small
    elif n < 100 then Medium
    else Large

let classifyNumber n =
    match n with
    | Small -> "Small"
    | Medium -> "Medium"
    | Large -> "Large"

let run () =
    printfn "[STEP 7: Active Patterns]"
    [5; 42; 1000] |> List.iter (fun n -> printfn "%d is %s" n (classifyNumber n))
    printfn "Active patterns improve readability by naming classifications.\n"