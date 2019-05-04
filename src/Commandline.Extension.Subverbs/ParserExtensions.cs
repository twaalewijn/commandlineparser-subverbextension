using System;
using System.Collections.Generic;
using System.Linq;
using Commandline.Extension.Subverbs;

namespace CommandLine
{
    public static class ParserExtensions
    {
        /// <summary>
        /// Parses the passed arguments for both verbsets and regular verbs.
        /// </summary>
        /// <param name="parser">The <see cref="Parser"/> to use to parse the arguments.</param>
        /// <param name="args">The arguments to parse.</param>
        /// <param name="verbSetTypes">The empty verb types that should be considered as verbsets while parsing.</param>
        /// <param name="verbTypes">The regular verb types to parse besides the verbsets.</param>
        /// <param name="onVerbsetParsed">A method that is called when a verbset verb has been parsed.</param>
        /// <returns>A <see cref="ParserResult{T}"/> with either the verb type that was parsed or one or more <see cref="Error"/>s.</returns>
        public static ParserResult<object> ParseSetArguments(this Parser parser,
            IEnumerable<string> args,
            IEnumerable<Type> verbSetTypes,
            IEnumerable<Type> verbTypes,
            Func<Parser, Parsed<object>, IEnumerable<string>, bool, ParserResult<object>> onVerbsetParsed)
        {
            IEnumerable<string> passedArgs = args ?? Enumerable.Empty<string>();
            Type[] verbArray = verbTypes?.ToArray() ?? new Type[0];

            // Copy parser with settings except for the HelpWriter to prevent help being written while checking for verbsets.
            Parser p = new Parser(settings =>
            {
                settings.AutoHelp = parser.Settings.AutoHelp;
                settings.AutoVersion = parser.Settings.AutoVersion;
                settings.CaseInsensitiveEnumValues = parser.Settings.CaseInsensitiveEnumValues;
                settings.CaseSensitive = parser.Settings.CaseSensitive;
                settings.EnableDashDash = parser.Settings.EnableDashDash;
                settings.IgnoreUnknownArguments = parser.Settings.IgnoreUnknownArguments;
                settings.MaximumDisplayWidth = parser.Settings.MaximumDisplayWidth;
                settings.ParsingCulture = parser.Settings.ParsingCulture;
            });

            ParserResult<object> result = null;

            if (verbArray.Length > 0)
            {
                // Check for regular verbs first.
                result = p.ParseArguments(args, verbArray);

                if (result.Tag == ParserResultType.Parsed)
                {
                    return result;
                }
            }

            Type[] verbSetArray = verbSetTypes?.ToArray() ?? new Type[0];

            if (verbSetArray.Length > 0)
            {
                AnalyzedVerbSetArgument analyzed = DetermineVerbSetArgToParse(passedArgs);

                string argToParse = analyzed.ArgToParse;
                bool containsHelpVerb = analyzed.ContainsHelpVerb;
                bool containsHelpOrVersionOption = analyzed.ContainsHelpOrVersionOption;

                // Parse for verbsets.
                result = p.ParseArguments(new string[] { argToParse }, verbSetArray);

                if (result.Tag == ParserResultType.Parsed)
                {
                    if (onVerbsetParsed != null)
                    {
                        IEnumerable<string> subArgsToParse = containsHelpVerb
                            ? passedArgs.Take(1)
                            : containsHelpOrVersionOption
                                ? passedArgs.Skip(1).Take(1)
                                : passedArgs.Skip(1);

                        return onVerbsetParsed(parser, (Parsed<object>)result, subArgsToParse, containsHelpVerb || containsHelpOrVersionOption);
                    }

                    return result;
                }
            }

            // Both regular verbs and verbsets failed to parse.
            // Combine both verb arrays and parse again using the actual parser to account for help/errors.
            Type[] fullVerbArray = new Type[verbSetArray.Length + verbArray.Length];
            verbSetArray.CopyTo(fullVerbArray, 0);
            verbArray.CopyTo(fullVerbArray, verbSetArray.Length);

            return parser.ParseArguments(passedArgs, fullVerbArray);
        }

        /// <summary>
        /// Parses the passed arguments for both verbsets and regular verbs.
        /// </summary>
        /// <param name="parser">The <see cref="Parser"/> to use to parse the arguments.</param>
        /// <param name="args">The arguments to parse.</param>
        /// <param name="verbSetTypes">The empty verb types that should be considered as verbsets while parsing.</param>
        /// <param name="verbTypes">The regular verb types to parse besides the verbsets.</param>
        /// <param name="onVerbsetParsed">A method that is called when a verbset verb has been parsed.</param>
        /// <param name="helpOrVersionRequested">Whether or not the previous verbset was called with a help verb or help/version option.</param>
        /// <returns>A <see cref="ParserResult{T}"/> with either the verb type that was parsed or one or more <see cref="Error"/>s.</returns>
        public static ParserResult<object> ParseSetArguments(this Parser parser,
            IEnumerable<string> args,
            IEnumerable<Type> verbSetTypes,
            IEnumerable<Type> verbTypes,
            Func<Parser, Parsed<object>, IEnumerable<string>, bool, ParserResult<object>> onVerbsetParsed,
            bool helpOrVersionRequested)
        {
            if (helpOrVersionRequested)
            {
                IEnumerable<Type> verbSets = verbSetTypes ?? Enumerable.Empty<Type>();
                IEnumerable<Type> verbs = verbTypes ?? Enumerable.Empty<Type>();
                return parser.ParseArguments(args, verbSets.Concat(verbs).ToArray());
            }

            return parser.ParseSetArguments(args, verbSetTypes, verbTypes, onVerbsetParsed);
        }

        private static AnalyzedVerbSetArgument DetermineVerbSetArgToParse(IEnumerable<string> args)
        {
            int argCount = args.Count();
            bool containsHelpVerb = false;
            bool containsHelpOrVersionOption = false;
            string argToParse = null;

            if (argCount == 0)
            {
                return new AnalyzedVerbSetArgument(string.Empty, false, false);
            }
            else if (argCount == 1)
            {
                argToParse = args.ElementAt(0);

                if (argToParse == "help" || argToParse == "version")
                {
                    containsHelpVerb = true;
                }
                else if (argToParse == "--help" || argToParse == "--version")
                {
                    containsHelpOrVersionOption = true;
                }

                return new AnalyzedVerbSetArgument(argToParse, containsHelpVerb, containsHelpOrVersionOption);
            }

            IEnumerable<string> argsToParse = args.TakeWhile(x => !x.StartsWith("-"));

            string firstArg = null;

            if (!argsToParse.Any())
            {
                firstArg = args.First();
                containsHelpOrVersionOption = firstArg == "--help" || firstArg == "--version";

                return new AnalyzedVerbSetArgument(string.Empty, false, containsHelpOrVersionOption);
            }

            firstArg = argsToParse.First();
            argToParse = firstArg;

            if (firstArg == "help")
            {
                argToParse = args.Skip(1).TakeWhile(x => !x.StartsWith("-")).FirstOrDefault() ?? string.Empty;

                containsHelpVerb = true;
            }
            else if (args.ElementAt(1) == "--help" || args.ElementAt(1) == "--version")
            {
                containsHelpOrVersionOption = true;
            }

            return new AnalyzedVerbSetArgument(argToParse, containsHelpVerb, containsHelpOrVersionOption);
        }
    }
}
