namespace FizzBuzzTest
{
    using System.Globalization;
    using FizzBuzz;
    using NUnit.Framework;

    [TestFixture]
    public class ReplacerTest
    {
        #region [ Fields ]

        private Replacement _replacement;

        #endregion

        #region [ Pre/Post Test ]

        [SetUp]
        public void SetUp()
        {
        }

        #endregion

        #region [ Tests ]

        [Test]
        public void ReplacementReturnsFalseIfNumberIsNotDivisibleByDivisor()
        {
            // Assemble
            const int divisor = 3;
            const int number = 4;
            Assert.IsFalse(number % divisor == 0);
            this._replacement = new Replacement(divisor, "Fizz");

            // Act
            var result = this._replacement.CanHandle(number);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ReplacementReturnsTrueIfNumberIsEqualToDivisor()
        {
            // Assemble
            const int divisor = 3;
            const int number = 3;
            Assert.IsTrue(number == divisor);
            this._replacement = new Replacement(divisor, "Fizz");

            // Act
            var result = this._replacement.CanHandle(number);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void ReplacementReturnsTrueIfNumberIsAMultipleOfDivisor()
        {
            // Assemble
            const int divisor = 3;
            const int number = 3;
            Assert.IsTrue(number == divisor);
            this._replacement = new Replacement(divisor, "Fizz");

            // Act
            var result = this._replacement.CanHandle(number * 2);

            // Assert
            Assert.IsTrue(result);
        }

        #endregion
    }
}
