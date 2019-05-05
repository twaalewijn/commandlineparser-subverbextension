using System;
using CommandLine;

namespace Commandline.Extension.Subverbs.Tests.Verbs
{
    public class AddVerb
    {
        [Option('f', "first", HelpText = "First number.", Required = true)]
        public int First { get; set; }

        [Option('s', "second", HelpText = "Second number.")]
        public int Second { get; set; }
    }

    [Verb("add", HelpText = "First add command.")]
    public class AddVerb1 : AddVerb
    {
    }

    [Verb("add", HelpText = "Second add command.")]
    public class AddVerb2 : AddVerb
    {
    }

    [Verb("add", HelpText = "Third add command.")]
    public class AddVerb3 : AddVerb
    {
    }

    [Verb("add", HelpText = "Fourth add command.")]
    public class AddVerb4 : AddVerb
    {
    }

    [Verb("add", HelpText = "Fifth add command.")]
    public class AddVerb5 : AddVerb
    {
    }

    [Verb("add", HelpText = "Sixth add command.")]
    public class AddVerb6 : AddVerb
    {
    }

    [Verb("add", HelpText = "Seventh add command.")]
    public class AddVerb7 : AddVerb
    {
    }

    [Verb("add", HelpText = "Eigth add command.")]
    public class AddVerb8 : AddVerb
    {
    }

    [Verb("add", HelpText = "Ninth add command.")]
    public class AddVerb9 : AddVerb
    {
    }

    [Verb("add", HelpText = "Tenth add command.")]
    public class AddVerb10 : AddVerb
    {
    }

    [Verb("add", HelpText = "Eleventh add command.")]
    public class AddVerb11 : AddVerb
    {
    }

    [Verb("add", HelpText = "Twelfth add command.")]
    public class AddVerb12 : AddVerb
    {
    }

    [Verb("add", HelpText = "Thirteenth add command.")]
    public class AddVerb13 : AddVerb
    {
    }

    [Verb("add", HelpText = "Fourteenth add command.")]
    public class AddVerb14 : AddVerb
    {
    }

    [Verb("add", HelpText = "Fifteenth add command.")]
    public class AddVerb15 : AddVerb
    {
    }

    [Verb("add", HelpText = "Sixteenth add command.")]
    public class AddVerb16 : AddVerb
    {
    }
}
