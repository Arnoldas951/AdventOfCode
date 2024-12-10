using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AOC._2024.Day10
{
    public class Solution
    {
        private Dictionary<int, List<Point>> PointsMapped = new Dictionary<int, List<Point>>();
        private int routes = 0;
        private List<Point> pointsFound;
        public int Solution1(List<string> input)
        {
            for (int i = 0; i < input.Count; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    if (!PointsMapped.ContainsKey(input[i][j] - '0'))
                        PointsMapped.Add((input[i][j]) - '0', new List<Point>() { new Point(j, i) });
                    else
                        PointsMapped[input[i][j] - '0'].Add(new Point(j, i));
                }
            }

            for (int i = 0; i < PointsMapped[0].Count; i++)
            {
                pointsFound = new List<Point>();
                HasEnd(0, PointsMapped[0][i]);
                Console.WriteLine(PointsMapped[0][i]);
                Console.WriteLine(routes);

            }
            return routes;
        }

        public void HasEnd(int value, Point startingPoint)
        {
            var pointsOfInterest = PointsMapped[value + 1];
            for (int i = 0; i < pointsOfInterest.Count; i++)
            {
                int xdif = Math.Abs(startingPoint.X - pointsOfInterest[i].X);
                int ydif = Math.Abs(startingPoint.Y - pointsOfInterest[i].Y);
                if ((xdif == 1 && ydif == 0) || (ydif == 1 && xdif == 0))
                {
                    if (value + 1 == 9)
                    {
                        Console.WriteLine($"{value + 1}, {PointsMapped[value + 1][i]}");
                        if (!pointsFound.Contains(PointsMapped[value + 1][i]))
                        {
                            routes++;
                            pointsFound.Add(PointsMapped[value + 1][i]);
                        }
                    }
                    else
                        HasEnd(value + 1, pointsOfInterest[i]);
                }
            }
        }


        public int Solution2(List<string> input) {

            for (int i = 0; i < input.Count; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    if (!PointsMapped.ContainsKey(input[i][j] - '0'))
                        PointsMapped.Add((input[i][j]) - '0', new List<Point>() { new Point(j, i) });
                    else
                        PointsMapped[input[i][j] - '0'].Add(new Point(j, i));
                }
            }

            for (int i = 0; i < PointsMapped[0].Count; i++)
            {
                HasEnd2(0, PointsMapped[0][i]);
                Console.WriteLine(PointsMapped[0][i]);
                Console.WriteLine(routes);

            }
            return routes;
        }

        public void HasEnd2(int value, Point startingPoint)
        {
            var pointsOfInterest = PointsMapped[value + 1];
            for (int i = 0; i < pointsOfInterest.Count; i++)
            {
                int xdif = Math.Abs(startingPoint.X - pointsOfInterest[i].X);
                int ydif = Math.Abs(startingPoint.Y - pointsOfInterest[i].Y);
                if ((xdif == 1 && ydif == 0) || (ydif == 1 && xdif == 0))
                {
                    if (value + 1 == 9)
                    {
                            routes++;
                    }
                    else
                        HasEnd2(value + 1, pointsOfInterest[i]);
                }
            }
        }
    }
}