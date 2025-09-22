module Examples

open System

// 1) Immutability and basic values
let answer = 42
let pi = 3.14159
let greeting name = $"Hello, {name}!" // string interpolation

// 2) Records (product types)
type Person = { Name: string; Age: int }

let birthday p = { p with Age = p.Age + 1 }

// 3) Discriminated Unions (sum types)
type Shape =
    | Circle of radius: float
    | Rectangle of width: float * height: float

let area shape =
    match shape with
    | Circle r -> Math.PI * r * r
    | Rectangle (w, h) -> w * h

// 4) Option type and pattern matching
let tryHead list =
    match list with
    | [] -> None
    | x :: _ -> Some x

// 5) Pipelines and function composition
let square x = x * x
let isEven x = x % 2 = 0

let pipelineDemo (xs: int list) =
    xs
    |> List.filter isEven
    |> List.map square
    |> List.sum

// 6) Tail-recursive map (memory efficient for very large lists)
let myMapTailRec (fn: 'T -> 'U) (items: 'T list) : 'U list =
    let rec loop acc rest =
        match rest with
        | [] -> List.rev acc
        | x :: xs -> loop (fn x :: acc) xs
    loop [] items

// 7) Active patterns for readable classification
let (|Small|Medium|Large|) (n: int) =
    if n < 10 then Small
    elif n < 100 then Medium
    else Large

let classifyNumber n =
    match n with
    | Small -> "Small"
    | Medium -> "Medium"
    | Large -> "Large"

// 8) Sequences (lazy evaluation)
let firstSquares n =
    seq { for i in 1 .. n do yield i * i }

// 9) Simple Async demo (non-blocking delay)
let asyncWork (name: string) = async {
    do! Async.Sleep 50
    return $"Work done for {name}" }

// 10) Result type and error handling without exceptions
let tryParseInt (s: string) : Result<int, string> =
    match Int32.TryParse s with
    | true, v -> Ok v
    | false, _ -> Error $"'{s}' is not an int"

let sumTwoInts (a: string) (b: string) : Result<int, string> =
    match tryParseInt a, tryParseInt b with
    | Ok x, Ok y -> Ok (x + y)
    | Error e, _ -> Error e
    | _, Error e -> Error e

// 11) Units of Measure for type-safe numbers
[<Measure>] type m   // meters
[<Measure>] type s   // seconds

let distance : float<m> = 100.0<m>
let timeSpan : float<s> = 9.58<s>
let speed : float<m/s> = distance / timeSpan // m per s

// 12) A simple computation expression (MaybeBuilder for Option)
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

// 13) Interop with .NET OOP (classes, interfaces, object expressions)
let dotnetStringDemo (s: string) = s.ToUpperInvariant().Replace(" ", "-")

// Implementing an interface on the fly using an object expression
let timerDemo () =
    let sw = Diagnostics.Stopwatch()
    sw.Start()
    System.Threading.Thread.Sleep 5
    sw.Stop()
    sw.ElapsedMilliseconds

let runDemos () =
    printfn "--- Basics ---"
    printfn "answer = %d, pi ~ %.2f" answer pi
    printfn "%s" (greeting "F# Learner")

    printfn "\n--- Records ---"
    let alice = { Name = "Alice"; Age = 30 }
    let olderAlice = birthday alice
    printfn "%s had a birthday: %d -> %d" alice.Name alice.Age olderAlice.Age

    printfn "\n--- Discriminated Unions ---"
    printfn "Area circle r=2: %.3f" (area (Circle 2.0))
    printfn "Area rectangle 3x4: %.3f" (area (Rectangle (3.0, 4.0)))

    printfn "\n--- Option & Pattern Matching ---"
    match tryHead [1;2;3] with
    | Some h -> printfn "Head is %d" h
    | None -> printfn "List was empty"

    printfn "\n--- Pipelines ---"
    printfn "Sum of squares of even numbers in [1..10] = %d" (pipelineDemo [1..10])

    printfn "\n--- Tail-recursive myMap ---"
    printfn "myMapTailRec (+1) [1;2;3] -> %A" (myMapTailRec ((+) 1) [1;2;3])

    printfn "\n--- Active Patterns ---"
    [5; 42; 1000] |> List.iter (fun n -> printfn "%d is %s" n (classifyNumber n))

    printfn "\n--- Sequences (lazy) ---"
    firstSquares 5 |> Seq.iter (printf "%d ")
    printfn ""

    printfn "\n--- Async ---"
    let result = asyncWork "demo" |> Async.RunSynchronously
    printfn "%s" result

    printfn "\n--- Result type ---"
    printfn "sumTwoInts '10' '20' -> %A" (sumTwoInts "10" "20")
    printfn "sumTwoInts '10' 'x' -> %A" (sumTwoInts "10" "x")

    printfn "\n--- Units of Measure ---"
    printfn "distance = %A, time = %A, speed = %A (m/s)" distance timeSpan speed

    printfn "\n--- Computation Expressions (Option) ---"
    printfn "safePipeline 100 2 5 -> %A" (safePipeline 100 2 5)
    printfn "safePipeline 100 0 5 -> %A" (safePipeline 100 0 5)

    printfn "\n--- .NET Interop ---"
    printfn "%s" (dotnetStringDemo "hello world from fsharp")
    printfn "Timer demo ~%d ms" (timerDemo ())
