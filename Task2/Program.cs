using System;

namespace Task2
{
    public static class Program
    {
        public static void Main()
        {
            var sum = 0;
            var count = int.Parse(Console.ReadLine());
            for (var i = 0; i < count; i++)
            {
                sum += int.Parse(Console.ReadLine());
            }
            Console.WriteLine(0 - sum);
        }
    }
}