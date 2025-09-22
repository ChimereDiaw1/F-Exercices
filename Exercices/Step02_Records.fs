module Step02_Records

(***
STEP 2 — Records (product types)
- Records are lightweight immutable aggregates with named fields.
- Use copy-and-update syntax { x with Field = newValue } to produce a new record based on an existing one.
***)

type Person = { Name: string; Age: int }

let birthday p = { p with Age = p.Age + 1 }

let run () =
    printfn "[STEP 2: Records]"
    let alice = { Name = "Alice"; Age = 30 }
    let olderAlice = birthday alice
    printfn "Original: %s (%d)" alice.Name alice.Age
    printfn "After birthday: %s (%d)" olderAlice.Name olderAlice.Age
    printfn "Records are immutable; copy-and-update returns a new value.\n"