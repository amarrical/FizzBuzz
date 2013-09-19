namespace FizzBuzz
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Translates numbers into strings based on replacements.
    /// </summary>
    public class Translator
    {
        #region [ Fields ]

        /// <summary>
        /// The list of replacements this translator will make.
        /// </summary>
        private readonly List<Replacement> _replacements;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Instantiates a new instance of the Translator class.
        /// </summary>
        public Translator()
        {
            this._replacements = new List<Replacement>();
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Adds a replacment to the list of replacments this translator will make.
        /// </summary>
        /// <param name="replacement">The Replacement to add.</param>
        public void AddReplacement(Replacement replacement)
        {
            if (this._replacements.Any(r => r.Divisor == replacement.Divisor))
            {
                throw new ArgumentException("Cannot add another replacment with the same divisor", "replacement");
            }

            this._replacements.Add(replacement);
        }

        /// <summary>
        /// Translates a number based on the replacements this class will handle.
        /// </summary>
        /// <param name="number">The number to translated.</param>
        /// <returns>A string representation of the number, or its replacement(s).</returns>
        public string Translate(int number)
        {
            var stringBuilder = new StringBuilder("");
            foreach (var divisor in this._replacements.Where(r => r.CanHandle(number)).OrderBy(r => r.Divisor))
            {
                stringBuilder.Append(divisor.ReplacmentString);
            }

            if (stringBuilder.Length == 0)
            {
                stringBuilder.Append(number.ToString(CultureInfo.InvariantCulture));
            }

            return stringBuilder.ToString();
        }

        #endregion
    }
}