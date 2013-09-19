namespace FizzBuzz
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Generates an output for a specified range.
    /// </summary>
    public class OutputGenerator
    {
        #region [ Fields ]

        /// <summary>
        /// The translator which will translate numbers.
        /// </summary>
        private readonly Translator _translator;

        #endregion
        
        #region [ Constructor ]

        /// <summary>
        /// Instantiates an instance of the OutputGenerator class;
        /// </summary>
        /// <param name="translator">The translator this output genrator will use.</param>
        public OutputGenerator(Translator translator)
        {
            this._translator = translator;
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Generates a list of strings for desired range based on which translators are configured.
        /// </summary>
        /// <param name="start">Beginning of the range</param>
        /// <param name="end">End of the range</param>
        /// <returns>A list of translated strings based on the range</returns>
        public List<string> Generate(int start, int end)
        {
            if (start > end)
                throw new ArgumentException("The end number must be larger than the start number", "end");

            var numbers = Enumerable.Range(start, (end - start) + 1).ToList();
            var result = new List<String>();
            numbers.ForEach(n => result.Add(this._translator.Translate(n)));
            return result;
        }
    }

    #endregion

}