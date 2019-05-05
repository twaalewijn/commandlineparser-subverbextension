using System;
using System.Collections.Generic;
using CommandLine;
using Commandline.Extension.Subverbs.Tests.Verbs;
using FluentAssertions;
using Xunit;

namespace Commandline.Extension.Subverbs.Tests
{
    public class TestsWithValueVerb
    {
        private void TestParsedEchoVerb<T>(ParserResult<object> result, string input)
            where T : EchoVerb
        {
            result.Should().BeOfType(typeof(Parsed<object>), "the args should have been parsed.");

            Parsed<object> parsedResult = (Parsed<object>)result;

            parsedResult.Value.Should().BeOfType(typeof(T), $"the args should have been mapped to the {typeof(T).Name} type.");

            ((T)parsedResult.Value).Input.Should().Be(input);
        }

        [Fact]
        public void Can_Parse_Verbs_With_Values()
        {
            Parser parser = new Parser();

            string[] args = new string[] { "echo", "test" };

            ParserResult<object> onVerbSetParsed(Parser p, ParserResult<object> parsed, IEnumerable<string> argsToParse, bool hasHelpOrVersion)
            {
                throw new Exception("This method should not have been called.");
            }

            ParserResult<object> result = parser.ParseSetArguments(args, null, new Type[] { typeof(EchoVerb1) }, onVerbSetParsed);

            TestParsedEchoVerb<EchoVerb1>(result, "test");
        }

        [Fact]
        public void Can_Parse_Verbs_With_Values_Within_VerbSets()
        {
            Parser parser = new Parser();

            string[] args = new string[] { "verbset1", "echo", "test" };

            ParserResult<object> onVerbSetParsed(Parser p, ParserResult<object> parsed, IEnumerable<string> argsToParse, bool hasHelpOrVersion)
            {
                return parsed.MapResult(
                    (VerbSet1 _) => p.ParseArguments(argsToParse, typeof(EchoVerb1)),
                    (_) => throw new Exception("This mapped path should not be reachable."));
            }

            ParserResult<object> result = parser.ParseSetArguments(args, new Type[] { typeof(VerbSet1) }, null, onVerbSetParsed);

            TestParsedEchoVerb<EchoVerb1>(result, "test");
        }

        [Fact]
        public void Can_Parse_Verbs_With_Values_Within_VerbSets_When_Passing_Multiple_Sets()
        {
            Parser parser = new Parser();

            string[] args = new string[] { "verbset2", "echo", "test" };

            ParserResult<object> onVerbSetParsed(Parser p, ParserResult<object> parsed, IEnumerable<string> argsToParse, bool hasHelpOrVersion)
            {
                return parsed.MapResult(
                    (VerbSet1 _) => throw new Exception("This mapped path should not be reachable."),
                    (VerbSet2 _) => p.ParseArguments(argsToParse, typeof(EchoVerb1)),
                    (_) => throw new Exception("This mapped path should not be reachable."));
            }

            ParserResult<object> result = parser.ParseSetArguments(args, new Type[] { typeof(VerbSet1), typeof(VerbSet2) }, null, onVerbSetParsed);

            TestParsedEchoVerb<EchoVerb1>(result, "test");
        }

        [Fact]
        public void Can_Parse_Verbs_With_Values_Within_VerbSets_When_Passing_Multiple_Sets_And_Regular_Verbs()
        {
            Parser parser = new Parser();

            string[] args = new string[] { "verbset2", "echo", "test" };

            ParserResult<object> onVerbSetParsed(Parser p, ParserResult<object> parsed, IEnumerable<string> argsToParse, bool hasHelpOrVersion)
            {
                return parsed.MapResult(
                    (VerbSet1 _) => throw new Exception("This mapped path should not be reachable."),
                    (VerbSet2 _) => p.ParseArguments(argsToParse, typeof(EchoVerb3)),
                    (_) => throw new Exception("This mapped path should not be reachable."));
            }

            ParserResult<object> result = parser.ParseSetArguments(args, new Type[] { typeof(VerbSet1), typeof(VerbSet2) }, new Type[] { typeof(EchoVerb1), typeof(EchoVerb2) }, onVerbSetParsed);

            TestParsedEchoVerb<EchoVerb3>(result, "test");
        }

        [Fact]
        public void Can_Parse_Verbs_With_Values_Within_VerbSets_Next_To_Sets_When_Passing_Multiple_Sets_And_Regular_Verbs()
        {
            Parser parser = new Parser();

            string[] args = new string[] { "verbset1", "echo", "test" };

            ParserResult<object> onVerbSetParsed(Parser p, ParserResult<object> parsed, IEnumerable<string> argsToParse, bool hasHelpOrVersion)
            {
                return parsed.MapResult(
                    (VerbSet1 _) => p.ParseSetArguments(argsToParse, new Type[] { typeof(VerbSet3), typeof(VerbSet4) }, new Type[] { typeof(EchoVerb3) }, onNestedParsed, hasHelpOrVersion),
                    (VerbSet2 _) => throw new Exception("This mapped path should not be reachable."),
                    (_) => throw new Exception("This mapped path should not be reachable."));
            }

            ParserResult<object> onNestedParsed(Parser p, ParserResult<object> parsed, IEnumerable<string> argsToParse, bool hasHelpOrVersion)
            {
                throw new Exception("This method shouldn't have been called.");
            }

            ParserResult<object> result = parser.ParseSetArguments(args, new Type[] { typeof(VerbSet1), typeof(VerbSet2) }, new Type[] { typeof(EchoVerb1), typeof(EchoVerb2) }, onVerbSetParsed);

            TestParsedEchoVerb<EchoVerb3>(result, "test");
        }

        [Fact]
        public void Can_Parse_Verbs_With_Values_Within_Nested_VerbSets_When_Passing_Multiple_Sets_And_Regular_Verbs()
        {
            Parser parser = new Parser();

            string[] args = new string[] { "verbset1", "verbset3", "echo", "test" };

            ParserResult<object> onVerbSetParsed(Parser p, ParserResult<object> parsed, IEnumerable<string> argsToParse, bool hasHelpOrVersion)
            {
                return parsed.MapResult(
                    (VerbSet1 _) => p.ParseSetArguments(argsToParse, new Type[] { typeof(VerbSet3), typeof(VerbSet4) }, new Type[] { typeof(EchoVerb3) }, onNestedParsed, hasHelpOrVersion),
                    (VerbSet2 _) => throw new Exception("This mapped path should not be reachable."),
                    (_) => throw new Exception("This mapped path should not be reachable."));
            }

            ParserResult<object> onNestedParsed(Parser p, ParserResult<object> parsed, IEnumerable<string> argsToParse, bool hasHelpOrVersion)
            {
                return parsed.MapResult(
                    (VerbSet3 _) => p.ParseArguments(argsToParse, typeof(EchoVerb4)),
                    (VerbSet4 _) => throw new Exception("This mapped path should not be reachable."),
                    (_) => throw new Exception("This mapped path should not be reachable."));
            }

            ParserResult<object> result = parser.ParseSetArguments(args, new Type[] { typeof(VerbSet1), typeof(VerbSet2) }, new Type[] { typeof(EchoVerb1), typeof(EchoVerb2) }, onVerbSetParsed);

            TestParsedEchoVerb<EchoVerb4>(result, "test");
        }
    }
}
