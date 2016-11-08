using System;

namespace FizzBuzzRefactoringKata
{
    public static class FizzBuzz
    {
        public static String Say(Int32 number)
        {
            String result = null;
            if (number % 3 == 0) result += "Fizz";
            if (number % 5 == 0) result += "Buzz";
            if (number % 7 == 0) result += "Yo";
            return String.IsNullOrWhiteSpace(result) ? number.ToString() : result;
        }
    }
}