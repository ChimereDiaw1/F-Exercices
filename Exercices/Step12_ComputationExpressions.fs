module Step12_ComputationExpressions

(***
STEP 12 — Computation Expressions (Option example)
- Computation expressions provide custom syntactic sugar for workflows.
- Here we build a simple MaybeBuilder to chain Option operations elegantly.
***)

type MaybeBuilder() =
    member _.Bind(m, f) = Option.bind f m
    member _.Return x = Some x
    member _.ReturnFrom m = m

let maybe = MaybeBuilder()

let divide (x: int) (y: int) = if y = 0 then None else Some (x / y)

let safePipeline a b c =
    maybe {
        let! x = divide a b
        let! y = divide x c
        return y
    }

let run () =
    printfn "[STEP 12: Computation Expressions]"
    printfn "safePipeline 100 2 5 -> %A" (safePipeline 100 2 5)
    printfn "safePipeline 100 0 5 -> %A" (safePipeline 100 0 5)
    printfn "CEs let you define domain-specific mini-languages for workflows.\n"