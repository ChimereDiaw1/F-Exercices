module Program

/// A simple implementation of List.map written recursively.
let rec myMap (fn: 'T -> 'U) (items: 'T list) : 'U list =
    match items with
    | [] -> []
    | x :: xs -> fn x :: myMap fn xs

[<EntryPoint>]
let main _argv =
    // quick self-check
    let _ = myMap ((+) 1) [1;2;3]

    // run step-by-step modules
    Step01_Immutability.run()
    Step02_Records.run()
    Step03_DiscriminatedUnions.run()
    Step04_OptionAndPatternMatching.run()
    Step05_Pipelines.run()
    Step06_TailRecursiveMap.run()
    Step07_ActivePatterns.run()
    Step08_Sequences.run()
    Step09_Async.run()
    Step10_Result.run()
    Step11_UnitsOfMeasure.run()
    Step12_ComputationExpressions.run()
    Step13_DotNetInterop.run()
    0