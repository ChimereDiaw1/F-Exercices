module Step13_DotNetInterop

open System

(***
STEP 13 — .NET Interop
- F# runs on .NET and interoperates seamlessly with .NET libraries and OO APIs.
- You can call methods, use classes, and interact with interfaces.
***)

let dotnetStringDemo (s: string) = s.ToUpperInvariant().Replace(" ", "-")

let timerDemo () =
    let sw = Diagnostics.Stopwatch()
    sw.Start()
    System.Threading.Thread.Sleep 5
    sw.Stop()
    sw.ElapsedMilliseconds

let run () =
    printfn "[STEP 13: .NET Interop]"
    printfn "%s" (dotnetStringDemo "hello world from fsharp")
    printfn "Timer demo ~%d ms" (timerDemo ())
    printfn "You can use any .NET API directly from F#.\n"