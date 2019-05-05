using System;
using System.Collections.Generic;
using CommandLine;
using Commandline.Extension.Subverbs.Tests.Verbs;
using FluentAssertions;
using Xunit;

namespace Commandline.Extension.Subverbs.Tests
{
    public class TestsWithOptionVerb
    {
        private void TestParsedAddVerb<T>(ParserResult<object> result, int first, int second)
            where T : AddVerb
        {
            result.Should().BeOfType(typeof(Parsed<object>), "the args should have been parsed.");

            Parsed<object> parsedResult = (Parsed<object>)result;

            parsedResult.Value.Should().BeOfType(typeof(T), $"the args should have been mapped to the {typeof(T).Name} type.");

            T addResult = (T)parsedResult.Value;

            addResult.First.Should().Be(first);
            addResult.Second.Should().Be(second);
        }

        [Fact]
        public void Can_Parse_Verbs_With_Options()
        {
            Parser parser = new Parser();

            string[] args = new string[] { "add", "-f", "7", "-s", "10" };

            ParserResult<object> onVerbSetParsed(Parser p, ParserResult<object> parsed, IEnumerable<string> argsToParse, bool hasHelpOrVersion)
            {
                throw new Exception("This method should not have been called.");
            }

            ParserResult<object> result = parser.ParseSetArguments(args, null, new Type[] { typeof(AddVerb1) }, onVerbSetParsed);

            TestParsedAddVerb<AddVerb1>(result, 7, 10);
        }

        [Fact]
        public void Can_Parse_Verbs_With_Values_Within_VerbSets()
        {
            Parser parser = new Parser();

            string[] args = new string[] { "verbset1", "add", "-f", "7", "-s", "10" };

            ParserResult<object> onVerbSetParsed(Parser p, ParserResult<object> parsed, IEnumerable<string> argsToParse, bool hasHelpOrVersion)
            {
                return parsed.MapResult(
                    (VerbSet1 _) => p.ParseArguments(argsToParse, typeof(AddVerb1)),
                    (_) => throw new Exception("This mapped path should not be reachable."));
            }

            ParserResult<object> result = parser.ParseSetArguments(args, new Type[] { typeof(VerbSet1) }, null, onVerbSetParsed);

            TestParsedAddVerb<AddVerb1>(result, 7, 10);
        }

        [Fact]
        public void Can_Parse_Verbs_With_Options_Within_VerbSets_When_Passing_Multiple_Sets()
        {
            Parser parser = new Parser();

            string[] args = new string[] { "verbset2", "add", "-f", "7", "-s", "10" };

            ParserResult<object> onVerbSetParsed(Parser p, ParserResult<object> parsed, IEnumerable<string> argsToParse, bool hasHelpOrVersion)
            {
                return parsed.MapResult(
                    (VerbSet1 _) => throw new Exception("This mapped path should not be reachable."),
                    (VerbSet2 _) => p.ParseArguments(argsToParse, typeof(AddVerb1)),
                    (_) => throw new Exception("This mapped path should not be reachable."));
            }

            ParserResult<object> result = parser.ParseSetArguments(args, new Type[] { typeof(VerbSet1), typeof(VerbSet2) }, null, onVerbSetParsed);

            TestParsedAddVerb<AddVerb1>(result, 7, 10);
        }

        [Fact]
        public void Can_Parse_Verbs_With_Options_Within_VerbSets_When_Passing_Multiple_Sets_And_Regular_Verbs()
        {
            Parser parser = new Parser();

            string[] args = new string[] { "verbset2", "add", "-f", "7", "-s", "10" };

            ParserResult<object> onVerbSetParsed(Parser p, ParserResult<object> parsed, IEnumerable<string> argsToParse, bool hasHelpOrVersion)
            {
                return parsed.MapResult(
                    (VerbSet1 _) => throw new Exception("This mapped path should not be reachable."),
                    (VerbSet2 _) => p.ParseArguments(argsToParse, typeof(AddVerb3)),
                    (_) => throw new Exception("This mapped path should not be reachable."));
            }

            ParserResult<object> result = parser.ParseSetArguments(args, new Type[] { typeof(VerbSet1), typeof(VerbSet2) }, new Type[] { typeof(AddVerb1), typeof(AddVerb2) }, onVerbSetParsed);

            TestParsedAddVerb<AddVerb3>(result, 7, 10);
        }

        [Fact]
        public void Can_Parse_Verbs_With_Options_Within_VerbSets_Next_To_Sets_When_Passing_Multiple_Sets_And_Regular_Verbs()
        {
            Parser parser = new Parser();

            string[] args = new string[] { "verbset1", "add", "-f", "7", "-s", "10" };

            ParserResult<object> onVerbSetParsed(Parser p, ParserResult<object> parsed, IEnumerable<string> argsToParse, bool hasHelpOrVersion)
            {
                return parsed.MapResult(
                    (VerbSet1 _) => p.ParseSetArguments(argsToParse, new Type[] { typeof(VerbSet3), typeof(VerbSet4) }, new Type[] { typeof(AddVerb3) }, onNestedParsed, hasHelpOrVersion),
                    (VerbSet2 _) => throw new Exception("This mapped path should not be reachable."),
                    (_) => throw new Exception("This mapped path should not be reachable."));
            }

            ParserResult<object> onNestedParsed(Parser p, ParserResult<object> parsed, IEnumerable<string> argsToParse, bool hasHelpOrVersion)
            {
                throw new Exception("This method shouldn't have been called.");
            }

            ParserResult<object> result = parser.ParseSetArguments(args, new Type[] { typeof(VerbSet1), typeof(VerbSet2) }, new Type[] { typeof(AddVerb1), typeof(AddVerb2) }, onVerbSetParsed);

            TestParsedAddVerb<AddVerb3>(result, 7, 10);
        }

        [Fact]
        public void Can_Parse_Verbs_With_Options_Within_Nested_VerbSets_When_Passing_Multiple_Sets_And_Regular_Verbs()
        {
            Parser parser = new Parser();

            string[] args = new string[] { "verbset1", "verbset3", "add", "-f", "7", "-s", "10" };

            ParserResult<object> onVerbSetParsed(Parser p, ParserResult<object> parsed, IEnumerable<string> argsToParse, bool hasHelpOrVersion)
            {
                return parsed.MapResult(
                    (VerbSet1 _) => p.ParseSetArguments(argsToParse, new Type[] { typeof(VerbSet3), typeof(VerbSet4) }, new Type[] { typeof(AddVerb3) }, onNestedParsed, hasHelpOrVersion),
                    (VerbSet2 _) => throw new Exception("This mapped path should not be reachable."),
                    (_) => throw new Exception("This mapped path should not be reachable."));
            }

            ParserResult<object> onNestedParsed(Parser p, ParserResult<object> parsed, IEnumerable<string> argsToParse, bool hasHelpOrVersion)
            {
                return parsed.MapResult(
                    (VerbSet3 _) => p.ParseArguments(argsToParse, typeof(AddVerb4)),
                    (VerbSet4 _) => throw new Exception("This mapped path should not be reachable."),
                    (_) => throw new Exception("This mapped path should not be reachable."));
            }

            ParserResult<object> result = parser.ParseSetArguments(args, new Type[] { typeof(VerbSet1), typeof(VerbSet2) }, new Type[] { typeof(AddVerb1), typeof(AddVerb2) }, onVerbSetParsed);

            TestParsedAddVerb<AddVerb4>(result, 7, 10);
        }
    }
}
