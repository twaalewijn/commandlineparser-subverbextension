using System;
using CommandLine;

namespace Commandline.Extension.Subverbs.Tests.Verbs
{
    public class EchoVerb
    {
        [Value(0, HelpText = "Value to echo.")]
        public string Input { get; set; }
    }

    [Verb("echo", HelpText = "First echo command.")]
    public class EchoVerb1 : EchoVerb
    {
    }

    [Verb("echo", HelpText = "Second echo command.")]
    public class EchoVerb2 : EchoVerb
    {
    }

    [Verb("echo", HelpText = "Third echo command.")]
    public class EchoVerb3 : EchoVerb
    {
    }

    [Verb("echo", HelpText = "Fourth echo command.")]
    public class EchoVerb4 : EchoVerb
    {
    }

    [Verb("echo", HelpText = "Fifth echo command.")]
    public class EchoVerb5 : EchoVerb
    {
    }

    [Verb("echo", HelpText = "Sixth echo command.")]
    public class EchoVerb6 : EchoVerb
    {
    }

    [Verb("echo", HelpText = "Seventh echo command.")]
    public class EchoVerb7 : EchoVerb
    {
    }

    [Verb("echo", HelpText = "Eigth echo command.")]
    public class EchoVerb8 : EchoVerb
    {
    }

    [Verb("echo", HelpText = "Ninth echo command.")]
    public class EchoVerb9 : EchoVerb
    {
    }

    [Verb("echo", HelpText = "Tenth echo command.")]
    public class EchoVerb10 : EchoVerb
    {
    }

    [Verb("echo", HelpText = "Eleventh echo command.")]
    public class EchoVerb11 : EchoVerb
    {
    }

    [Verb("echo", HelpText = "Twelfth echo command.")]
    public class EchoVerb12 : EchoVerb
    {
    }

    [Verb("echo", HelpText = "Thirteenth echo command.")]
    public class EchoVerb13 : EchoVerb
    {
    }

    [Verb("echo", HelpText = "Fourteenth echo command.")]
    public class EchoVerb14 : EchoVerb
    {
    }

    [Verb("echo", HelpText = "Fifteenth echo command.")]
    public class EchoVerb15 : EchoVerb
    {
    }

    [Verb("echo", HelpText = "Sixteenth echo command.")]
    public class EchoVerb16 : EchoVerb
    {
    }
}
