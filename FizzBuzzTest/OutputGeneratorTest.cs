namespace FizzBuzzTest
{
    using System;
    using System.Linq;
    using FizzBuzz;
    using NUnit.Framework;

    [TestFixture]
    public class OutputGeneratorTest
    {
        #region [ Fields ]

        private OutputGenerator _generator;
        private Translator _translator;

        #endregion
        
        #region [ Pre / Post Test ]

        [SetUp]
        public void SetUp()
        {
            // Empty translator will do nothing so no need to mock.
            this._translator = new Translator();
            this._generator = new OutputGenerator(this._translator);
        }

        #endregion
        
        #region [ Tests ]

        [Test]
        public void GeneratorThrowsExcpetionWhenFirstNumberIsLargerThanSecond()
        {
            // Arrange
            const int first = 100;
            const int second = 10;
            Assert.IsTrue(first > second);

            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => this._generator.Generate(first, second));
        }

        [Test]
        public void GeneratorCanAcceptARangeForGeneration()
        {
            // Arrange
            // Act
            var result = this._generator.Generate(1, 100);

            // Assert
            Assert.AreEqual(100, result.Count);
        }

        [Test]
        public void GeneratorWillUseOutputFromTranslator()
        {
            // Arrange
            const string expectedReplacement = "Foo";
            var replacment = new Replacement(3, expectedReplacement);
            this._translator.AddReplacement(replacment);

            // Act
            var result = this._generator.Generate(3, 3);

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(expectedReplacement, result.First());
        }

        #endregion
    }
}
