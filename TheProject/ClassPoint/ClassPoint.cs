using System;
using System.Linq;
using System.Collections.Generic;

namespace ClassPoint
{
    class ClassPoint
    {
        static void Main(string[] args)
        {
            Point firstPoint = ReadPoint();
            Point secondPoint = ReadPoint();
            double result = TheDistance(firstPoint, secondPoint);
            Console.WriteLine($"{result:F2}");

        }

        static Point ReadPoint()
        {
            int[] pointData = Console.ReadLine()
                            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

            var point = new Point
            {
                X = pointData[0],
                Y = pointData[1]
            };

            return point;
        }

        static double TheDistance(Point a, Point b)
        {
            double diffX = a.X - b.X;
            double diffY = a.Y - b.Y;
            double distance = Math.Sqrt(diffX * diffX + diffY * diffY);
            return distance;
        }
    }

    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
