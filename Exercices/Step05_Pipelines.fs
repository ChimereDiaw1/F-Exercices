module Step05_Pipelines

(***
STEP 5 — Pipelines and function composition
- The pipeline operator (|>) passes a value to a function, improving readability.
- You can chain transformations in a left-to-right style.
***)

let square x = x * x
let isEven x = x % 2 = 0

let pipelineDemo (xs: int list) =
    xs
    |> List.filter isEven
    |> List.map square
    |> List.sum

let run () =
    printfn "[STEP 5: Pipelines]"
    printfn "Sum of squares of even numbers in [1..10] = %d" (pipelineDemo [1..10])
    printfn "Pipelines emphasize data flow and readability.\n"