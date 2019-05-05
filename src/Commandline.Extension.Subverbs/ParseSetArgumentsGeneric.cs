using System;
using System.Collections.Generic;

namespace CommandLine
{
    public static partial class ParserExtensions
    {
        /// <summary>
        /// Parses the passed arguments for both verbsets and regular verbs.
        /// </summary>
        /// <param name="parser">The <see cref="Parser"/> to use to parse the arguments.</param>
        /// <param name="args">The arguments to parse.</param>
        /// <param name="onVerbsetParsed">A method that is called when a verbset verb has been parsed.</param>
        /// <param name="verbTypes">The regular verb types to parse besides the verbsets.</param>
        /// <typeparam name="T">The type to parse as a verbset.</typeparam>
        /// <returns>A <see cref="ParserResult{T}"/> with either the verb type that was parsed or one or more <see cref="Error"/>s.</returns>
        public static ParserResult<object> ParseSetArguments<T>(this Parser parser,
            IEnumerable<string> args,
            Func<Parser, ParserResult<object>, IEnumerable<string>, bool, ParserResult<object>> onVerbsetParsed,
            params Type[] verbTypes)
        {
            return ParseSetArguments<T>(parser,
                args,
                onVerbsetParsed,
                false,
                verbTypes);
        }

        /// <summary>
        /// Parses the passed arguments for both verbsets and regular verbs.
        /// </summary>
        /// <param name="parser">The <see cref="Parser"/> to use to parse the arguments.</param>
        /// <param name="args">The arguments to parse.</param>
        /// <param name="onVerbsetParsed">A method that is called when a verbset verb has been parsed.</param>
        /// <param name="verbTypes">The regular verb types to parse besides the verbsets.</param>
        /// <typeparam name="T1">The first type to parse as a verbset.</typeparam>
        /// <typeparam name="T2">The second type to parse as a verbset.</typeparam>
        /// <returns>A <see cref="ParserResult{T}"/> with either the verb type that was parsed or one or more <see cref="Error"/>s.</returns>
        public static ParserResult<object> ParseSetArguments<T1, T2>(this Parser parser,
            IEnumerable<string> args,
            Func<Parser, ParserResult<object>, IEnumerable<string>, bool, ParserResult<object>> onVerbsetParsed,
            params Type[] verbTypes)
        {
            return ParseSetArguments<T1, T2>(parser,
                args,
                onVerbsetParsed,
                false,
                verbTypes);
        }

        /// <summary>
        /// Parses the passed arguments for both verbsets and regular verbs.
        /// </summary>
        /// <param name="parser">The <see cref="Parser"/> to use to parse the arguments.</param>
        /// <param name="args">The arguments to parse.</param>
        /// <param name="onVerbsetParsed">A method that is called when a verbset verb has been parsed.</param>
        /// <param name="verbTypes">The regular verb types to parse besides the verbsets.</param>
        /// <typeparam name="T1">The first type to parse as a verbset.</typeparam>
        /// <typeparam name="T2">The second type to parse as a verbset.</typeparam>
        /// <typeparam name="T3">The third type to parse as a verbset.</typeparam>
        /// <returns>A <see cref="ParserResult{T}"/> with either the verb type that was parsed or one or more <see cref="Error"/>s.</returns>
        public static ParserResult<object> ParseSetArguments<T1, T2, T3>(this Parser parser,
            IEnumerable<string> args,
            Func<Parser, ParserResult<object>, IEnumerable<string>, bool, ParserResult<object>> onVerbsetParsed,
            params Type[] verbTypes)
        {
            return ParseSetArguments<T1, T2, T3>(parser,
                args,
                onVerbsetParsed,
                false,
                verbTypes);
        }

        /// <summary>
        /// Parses the passed arguments for both verbsets and regular verbs.
        /// </summary>
        /// <param name="parser">The <see cref="Parser"/> to use to parse the arguments.</param>
        /// <param name="args">The arguments to parse.</param>
        /// <param name="onVerbsetParsed">A method that is called when a verbset verb has been parsed.</param>
        /// <param name="verbTypes">The regular verb types to parse besides the verbsets.</param>
        /// <typeparam name="T1">The first type to parse as a verbset.</typeparam>
        /// <typeparam name="T2">The second type to parse as a verbset.</typeparam>
        /// <typeparam name="T3">The third type to parse as a verbset.</typeparam>
        /// <typeparam name="T4">The fourth type to parse as a verbset.</typeparam>
        /// <returns>A <see cref="ParserResult{T}"/> with either the verb type that was parsed or one or more <see cref="Error"/>s.</returns>
        public static ParserResult<object> ParseSetArguments<T1, T2, T3, T4>(this Parser parser,
            IEnumerable<string> args,
            Func<Parser, ParserResult<object>, IEnumerable<string>, bool, ParserResult<object>> onVerbsetParsed,
            params Type[] verbTypes)
        {
            return ParseSetArguments<T1, T2, T3, T4>(parser,
                args,
                onVerbsetParsed,
                false,
                verbTypes);
        }

        /// <summary>
        /// Parses the passed arguments for both verbsets and regular verbs.
        /// </summary>
        /// <param name="parser">The <see cref="Parser"/> to use to parse the arguments.</param>
        /// <param name="args">The arguments to parse.</param>
        /// <param name="onVerbsetParsed">A method that is called when a verbset verb has been parsed.</param>
        /// <param name="verbTypes">The regular verb types to parse besides the verbsets.</param>
        /// <typeparam name="T1">The first type to parse as a verbset.</typeparam>
        /// <typeparam name="T2">The second type to parse as a verbset.</typeparam>
        /// <typeparam name="T3">The third type to parse as a verbset.</typeparam>
        /// <typeparam name="T4">The fourth type to parse as a verbset.</typeparam>
        /// <typeparam name="T5">The fifth type to parse as a verbset.</typeparam>
        /// <returns>A <see cref="ParserResult{T}"/> with either the verb type that was parsed or one or more <see cref="Error"/>s.</returns>
        public static ParserResult<object> ParseSetArguments<T1, T2, T3, T4, T5>(this Parser parser,
            IEnumerable<string> args,
            Func<Parser, ParserResult<object>, IEnumerable<string>, bool, ParserResult<object>> onVerbsetParsed,
            params Type[] verbTypes)
        {
            return ParseSetArguments<T1, T2, T3, T4, T5>(parser,
                args,
                onVerbsetParsed,
                false,
                verbTypes);
        }

        /// <summary>
        /// Parses the passed arguments for both verbsets and regular verbs.
        /// </summary>
        /// <param name="parser">The <see cref="Parser"/> to use to parse the arguments.</param>
        /// <param name="args">The arguments to parse.</param>
        /// <param name="onVerbsetParsed">A method that is called when a verbset verb has been parsed.</param>
        /// <param name="verbTypes">The regular verb types to parse besides the verbsets.</param>
        /// <typeparam name="T1">The first type to parse as a verbset.</typeparam>
        /// <typeparam name="T2">The second type to parse as a verbset.</typeparam>
        /// <typeparam name="T3">The third type to parse as a verbset.</typeparam>
        /// <typeparam name="T4">The fourth type to parse as a verbset.</typeparam>
        /// <typeparam name="T5">The fifth type to parse as a verbset.</typeparam>
        /// <typeparam name="T6">The sixth type to parse as a verbset.</typeparam>
        /// <returns>A <see cref="ParserResult{T}"/> with either the verb type that was parsed or one or more <see cref="Error"/>s.</returns>
        public static ParserResult<object> ParseSetArguments<T1, T2, T3, T4, T5, T6>(this Parser parser,
            IEnumerable<string> args,
            Func<Parser, ParserResult<object>, IEnumerable<string>, bool, ParserResult<object>> onVerbsetParsed,
            params Type[] verbTypes)
        {
            return ParseSetArguments<T1, T2, T3, T4, T5, T6>(parser,
                args,
                onVerbsetParsed,
                false,
                verbTypes);
        }

        /// <summary>
        /// Parses the passed arguments for both verbsets and regular verbs.
        /// </summary>
        /// <param name="parser">The <see cref="Parser"/> to use to parse the arguments.</param>
        /// <param name="args">The arguments to parse.</param>
        /// <param name="onVerbsetParsed">A method that is called when a verbset verb has been parsed.</param>
        /// <param name="verbTypes">The regular verb types to parse besides the verbsets.</param>
        /// <typeparam name="T1">The first type to parse as a verbset.</typeparam>
        /// <typeparam name="T2">The second type to parse as a verbset.</typeparam>
        /// <typeparam name="T3">The third type to parse as a verbset.</typeparam>
        /// <typeparam name="T4">The fourth type to parse as a verbset.</typeparam>
        /// <typeparam name="T5">The fifth type to parse as a verbset.</typeparam>
        /// <typeparam name="T6">The sixth type to parse as a verbset.</typeparam>
        /// <typeparam name="T6">The seventh type to parse as a verbset.</typeparam>
        /// <returns>A <see cref="ParserResult{T}"/> with either the verb type that was parsed or one or more <see cref="Error"/>s.</returns>
        public static ParserResult<object> ParseSetArguments<T1, T2, T3, T4, T5, T6, T7>(this Parser parser,
            IEnumerable<string> args,
            Func<Parser, ParserResult<object>, IEnumerable<string>, bool, ParserResult<object>> onVerbsetParsed,
            params Type[] verbTypes)
        {
            return ParseSetArguments<T1, T2, T3, T4, T5, T6, T7>(parser,
                args,
                onVerbsetParsed,
                false,
                verbTypes);
        }

        /// <summary>
        /// Parses the passed arguments for both verbsets and regular verbs.
        /// </summary>
        /// <param name="parser">The <see cref="Parser"/> to use to parse the arguments.</param>
        /// <param name="args">The arguments to parse.</param>
        /// <param name="onVerbsetParsed">A method that is called when a verbset verb has been parsed.</param>
        /// <param name="verbTypes">The regular verb types to parse besides the verbsets.</param>
        /// <typeparam name="T1">The first type to parse as a verbset.</typeparam>
        /// <typeparam name="T2">The second type to parse as a verbset.</typeparam>
        /// <typeparam name="T3">The third type to parse as a verbset.</typeparam>
        /// <typeparam name="T4">The fourth type to parse as a verbset.</typeparam>
        /// <typeparam name="T5">The fifth type to parse as a verbset.</typeparam>
        /// <typeparam name="T6">The sixth type to parse as a verbset.</typeparam>
        /// <typeparam name="T6">The seventh type to parse as a verbset.</typeparam>
        /// <typeparam name="T7">The seventh type to parse as a verbset.</typeparam>
        /// <returns>A <see cref="ParserResult{T}"/> with either the verb type that was parsed or one or more <see cref="Error"/>s.</returns>
        public static ParserResult<object> ParseSetArguments<T1, T2, T3, T4, T5, T6, T7, T8>(this Parser parser,
            IEnumerable<string> args,
            Func<Parser, ParserResult<object>, IEnumerable<string>, bool, ParserResult<object>> onVerbsetParsed,
            params Type[] verbTypes)
        {
            return ParseSetArguments<T1, T2, T3, T4, T5, T6, T7, T8>(parser,
                args,
                onVerbsetParsed,
                false,
                verbTypes);
        }

        /// <summary>
        /// Parses the passed arguments for both verbsets and regular verbs.
        /// </summary>
        /// <param name="parser">The <see cref="Parser"/> to use to parse the arguments.</param>
        /// <param name="args">The arguments to parse.</param>
        /// <param name="onVerbsetParsed">A method that is called when a verbset verb has been parsed.</param>
        /// <param name="verbTypes">The regular verb types to parse besides the verbsets.</param>
        /// <typeparam name="T1">The first type to parse as a verbset.</typeparam>
        /// <typeparam name="T2">The second type to parse as a verbset.</typeparam>
        /// <typeparam name="T3">The third type to parse as a verbset.</typeparam>
        /// <typeparam name="T4">The fourth type to parse as a verbset.</typeparam>
        /// <typeparam name="T5">The fifth type to parse as a verbset.</typeparam>
        /// <typeparam name="T6">The sixth type to parse as a verbset.</typeparam>
        /// <typeparam name="T6">The seventh type to parse as a verbset.</typeparam>
        /// <typeparam name="T7">The seventh type to parse as a verbset.</typeparam>
        /// <typeparam name="T8">The eigth type to parse as a verbset.</typeparam>
        /// <returns>A <see cref="ParserResult{T}"/> with either the verb type that was parsed or one or more <see cref="Error"/>s.</returns>
        public static ParserResult<object> ParseSetArguments<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Parser parser,
            IEnumerable<string> args,
            Func<Parser, ParserResult<object>, IEnumerable<string>, bool, ParserResult<object>> onVerbsetParsed,
            params Type[] verbTypes)
        {
            return ParseSetArguments<T1, T2, T3, T4, T5, T6, T7, T8, T9>(parser,
                args,
                onVerbsetParsed,
                false,
                verbTypes);
        }

        /// <summary>
        /// Parses the passed arguments for both verbsets and regular verbs.
        /// </summary>
        /// <param name="parser">The <see cref="Parser"/> to use to parse the arguments.</param>
        /// <param name="args">The arguments to parse.</param>
        /// <param name="onVerbsetParsed">A method that is called when a verbset verb has been parsed.</param>
        /// <param name="verbTypes">The regular verb types to parse besides the verbsets.</param>
        /// <typeparam name="T1">The first type to parse as a verbset.</typeparam>
        /// <typeparam name="T2">The second type to parse as a verbset.</typeparam>
        /// <typeparam name="T3">The third type to parse as a verbset.</typeparam>
        /// <typeparam name="T4">The fourth type to parse as a verbset.</typeparam>
        /// <typeparam name="T5">The fifth type to parse as a verbset.</typeparam>
        /// <typeparam name="T6">The sixth type to parse as a verbset.</typeparam>
        /// <typeparam name="T6">The seventh type to parse as a verbset.</typeparam>
        /// <typeparam name="T7">The seventh type to parse as a verbset.</typeparam>
        /// <typeparam name="T8">The eigth type to parse as a verbset.</typeparam>
        /// <typeparam name="T9">The ninth type to parse as a verbset.</typeparam>
        /// <typeparam name="T10">The tenth type to parse as a verbset.</typeparam>
        /// <returns>A <see cref="ParserResult{T}"/> with either the verb type that was parsed or one or more <see cref="Error"/>s.</returns>
        public static ParserResult<object> ParseSetArguments<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this Parser parser,
            IEnumerable<string> args,
            Func<Parser, ParserResult<object>, IEnumerable<string>, bool, ParserResult<object>> onVerbsetParsed,
            params Type[] verbTypes)
        {
            return ParseSetArguments<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(parser,
                args,
                onVerbsetParsed,
                false,
                verbTypes);
        }

        /// <summary>
        /// Parses the passed arguments for both verbsets and regular verbs.
        /// </summary>
        /// <param name="parser">The <see cref="Parser"/> to use to parse the arguments.</param>
        /// <param name="args">The arguments to parse.</param>
        /// <param name="onVerbsetParsed">A method that is called when a verbset verb has been parsed.</param>
        /// <param name="verbTypes">The regular verb types to parse besides the verbsets.</param>
        /// <typeparam name="T1">The first type to parse as a verbset.</typeparam>
        /// <typeparam name="T2">The second type to parse as a verbset.</typeparam>
        /// <typeparam name="T3">The third type to parse as a verbset.</typeparam>
        /// <typeparam name="T4">The fourth type to parse as a verbset.</typeparam>
        /// <typeparam name="T5">The fifth type to parse as a verbset.</typeparam>
        /// <typeparam name="T6">The sixth type to parse as a verbset.</typeparam>
        /// <typeparam name="T6">The seventh type to parse as a verbset.</typeparam>
        /// <typeparam name="T7">The seventh type to parse as a verbset.</typeparam>
        /// <typeparam name="T8">The eigth type to parse as a verbset.</typeparam>
        /// <typeparam name="T9">The ninth type to parse as a verbset.</typeparam>
        /// <typeparam name="T10">The tenth type to parse as a verbset.</typeparam>
        /// <typeparam name="T11">The eleventh type to parse as a verbset.</typeparam>
        /// <returns>A <see cref="ParserResult{T}"/> with either the verb type that was parsed or one or more <see cref="Error"/>s.</returns>
        public static ParserResult<object> ParseSetArguments<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this Parser parser,
            IEnumerable<string> args,
            Func<Parser, ParserResult<object>, IEnumerable<string>, bool, ParserResult<object>> onVerbsetParsed,
            params Type[] verbTypes)
        {
            return ParseSetArguments<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(parser,
                args,
                onVerbsetParsed,
                false,
                verbTypes);
        }

        /// <summary>
        /// Parses the passed arguments for both verbsets and regular verbs.
        /// </summary>
        /// <param name="parser">The <see cref="Parser"/> to use to parse the arguments.</param>
        /// <param name="args">The arguments to parse.</param>
        /// <param name="onVerbsetParsed">A method that is called when a verbset verb has been parsed.</param>
        /// <param name="verbTypes">The regular verb types to parse besides the verbsets.</param>
        /// <typeparam name="T1">The first type to parse as a verbset.</typeparam>
        /// <typeparam name="T2">The second type to parse as a verbset.</typeparam>
        /// <typeparam name="T3">The third type to parse as a verbset.</typeparam>
        /// <typeparam name="T4">The fourth type to parse as a verbset.</typeparam>
        /// <typeparam name="T5">The fifth type to parse as a verbset.</typeparam>
        /// <typeparam name="T6">The sixth type to parse as a verbset.</typeparam>
        /// <typeparam name="T6">The seventh type to parse as a verbset.</typeparam>
        /// <typeparam name="T7">The seventh type to parse as a verbset.</typeparam>
        /// <typeparam name="T8">The eigth type to parse as a verbset.</typeparam>
        /// <typeparam name="T9">The ninth type to parse as a verbset.</typeparam>
        /// <typeparam name="T10">The tenth type to parse as a verbset.</typeparam>
        /// <typeparam name="T11">The eleventh type to parse as a verbset.</typeparam>
        /// <typeparam name="T12">The twelfth type to parse as a verbset.</typeparam>
        /// <returns>A <see cref="ParserResult{T}"/> with either the verb type that was parsed or one or more <see cref="Error"/>s.</returns>
        public static ParserResult<object> ParseSetArguments<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this Parser parser,
            IEnumerable<string> args,
            Func<Parser, ParserResult<object>, IEnumerable<string>, bool, ParserResult<object>> onVerbsetParsed,
            params Type[] verbTypes)
        {
            return ParseSetArguments<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(parser,
                args,
                onVerbsetParsed,
                false,
                verbTypes);
        }

        /// <summary>
        /// Parses the passed arguments for both verbsets and regular verbs.
        /// </summary>
        /// <param name="parser">The <see cref="Parser"/> to use to parse the arguments.</param>
        /// <param name="args">The arguments to parse.</param>
        /// <param name="onVerbsetParsed">A method that is called when a verbset verb has been parsed.</param>
        /// <param name="verbTypes">The regular verb types to parse besides the verbsets.</param>
        /// <typeparam name="T1">The first type to parse as a verbset.</typeparam>
        /// <typeparam name="T2">The second type to parse as a verbset.</typeparam>
        /// <typeparam name="T3">The third type to parse as a verbset.</typeparam>
        /// <typeparam name="T4">The fourth type to parse as a verbset.</typeparam>
        /// <typeparam name="T5">The fifth type to parse as a verbset.</typeparam>
        /// <typeparam name="T6">The sixth type to parse as a verbset.</typeparam>
        /// <typeparam name="T6">The seventh type to parse as a verbset.</typeparam>
        /// <typeparam name="T7">The seventh type to parse as a verbset.</typeparam>
        /// <typeparam name="T8">The eigth type to parse as a verbset.</typeparam>
        /// <typeparam name="T9">The ninth type to parse as a verbset.</typeparam>
        /// <typeparam name="T10">The tenth type to parse as a verbset.</typeparam>
        /// <typeparam name="T11">The eleventh type to parse as a verbset.</typeparam>
        /// <typeparam name="T12">The twelfth type to parse as a verbset.</typeparam>
        /// <typeparam name="T13">The thirteenth type to parse as a verbset.</typeparam>
        /// <returns>A <see cref="ParserResult{T}"/> with either the verb type that was parsed or one or more <see cref="Error"/>s.</returns>
        public static ParserResult<object> ParseSetArguments<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this Parser parser,
            IEnumerable<string> args,
            Func<Parser, ParserResult<object>, IEnumerable<string>, bool, ParserResult<object>> onVerbsetParsed,
            params Type[] verbTypes)
        {
            return ParseSetArguments<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(parser,
                args,
                onVerbsetParsed,
                false,
                verbTypes);
        }

        /// <summary>
        /// Parses the passed arguments for both verbsets and regular verbs.
        /// </summary>
        /// <param name="parser">The <see cref="Parser"/> to use to parse the arguments.</param>
        /// <param name="args">The arguments to parse.</param>
        /// <param name="onVerbsetParsed">A method that is called when a verbset verb has been parsed.</param>
        /// <param name="verbTypes">The regular verb types to parse besides the verbsets.</param>
        /// <typeparam name="T1">The first type to parse as a verbset.</typeparam>
        /// <typeparam name="T2">The second type to parse as a verbset.</typeparam>
        /// <typeparam name="T3">The third type to parse as a verbset.</typeparam>
        /// <typeparam name="T4">The fourth type to parse as a verbset.</typeparam>
        /// <typeparam name="T5">The fifth type to parse as a verbset.</typeparam>
        /// <typeparam name="T6">The sixth type to parse as a verbset.</typeparam>
        /// <typeparam name="T6">The seventh type to parse as a verbset.</typeparam>
        /// <typeparam name="T7">The seventh type to parse as a verbset.</typeparam>
        /// <typeparam name="T8">The eigth type to parse as a verbset.</typeparam>
        /// <typeparam name="T9">The ninth type to parse as a verbset.</typeparam>
        /// <typeparam name="T10">The tenth type to parse as a verbset.</typeparam>
        /// <typeparam name="T11">The eleventh type to parse as a verbset.</typeparam>
        /// <typeparam name="T12">The twelfth type to parse as a verbset.</typeparam>
        /// <typeparam name="T13">The thirteenth type to parse as a verbset.</typeparam>
        /// <typeparam name="T14">The fourteenth type to parse as a verbset.</typeparam>
        /// <returns>A <see cref="ParserResult{T}"/> with either the verb type that was parsed or one or more <see cref="Error"/>s.</returns>
        public static ParserResult<object> ParseSetArguments<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this Parser parser,
            IEnumerable<string> args,
            Func<Parser, ParserResult<object>, IEnumerable<string>, bool, ParserResult<object>> onVerbsetParsed,
            params Type[] verbTypes)
        {
            return ParseSetArguments<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(parser,
                args,
                onVerbsetParsed,
                false,
                verbTypes);
        }

        /// <summary>
        /// Parses the passed arguments for both verbsets and regular verbs.
        /// </summary>
        /// <param name="parser">The <see cref="Parser"/> to use to parse the arguments.</param>
        /// <param name="args">The arguments to parse.</param>
        /// <param name="onVerbsetParsed">A method that is called when a verbset verb has been parsed.</param>
        /// <param name="verbTypes">The regular verb types to parse besides the verbsets.</param>
        /// <typeparam name="T1">The first type to parse as a verbset.</typeparam>
        /// <typeparam name="T2">The second type to parse as a verbset.</typeparam>
        /// <typeparam name="T3">The third type to parse as a verbset.</typeparam>
        /// <typeparam name="T4">The fourth type to parse as a verbset.</typeparam>
        /// <typeparam name="T5">The fifth type to parse as a verbset.</typeparam>
        /// <typeparam name="T6">The sixth type to parse as a verbset.</typeparam>
        /// <typeparam name="T6">The seventh type to parse as a verbset.</typeparam>
        /// <typeparam name="T7">The seventh type to parse as a verbset.</typeparam>
        /// <typeparam name="T8">The eigth type to parse as a verbset.</typeparam>
        /// <typeparam name="T9">The ninth type to parse as a verbset.</typeparam>
        /// <typeparam name="T10">The tenth type to parse as a verbset.</typeparam>
        /// <typeparam name="T11">The eleventh type to parse as a verbset.</typeparam>
        /// <typeparam name="T12">The twelfth type to parse as a verbset.</typeparam>
        /// <typeparam name="T13">The thirteenth type to parse as a verbset.</typeparam>
        /// <typeparam name="T14">The fourteenth type to parse as a verbset.</typeparam>
        /// <typeparam name="T15">The fifteenth type to parse as a verbset.</typeparam>
        /// <returns>A <see cref="ParserResult{T}"/> with either the verb type that was parsed or one or more <see cref="Error"/>s.</returns>
        public static ParserResult<object> ParseSetArguments<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this Parser parser,
            IEnumerable<string> args,
            Func<Parser, ParserResult<object>, IEnumerable<string>, bool, ParserResult<object>> onVerbsetParsed,
            params Type[] verbTypes)
        {
            return ParseSetArguments<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(parser,
                args,
                onVerbsetParsed,
                false,
                verbTypes);
        }

        /// <summary>
        /// Parses the passed arguments for both verbsets and regular verbs.
        /// </summary>
        /// <param name="parser">The <see cref="Parser"/> to use to parse the arguments.</param>
        /// <param name="args">The arguments to parse.</param>
        /// <param name="onVerbsetParsed">A method that is called when a verbset verb has been parsed.</param>
        /// <param name="verbTypes">The regular verb types to parse besides the verbsets.</param>
        /// <typeparam name="T1">The first type to parse as a verbset.</typeparam>
        /// <typeparam name="T2">The second type to parse as a verbset.</typeparam>
        /// <typeparam name="T3">The third type to parse as a verbset.</typeparam>
        /// <typeparam name="T4">The fourth type to parse as a verbset.</typeparam>
        /// <typeparam name="T5">The fifth type to parse as a verbset.</typeparam>
        /// <typeparam name="T6">The sixth type to parse as a verbset.</typeparam>
        /// <typeparam name="T6">The seventh type to parse as a verbset.</typeparam>
        /// <typeparam name="T7">The seventh type to parse as a verbset.</typeparam>
        /// <typeparam name="T8">The eigth type to parse as a verbset.</typeparam>
        /// <typeparam name="T9">The ninth type to parse as a verbset.</typeparam>
        /// <typeparam name="T10">The tenth type to parse as a verbset.</typeparam>
        /// <typeparam name="T11">The eleventh type to parse as a verbset.</typeparam>
        /// <typeparam name="T12">The twelfth type to parse as a verbset.</typeparam>
        /// <typeparam name="T13">The thirteenth type to parse as a verbset.</typeparam>
        /// <typeparam name="T14">The fourteenth type to parse as a verbset.</typeparam>
        /// <typeparam name="T15">The fifteenth type to parse as a verbset.</typeparam>
        /// <typeparam name="T16">The sixteenth type to parse as a verbset.</typeparam>
        /// <returns>A <see cref="ParserResult{T}"/> with either the verb type that was parsed or one or more <see cref="Error"/>s.</returns>
        public static ParserResult<object> ParseSetArguments<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this Parser parser,
            IEnumerable<string> args,
            Func<Parser, ParserResult<object>, IEnumerable<string>, bool, ParserResult<object>> onVerbsetParsed,
            params Type[] verbTypes)
        {
            return ParseSetArguments<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(parser,
                args,
                onVerbsetParsed,
                false,
                verbTypes);
        }

        /// <summary>
        /// Parses the passed arguments for both verbsets and regular verbs.
        /// </summary>
        /// <param name="parser">The <see cref="Parser"/> to use to parse the arguments.</param>
        /// <param name="args">The arguments to parse.</param>
        /// <param name="onVerbsetParsed">A method that is called when a verbset verb has been parsed.</param>
        /// <param name="helpOrVersionRequested">Whether or not the previous verbset was called with a help verb or help/version option.</param>
        /// <param name="verbTypes">The regular verb types to parse besides the verbsets.</param>
        /// <typeparam name="T">The first type to parse as a verbset.</typeparam>
        /// <returns>A <see cref="ParserResult{T}"/> with either the verb type that was parsed or one or more <see cref="Error"/>s.</returns>
        public static ParserResult<object> ParseSetArguments<T>(this Parser parser,
            IEnumerable<string> args,
            Func<Parser, ParserResult<object>, IEnumerable<string>, bool, ParserResult<object>> onVerbsetParsed,
            bool helpOrVersionRequested,
            params Type[] verbTypes)
        {
            return ParseSetArguments(parser,
                args,
                new Type[] { typeof(T) },
                verbTypes,
                onVerbsetParsed,
                helpOrVersionRequested);
        }

        /// <summary>
        /// Parses the passed arguments for both verbsets and regular verbs.
        /// </summary>
        /// <param name="parser">The <see cref="Parser"/> to use to parse the arguments.</param>
        /// <param name="args">The arguments to parse.</param>
        /// <param name="onVerbsetParsed">A method that is called when a verbset verb has been parsed.</param>
        /// <param name="helpOrVersionRequested">Whether or not the previous verbset was called with a help verb or help/version option.</param>
        /// <param name="verbTypes">The regular verb types to parse besides the verbsets.</param>
        /// <typeparam name="T1">The first type to parse as a verbset.</typeparam>
        /// <typeparam name="T2">The second type to parse as a verbset.</typeparam>
        /// <returns>A <see cref="ParserResult{T}"/> with either the verb type that was parsed or one or more <see cref="Error"/>s.</returns>
        public static ParserResult<object> ParseSetArguments<T1, T2>(this Parser parser,
            IEnumerable<string> args,
            Func<Parser, ParserResult<object>, IEnumerable<string>, bool, ParserResult<object>> onVerbsetParsed,
            bool helpOrVersionRequested,
            params Type[] verbTypes)
        {
            return ParseSetArguments(parser,
                args,
                new Type[] { typeof(T1), typeof(T2) },
                verbTypes,
                onVerbsetParsed,
                helpOrVersionRequested);
        }

        /// <summary>
        /// Parses the passed arguments for both verbsets and regular verbs.
        /// </summary>
        /// <param name="parser">The <see cref="Parser"/> to use to parse the arguments.</param>
        /// <param name="args">The arguments to parse.</param>
        /// <param name="onVerbsetParsed">A method that is called when a verbset verb has been parsed.</param>
        /// <param name="helpOrVersionRequested">Whether or not the previous verbset was called with a help verb or help/version option.</param>
        /// <param name="verbTypes">The regular verb types to parse besides the verbsets.</param>
        /// <typeparam name="T1">The first type to parse as a verbset.</typeparam>
        /// <typeparam name="T2">The second type to parse as a verbset.</typeparam>
        /// <typeparam name="T3">The third type to parse as a verbset.</typeparam>
        /// <returns>A <see cref="ParserResult{T}"/> with either the verb type that was parsed or one or more <see cref="Error"/>s.</returns>
        public static ParserResult<object> ParseSetArguments<T1, T2, T3>(this Parser parser,
            IEnumerable<string> args,
            Func<Parser, ParserResult<object>, IEnumerable<string>, bool, ParserResult<object>> onVerbsetParsed,
            bool helpOrVersionRequested,
            params Type[] verbTypes)
        {
            return ParseSetArguments(parser,
                args,
                new Type[] { typeof(T1), typeof(T2), typeof(T3) },
                verbTypes,
                onVerbsetParsed,
                helpOrVersionRequested);
        }

        /// <summary>
        /// Parses the passed arguments for both verbsets and regular verbs.
        /// </summary>
        /// <param name="parser">The <see cref="Parser"/> to use to parse the arguments.</param>
        /// <param name="args">The arguments to parse.</param>
        /// <param name="onVerbsetParsed">A method that is called when a verbset verb has been parsed.</param>
        /// <param name="helpOrVersionRequested">Whether or not the previous verbset was called with a help verb or help/version option.</param>
        /// <param name="verbTypes">The regular verb types to parse besides the verbsets.</param>
        /// <typeparam name="T1">The first type to parse as a verbset.</typeparam>
        /// <typeparam name="T2">The second type to parse as a verbset.</typeparam>
        /// <typeparam name="T3">The third type to parse as a verbset.</typeparam>
        /// <typeparam name="T4">The fourth type to parse as a verbset.</typeparam>
        /// <returns>A <see cref="ParserResult{T}"/> with either the verb type that was parsed or one or more <see cref="Error"/>s.</returns>
        public static ParserResult<object> ParseSetArguments<T1, T2, T3, T4>(this Parser parser,
            IEnumerable<string> args,
            Func<Parser, ParserResult<object>, IEnumerable<string>, bool, ParserResult<object>> onVerbsetParsed,
            bool helpOrVersionRequested,
            params Type[] verbTypes)
        {
            return ParseSetArguments(parser,
                args,
                new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) },
                verbTypes,
                onVerbsetParsed,
                helpOrVersionRequested);
        }

        /// <summary>
        /// Parses the passed arguments for both verbsets and regular verbs.
        /// </summary>
        /// <param name="parser">The <see cref="Parser"/> to use to parse the arguments.</param>
        /// <param name="args">The arguments to parse.</param>
        /// <param name="onVerbsetParsed">A method that is called when a verbset verb has been parsed.</param>
        /// <param name="helpOrVersionRequested">Whether or not the previous verbset was called with a help verb or help/version option.</param>
        /// <param name="verbTypes">The regular verb types to parse besides the verbsets.</param>
        /// <typeparam name="T1">The first type to parse as a verbset.</typeparam>
        /// <typeparam name="T2">The second type to parse as a verbset.</typeparam>
        /// <typeparam name="T3">The third type to parse as a verbset.</typeparam>
        /// <typeparam name="T4">The fourth type to parse as a verbset.</typeparam>
        /// <typeparam name="T5">The fifth type to parse as a verbset.</typeparam>
        /// <returns>A <see cref="ParserResult{T}"/> with either the verb type that was parsed or one or more <see cref="Error"/>s.</returns>
        public static ParserResult<object> ParseSetArguments<T1, T2, T3, T4, T5>(this Parser parser,
            IEnumerable<string> args,
            Func<Parser, ParserResult<object>, IEnumerable<string>, bool, ParserResult<object>> onVerbsetParsed,
            bool helpOrVersionRequested,
            params Type[] verbTypes)
        {
            return ParseSetArguments(parser,
                args,
                new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5) },
                verbTypes,
                onVerbsetParsed,
                helpOrVersionRequested);
        }

        /// <summary>
        /// Parses the passed arguments for both verbsets and regular verbs.
        /// </summary>
        /// <param name="parser">The <see cref="Parser"/> to use to parse the arguments.</param>
        /// <param name="args">The arguments to parse.</param>
        /// <param name="onVerbsetParsed">A method that is called when a verbset verb has been parsed.</param>
        /// <param name="helpOrVersionRequested">Whether or not the previous verbset was called with a help verb or help/version option.</param>
        /// <param name="verbTypes">The regular verb types to parse besides the verbsets.</param>
        /// <typeparam name="T1">The first type to parse as a verbset.</typeparam>
        /// <typeparam name="T2">The second type to parse as a verbset.</typeparam>
        /// <typeparam name="T3">The third type to parse as a verbset.</typeparam>
        /// <typeparam name="T4">The fourth type to parse as a verbset.</typeparam>
        /// <typeparam name="T5">The fifth type to parse as a verbset.</typeparam>
        /// <typeparam name="T6">The sixth type to parse as a verbset.</typeparam>
        /// <typeparam name="T6">The seventh type to parse as a verbset.</typeparam>
        /// <returns>A <see cref="ParserResult{T}"/> with either the verb type that was parsed or one or more <see cref="Error"/>s.</returns>
        public static ParserResult<object> ParseSetArguments<T1, T2, T3, T4, T5, T6>(this Parser parser,
            IEnumerable<string> args,
            Func<Parser, ParserResult<object>, IEnumerable<string>, bool, ParserResult<object>> onVerbsetParsed,
            bool helpOrVersionRequested,
            params Type[] verbTypes)
        {
            return ParseSetArguments(parser,
                args,
                new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6) },
                verbTypes,
                onVerbsetParsed,
                helpOrVersionRequested);
        }

        /// <summary>
        /// Parses the passed arguments for both verbsets and regular verbs.
        /// </summary>
        /// <param name="parser">The <see cref="Parser"/> to use to parse the arguments.</param>
        /// <param name="args">The arguments to parse.</param>
        /// <param name="onVerbsetParsed">A method that is called when a verbset verb has been parsed.</param>
        /// <param name="helpOrVersionRequested">Whether or not the previous verbset was called with a help verb or help/version option.</param>
        /// <param name="verbTypes">The regular verb types to parse besides the verbsets.</param>
        /// <typeparam name="T1">The first type to parse as a verbset.</typeparam>
        /// <typeparam name="T2">The second type to parse as a verbset.</typeparam>
        /// <typeparam name="T3">The third type to parse as a verbset.</typeparam>
        /// <typeparam name="T4">The fourth type to parse as a verbset.</typeparam>
        /// <typeparam name="T5">The fifth type to parse as a verbset.</typeparam>
        /// <typeparam name="T6">The sixth type to parse as a verbset.</typeparam>
        /// <typeparam name="T6">The seventh type to parse as a verbset.</typeparam>
        /// <typeparam name="T7">The seventh type to parse as a verbset.</typeparam>
        /// <returns>A <see cref="ParserResult{T}"/> with either the verb type that was parsed or one or more <see cref="Error"/>s.</returns>
        public static ParserResult<object> ParseSetArguments<T1, T2, T3, T4, T5, T6, T7>(this Parser parser,
            IEnumerable<string> args,
            Func<Parser, ParserResult<object>, IEnumerable<string>, bool, ParserResult<object>> onVerbsetParsed,
            bool helpOrVersionRequested,
            params Type[] verbTypes)
        {
            return ParseSetArguments(parser,
                args,
                new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7) },
                verbTypes,
                onVerbsetParsed,
                helpOrVersionRequested);
        }

        /// <summary>
        /// Parses the passed arguments for both verbsets and regular verbs.
        /// </summary>
        /// <param name="parser">The <see cref="Parser"/> to use to parse the arguments.</param>
        /// <param name="args">The arguments to parse.</param>
        /// <param name="onVerbsetParsed">A method that is called when a verbset verb has been parsed.</param>
        /// <param name="helpOrVersionRequested">Whether or not the previous verbset was called with a help verb or help/version option.</param>
        /// <param name="verbTypes">The regular verb types to parse besides the verbsets.</param>
        /// <typeparam name="T1">The first type to parse as a verbset.</typeparam>
        /// <typeparam name="T2">The second type to parse as a verbset.</typeparam>
        /// <typeparam name="T3">The third type to parse as a verbset.</typeparam>
        /// <typeparam name="T4">The fourth type to parse as a verbset.</typeparam>
        /// <typeparam name="T5">The fifth type to parse as a verbset.</typeparam>
        /// <typeparam name="T6">The sixth type to parse as a verbset.</typeparam>
        /// <typeparam name="T6">The seventh type to parse as a verbset.</typeparam>
        /// <typeparam name="T7">The seventh type to parse as a verbset.</typeparam>
        /// <typeparam name="T8">The eigth type to parse as a verbset.</typeparam>
        /// <returns>A <see cref="ParserResult{T}"/> with either the verb type that was parsed or one or more <see cref="Error"/>s.</returns>
        public static ParserResult<object> ParseSetArguments<T1, T2, T3, T4, T5, T6, T7, T8>(this Parser parser,
            IEnumerable<string> args,
            Func<Parser, ParserResult<object>, IEnumerable<string>, bool, ParserResult<object>> onVerbsetParsed,
            bool helpOrVersionRequested,
            params Type[] verbTypes)
        {
            return ParseSetArguments(parser,
                args,
                new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8) },
                verbTypes,
                onVerbsetParsed,
                helpOrVersionRequested);
        }

        /// <summary>
        /// Parses the passed arguments for both verbsets and regular verbs.
        /// </summary>
        /// <param name="parser">The <see cref="Parser"/> to use to parse the arguments.</param>
        /// <param name="args">The arguments to parse.</param>
        /// <param name="onVerbsetParsed">A method that is called when a verbset verb has been parsed.</param>
        /// <param name="helpOrVersionRequested">Whether or not the previous verbset was called with a help verb or help/version option.</param>
        /// <param name="verbTypes">The regular verb types to parse besides the verbsets.</param>
        /// <typeparam name="T1">The first type to parse as a verbset.</typeparam>
        /// <typeparam name="T2">The second type to parse as a verbset.</typeparam>
        /// <typeparam name="T3">The third type to parse as a verbset.</typeparam>
        /// <typeparam name="T4">The fourth type to parse as a verbset.</typeparam>
        /// <typeparam name="T5">The fifth type to parse as a verbset.</typeparam>
        /// <typeparam name="T6">The sixth type to parse as a verbset.</typeparam>
        /// <typeparam name="T6">The seventh type to parse as a verbset.</typeparam>
        /// <typeparam name="T7">The seventh type to parse as a verbset.</typeparam>
        /// <typeparam name="T8">The eigth type to parse as a verbset.</typeparam>
        /// <typeparam name="T9">The ninth type to parse as a verbset.</typeparam>
        /// <returns>A <see cref="ParserResult{T}"/> with either the verb type that was parsed or one or more <see cref="Error"/>s.</returns>
        public static ParserResult<object> ParseSetArguments<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Parser parser,
            IEnumerable<string> args,
            Func<Parser, ParserResult<object>, IEnumerable<string>, bool, ParserResult<object>> onVerbsetParsed,
            bool helpOrVersionRequested,
            params Type[] verbTypes)
        {
            return ParseSetArguments(parser,
                args,
                new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9) },
                verbTypes,
                onVerbsetParsed,
                helpOrVersionRequested);
        }

        /// <summary>
        /// Parses the passed arguments for both verbsets and regular verbs.
        /// </summary>
        /// <param name="parser">The <see cref="Parser"/> to use to parse the arguments.</param>
        /// <param name="args">The arguments to parse.</param>
        /// <param name="onVerbsetParsed">A method that is called when a verbset verb has been parsed.</param>
        /// <param name="helpOrVersionRequested">Whether or not the previous verbset was called with a help verb or help/version option.</param>
        /// <param name="verbTypes">The regular verb types to parse besides the verbsets.</param>
        /// <typeparam name="T1">The first type to parse as a verbset.</typeparam>
        /// <typeparam name="T2">The second type to parse as a verbset.</typeparam>
        /// <typeparam name="T3">The third type to parse as a verbset.</typeparam>
        /// <typeparam name="T4">The fourth type to parse as a verbset.</typeparam>
        /// <typeparam name="T5">The fifth type to parse as a verbset.</typeparam>
        /// <typeparam name="T6">The sixth type to parse as a verbset.</typeparam>
        /// <typeparam name="T6">The seventh type to parse as a verbset.</typeparam>
        /// <typeparam name="T7">The seventh type to parse as a verbset.</typeparam>
        /// <typeparam name="T8">The eigth type to parse as a verbset.</typeparam>
        /// <typeparam name="T9">The ninth type to parse as a verbset.</typeparam>
        /// <typeparam name="T10">The tenth type to parse as a verbset.</typeparam>
        /// <returns>A <see cref="ParserResult{T}"/> with either the verb type that was parsed or one or more <see cref="Error"/>s.</returns>
        public static ParserResult<object> ParseSetArguments<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this Parser parser,
            IEnumerable<string> args,
            Func<Parser, ParserResult<object>, IEnumerable<string>, bool, ParserResult<object>> onVerbsetParsed,
            bool helpOrVersionRequested,
            params Type[] verbTypes)
        {
            return ParseSetArguments(parser,
                args,
                new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9),
                    typeof(T10) },
                verbTypes,
                onVerbsetParsed,
                helpOrVersionRequested);
        }

        /// <summary>
        /// Parses the passed arguments for both verbsets and regular verbs.
        /// </summary>
        /// <param name="parser">The <see cref="Parser"/> to use to parse the arguments.</param>
        /// <param name="args">The arguments to parse.</param>
        /// <param name="onVerbsetParsed">A method that is called when a verbset verb has been parsed.</param>
        /// <param name="helpOrVersionRequested">Whether or not the previous verbset was called with a help verb or help/version option.</param>
        /// <param name="verbTypes">The regular verb types to parse besides the verbsets.</param>
        /// <typeparam name="T1">The first type to parse as a verbset.</typeparam>
        /// <typeparam name="T2">The second type to parse as a verbset.</typeparam>
        /// <typeparam name="T3">The third type to parse as a verbset.</typeparam>
        /// <typeparam name="T4">The fourth type to parse as a verbset.</typeparam>
        /// <typeparam name="T5">The fifth type to parse as a verbset.</typeparam>
        /// <typeparam name="T6">The sixth type to parse as a verbset.</typeparam>
        /// <typeparam name="T6">The seventh type to parse as a verbset.</typeparam>
        /// <typeparam name="T7">The seventh type to parse as a verbset.</typeparam>
        /// <typeparam name="T8">The eigth type to parse as a verbset.</typeparam>
        /// <typeparam name="T9">The ninth type to parse as a verbset.</typeparam>
        /// <typeparam name="T10">The tenth type to parse as a verbset.</typeparam>
        /// <typeparam name="T11">The eleventh type to parse as a verbset.</typeparam>
        /// <returns>A <see cref="ParserResult{T}"/> with either the verb type that was parsed or one or more <see cref="Error"/>s.</returns>
        public static ParserResult<object> ParseSetArguments<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this Parser parser,
            IEnumerable<string> args,
            Func<Parser, ParserResult<object>, IEnumerable<string>, bool, ParserResult<object>> onVerbsetParsed,
            bool helpOrVersionRequested,
            params Type[] verbTypes)
        {
            return ParseSetArguments(parser,
                args,
                new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9),
                    typeof(T10), typeof(T11) },
                verbTypes,
                onVerbsetParsed,
                helpOrVersionRequested);
        }

        /// <summary>
        /// Parses the passed arguments for both verbsets and regular verbs.
        /// </summary>
        /// <param name="parser">The <see cref="Parser"/> to use to parse the arguments.</param>
        /// <param name="args">The arguments to parse.</param>
        /// <param name="onVerbsetParsed">A method that is called when a verbset verb has been parsed.</param>
        /// <param name="helpOrVersionRequested">Whether or not the previous verbset was called with a help verb or help/version option.</param>
        /// <param name="verbTypes">The regular verb types to parse besides the verbsets.</param>
        /// <typeparam name="T1">The first type to parse as a verbset.</typeparam>
        /// <typeparam name="T2">The second type to parse as a verbset.</typeparam>
        /// <typeparam name="T3">The third type to parse as a verbset.</typeparam>
        /// <typeparam name="T4">The fourth type to parse as a verbset.</typeparam>
        /// <typeparam name="T5">The fifth type to parse as a verbset.</typeparam>
        /// <typeparam name="T6">The sixth type to parse as a verbset.</typeparam>
        /// <typeparam name="T6">The seventh type to parse as a verbset.</typeparam>
        /// <typeparam name="T7">The seventh type to parse as a verbset.</typeparam>
        /// <typeparam name="T8">The eigth type to parse as a verbset.</typeparam>
        /// <typeparam name="T9">The ninth type to parse as a verbset.</typeparam>
        /// <typeparam name="T10">The tenth type to parse as a verbset.</typeparam>
        /// <typeparam name="T11">The eleventh type to parse as a verbset.</typeparam>
        /// <typeparam name="T12">The twelfth type to parse as a verbset.</typeparam>
        /// <returns>A <see cref="ParserResult{T}"/> with either the verb type that was parsed or one or more <see cref="Error"/>s.</returns>
        public static ParserResult<object> ParseSetArguments<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this Parser parser,
            IEnumerable<string> args,
            Func<Parser, ParserResult<object>, IEnumerable<string>, bool, ParserResult<object>> onVerbsetParsed,
            bool helpOrVersionRequested,
            params Type[] verbTypes)
        {
            return ParseSetArguments(parser,
                args,
                new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9),
                    typeof(T10), typeof(T11), typeof(T12) },
                verbTypes,
                onVerbsetParsed,
                helpOrVersionRequested);
        }

        /// <summary>
        /// Parses the passed arguments for both verbsets and regular verbs.
        /// </summary>
        /// <param name="parser">The <see cref="Parser"/> to use to parse the arguments.</param>
        /// <param name="args">The arguments to parse.</param>
        /// <param name="onVerbsetParsed">A method that is called when a verbset verb has been parsed.</param>
        /// <param name="helpOrVersionRequested">Whether or not the previous verbset was called with a help verb or help/version option.</param>
        /// <param name="verbTypes">The regular verb types to parse besides the verbsets.</param>
        /// <typeparam name="T1">The first type to parse as a verbset.</typeparam>
        /// <typeparam name="T2">The second type to parse as a verbset.</typeparam>
        /// <typeparam name="T3">The third type to parse as a verbset.</typeparam>
        /// <typeparam name="T4">The fourth type to parse as a verbset.</typeparam>
        /// <typeparam name="T5">The fifth type to parse as a verbset.</typeparam>
        /// <typeparam name="T6">The sixth type to parse as a verbset.</typeparam>
        /// <typeparam name="T6">The seventh type to parse as a verbset.</typeparam>
        /// <typeparam name="T7">The seventh type to parse as a verbset.</typeparam>
        /// <typeparam name="T8">The eigth type to parse as a verbset.</typeparam>
        /// <typeparam name="T9">The ninth type to parse as a verbset.</typeparam>
        /// <typeparam name="T10">The tenth type to parse as a verbset.</typeparam>
        /// <typeparam name="T11">The eleventh type to parse as a verbset.</typeparam>
        /// <typeparam name="T12">The twelfth type to parse as a verbset.</typeparam>
        /// <typeparam name="T13">The thirteenth type to parse as a verbset.</typeparam>
        /// <returns>A <see cref="ParserResult{T}"/> with either the verb type that was parsed or one or more <see cref="Error"/>s.</returns>
        public static ParserResult<object> ParseSetArguments<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this Parser parser,
            IEnumerable<string> args,
            Func<Parser, ParserResult<object>, IEnumerable<string>, bool, ParserResult<object>> onVerbsetParsed,
            bool helpOrVersionRequested,
            params Type[] verbTypes)
        {
            return ParseSetArguments(parser,
                args,
                new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9),
                    typeof(T10), typeof(T11), typeof(T12), typeof(T13) },
                verbTypes,
                onVerbsetParsed,
                helpOrVersionRequested);
        }

        /// <summary>
        /// Parses the passed arguments for both verbsets and regular verbs.
        /// </summary>
        /// <param name="parser">The <see cref="Parser"/> to use to parse the arguments.</param>
        /// <param name="args">The arguments to parse.</param>
        /// <param name="onVerbsetParsed">A method that is called when a verbset verb has been parsed.</param>
        /// <param name="helpOrVersionRequested">Whether or not the previous verbset was called with a help verb or help/version option.</param>
        /// <param name="verbTypes">The regular verb types to parse besides the verbsets.</param>
        /// <typeparam name="T1">The first type to parse as a verbset.</typeparam>
        /// <typeparam name="T2">The second type to parse as a verbset.</typeparam>
        /// <typeparam name="T3">The third type to parse as a verbset.</typeparam>
        /// <typeparam name="T4">The fourth type to parse as a verbset.</typeparam>
        /// <typeparam name="T5">The fifth type to parse as a verbset.</typeparam>
        /// <typeparam name="T6">The sixth type to parse as a verbset.</typeparam>
        /// <typeparam name="T6">The seventh type to parse as a verbset.</typeparam>
        /// <typeparam name="T7">The seventh type to parse as a verbset.</typeparam>
        /// <typeparam name="T8">The eigth type to parse as a verbset.</typeparam>
        /// <typeparam name="T9">The ninth type to parse as a verbset.</typeparam>
        /// <typeparam name="T10">The tenth type to parse as a verbset.</typeparam>
        /// <typeparam name="T11">The eleventh type to parse as a verbset.</typeparam>
        /// <typeparam name="T12">The twelfth type to parse as a verbset.</typeparam>
        /// <typeparam name="T13">The thirteenth type to parse as a verbset.</typeparam>
        /// <typeparam name="T14">The fourteenth type to parse as a verbset.</typeparam>
        /// <returns>A <see cref="ParserResult{T}"/> with either the verb type that was parsed or one or more <see cref="Error"/>s.</returns>
        public static ParserResult<object> ParseSetArguments<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this Parser parser,
            IEnumerable<string> args,
            Func<Parser, ParserResult<object>, IEnumerable<string>, bool, ParserResult<object>> onVerbsetParsed,
            bool helpOrVersionRequested,
            params Type[] verbTypes)
        {
            return ParseSetArguments(parser,
                args,
                new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9),
                    typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14) },
                verbTypes,
                onVerbsetParsed,
                helpOrVersionRequested);
        }

        /// <summary>
        /// Parses the passed arguments for both verbsets and regular verbs.
        /// </summary>
        /// <param name="parser">The <see cref="Parser"/> to use to parse the arguments.</param>
        /// <param name="args">The arguments to parse.</param>
        /// <param name="onVerbsetParsed">A method that is called when a verbset verb has been parsed.</param>
        /// <param name="helpOrVersionRequested">Whether or not the previous verbset was called with a help verb or help/version option.</param>
        /// <param name="verbTypes">The regular verb types to parse besides the verbsets.</param>
        /// <typeparam name="T1">The first type to parse as a verbset.</typeparam>
        /// <typeparam name="T2">The second type to parse as a verbset.</typeparam>
        /// <typeparam name="T3">The third type to parse as a verbset.</typeparam>
        /// <typeparam name="T4">The fourth type to parse as a verbset.</typeparam>
        /// <typeparam name="T5">The fifth type to parse as a verbset.</typeparam>
        /// <typeparam name="T6">The sixth type to parse as a verbset.</typeparam>
        /// <typeparam name="T6">The seventh type to parse as a verbset.</typeparam>
        /// <typeparam name="T7">The seventh type to parse as a verbset.</typeparam>
        /// <typeparam name="T8">The eigth type to parse as a verbset.</typeparam>
        /// <typeparam name="T9">The ninth type to parse as a verbset.</typeparam>
        /// <typeparam name="T10">The tenth type to parse as a verbset.</typeparam>
        /// <typeparam name="T11">The eleventh type to parse as a verbset.</typeparam>
        /// <typeparam name="T12">The twelfth type to parse as a verbset.</typeparam>
        /// <typeparam name="T13">The thirteenth type to parse as a verbset.</typeparam>
        /// <typeparam name="T14">The fourteenth type to parse as a verbset.</typeparam>
        /// <typeparam name="T15">The fifteenth type to parse as a verbset.</typeparam>
        /// <returns>A <see cref="ParserResult{T}"/> with either the verb type that was parsed or one or more <see cref="Error"/>s.</returns>
        public static ParserResult<object> ParseSetArguments<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this Parser parser,
            IEnumerable<string> args,
            Func<Parser, ParserResult<object>, IEnumerable<string>, bool, ParserResult<object>> onVerbsetParsed,
            bool helpOrVersionRequested,
            params Type[] verbTypes)
        {
            return ParseSetArguments(parser,
                args,
                new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9),
                    typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14), typeof(T15) },
                verbTypes,
                onVerbsetParsed,
                helpOrVersionRequested);
        }

        /// <summary>
        /// Parses the passed arguments for both verbsets and regular verbs.
        /// </summary>
        /// <param name="parser">The <see cref="Parser"/> to use to parse the arguments.</param>
        /// <param name="args">The arguments to parse.</param>
        /// <param name="onVerbsetParsed">A method that is called when a verbset verb has been parsed.</param>
        /// <param name="helpOrVersionRequested">Whether or not the previous verbset was called with a help verb or help/version option.</param>
        /// <param name="verbTypes">The regular verb types to parse besides the verbsets.</param>
        /// <typeparam name="T1">The first type to parse as a verbset.</typeparam>
        /// <typeparam name="T2">The second type to parse as a verbset.</typeparam>
        /// <typeparam name="T3">The third type to parse as a verbset.</typeparam>
        /// <typeparam name="T4">The fourth type to parse as a verbset.</typeparam>
        /// <typeparam name="T5">The fifth type to parse as a verbset.</typeparam>
        /// <typeparam name="T6">The sixth type to parse as a verbset.</typeparam>
        /// <typeparam name="T6">The seventh type to parse as a verbset.</typeparam>
        /// <typeparam name="T7">The seventh type to parse as a verbset.</typeparam>
        /// <typeparam name="T8">The eigth type to parse as a verbset.</typeparam>
        /// <typeparam name="T9">The ninth type to parse as a verbset.</typeparam>
        /// <typeparam name="T10">The tenth type to parse as a verbset.</typeparam>
        /// <typeparam name="T11">The eleventh type to parse as a verbset.</typeparam>
        /// <typeparam name="T12">The twelfth type to parse as a verbset.</typeparam>
        /// <typeparam name="T13">The thirteenth type to parse as a verbset.</typeparam>
        /// <typeparam name="T14">The fourteenth type to parse as a verbset.</typeparam>
        /// <typeparam name="T15">The fifteenth type to parse as a verbset.</typeparam>
        /// <typeparam name="T16">The sixteenth type to parse as a verbset.</typeparam>
        /// <returns>A <see cref="ParserResult{T}"/> with either the verb type that was parsed or one or more <see cref="Error"/>s.</returns>
        public static ParserResult<object> ParseSetArguments<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this Parser parser,
            IEnumerable<string> args,
            Func<Parser, ParserResult<object>, IEnumerable<string>, bool, ParserResult<object>> onVerbsetParsed,
            bool helpOrVersionRequested,
            params Type[] verbTypes)
        {
            return ParseSetArguments(parser,
                args,
                new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9),
                    typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14), typeof(T15), typeof(T16) },
                verbTypes,
                onVerbsetParsed,
                helpOrVersionRequested);
        }
    }
}
