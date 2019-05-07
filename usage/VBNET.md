# Usage for C#
Define an empty verb class that should act as a subverb set:

```vb
<Verb("calc", HelpText:="Calculator command.")>
Class CalculatorVerbSet
End Class
```

Add some verbs that act as the actual command options:

```vb
<Verb("add", HelpText:="Add two numbers.")>
Class AddVerb
    <CommandLine.Option("f"c, "first", Required:=True, HelpText:="The first number to add to the second.")>
    Public Property First As Int32

    <CommandLine.Option("s"c, "second", Required:=True, HelpText:="The second number to add to the first.")>
    Public Property Second As Int32
End Class

<Verb("subtract", HelpText:="Subtract two numbers.")>
Class SubtractVerb
    <CommandLine.Option("f"c, "first", Required:=True, HelpText:="The number to subract from.")>
    Public Property First As Int32

    <CommandLine.Option("s"c, "second", Required:=True, HelpText:="The number to subtract from the first.")>
    Public Property Second As Int32
End Class
```

Then, instead of calling ```ParseArguments``` on your Parser, call ```ParseSetArguments``` instead:

```vb
Module Program
    Function Main(args As String()) As Int32
        'Parse using ParseSetArguments instead of ParseArguments'
        Dim result As ParserResult(Of Object) =
            Parser.Default.ParseSetArguments(Of CalculatorVerbSet)(args, AddressOf OnVerbSetParsed)

        'Handle the actual verbs like normal.'
        Return result.MapResult(
            Function(add As AddVerb)
                Console.WriteLine(add.First + add.Second)
                Return 0
            End Function,
            Function(subtract As SubtractVerb)
                Console.WriteLine(subtract.First - subtract.Second)
                Return 0
            End Function,
            Function(errors As IEnumerable(Of CommandLine.Error)) 1)
    End Function

    Private Function OnVerbSetParsed(parser As Parser,
                                     parsed As Parsed(Of Object),
                                     args As IEnumerable(Of String),
                                     containedHelpOrVersion As Boolean) As ParserResult(Of Object)
        Return parsed.MapResult(
            Function(calc As CalculatorVerbSet)
                'Incase the calc verb was parsed, parse again for add or subtract.'
                Return parser.ParseArguments(Of AddVerb, SubtractVerb)(args)
            End Function,
            Function(errors As IEnumerable(Of CommandLine.Error)) parsed)
    End Function
End Module
```

Parsing verbs on the same level as verb sets is also supported:

```vb
'Here the add verb is available on the root level just like calc.'
Dim parsed = Parser.Default.ParseSetArguments(Of CalculatorVerbSet)(args, AddressOf onVerbSetParsed, GetType(AddVerb))
```

Nesting verb sets works as well, but to make sure auto help/version behaves properly call the ```ParseSetArguments``` overload with the value of ```containedHelpOrVersion``` from the callback:

```vb
Dim result As ParserResult(Of Object) =
    Parser.Default.ParseSetArguments(Of CalculatorVerbSet)(args, AddressOf OnCalcVerbSetParsed)

Private Function OnCalcVerbSetParsed(parser As Parser,
                                     parsed As Parsed(Of Object),
                                     args As IEnumerable(Of String),
                                     containedHelpOrVersion As Boolean) As ParserResult(Of Object)
    Return parsed.MapResult(
        Function(calc As CalculatorVerbSet)
            'Parse again for add or subtract verbs or the sci subverb set and pass containedHelpOrVersion.'
            Return parser.ParseSetArguments(Of SciCalculatorVerbSet)(args,
                                                                     AddressOf OnSciCalcVerbSetParsed,
                                                                     containedHelpOrVersion,
                                                                     GetType(AddVerb),
                                                                     GetType(SubtractVerb))
        End Function,
        Function(errors As IEnumerable(Of CommandLine.Error)) parsed)
End Function

Private Function OnSciCalcVerbSetParsed(parser As Parser,
                                 parsed As Parsed(Of Object),
                                 args As IEnumerable(Of String),
                                 containedHelpOrVersion As Boolean) As ParserResult(Of Object)
    Return parsed.MapResult(
        Function(calc As CalculatorVerbSet)
            'Parse again for verbs belonging to the sci subverb set.'
            Return parser.ParseArguments(Of SinVerb, CosVerb, TanVerb)(args)
        End Function,
        Function(errors As IEnumerable(Of CommandLine.Error)) parsed)
End Function
```