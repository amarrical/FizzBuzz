namespace FizzBuzz.UI
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var translator = new Translator();
            translator.AddReplacement(new Replacement(3, "Fizz"));
            translator.AddReplacement(new Replacement(5, "Buzz"));
            translator.AddReplacement(new Replacement(7, "Foo"));
            translator.AddReplacement(new Replacement(9, "Bar"));

            var generator = new OutputGenerator(translator);
            var output = generator.Generate(1, 315); // 315 is first value to have FizzBuzzFooBar
            output.ForEach(Console.WriteLine);
        }
    }
}
