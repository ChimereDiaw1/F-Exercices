module Step03_DiscriminatedUnions

open System

(***
STEP 3 — Discriminated Unions (sum types)
- DUs let you model alternatives explicitly and safely.
- Each case can carry values. Pattern matching forces you to handle all cases.
***)

type Shape =
    | Circle of radius: float
    | Rectangle of width: float * height: float

let area shape =
    match shape with
    | Circle r -> Math.PI * r * r
    | Rectangle (w, h) -> w * h

let run () =
    printfn "[STEP 3: Discriminated Unions]"
    printfn "Area of circle r=2: %.3f" (area (Circle 2.0))
    printfn "Area of rectangle 3x4: %.3f" (area (Rectangle (3.0, 4.0)))
    printfn "Pattern matching ensures all DU cases are handled.\n"