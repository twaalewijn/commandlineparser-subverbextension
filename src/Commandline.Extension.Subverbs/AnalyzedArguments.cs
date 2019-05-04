using System;

namespace Commandline.Extension.Subverbs
{
    /// <summary>
    /// Contains information needed to handle parsing verbsets correctly.
    /// </summary>
    internal struct AnalyzedVerbSetArgument
    {
        /// <summary>
        /// Gets the argument value to parse as a verbset.
        /// </summary>
        public string ArgToParse { get; }

        /// <summary>
        /// Gets a value indicating whether or not the argument was preceded by a help verb.
        /// </summary>
        public bool ContainsHelpVerb { get; }

        /// <summary>
        /// Gets a value indicating whether or not the argument was succeeded by a help or version option.
        /// </summary>
        public bool ContainsHelpOrVersionOption { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnalyzedVerbSetArgument"/> struct.
        /// </summary>
        /// <param name="argToParse">The argument value to parse as a verbset.</param>
        /// <param name="helpVerb">Whether or not the argument was preceded by a help verb.</param>
        /// <param name="helpOrVersionOption">Whether or not the argument was succeeded by a help or version option.</param>
        public AnalyzedVerbSetArgument(string argToParse, bool helpVerb, bool helpOrVersionOption)
        {
            this.ArgToParse = argToParse;
            this.ContainsHelpVerb = helpVerb;
            this.ContainsHelpOrVersionOption = helpOrVersionOption;
        }
    }
}
