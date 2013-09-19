namespace FizzBuzz
{
    /// <summary>
    /// Contains a replacement for the translator.
    /// </summary>
    public class Replacement
    {
        #region [ Constructors ]

        /// <summary>
        /// Instantiates an instance of the ReplacmentString class.
        /// </summary>
        /// <param name="divisor">Divsor to detrmine numbers to replace.</param>
        /// <param name="replacement">ReplacmentString for numbers divisible by divisor.</param>
        public Replacement(int divisor, string replacement)
        {
            this.Divisor = divisor;
            this.ReplacmentString = replacement;
        }

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Divisor showing which numbers should be replaced.
        /// </summary>
        public int Divisor { get; private set; }

        /// <summary>
        /// Repacement for numbers divisible by divisor.
        /// </summary>
        public string ReplacmentString { get; private set; }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Determines if this is the proper divisor for the number in question.
        /// </summary>
        /// <param name="number">The number to be tested.</param>
        /// <returns>A value indicating whither the number should be replaced.</returns>
        public bool CanHandle(int number)
        {
            return (number % this.Divisor == 0);
        }

        #endregion
    }
}