using System;
using System.IO;
using System.Linq;
using System.Text;
using CommandLine;
using Commandline.Extension.Subverbs.Tests.Verbs;
using FluentAssertions;
using Xunit;
using System.Collections.Generic;

namespace Commandline.Extension.Subverbs.Tests
{
    public class TestsWithGenerics
    {
        [Fact]
        public void With_One_Generic_VerbSet_Type()
        {
            StringBuilder helpBuilder = new StringBuilder();
            StringWriter helpWriter = new StringWriter(helpBuilder);

            Parser parser = new Parser(settings => settings.HelpWriter = helpWriter);

            parser.ParseSetArguments<VerbSet1>(new string[0], null, typeof(AddVerb1), typeof(EchoVerb1));

            TestHelpWrittenForVerbs(helpBuilder, typeof(VerbSet1), typeof(AddVerb1), typeof(EchoVerb1));
        }

        [Fact]
        public void With_Two_Generic_VerbSet_Types()
        {
            StringBuilder helpBuilder = new StringBuilder();
            StringWriter helpWriter = new StringWriter(helpBuilder);

            Parser parser = new Parser(settings => settings.HelpWriter = helpWriter);

            parser.ParseSetArguments<VerbSet1, VerbSet2>(new string[0], null, typeof(AddVerb1), typeof(EchoVerb1));

            TestHelpWrittenForVerbs(helpBuilder, typeof(VerbSet1), typeof(VerbSet2), typeof(AddVerb1), typeof(EchoVerb1));
        }

        [Fact]
        public void With_Three_Generic_VerbSet_Types()
        {
            StringBuilder helpBuilder = new StringBuilder();
            StringWriter helpWriter = new StringWriter(helpBuilder);

            Parser parser = new Parser(settings => settings.HelpWriter = helpWriter);

            parser.ParseSetArguments<VerbSet1, VerbSet2, VerbSet3>(new string[0], null, typeof(AddVerb1), typeof(EchoVerb1));

            TestHelpWrittenForVerbs(helpBuilder, typeof(VerbSet1), typeof(VerbSet2), typeof(VerbSet3), typeof(AddVerb1), typeof(EchoVerb1));
        }

        [Fact]
        public void With_Four_Generic_VerbSet_Types()
        {
            StringBuilder helpBuilder = new StringBuilder();
            StringWriter helpWriter = new StringWriter(helpBuilder);

            Parser parser = new Parser(settings => settings.HelpWriter = helpWriter);

            parser.ParseSetArguments<VerbSet1, VerbSet2, VerbSet3, VerbSet4>(new string[0], null, typeof(AddVerb1), typeof(EchoVerb1));

            TestHelpWrittenForVerbs(helpBuilder, typeof(VerbSet1), typeof(VerbSet2), typeof(VerbSet3), typeof(VerbSet4), typeof(AddVerb1), typeof(EchoVerb1));
        }

        [Fact]
        public void With_Five_Generic_VerbSet_Types()
        {
            StringBuilder helpBuilder = new StringBuilder();
            StringWriter helpWriter = new StringWriter(helpBuilder);

            Parser parser = new Parser(settings => settings.HelpWriter = helpWriter);

            parser.ParseSetArguments<VerbSet1, VerbSet2, VerbSet3, VerbSet4, VerbSet5>(new string[0], null, typeof(AddVerb1), typeof(EchoVerb1));

            TestHelpWrittenForVerbs(helpBuilder, typeof(VerbSet1), typeof(VerbSet2), typeof(VerbSet3), typeof(VerbSet4), typeof(VerbSet5), typeof(AddVerb1), typeof(EchoVerb1));
        }

        [Fact]
        public void With_Six_Generic_VerbSet_Types()
        {
            StringBuilder helpBuilder = new StringBuilder();
            StringWriter helpWriter = new StringWriter(helpBuilder);

            Parser parser = new Parser(settings => settings.HelpWriter = helpWriter);

            parser.ParseSetArguments<VerbSet1, VerbSet2, VerbSet3, VerbSet4, VerbSet5, VerbSet6>(new string[0], null, typeof(AddVerb1), typeof(EchoVerb1));

            TestHelpWrittenForVerbs(helpBuilder, typeof(VerbSet1), typeof(VerbSet2), typeof(VerbSet3), typeof(VerbSet4), typeof(VerbSet5), typeof(VerbSet6), typeof(AddVerb1), typeof(EchoVerb1));
        }

        [Fact]
        public void With_Seven_Generic_VerbSet_Types()
        {
            StringBuilder helpBuilder = new StringBuilder();
            StringWriter helpWriter = new StringWriter(helpBuilder);

            Parser parser = new Parser(settings => settings.HelpWriter = helpWriter);

            parser.ParseSetArguments<VerbSet1, VerbSet2, VerbSet3, VerbSet4, VerbSet5, VerbSet6, VerbSet7>(new string[0], null, typeof(AddVerb1), typeof(EchoVerb1));

            TestHelpWrittenForVerbs(helpBuilder, typeof(VerbSet1), typeof(VerbSet2), typeof(VerbSet3), typeof(VerbSet4), typeof(VerbSet5), typeof(VerbSet6), typeof(VerbSet7),
                typeof(AddVerb1), typeof(EchoVerb1));
        }

        [Fact]
        public void With_Eight_Generic_VerbSet_Types()
        {
            StringBuilder helpBuilder = new StringBuilder();
            StringWriter helpWriter = new StringWriter(helpBuilder);

            Parser parser = new Parser(settings => settings.HelpWriter = helpWriter);

            parser.ParseSetArguments<VerbSet1, VerbSet2, VerbSet3, VerbSet4, VerbSet5, VerbSet6, VerbSet7, VerbSet8>(new string[0], null, typeof(AddVerb1), typeof(EchoVerb1));

            TestHelpWrittenForVerbs(helpBuilder, typeof(VerbSet1), typeof(VerbSet2), typeof(VerbSet3), typeof(VerbSet4), typeof(VerbSet5), typeof(VerbSet6), typeof(VerbSet7),
                typeof(VerbSet8), typeof(AddVerb1), typeof(EchoVerb1));
        }

        [Fact]
        public void With_Nine_Generic_VerbSet_Types()
        {
            StringBuilder helpBuilder = new StringBuilder();
            StringWriter helpWriter = new StringWriter(helpBuilder);

            Parser parser = new Parser(settings => settings.HelpWriter = helpWriter);

            parser.ParseSetArguments<VerbSet1, VerbSet2, VerbSet3, VerbSet4, VerbSet5, VerbSet6, VerbSet7, VerbSet8, VerbSet9>(new string[0], null, typeof(AddVerb1), typeof(EchoVerb1));

            TestHelpWrittenForVerbs(helpBuilder, typeof(VerbSet1), typeof(VerbSet2), typeof(VerbSet3), typeof(VerbSet4), typeof(VerbSet5), typeof(VerbSet6), typeof(VerbSet7),
                typeof(VerbSet8), typeof(VerbSet9), typeof(AddVerb1), typeof(EchoVerb1));
        }

        [Fact]
        public void With_Ten_Generic_VerbSet_Types()
        {
            StringBuilder helpBuilder = new StringBuilder();
            StringWriter helpWriter = new StringWriter(helpBuilder);

            Parser parser = new Parser(settings => settings.HelpWriter = helpWriter);

            parser.ParseSetArguments<VerbSet1, VerbSet2, VerbSet3, VerbSet4, VerbSet5, VerbSet6, VerbSet7, VerbSet8, VerbSet9,
                VerbSet10>(new string[0], null, typeof(AddVerb1), typeof(EchoVerb1));

            TestHelpWrittenForVerbs(helpBuilder, typeof(VerbSet1), typeof(VerbSet2), typeof(VerbSet3), typeof(VerbSet4), typeof(VerbSet5), typeof(VerbSet6), typeof(VerbSet7),
                typeof(VerbSet8), typeof(VerbSet9), typeof(VerbSet10), typeof(AddVerb1), typeof(EchoVerb1));
        }

        [Fact]
        public void With_Eleven_Generic_VerbSet_Types()
        {
            StringBuilder helpBuilder = new StringBuilder();
            StringWriter helpWriter = new StringWriter(helpBuilder);

            Parser parser = new Parser(settings => settings.HelpWriter = helpWriter);

            parser.ParseSetArguments<VerbSet1, VerbSet2, VerbSet3, VerbSet4, VerbSet5, VerbSet6, VerbSet7, VerbSet8, VerbSet9,
                VerbSet10, VerbSet11>(new string[0], null, typeof(AddVerb1), typeof(EchoVerb1));

            TestHelpWrittenForVerbs(helpBuilder, typeof(VerbSet1), typeof(VerbSet2), typeof(VerbSet3), typeof(VerbSet4), typeof(VerbSet5), typeof(VerbSet6), typeof(VerbSet7),
                typeof(VerbSet8), typeof(VerbSet9), typeof(VerbSet10), typeof(VerbSet11), typeof(AddVerb1), typeof(EchoVerb1));
        }

        [Fact]
        public void With_Twelve_Generic_VerbSet_Types()
        {
            StringBuilder helpBuilder = new StringBuilder();
            StringWriter helpWriter = new StringWriter(helpBuilder);

            Parser parser = new Parser(settings => settings.HelpWriter = helpWriter);

            parser.ParseSetArguments<VerbSet1, VerbSet2, VerbSet3, VerbSet4, VerbSet5, VerbSet6, VerbSet7, VerbSet8, VerbSet9,
                VerbSet10, VerbSet11, VerbSet12>(new string[0], null, typeof(AddVerb1), typeof(EchoVerb1));

            TestHelpWrittenForVerbs(helpBuilder, typeof(VerbSet1), typeof(VerbSet2), typeof(VerbSet3), typeof(VerbSet4), typeof(VerbSet5), typeof(VerbSet6), typeof(VerbSet7),
                typeof(VerbSet8), typeof(VerbSet9), typeof(VerbSet10), typeof(VerbSet11), typeof(VerbSet12), typeof(AddVerb1), typeof(EchoVerb1));
        }

        [Fact]
        public void With_Thirteen_Generic_VerbSet_Types()
        {
            StringBuilder helpBuilder = new StringBuilder();
            StringWriter helpWriter = new StringWriter(helpBuilder);

            Parser parser = new Parser(settings => settings.HelpWriter = helpWriter);

            parser.ParseSetArguments<VerbSet1, VerbSet2, VerbSet3, VerbSet4, VerbSet5, VerbSet6, VerbSet7, VerbSet8, VerbSet9,
                VerbSet10, VerbSet11, VerbSet12, VerbSet13>(new string[0], null, typeof(AddVerb1), typeof(EchoVerb1));

            TestHelpWrittenForVerbs(helpBuilder, typeof(VerbSet1), typeof(VerbSet2), typeof(VerbSet3), typeof(VerbSet4), typeof(VerbSet5), typeof(VerbSet6), typeof(VerbSet7),
                typeof(VerbSet8), typeof(VerbSet9), typeof(VerbSet10), typeof(VerbSet11), typeof(VerbSet12), typeof(VerbSet13), typeof(AddVerb1), typeof(EchoVerb1));
        }

        [Fact]
        public void With_Fourteen_Generic_VerbSet_Types()
        {
            StringBuilder helpBuilder = new StringBuilder();
            StringWriter helpWriter = new StringWriter(helpBuilder);

            Parser parser = new Parser(settings => settings.HelpWriter = helpWriter);

            parser.ParseSetArguments<VerbSet1, VerbSet2, VerbSet3, VerbSet4, VerbSet5, VerbSet6, VerbSet7, VerbSet8, VerbSet9,
                VerbSet10, VerbSet11, VerbSet12, VerbSet13, VerbSet14>(new string[0], null, typeof(AddVerb1), typeof(EchoVerb1));

            TestHelpWrittenForVerbs(helpBuilder, typeof(VerbSet1), typeof(VerbSet2), typeof(VerbSet3), typeof(VerbSet4), typeof(VerbSet5), typeof(VerbSet6), typeof(VerbSet7),
                typeof(VerbSet8), typeof(VerbSet9), typeof(VerbSet10), typeof(VerbSet11), typeof(VerbSet12), typeof(VerbSet13), typeof(VerbSet14), typeof(AddVerb1), typeof(EchoVerb1));
        }

        [Fact]
        public void With_Fifteen_Generic_VerbSet_Types()
        {
            StringBuilder helpBuilder = new StringBuilder();
            StringWriter helpWriter = new StringWriter(helpBuilder);

            Parser parser = new Parser(settings => settings.HelpWriter = helpWriter);

            parser.ParseSetArguments<VerbSet1, VerbSet2, VerbSet3, VerbSet4, VerbSet5, VerbSet6, VerbSet7, VerbSet8, VerbSet9,
                VerbSet10, VerbSet11, VerbSet12, VerbSet13, VerbSet14, VerbSet15>(new string[0], null, typeof(AddVerb1), typeof(EchoVerb1));

            TestHelpWrittenForVerbs(helpBuilder, typeof(VerbSet1), typeof(VerbSet2), typeof(VerbSet3), typeof(VerbSet4), typeof(VerbSet5), typeof(VerbSet6), typeof(VerbSet7),
                typeof(VerbSet8), typeof(VerbSet9), typeof(VerbSet10), typeof(VerbSet11), typeof(VerbSet12), typeof(VerbSet13), typeof(VerbSet14),
                typeof(VerbSet15), typeof(AddVerb1), typeof(EchoVerb1));
        }

        [Fact]
        public void With_Sixteen_Generic_VerbSet_Types()
        {
            StringBuilder helpBuilder = new StringBuilder();
            StringWriter helpWriter = new StringWriter(helpBuilder);

            Parser parser = new Parser(settings => settings.HelpWriter = helpWriter);

            parser.ParseSetArguments<VerbSet1, VerbSet2, VerbSet3, VerbSet4, VerbSet5, VerbSet6, VerbSet7, VerbSet8, VerbSet9,
                VerbSet10, VerbSet11, VerbSet12, VerbSet13, VerbSet14, VerbSet15, VerbSet16>(new string[0], null, typeof(AddVerb1), typeof(EchoVerb1));

            TestHelpWrittenForVerbs(helpBuilder, typeof(VerbSet1), typeof(VerbSet2), typeof(VerbSet3), typeof(VerbSet4), typeof(VerbSet5), typeof(VerbSet6), typeof(VerbSet7),
                typeof(VerbSet8), typeof(VerbSet9), typeof(VerbSet10), typeof(VerbSet11), typeof(VerbSet12), typeof(VerbSet13), typeof(VerbSet14),
                typeof(VerbSet15), typeof(VerbSet16), typeof(AddVerb1), typeof(EchoVerb1));
        }

        [Fact]
        public void With_One_Generic_VerbSet_Type_Nested()
        {
            StringBuilder helpBuilder = new StringBuilder();
            StringWriter helpWriter = new StringWriter(helpBuilder);

            Parser parser = new Parser(settings => settings.HelpWriter = helpWriter);

            ParserResult<object> onVerbSetParsed(Parser p, ParserResult<object> parsed, IEnumerable<string> argsToParse, bool hasHelpOrVersion)
            {
                return parsed.MapResult(
                    (VerbSet1 _) => parser.ParseSetArguments<VerbSet1>(argsToParse, null, hasHelpOrVersion, typeof(AddVerb1), typeof(EchoVerb1)),
                    (_) => throw new Exception("This mapped path should not have been called."));
            }

            parser.ParseSetArguments<VerbSet1>(new string[] { "verbset1" }, onVerbSetParsed);

            TestHelpWrittenForVerbs(helpBuilder, typeof(VerbSet1), typeof(AddVerb1), typeof(EchoVerb1));
        }

        [Fact]
        public void With_Two_Generic_VerbSet_Types_Nested()
        {
            StringBuilder helpBuilder = new StringBuilder();
            StringWriter helpWriter = new StringWriter(helpBuilder);

            Parser parser = new Parser(settings => settings.HelpWriter = helpWriter);

            ParserResult<object> onVerbSetParsed(Parser p, ParserResult<object> parsed, IEnumerable<string> argsToParse, bool hasHelpOrVersion)
            {
                return parsed.MapResult(
                    (VerbSet1 _) => parser.ParseSetArguments<VerbSet1, VerbSet2>(argsToParse, null, hasHelpOrVersion, typeof(AddVerb1), typeof(EchoVerb1)),
                    (_) => throw new Exception("This mapped path should not have been called."));
            }

            parser.ParseSetArguments<VerbSet1>(new string[] { "verbset1" }, onVerbSetParsed);

            TestHelpWrittenForVerbs(helpBuilder, typeof(VerbSet1), typeof(VerbSet2), typeof(AddVerb1), typeof(EchoVerb1));
        }

        [Fact]
        public void With_Three_Generic_VerbSet_Types_Nested()
        {
            StringBuilder helpBuilder = new StringBuilder();
            StringWriter helpWriter = new StringWriter(helpBuilder);

            Parser parser = new Parser(settings => settings.HelpWriter = helpWriter);

            ParserResult<object> onVerbSetParsed(Parser p, ParserResult<object> parsed, IEnumerable<string> argsToParse, bool hasHelpOrVersion)
            {
                return parsed.MapResult(
                    (VerbSet1 _) => parser.ParseSetArguments<VerbSet1, VerbSet2, VerbSet3>(argsToParse, null, hasHelpOrVersion, typeof(AddVerb1), typeof(EchoVerb1)),
                    (_) => throw new Exception("This mapped path should not have been called."));
            }

            parser.ParseSetArguments<VerbSet1>(new string[] { "verbset1" }, onVerbSetParsed);

            TestHelpWrittenForVerbs(helpBuilder, typeof(VerbSet1), typeof(VerbSet2), typeof(VerbSet3), typeof(AddVerb1), typeof(EchoVerb1));
        }

        [Fact]
        public void With_Four_Generic_VerbSet_Types_Nested()
        {
            StringBuilder helpBuilder = new StringBuilder();
            StringWriter helpWriter = new StringWriter(helpBuilder);

            Parser parser = new Parser(settings => settings.HelpWriter = helpWriter);

            ParserResult<object> onVerbSetParsed(Parser p, ParserResult<object> parsed, IEnumerable<string> argsToParse, bool hasHelpOrVersion)
            {
                return parsed.MapResult(
                    (VerbSet1 _) => parser.ParseSetArguments<VerbSet1, VerbSet2, VerbSet3, VerbSet4>(argsToParse, null, hasHelpOrVersion, typeof(AddVerb1), typeof(EchoVerb1)),
                    (_) => throw new Exception("This mapped path should not have been called."));
            }

            parser.ParseSetArguments<VerbSet1>(new string[] { "verbset1" }, onVerbSetParsed);

            TestHelpWrittenForVerbs(helpBuilder, typeof(VerbSet1), typeof(VerbSet2), typeof(VerbSet3), typeof(VerbSet4), typeof(AddVerb1), typeof(EchoVerb1));
        }

        [Fact]
        public void With_Five_Generic_VerbSet_Types_Nested()
        {
            StringBuilder helpBuilder = new StringBuilder();
            StringWriter helpWriter = new StringWriter(helpBuilder);

            Parser parser = new Parser(settings => settings.HelpWriter = helpWriter);

            ParserResult<object> onVerbSetParsed(Parser p, ParserResult<object> parsed, IEnumerable<string> argsToParse, bool hasHelpOrVersion)
            {
                return parsed.MapResult(
                    (VerbSet1 _) => parser.ParseSetArguments<VerbSet1, VerbSet2, VerbSet3, VerbSet4, VerbSet5>(argsToParse, null, hasHelpOrVersion, typeof(AddVerb1), typeof(EchoVerb1)),
                    (_) => throw new Exception("This mapped path should not have been called."));
            }

            parser.ParseSetArguments<VerbSet1>(new string[] { "verbset1" }, onVerbSetParsed);

            TestHelpWrittenForVerbs(helpBuilder, typeof(VerbSet1), typeof(VerbSet2), typeof(VerbSet3), typeof(VerbSet4), typeof(VerbSet5), typeof(AddVerb1), typeof(EchoVerb1));
        }

        [Fact]
        public void With_Six_Generic_VerbSet_Types_Nested()
        {
            StringBuilder helpBuilder = new StringBuilder();
            StringWriter helpWriter = new StringWriter(helpBuilder);

            Parser parser = new Parser(settings => settings.HelpWriter = helpWriter);

            ParserResult<object> onVerbSetParsed(Parser p, ParserResult<object> parsed, IEnumerable<string> argsToParse, bool hasHelpOrVersion)
            {
                return parsed.MapResult(
                    (VerbSet1 _) => parser.ParseSetArguments<VerbSet1, VerbSet2, VerbSet3, VerbSet4, VerbSet5, VerbSet6>(argsToParse, null, hasHelpOrVersion, typeof(AddVerb1), typeof(EchoVerb1)),
                    (_) => throw new Exception("This mapped path should not have been called."));
            }

            parser.ParseSetArguments<VerbSet1>(new string[] { "verbset1" }, onVerbSetParsed);

            TestHelpWrittenForVerbs(helpBuilder, typeof(VerbSet1), typeof(VerbSet2), typeof(VerbSet3), typeof(VerbSet4), typeof(VerbSet5), typeof(VerbSet6), typeof(AddVerb1), typeof(EchoVerb1));
        }

        [Fact]
        public void With_Seven_Generic_VerbSet_Types_Nested()
        {
            StringBuilder helpBuilder = new StringBuilder();
            StringWriter helpWriter = new StringWriter(helpBuilder);

            Parser parser = new Parser(settings => settings.HelpWriter = helpWriter);

            ParserResult<object> onVerbSetParsed(Parser p, ParserResult<object> parsed, IEnumerable<string> argsToParse, bool hasHelpOrVersion)
            {
                return parsed.MapResult(
                    (VerbSet1 _) => parser.ParseSetArguments<VerbSet1, VerbSet2, VerbSet3, VerbSet4, VerbSet5, VerbSet6, VerbSet7>(argsToParse, null, hasHelpOrVersion, typeof(AddVerb1), typeof(EchoVerb1)),
                    (_) => throw new Exception("This mapped path should not have been called."));
            }

            parser.ParseSetArguments<VerbSet1>(new string[] { "verbset1" }, onVerbSetParsed);

            TestHelpWrittenForVerbs(helpBuilder, typeof(VerbSet1), typeof(VerbSet2), typeof(VerbSet3), typeof(VerbSet4), typeof(VerbSet5), typeof(VerbSet6), typeof(VerbSet7),
                typeof(AddVerb1), typeof(EchoVerb1));
        }

        [Fact]
        public void With_Eight_Generic_VerbSet_Types_Nested()
        {
            StringBuilder helpBuilder = new StringBuilder();
            StringWriter helpWriter = new StringWriter(helpBuilder);

            Parser parser = new Parser(settings => settings.HelpWriter = helpWriter);

            ParserResult<object> onVerbSetParsed(Parser p, ParserResult<object> parsed, IEnumerable<string> argsToParse, bool hasHelpOrVersion)
            {
                return parsed.MapResult(
                    (VerbSet1 _) => parser.ParseSetArguments<VerbSet1, VerbSet2, VerbSet3, VerbSet4, VerbSet5, VerbSet6, VerbSet7,
                        VerbSet8>(argsToParse, null, hasHelpOrVersion, typeof(AddVerb1), typeof(EchoVerb1)),
                    (_) => throw new Exception("This mapped path should not have been called."));
            }

            parser.ParseSetArguments<VerbSet1>(new string[] { "verbset1" }, onVerbSetParsed);

            TestHelpWrittenForVerbs(helpBuilder, typeof(VerbSet1), typeof(VerbSet2), typeof(VerbSet3), typeof(VerbSet4), typeof(VerbSet5), typeof(VerbSet6), typeof(VerbSet7),
                typeof(VerbSet8), typeof(AddVerb1), typeof(EchoVerb1));
        }

        [Fact]
        public void With_Nine_Generic_VerbSet_Types_Nested()
        {
            StringBuilder helpBuilder = new StringBuilder();
            StringWriter helpWriter = new StringWriter(helpBuilder);

            Parser parser = new Parser(settings => settings.HelpWriter = helpWriter);

            ParserResult<object> onVerbSetParsed(Parser p, ParserResult<object> parsed, IEnumerable<string> argsToParse, bool hasHelpOrVersion)
            {
                return parsed.MapResult(
                    (VerbSet1 _) => parser.ParseSetArguments<VerbSet1, VerbSet2, VerbSet3, VerbSet4, VerbSet5, VerbSet6, VerbSet7,
                        VerbSet8, VerbSet9>(argsToParse, null, hasHelpOrVersion, typeof(AddVerb1), typeof(EchoVerb1)),
                    (_) => throw new Exception("This mapped path should not have been called."));
            }

            parser.ParseSetArguments<VerbSet1>(new string[] { "verbset1" }, onVerbSetParsed);

            TestHelpWrittenForVerbs(helpBuilder, typeof(VerbSet1), typeof(VerbSet2), typeof(VerbSet3), typeof(VerbSet4), typeof(VerbSet5), typeof(VerbSet6), typeof(VerbSet7),
                typeof(VerbSet8), typeof(VerbSet9), typeof(AddVerb1), typeof(EchoVerb1));
        }

        [Fact]
        public void With_Ten_Generic_VerbSet_Types_Nested()
        {
            StringBuilder helpBuilder = new StringBuilder();
            StringWriter helpWriter = new StringWriter(helpBuilder);

            Parser parser = new Parser(settings => settings.HelpWriter = helpWriter);

            ParserResult<object> onVerbSetParsed(Parser p, ParserResult<object> parsed, IEnumerable<string> argsToParse, bool hasHelpOrVersion)
            {
                return parsed.MapResult(
                    (VerbSet1 _) => parser.ParseSetArguments<VerbSet1, VerbSet2, VerbSet3, VerbSet4, VerbSet5, VerbSet6, VerbSet7,
                        VerbSet8, VerbSet9, VerbSet10>(argsToParse, null, hasHelpOrVersion, typeof(AddVerb1), typeof(EchoVerb1)),
                    (_) => throw new Exception("This mapped path should not have been called."));
            }

            parser.ParseSetArguments<VerbSet1>(new string[] { "verbset1" }, onVerbSetParsed);

            TestHelpWrittenForVerbs(helpBuilder, typeof(VerbSet1), typeof(VerbSet2), typeof(VerbSet3), typeof(VerbSet4), typeof(VerbSet5), typeof(VerbSet6), typeof(VerbSet7),
                typeof(VerbSet8), typeof(VerbSet9), typeof(VerbSet10), typeof(AddVerb1), typeof(EchoVerb1));
        }

        [Fact]
        public void With_Eleven_Generic_VerbSet_Types_Nested()
        {
            StringBuilder helpBuilder = new StringBuilder();
            StringWriter helpWriter = new StringWriter(helpBuilder);

            Parser parser = new Parser(settings => settings.HelpWriter = helpWriter);

            ParserResult<object> onVerbSetParsed(Parser p, ParserResult<object> parsed, IEnumerable<string> argsToParse, bool hasHelpOrVersion)
            {
                return parsed.MapResult(
                    (VerbSet1 _) => parser.ParseSetArguments<VerbSet1, VerbSet2, VerbSet3, VerbSet4, VerbSet5, VerbSet6, VerbSet7,
                        VerbSet8, VerbSet9, VerbSet10, VerbSet11>(argsToParse, null, hasHelpOrVersion, typeof(AddVerb1), typeof(EchoVerb1)),
                    (_) => throw new Exception("This mapped path should not have been called."));
            }

            parser.ParseSetArguments<VerbSet1>(new string[] { "verbset1" }, onVerbSetParsed);

            TestHelpWrittenForVerbs(helpBuilder, typeof(VerbSet1), typeof(VerbSet2), typeof(VerbSet3), typeof(VerbSet4), typeof(VerbSet5), typeof(VerbSet6), typeof(VerbSet7),
                typeof(VerbSet8), typeof(VerbSet9), typeof(VerbSet10), typeof(VerbSet11), typeof(AddVerb1), typeof(EchoVerb1));
        }

        [Fact]
        public void With_Twelve_Generic_VerbSet_Types_Nested()
        {
            StringBuilder helpBuilder = new StringBuilder();
            StringWriter helpWriter = new StringWriter(helpBuilder);

            Parser parser = new Parser(settings => settings.HelpWriter = helpWriter);

            ParserResult<object> onVerbSetParsed(Parser p, ParserResult<object> parsed, IEnumerable<string> argsToParse, bool hasHelpOrVersion)
            {
                return parsed.MapResult(
                    (VerbSet1 _) => parser.ParseSetArguments<VerbSet1, VerbSet2, VerbSet3, VerbSet4, VerbSet5, VerbSet6, VerbSet7,
                        VerbSet8, VerbSet9, VerbSet10, VerbSet11, VerbSet12>(argsToParse, null, hasHelpOrVersion, typeof(AddVerb1), typeof(EchoVerb1)),
                    (_) => throw new Exception("This mapped path should not have been called."));
            }

            parser.ParseSetArguments<VerbSet1>(new string[] { "verbset1" }, onVerbSetParsed);

            TestHelpWrittenForVerbs(helpBuilder, typeof(VerbSet1), typeof(VerbSet2), typeof(VerbSet3), typeof(VerbSet4), typeof(VerbSet5), typeof(VerbSet6), typeof(VerbSet7),
                typeof(VerbSet8), typeof(VerbSet9), typeof(VerbSet10), typeof(VerbSet11), typeof(VerbSet12), typeof(AddVerb1), typeof(EchoVerb1));
        }

        [Fact]
        public void With_Thirteen_Generic_VerbSet_Types_Nested()
        {
            StringBuilder helpBuilder = new StringBuilder();
            StringWriter helpWriter = new StringWriter(helpBuilder);

            Parser parser = new Parser(settings => settings.HelpWriter = helpWriter);

            ParserResult<object> onVerbSetParsed(Parser p, ParserResult<object> parsed, IEnumerable<string> argsToParse, bool hasHelpOrVersion)
            {
                return parsed.MapResult(
                    (VerbSet1 _) => parser.ParseSetArguments<VerbSet1, VerbSet2, VerbSet3, VerbSet4, VerbSet5, VerbSet6, VerbSet7,
                        VerbSet8, VerbSet9, VerbSet10, VerbSet11, VerbSet12, VerbSet13>(argsToParse, null, hasHelpOrVersion, typeof(AddVerb1), typeof(EchoVerb1)),
                    (_) => throw new Exception("This mapped path should not have been called."));
            }

            parser.ParseSetArguments<VerbSet1>(new string[] { "verbset1" }, onVerbSetParsed);

            TestHelpWrittenForVerbs(helpBuilder, typeof(VerbSet1), typeof(VerbSet2), typeof(VerbSet3), typeof(VerbSet4), typeof(VerbSet5), typeof(VerbSet6), typeof(VerbSet7),
                typeof(VerbSet8), typeof(VerbSet9), typeof(VerbSet10), typeof(VerbSet11), typeof(VerbSet12), typeof(VerbSet13), typeof(AddVerb1), typeof(EchoVerb1));
        }

        [Fact]
        public void With_Fourteen_Generic_VerbSet_Types_Nested()
        {
            StringBuilder helpBuilder = new StringBuilder();
            StringWriter helpWriter = new StringWriter(helpBuilder);

            Parser parser = new Parser(settings => settings.HelpWriter = helpWriter);

            ParserResult<object> onVerbSetParsed(Parser p, ParserResult<object> parsed, IEnumerable<string> argsToParse, bool hasHelpOrVersion)
            {
                return parsed.MapResult(
                    (VerbSet1 _) => parser.ParseSetArguments<VerbSet1, VerbSet2, VerbSet3, VerbSet4, VerbSet5, VerbSet6, VerbSet7,
                        VerbSet8, VerbSet9, VerbSet10, VerbSet11, VerbSet12, VerbSet13, VerbSet14>(argsToParse, null, hasHelpOrVersion, typeof(AddVerb1), typeof(EchoVerb1)),
                    (_) => throw new Exception("This mapped path should not have been called."));
            }

            parser.ParseSetArguments<VerbSet1>(new string[] { "verbset1" }, onVerbSetParsed);

            TestHelpWrittenForVerbs(helpBuilder, typeof(VerbSet1), typeof(VerbSet2), typeof(VerbSet3), typeof(VerbSet4), typeof(VerbSet5), typeof(VerbSet6), typeof(VerbSet7),
                typeof(VerbSet8), typeof(VerbSet9), typeof(VerbSet10), typeof(VerbSet11), typeof(VerbSet12), typeof(VerbSet13), typeof(VerbSet14), typeof(AddVerb1), typeof(EchoVerb1));
        }

        [Fact]
        public void With_Fifteen_Generic_VerbSet_Types_Nested()
        {
            StringBuilder helpBuilder = new StringBuilder();
            StringWriter helpWriter = new StringWriter(helpBuilder);

            Parser parser = new Parser(settings => settings.HelpWriter = helpWriter);

            ParserResult<object> onVerbSetParsed(Parser p, ParserResult<object> parsed, IEnumerable<string> argsToParse, bool hasHelpOrVersion)
            {
                return parsed.MapResult(
                    (VerbSet1 _) => parser.ParseSetArguments<VerbSet1, VerbSet2, VerbSet3, VerbSet4, VerbSet5, VerbSet6, VerbSet7,
                        VerbSet8, VerbSet9, VerbSet10, VerbSet11, VerbSet12, VerbSet13, VerbSet14, VerbSet15>(argsToParse, null, hasHelpOrVersion, typeof(AddVerb1), typeof(EchoVerb1)),
                    (_) => throw new Exception("This mapped path should not have been called."));
            }

            parser.ParseSetArguments<VerbSet1>(new string[] { "verbset1" }, onVerbSetParsed);

            TestHelpWrittenForVerbs(helpBuilder, typeof(VerbSet1), typeof(VerbSet2), typeof(VerbSet3), typeof(VerbSet4), typeof(VerbSet5), typeof(VerbSet6), typeof(VerbSet7),
                typeof(VerbSet8), typeof(VerbSet9), typeof(VerbSet10), typeof(VerbSet11), typeof(VerbSet12), typeof(VerbSet13), typeof(VerbSet14),
                typeof(VerbSet15), typeof(AddVerb1), typeof(EchoVerb1));
        }

        [Fact]
        public void With_Sixteen_Generic_VerbSet_Types_Nested()
        {
            StringBuilder helpBuilder = new StringBuilder();
            StringWriter helpWriter = new StringWriter(helpBuilder);

            Parser parser = new Parser(settings => settings.HelpWriter = helpWriter);

            ParserResult<object> onVerbSetParsed(Parser p, ParserResult<object> parsed, IEnumerable<string> argsToParse, bool hasHelpOrVersion)
            {
                return parsed.MapResult(
                    (VerbSet1 _) => parser.ParseSetArguments<VerbSet1, VerbSet2, VerbSet3, VerbSet4, VerbSet5, VerbSet6, VerbSet7,
                        VerbSet8, VerbSet9, VerbSet10, VerbSet11, VerbSet12, VerbSet13, VerbSet14, VerbSet15, VerbSet16>(argsToParse, null, hasHelpOrVersion, typeof(AddVerb1), typeof(EchoVerb1)),
                    (_) => throw new Exception("This mapped path should not have been called."));
            }

            parser.ParseSetArguments<VerbSet1>(new string[] { "verbset1" }, onVerbSetParsed);

            TestHelpWrittenForVerbs(helpBuilder, typeof(VerbSet1), typeof(VerbSet2), typeof(VerbSet3), typeof(VerbSet4), typeof(VerbSet5), typeof(VerbSet6), typeof(VerbSet7),
                typeof(VerbSet8), typeof(VerbSet9), typeof(VerbSet10), typeof(VerbSet11), typeof(VerbSet12), typeof(VerbSet13), typeof(VerbSet14),
                typeof(VerbSet15), typeof(VerbSet16), typeof(AddVerb1), typeof(EchoVerb1));
        }

        private void TestHelpWrittenForVerbs(StringBuilder helpBuilder, params Type[] verbsInHelp)
        {
            string[] helpLines = helpBuilder.ToString().Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            int helpIndex = 4;

            foreach (Type verbType in verbsInHelp)
            {
                VerbAttribute verbAttribute = (VerbAttribute)verbType.GetCustomAttributes(typeof(VerbAttribute), false)[0];
                NormalizeHelpLine(helpLines[helpIndex]).Should().Be(NormalizeHelpLine($"{verbAttribute.Name}{verbAttribute.HelpText}"));
                helpIndex++;
            }
        }

        private string NormalizeHelpLine(string helpLine)
        {
            return new string(helpLine.Where(x => !char.IsWhiteSpace(x)).ToArray());
        }
    }
}
