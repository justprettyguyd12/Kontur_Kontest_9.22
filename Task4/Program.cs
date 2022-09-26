using System;
using System.Runtime;
using System.Linq;


namespace Task1
{
    public static class Program
    {
        public static void Main()
        {
            var sizes = Console.ReadLine().Split(' ');
            var heigth = int.Parse(sizes[0]);
            var width = int.Parse(sizes[1]);
            var map = new bool[heigth, width];
            for (var h = 0; h < heigth; h++)
            {
                var line = Console.ReadLine();
                for (var w = 0; w < width; w++)
                {
                    map[h, w] = line[w] == '*' ? false : true;
                }
            }
            var result = CheckMap(map);
            Console.WriteLine(result);
        }

        private static int CheckMap(bool[,] map)
        {
            var maxArea = 0;
            var heigth = map.GetLength(0) - 1;
            var width = map.GetLength(1) - 1;
            for (var h = 1; h < heigth; h++)
            {
                for (var w = 1; w < width; w++)
                {
                    var area = CheckPlace(map, h, w);
                    if (area > maxArea)
                        maxArea = area;
                }
            }
            return maxArea;
        }

        private static int CheckPlace(bool[,] map, int heigth, int width)
        {
            if (!map[heigth, width])
                return 0;
            var maxDown = CheckMaxDown(map, heigth, width);
            var maxRight = CheckMaxRight(map, heigth, width);
            var maxArea = maxRight;
            for (var h = 1; h <= maxDown; h++)
            {
                var nextWidth = CheckMaxRight(map, heigth + h - 1, width);
                if (nextWidth < maxRight)
                    maxRight = nextWidth;
                var area = h * maxRight;
                if (area > maxArea)
                    maxArea = area;
            }
            return maxArea;
        }

        private static int CheckMaxDown(bool[,] map, int heigth, int width)
        {
            var result = 0;
            for (var h = heigth;; h++)
            {
                if (!map[h, width])
                    return result;
                result++;
            }
        }

        private static int CheckMaxRight(bool[,] map, int heigth, int width)
        {
            var result = 0;
            for (var w = width;; w++)
            {
                if (!map[heigth, w])
                    return result;
                result++;
            }
        }

    }
}