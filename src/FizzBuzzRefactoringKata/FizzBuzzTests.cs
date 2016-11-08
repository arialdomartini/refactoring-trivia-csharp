using System;
using Xunit;

namespace FizzBuzzRefactoringKata
{
    public class FizzBuzzTests
    {
        [Theory]
        [InlineData(3, "Fizz")]
        [InlineData(3 * 2, "Fizz")]
        [InlineData(5, "Buzz")]
        [InlineData(5 * 2, "Buzz")]
        [InlineData(15, "FizzBuzz")]
        [InlineData(15 * 2, "FizzBuzz")]
        [InlineData(1, "1")]
        [InlineData(2, "2")]
        [InlineData(4, "4")]
        [InlineData(8, "8")]
        [InlineData(7, "Yo")]
        [InlineData(7 * 3, "FizzYo")]
        [InlineData(7 * 5, "BuzzYo")]
        [InlineData(7 * 3 * 5, "FizzBuzzYo")]
        public void SingleNumber(Int32 input, String expected)
        {
            Assert.Equal(expected, FizzBuzz.Say(input));
        }
    }
}