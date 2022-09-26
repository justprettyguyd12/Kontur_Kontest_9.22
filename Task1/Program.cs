using System;
using System.Runtime;
using System.Linq;


namespace Task1
{
    public static class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var numbers = input.ToCharArray();
            var maxValue = SortNumbers(numbers, true);
            var minValue = SortNumbers(numbers, false);
            Console.WriteLine(maxValue - minValue);
        }

        private static int SortNumbers(char[] numbers, bool isInReverseOrder)
        {
            Array.Sort(numbers);
            if (isInReverseOrder)
                numbers = numbers.Reverse().ToArray();
            var result = int.Parse(string.Join("", numbers));
            return result;
        }
    }
}