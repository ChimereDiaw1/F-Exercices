module Step11_UnitsOfMeasure

(***
STEP 11 — Units of Measure
- Units attach metadata (like meters, seconds) to numeric types at compile time.
- Prevents unit mix-ups (e.g., adding meters to seconds) by type-checking.
***)

[<Measure>] type m   // meters
[<Measure>] type s   // seconds

let distance : float<m> = 100.0<m>
let timeSpan : float<s> = 9.58<s>
let speed : float<m/s> = distance / timeSpan // m per s

let run () =
    printfn "[STEP 11: Units of Measure]"
    printfn "distance = %A, time = %A, speed = %A (m/s)" distance timeSpan speed
    printfn "The compiler enforces unit correctness at compile time.\n"