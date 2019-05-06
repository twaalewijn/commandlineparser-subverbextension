# Usage for C#
Define an empty verb type that should act as a subverb set:

```fsharp
// Make sure to include () to ensure the type has a constructor.
// The CommandLineParser library expects at least one constructor on the type.
// If no constructors are found on the type you'll get an exception while parsing.
[<Verb("calc", HelpText = "Calculator commands.")>]
type CalculatorVerbSet() = class end
```

Add some verb types that act as the actual command options:

```fsharp
[<Verb("add", HelpText = "Add two numbers.")>]
type AddVerb = {
    [<Value(0, Required = true, HelpText = "The first number to add to the second.")>] first : int;
    [<Value(1, Required = true, HelpText = "The second number to add to the first.")>] second : int;
}

[<Verb("subtract", HelpText = "Subtract two numbers.")>]
type SubtractVerb = {
    [<Value(0, Required = true, HelpText = "The number to subract from.")>] first : int;
    [<Value(1, Required = true, HelpText = "The number to subtract from the first.")>] second : int;
}
```

Then, instead of calling ```ParseArguments``` on your Parser, call ```ParseSetArguments``` instead:

```fsharp
// Define a function that will be called when 'calc' is parsed as the current verb.
let onVerbSetParsed (parser:Parser) (parsed:Parsed<obj>) (args:IEnumerable<string>) (containedHelpOrVersion:bool) =
        match parsed.Value with
        | :? CalculatorVerbSet -> parser.ParseArguments<AddVerb, SubtractVerb> args
        | _ -> parsed :> ParserResult<obj>

// Either:
// - Define functions to convert the F# func to the System.Func type that ParseSetArguments expects.
// - Cast the F# func to Func<_,_,_,_,_> while calling ParseSetArguments.
//   This would make the parser call in main look like this:
//     Parser.Default.ParseSetArguments<CalculatorVerbSet>(argv, Func<_,_,_,_,_> onVerbSetParsed)
let toOnVerbSetParsedFunc<'a, 'b, 'c, 'd, 'e> f =
    System.Func<Parser, Parsed<obj>, IEnumerable<string>, bool, ParserResult<obj>> f

let onVerbSetParsedFunc = toOnVerbSetParsedFunc onVerbSetParsed

let onAddParsed (addOpts:AddVerb) =
    let add x y = x + y
    let result = add addOpts.first addOpts.second
    printfn "%d" result
    0

let onSubtractParsed (subtractOpts:SubtractVerb) =
    let subtract x y = x - y
    let result = subtract subtractOpts.first subtractOpts.second
    printfn "%d" result
    0

let onParsed (parsed:Parsed<obj>) =
    match parsed.Value with
    | :? AddVerb as add -> onAddParsed add
    | :? SubtractVerb as subtract -> onSubtractParsed subtract
    | _ -> 1

[<EntryPoint>]
let main argv =
    let result =
        // Call ParseSetArguments instead of ParseArguments.
        Parser.Default.ParseSetArguments<CalculatorVerbSet>(argv, onVerbSetParsedFunc)

    match result with
    | :? Parsed<obj> as parsed -> onParsed parsed
    | _ -> 1
```

Parsing verbs on the same level as verb sets is also supported:

```fsharp
// Here the add verb is available on the root level just like calc.
let result = Parser.Default.ParseSetArguments<CalculatorVerbSet>(argv, onVerbSetParsedFunc, typeof<AddVerb>)
```

Nesting verb sets works as well, but to make sure auto help/version behaves properly call the ```ParseSetArguments``` overload with the value of ```containedHelpOrVersion``` from the callback function:

```fsharp
let onSciVerbSetParsed (parser:Parser) (parsed:Parsed<obj>) (args:IEnumerable<string>) (containedHelpOrVersion:bool) =
    match parsed.Value with
    | :? SciCalculatorVerbSet ->
        // Parse again for verbs belonging to the sci subverb set.
        parser.ParseArguments<SinVerb, CosVerb, TanVerb> args
    | _ -> parsed :> ParserResult<obj>

let onCalcVerbSetParsed (parser:Parser) (parsed:Parsed<obj>) (args:IEnumerable<string>) (containedHelpOrVersion:bool) =
    match parsed.Value with
    | :? CalculatorVerbSet ->
        // Parse again for add or subtract verbs or the sci subverb set and pass containedHelpOrVersion.
        parser.ParseSetArguments<SciCalculatorVerbSet>(args, Func<_,_,_,_,_> onSciVerbSetParsed, containedHelpOrVersion, typeof<AddVerb>, typeof<SubtractVerb>)
    | _ -> parsed :> ParserResult<obj>

[<EntryPoint>]
let main argv =
    let result = Parser.Default.ParseSetArguments<CalculatorVerbSet>(argv, Func<_,_,_,_,_> onCalcVerbSetParsed)
```