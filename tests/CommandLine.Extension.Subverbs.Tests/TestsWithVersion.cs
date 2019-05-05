using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CommandLine;
using Commandline.Extension.Subverbs.Tests.Verbs;
using FluentAssertions;
using Xunit;

namespace Commandline.Extension.Subverbs.Tests
{
    public class TestsWithVersion
    {
        [Theory]
        [InlineData("version")]
        [InlineData("--version")]
        [InlineData("version", "verbset1")]
        [InlineData("verbset1", "--version")]
        [InlineData("verbset1", "version")]
        [InlineData("version", "add")]
        [InlineData("add", "--version")]
        [InlineData("version", "echo")]
        [InlineData("echo", "--version")]
        [InlineData("verbset1", "version", "verbset2")]
        [InlineData("verbset1", "verbset2", "--version")]
        [InlineData("verbset1", "verbset2", "version")]
        [InlineData("verbset1", "version", "add")]
        [InlineData("verbset1", "add", "--version")]
        [InlineData("verbset1", "version", "echo")]
        [InlineData("verbset1", "echo", "--version")]
        [InlineData("verbset1", "verbset2", "version", "add")]
        [InlineData("verbset1", "verbset2", "version", "echo")]
        [InlineData("verbset1", "verbset2", "add", "--version")]
        [InlineData("verbset1", "verbset2", "echo", "--version")]
        public void Version_Line_Is_Written_With_Auto_Help(params string[] args)
        {
            StringBuilder helpBuilder = new StringBuilder();
            StringWriter helpWriter = new StringWriter(helpBuilder);

            Parser parser = new Parser(settings => settings.HelpWriter = helpWriter);

            ParserResult<object> onVerbSetParsed(Parser p, ParserResult<object> parsed, IEnumerable<string> argsToParse, bool hasHelpOrVersion)
            {
                return parsed.MapResult(
                    (VerbSet1 _) => p.ParseSetArguments(argsToParse, new Type[] { typeof(VerbSet2), typeof(VerbSet3) }, new Type[] { typeof(AddVerb2), typeof(EchoVerb2) }, onNestedParsed, hasHelpOrVersion),
                    (_) => throw new Exception("This mapped path should not have been called."));
            }

            ParserResult<object> onNestedParsed(Parser p, ParserResult<object> parsed, IEnumerable<string> argsToParse, bool hasHelpOrVersion)
            {
                return parsed.MapResult(
                    (VerbSet2 _) => p.ParseArguments(argsToParse, typeof(AddVerb3), typeof(EchoVerb3)),
                    (VerbSet3 _) => throw new Exception("This mapped path should not have been called."),
                    (_) => throw new Exception("This mapped path should not have been called."));
            }

            ParserResult<object> result = parser.ParseSetArguments(args, new Type[] { typeof(VerbSet1) }, new Type[] { typeof(AddVerb1), typeof(EchoVerb1) }, onVerbSetParsed);

            string[] helpLines = helpBuilder.ToString().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            helpLines.Length.Should().Be(1, "version only outputs one line of text.");
        }

        [Theory]
        [InlineData("version")]
        [InlineData("--version")]
        [InlineData("version", "verbset1")]
        [InlineData("verbset1", "--version")]
        [InlineData("verbset1", "version")]
        [InlineData("version", "add")]
        [InlineData("add", "--version")]
        [InlineData("version", "echo")]
        [InlineData("echo", "--version")]
        [InlineData("verbset1", "version", "verbset2")]
        [InlineData("verbset1", "verbset2", "--version")]
        [InlineData("verbset1", "verbset2", "version")]
        [InlineData("verbset1", "version", "add")]
        [InlineData("verbset1", "add", "--version")]
        [InlineData("verbset1", "version", "echo")]
        [InlineData("verbset1", "echo", "--version")]
        [InlineData("verbset1", "verbset2", "version", "add")]
        [InlineData("verbset1", "verbset2", "version", "echo")]
        [InlineData("verbset1", "verbset2", "add", "--version")]
        [InlineData("verbset1", "verbset2", "echo", "--version")]
        public void Help_With_Errors_Are_Written_With_No_Auto_Help(params string[] args)
        {
            StringBuilder helpBuilder = new StringBuilder();
            StringWriter helpWriter = new StringWriter(helpBuilder);

            Parser parser = new Parser(settings =>
            {
                settings.AutoVersion = false;
                settings.HelpWriter = helpWriter;
            });

            ParserResult<object> onVerbSetParsed(Parser p, ParserResult<object> parsed, IEnumerable<string> argsToParse, bool hasHelpOrVersion)
            {
                return parsed.MapResult(
                    (VerbSet1 _) => p.ParseSetArguments(argsToParse, new Type[] { typeof(VerbSet2), typeof(VerbSet3) }, new Type[] { typeof(AddVerb2), typeof(EchoVerb2) }, onNestedParsed, hasHelpOrVersion),
                    (_) => throw new Exception("This mapped path should not have been called."));
            }

            ParserResult<object> onNestedParsed(Parser p, ParserResult<object> parsed, IEnumerable<string> argsToParse, bool hasHelpOrVersion)
            {
                return parsed.MapResult(
                    (VerbSet2 _) => p.ParseArguments(argsToParse, typeof(AddVerb3), typeof(EchoVerb3)),
                    (VerbSet3 _) => throw new Exception("This mapped path should not have been called."),
                    (_) => throw new Exception("This mapped path should not have been called."));
            }

            ParserResult<object> result = parser.ParseSetArguments(args, new Type[] { typeof(VerbSet1) }, new Type[] { typeof(AddVerb1), typeof(EchoVerb1) }, onVerbSetParsed);

            string[] helpLines = helpBuilder.ToString().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            helpLines[2].Should().Be("ERROR(S):", "version gives errors if AutoVersion is false.");
        }
    }
}
