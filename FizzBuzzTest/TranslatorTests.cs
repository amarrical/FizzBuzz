namespace FizzBuzzTest
{
    using System;
    using FizzBuzz;
    using NUnit.Framework;

    [TestFixture]
    public class TranslatorTests
    {
        #region [ Fields ]

        private Translator _translator;

        #endregion
        
        #region [ Pre/Post Test ]

        [SetUp]
        public void SetUp()
        {
            this._translator = new Translator();
        }

        #endregion
        
        #region [ Tests ]

        [TestCase(1, "1")]
        [TestCase(2, "2")]
        [TestCase(3, "3")]
        [TestCase(5, "5")]
        [TestCase(10, "10")]
        [TestCase(456, "456")]
        public void UninitalizedTranslatorWillReturnNumberStrings(int number, string expected)
        {
            // Arrange
            // Act
            var result = this._translator.Translate(number);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TranslatorWillReplaceNumberIfItHasSuitableReplacement()
        {
            // Arrange
            const string replacementString = "Replacement";
            const int divisor = 3;
            var replacment = new Replacement(divisor, replacementString);
            const int number = 6;
            Assert.IsTrue(replacment.CanHandle(number));

            // Act
            this._translator.AddReplacement(replacment);
            var result = this._translator.Translate(number);

            // Assert
            Assert.AreEqual(replacementString, result);
        }

        [Test]
        public void TranslatorWillReplaceWithBothValuesInOrderOfDivisorIfNumberCanBeHandledByMultipleRepacements()
        {
            const string replacementString1 = "Fizz";
            const int divisor1 = 3;
            var replacment1 = new Replacement(divisor1, replacementString1);

            const string replacementString2 = "Buzz";
            const int divisor2 = 5;
            var replacment2 = new Replacement(divisor2, replacementString2);

            const int number = 15;
            Assert.IsTrue(replacment1.CanHandle(number));
            Assert.IsTrue(replacment2.CanHandle(number));
            Assert.IsTrue(divisor1 < divisor2);
            const string expectedResult = replacementString1 + replacementString2;

            // Act
            this._translator.AddReplacement(replacment1);
            this._translator.AddReplacement(replacment2);
            var result = this._translator.Translate(number);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void TranslatorCannotAddASecondReplacementThatConstainsADivisorWhichAlreadyExists()
        {
            // Arrange
            const int divisor = 3;
            var replacment1 = new Replacement(divisor, "Fizz");
            var replacment2 = new Replacement(divisor, "Buzz");

            // Act
            this._translator.AddReplacement(replacment1);

            // Assert
            Assert.Throws<ArgumentException>(() => this._translator.AddReplacement(replacment2));
        }

        #endregion

        #region [ Depreciated Tests ]
        // I would normally delete these from the test cases as they are no longer valid
        // But I wanted to make sure you could see code you remember me writing

        [Test]
        [Ignore("Depriciated Test")]
        public void IfNumberIsNotDivisibleBy3Or5ReturnNumberAsString()
        {
            var result = this._translator.Translate(1);
            Assert.AreEqual("1", result);
        }

        [Test]
        [Ignore("Depriciated Test")]
        public void IfNumberIsDivisibleBy3PrintFizz()
        {
            var result = this._translator.Translate(3);
            Assert.AreEqual("Fizz", result);
        }

        [Test]
        [Ignore("Depriciated Test")]
        public void IfNumberIsDivisibleBy5PrintBuzz()
        {
            var result = this._translator.Translate(5);
            Assert.AreEqual("Buzz", result);
        }

        [Test]
        [Ignore("Depriciated Test")]
        public void IfNumberIsDivisibleBy3And5PrintFizzBuzz()
        {
            var result = this._translator.Translate(15);
            Assert.AreEqual("FizzBuzz", result);
        }

        #endregion
    }
}
