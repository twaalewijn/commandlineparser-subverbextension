# Usage for C#
Define an empty verb class that should act as a subverb set:

```csharp
[Verb("calc", HelpText = "Calculator commands.")]
public class CalculatorVerbSet
{
}
```

Add some verbs that act as the actual command options:

```csharp
[Verb("add", HelpText = "Add two numbers.")]
public class AddVerb
{
    [Value(0, Required = true, HelpText = "The first number to add to the second.")]
    public int First { get; set; }

    [Value(1, Required = true, HelpText = "The second number to add to the first.")]
    public int Second { get; set; }
}

[Verb("subtract", HelpText = "Subtract two numbers.")]
public class SubtractVerb
{
    [Value(0, Required = true, HelpText = "The number to subract from.")]
    public int First { get; set; }

    [Value(1, Required = true, HelpText = "The number to subtract from the first.")]
    public int Second { get; set; }
}
```

Then, instead of calling ```ParseArguments``` on your Parser, call ```ParseSetArguments``` instead:

```csharp
class Program
{
    static int Main(string[] args)
    {
        // Parse using ParseSetArguments instead of ParseArguments.
        ParserResult<object> parsed = Parser.Default
            .ParseSetArguments<CalculatorVerbSet>(args, onVerbSetParsed);

        // Handle the actual verbs like normal.
        return parsed.MapResult(
            (AddVerb add) =>
            {
                Console.WriteLine(add.First + add.Second);
                return 0;
            },
            (SubtractVerb subtract) =>
            {
                Console.WriteLine(subtract.First - subtract.Second);
                return 0;
            },
            (_) => 1);
    }

    private static ParserResult<object> onVerbSetParsed(Parser parser,
        Parsed<object> parsed,
        IEnumerable<string> argsToParse,
        bool containedHelpOrVersion)
    {
        return parsed.MapResult(
            // Incase the calc verb was parsed, parse again for add or subtract.
            (CalculatorVerbSet _) => parser.ParseArguments<AddVerb, SubtractVerb>(argsToParse),
            (_) => parsed);
    }
}
```

Parsing verbs on the same level as verb sets is also supported:

```csharp
// Here the add verb is available on the root level just like calc.
ParserResult<object> parsed = Parser.Default
    .ParseSetArguments<CalculatorVerbSet>(args, onVerbSetParsed, typeof(AddVerb));
```

Nesting verb sets works as well, but to make sure auto help/version behaves properly call the ```ParseSetArguments``` overload with the value of ```containedHelpOrVersion``` from the callback:

```csharp
ParserResult<object> parsed = Parser.Default
    .ParseSetArguments<CalculatorVerbSet>(args, onCalcVerbSetParsed);

private static ParserResult<object> onCalcVerbSetParsed(Parser parser,
    Parsed<object> parsed,
    IEnumerable<string> argsToParse,
    bool containedHelpOrVersion)
{
    return parsed.MapResult(
        // Parse again for add or subtract verbs or the sci subverb set and pass containedHelpOrVersion.
        (CalculatorVerbSet _) =>
            parser.ParseSetArguments<SciCalculatorVerbSet>(argsToParse,
                onSciCalcVerbSetParsed,
                containedHelpOrVersion,
                typeof(AddVerb),
                typeof(SubtractVerb)),
        (_) => parsed);
}

private static ParserResult<object> onSciCalcVerbSetParsed(Parser parser,
    Parsed<object> parsed,
    IEnumerable<string> argsToParse,
    bool containedHelpOrVersion)
{
    return parsed.MapResult(
        // Parse again for verbs belonging to the sci subverb set.
        (SciCalculatorVerbSet _) => parser.ParseArguments<SinVerb, CosVerb, TanVerb>(argsToParse),
        (_) => parsed);
}
```