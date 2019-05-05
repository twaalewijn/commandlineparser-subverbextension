using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CommandLine;
using Commandline.Extension.Subverbs.Tests.Verbs;
using FluentAssertions;
using Xunit;

namespace Commandline.Extension.Subverbs.Tests
{
    public class TestsWithHelp
    {
        [Theory]
        [InlineData(false)]
        [InlineData(true, "help")]
        [InlineData(true, "--help")]
        public void Base_Help_Is_Written_For_Verbs(bool requested, params string[] args)
        {
            StringBuilder helpBuilder = new StringBuilder();
            StringWriter helpWriter = new StringWriter(helpBuilder);

            Parser parser = new Parser(settings => settings.HelpWriter = helpWriter);

            ParserResult<object> onVerbSetParsed(Parser p, ParserResult<object> parsed, IEnumerable<string> argsToParse, bool hasHelpOrVersion)
            {
                throw new Exception("This method should not have been called.");
            }

            ParserResult<object> result = parser.ParseSetArguments(args, null, new Type[] { typeof(AddVerb1), typeof(EchoVerb1) }, onVerbSetParsed);

            TestHelpWrittenForVerbs(helpBuilder, requested, typeof(AddVerb1), typeof(EchoVerb1));
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true, "help")]
        [InlineData(true, "--help")]
        public void Base_Help_Is_Written_For_VerbSets(bool requested, params string[] args)
        {
            StringBuilder helpBuilder = new StringBuilder();
            StringWriter helpWriter = new StringWriter(helpBuilder);

            Parser parser = new Parser(settings => settings.HelpWriter = helpWriter);

            ParserResult<object> onVerbSetParsed(Parser p, ParserResult<object> parsed, IEnumerable<string> argsToParse, bool hasHelpOrVersion)
            {
                throw new Exception("This method should not have been called.");
            }

            ParserResult<object> result = parser.ParseSetArguments(args, new Type[] { typeof(VerbSet1), typeof(VerbSet2) }, null, onVerbSetParsed);

            TestHelpWrittenForVerbs(helpBuilder, requested, typeof(VerbSet1), typeof(VerbSet2));
        }

        [Theory]
        [InlineData(false, "add")]
        [InlineData(true, "help", "add")]
        [InlineData(true, "add", "--help")]
        public void Help_Is_Written_For_Verb_With_Options(bool requested, params string[] args)
        {
            StringBuilder helpBuilder = new StringBuilder();
            StringWriter helpWriter = new StringWriter(helpBuilder);

            Parser parser = new Parser(settings => settings.HelpWriter = helpWriter);

            ParserResult<object> onVerbSetParsed(Parser p, ParserResult<object> parsed, IEnumerable<string> argsToParse, bool hasHelpOrVersion)
            {
                throw new Exception("This method should not have been called.");
            }

            ParserResult<object> result = parser.ParseSetArguments(args, null, new Type[] { typeof(AddVerb1) }, onVerbSetParsed);

            TestHelpWrittenForAddVerb<AddVerb1>(helpBuilder, requested);
        }

        [Theory]
        [InlineData(false, "echo")]
        [InlineData(true, "help", "echo")]
        [InlineData(true, "echo", "--help")]
        public void Help_Is_Written_For_Verb_With_Values(bool requested, params string[] args)
        {
            StringBuilder helpBuilder = new StringBuilder();
            StringWriter helpWriter = new StringWriter(helpBuilder);

            Parser parser = new Parser(settings => settings.HelpWriter = helpWriter);

            ParserResult<object> onVerbSetParsed(Parser p, ParserResult<object> parsed, IEnumerable<string> argsToParse, bool hasHelpOrVersion)
            {
                throw new Exception("This method should not have been called.");
            }

            ParserResult<object> result = parser.ParseSetArguments(args, null, new Type[] { typeof(EchoVerb1) }, onVerbSetParsed);

            TestHelpWrittenForEchoVerb<EchoVerb1>(helpBuilder, requested);
        }

        [Theory]
        [InlineData(false, "verbset1")]
        [InlineData(true, "help", "verbset1")]
        [InlineData(true, "verbset1", "--help")]
        public void Help_Is_Written_For_Verbs_Nested_In_A_VerbSet(bool requested, params string[] args)
        {
            StringBuilder helpBuilder = new StringBuilder();
            StringWriter helpWriter = new StringWriter(helpBuilder);

            Parser parser = new Parser(settings => settings.HelpWriter = helpWriter);

            ParserResult<object> onVerbSetParsed(Parser p, ParserResult<object> parsed, IEnumerable<string> argsToParse, bool hasHelpOrVersion)
            {
                return parsed.MapResult(
                    (VerbSet1 _) => p.ParseArguments(argsToParse, typeof(AddVerb1), typeof(EchoVerb1)),
                    (_) => throw new Exception("This mapped path should not have been called."));
            }

            ParserResult<object> result = parser.ParseSetArguments(args, new Type[] { typeof(VerbSet1) }, null, onVerbSetParsed);

            TestHelpWrittenForVerbs(helpBuilder, requested, typeof(AddVerb1), typeof(EchoVerb1));
        }

        [Theory]
        [InlineData(false, "verbset1")]
        [InlineData(true, "help", "verbset1")]
        [InlineData(true, "verbset1", "--help")]
        public void Help_Is_Written_For_VerbSets_Nested_In_A_VerbSet(bool requested, params string[] args)
        {
            StringBuilder helpBuilder = new StringBuilder();
            StringWriter helpWriter = new StringWriter(helpBuilder);

            Parser parser = new Parser(settings => settings.HelpWriter = helpWriter);

            ParserResult<object> onVerbSetParsed(Parser p, ParserResult<object> parsed, IEnumerable<string> argsToParse, bool hasHelpOrVersion)
            {
                return parsed.MapResult(
                    (VerbSet1 _) => p.ParseSetArguments(argsToParse, new Type[] { typeof(VerbSet2), typeof(VerbSet3) }, null, onNestedParsed, hasHelpOrVersion),
                    (_) => throw new Exception("This mapped path should not have been called."));
            }

            ParserResult<object> onNestedParsed(Parser p, ParserResult<object> parsed, IEnumerable<string> argsToParse, bool hasHelpOrVersion)
            {
                throw new Exception("This method should not have been called");
            }

            ParserResult<object> result = parser.ParseSetArguments(args, new Type[] { typeof(VerbSet1) }, null, onVerbSetParsed);

            TestHelpWrittenForVerbs(helpBuilder, requested, typeof(VerbSet2), typeof(VerbSet3));
        }

        [Theory]
        [InlineData(false, "verbset1", "verbset2")]
        [InlineData(true, "verbset1", "help", "verbset2")]
        [InlineData(true, "verbset1", "verbset2", "--help")]
        public void Help_Is_Written_For_VerbSets_Nested_In_A_Nested_VerbSet(bool requested, params string[] args)
        {
            StringBuilder helpBuilder = new StringBuilder();
            StringWriter helpWriter = new StringWriter(helpBuilder);

            Parser parser = new Parser(settings => settings.HelpWriter = helpWriter);

            ParserResult<object> onVerbSetParsed(Parser p, ParserResult<object> parsed, IEnumerable<string> argsToParse, bool hasHelpOrVersion)
            {
                return parsed.MapResult(
                    (VerbSet1 _) => p.ParseSetArguments(argsToParse, new Type[] { typeof(VerbSet2), typeof(VerbSet3) }, null, onNestedParsed, hasHelpOrVersion),
                    (_) => throw new Exception("This mapped path should not have been called."));
            }

            ParserResult<object> onNestedParsed(Parser p, ParserResult<object> parsed, IEnumerable<string> argsToParse, bool hasHelpOrVersion)
            {
                return parsed.MapResult(
                    (VerbSet2 _) => p.ParseSetArguments(argsToParse, new Type[] { typeof(VerbSet4), typeof(VerbSet5) }, null, onNestedParsed, hasHelpOrVersion),
                    (VerbSet3 _) => throw new Exception("This mapped path should not have been called."),
                    (_) => throw new Exception("This mapped path should not have been called."));
            }

            ParserResult<object> result = parser.ParseSetArguments(args, new Type[] { typeof(VerbSet1) }, null, onVerbSetParsed);

            TestHelpWrittenForVerbs(helpBuilder, requested, typeof(VerbSet4), typeof(VerbSet5));
        }

        [Theory]
        [InlineData(false, "verbset1", "verbset2")]
        [InlineData(true, "verbset1", "help", "verbset2")]
        [InlineData(true, "verbset1", "verbset2", "--help")]
        public void Help_Is_Written_For_Verbs_Nested_In_A_Nested_VerbSet(bool requested, params string[] args)
        {
            StringBuilder helpBuilder = new StringBuilder();
            StringWriter helpWriter = new StringWriter(helpBuilder);

            Parser parser = new Parser(settings => settings.HelpWriter = helpWriter);

            ParserResult<object> onVerbSetParsed(Parser p, ParserResult<object> parsed, IEnumerable<string> argsToParse, bool hasHelpOrVersion)
            {
                return parsed.MapResult(
                    (VerbSet1 _) => p.ParseSetArguments(argsToParse, new Type[] { typeof(VerbSet2), typeof(VerbSet3) }, null, onNestedParsed, hasHelpOrVersion),
                    (_) => throw new Exception("This mapped path should not have been called."));
            }

            ParserResult<object> onNestedParsed(Parser p, ParserResult<object> parsed, IEnumerable<string> argsToParse, bool hasHelpOrVersion)
            {
                return parsed.MapResult(
                    (VerbSet2 _) => p.ParseArguments(argsToParse, typeof(AddVerb1), typeof(EchoVerb1)),
                    (VerbSet3 _) => throw new Exception("This mapped path should not have been called."),
                    (_) => throw new Exception("This mapped path should not have been called."));
            }

            ParserResult<object> result = parser.ParseSetArguments(args, new Type[] { typeof(VerbSet1) }, null, onVerbSetParsed);

            TestHelpWrittenForVerbs(helpBuilder, requested, typeof(AddVerb1), typeof(EchoVerb1));
        }

        [Theory]
        [InlineData(false, "verbset1", "verbset2", "add")]
        [InlineData(true, "verbset1", "verbset2", "help", "add")]
        [InlineData(true, "verbset1", "verbset2", "add", "--help")]
        public void Help_Is_Written_For_Verbs_With_Options_Nested_In_A_Nested_VerbSet(bool requested, params string[] args)
        {
            StringBuilder helpBuilder = new StringBuilder();
            StringWriter helpWriter = new StringWriter(helpBuilder);

            Parser parser = new Parser(settings => settings.HelpWriter = helpWriter);

            ParserResult<object> onVerbSetParsed(Parser p, ParserResult<object> parsed, IEnumerable<string> argsToParse, bool hasHelpOrVersion)
            {
                return parsed.MapResult(
                    (VerbSet1 _) => p.ParseSetArguments(argsToParse, new Type[] { typeof(VerbSet2), typeof(VerbSet3) }, null, onNestedParsed, hasHelpOrVersion),
                    (_) => throw new Exception("This mapped path should not have been called."));
            }

            ParserResult<object> onNestedParsed(Parser p, ParserResult<object> parsed, IEnumerable<string> argsToParse, bool hasHelpOrVersion)
            {
                return parsed.MapResult(
                    (VerbSet2 _) => p.ParseArguments(argsToParse, typeof(AddVerb1), typeof(EchoVerb1)),
                    (VerbSet3 _) => throw new Exception("This mapped path should not have been called."),
                    (_) => throw new Exception("This mapped path should not have been called."));
            }

            ParserResult<object> result = parser.ParseSetArguments(args, new Type[] { typeof(VerbSet1) }, null, onVerbSetParsed);

            TestHelpWrittenForAddVerb<AddVerb1>(helpBuilder, requested);
        }

        [Theory]
        [InlineData(false, "verbset1", "verbset2", "echo")]
        [InlineData(true, "verbset1", "verbset2", "help", "echo")]
        [InlineData(true, "verbset1", "verbset2", "echo", "--help")]
        public void Help_Is_Written_For_Verbs_With_Values_Nested_In_A_Nested_VerbSet(bool requested, params string[] args)
        {
            StringBuilder helpBuilder = new StringBuilder();
            StringWriter helpWriter = new StringWriter(helpBuilder);

            Parser parser = new Parser(settings => settings.HelpWriter = helpWriter);

            ParserResult<object> onVerbSetParsed(Parser p, ParserResult<object> parsed, IEnumerable<string> argsToParse, bool hasHelpOrVersion)
            {
                return parsed.MapResult(
                    (VerbSet1 _) => p.ParseSetArguments(argsToParse, new Type[] { typeof(VerbSet2), typeof(VerbSet3) }, null, onNestedParsed, hasHelpOrVersion),
                    (_) => throw new Exception("This mapped path should not have been called."));
            }

            ParserResult<object> onNestedParsed(Parser p, ParserResult<object> parsed, IEnumerable<string> argsToParse, bool hasHelpOrVersion)
            {
                return parsed.MapResult(
                    (VerbSet2 _) => p.ParseArguments(argsToParse, typeof(AddVerb1), typeof(EchoVerb1)),
                    (VerbSet3 _) => throw new Exception("This mapped path should not have been called."),
                    (_) => throw new Exception("This mapped path should not have been called."));
            }

            ParserResult<object> result = parser.ParseSetArguments(args, new Type[] { typeof(VerbSet1) }, null, onVerbSetParsed);

            TestHelpWrittenForEchoVerb<EchoVerb1>(helpBuilder, requested);
        }

        private void TestHelpWrittenForVerbs(StringBuilder helpBuilder, bool requested, params Type[] verbsInHelp)
        {
            string[] helpLines = helpBuilder.ToString().Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            int helpIndex = requested ? 2 : 4;

            foreach (Type verbType in verbsInHelp)
            {
                VerbAttribute verbAttribute = (VerbAttribute)verbType.GetCustomAttributes(typeof(VerbAttribute), false)[0];
                NormalizeHelpLine(helpLines[helpIndex]).Should().Be(NormalizeHelpLine($"{verbAttribute.Name}{verbAttribute.HelpText}"));
                helpIndex++;
            }
        }

        private void TestHelpWrittenForAddVerb<T>(StringBuilder helpBuilder, bool requested)
            where T : AddVerb
        {
            string[] helpLines = helpBuilder.ToString().Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            int helpIndex = requested ? 2 : 4;

            OptionAttribute firstOption = (OptionAttribute)typeof(T).GetProperty(nameof(AddVerb.First)).GetCustomAttributes(typeof(OptionAttribute), false)[0];
            OptionAttribute secondOption = (OptionAttribute)typeof(T).GetProperty(nameof(AddVerb.Second)).GetCustomAttributes(typeof(OptionAttribute), false)[0];

            NormalizeHelpLine(helpLines[helpIndex]).Should().Be(OptionAttributeToString(firstOption));
            NormalizeHelpLine(helpLines[helpIndex + 1]).Should().Be(OptionAttributeToString(secondOption));
        }

        private void TestHelpWrittenForEchoVerb<T>(StringBuilder helpBuilder, bool requested)
            where T : EchoVerb
        {
            string[] helpLines = helpBuilder.ToString().Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            int helpIndex = requested ? 4 : 6;

            helpLines[helpIndex].Trim().Should().Be("value pos. 0    Required. Value to echo.");
        }

        private string NormalizeHelpLine(string helpLine)
        {
            return new string(helpLine.Where(x => !char.IsWhiteSpace(x)).ToArray());
        }

        private string OptionAttributeToString(OptionAttribute optionAttribute)
        {
            StringBuilder builder = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(optionAttribute.ShortName))
            {
                builder.Append($"-{optionAttribute.ShortName}");

                if (!string.IsNullOrWhiteSpace(optionAttribute.LongName))
                {
                    builder.Append(",");
                }
            }

            if (!string.IsNullOrWhiteSpace(optionAttribute.LongName))
            {
                builder.Append($"--{optionAttribute.LongName}");
            }

            if (optionAttribute.Required)
            {
                builder.Append("Required.");
            }

            if (!string.IsNullOrWhiteSpace(optionAttribute.HelpText))
            {
                builder.Append(NormalizeHelpLine(optionAttribute.HelpText));
            }

            return builder.ToString();
        }
    }
}
