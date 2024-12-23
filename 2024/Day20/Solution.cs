using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AOC._2024.Day20
{
    public class Solution
    {


        public int Solution1(List<string> input)
        {
            Point end = new Point(0, 0);
            Point start = new Point(0, 0);
            List<Point> road = new List<Point>();
            int counter = 0;
            for (int i = 0; i < input.Count; i++)
            {
                int endIndex = input[i].IndexOf("E");
                int startIndex = input[i].IndexOf("S");
                if (endIndex >= 0)
                {
                    end.X = endIndex;
                    end.Y = i;
                    //input[i].Replace("E", ".");
                    input[i] = input.ElementAt(i).Replace("E", ".");
                }

                if (startIndex >= 0)
                {
                    start.X = startIndex;
                    start.Y = i;
                }

                //for(int j = 0; j < input[i].Length; j++)
                //{
                //    if (input[i][j] == '.')
                //        road.Add(new Point(j, i));
                //}
            }

            road = GetOrderedRoad(input, start, end);
            int length = road.Count;
            Dictionary<int, int> testdic = new Dictionary<int, int>();
            for (int i = 0; i < road.Count; i++)
            {

                //for(int j = i+1; j < road.Count; j++)
                //{

                //}
                var test = road.Skip(i).Where(f =>
                (Math.Abs(f.X - road[i].X) == 2 && f.Y - road[i].Y == 0)
                || (f.X - road[i].X == 0 && Math.Abs(f.Y - road[i].Y) == 2)
                ||
                (Math.Abs(f.X - road[i].X) == 1 && Math.Abs(f.Y - road[i].Y) == 1)).ToList();



                foreach (Point tile in test)
                {

                    //Point connectingTile = new((road[i].X + tile.X) / 2, (road[i].Y + tile.Y) / 2);
                    //int connectingCount = road.IndexOf(tile) - i;
                    //if (!road.Any(f => f == connectingTile))
                    //{
                    int newRoad = road.IndexOf(tile) - i - 2;

                    if (newRoad >= 100)
                    {
                        //Console.WriteLine(road[i] + " " + tile + " " + newRoad);
                        if (!testdic.ContainsKey(newRoad))
                        {
                            testdic.Add(newRoad, 1);
                        }
                        else
                        {
                            testdic[newRoad]++;
                        }
                    }

                    //counter++;
                    //}
                }

                //for(int j = i+1; j < road.Count; j++)
                //{

                //}
            }
            return testdic.Where(f => f.Key >= 100).Sum(f => f.Value);
        }

        private List<Point> GetOrderedRoad(List<string> input, Point start, Point end)
        {
            List<Point> road = new List<Point>();
            road.Add(start);
            while (start != end)
            {
                if (input[start.Y][start.X + 1] == '.' && !road.Contains(new(start.X + 1, start.Y)))
                {
                    start.X++;
                    road.Add(new Point(start.X, start.Y));
                    continue;
                }

                if (input[start.Y][start.X - 1] == '.' && !road.Contains(new(start.X - 1, start.Y)))
                {
                    start.X--;
                    road.Add(new Point(start.X, start.Y));
                    continue;
                }

                if (input[start.Y + 1][start.X] == '.' && !road.Contains(new(start.X, start.Y + 1)))
                {
                    start.Y++;
                    road.Add(new Point(start.X, start.Y));
                    continue;
                }

                if (input[start.Y - 1][start.X] == '.' && !road.Contains(new(start.X, start.Y - 1)))
                {
                    start.Y--;
                    road.Add(new Point(start.X, start.Y));
                    continue;
                }
            }

            //road.RemoveAt(0);
            return road;
        }

        public int Solution2(List<string> input)
        {
            Point end = new Point(0, 0);
            Point start = new Point(0, 0);
            List<Point> road = new List<Point>();
            Dictionary<Point, List<Point>> Visited = new Dictionary<Point, List<Point>>();
            for (int i = 0; i < input.Count; i++)
            {
                int endIndex = input[i].IndexOf("E");
                int startIndex = input[i].IndexOf("S");
                if (endIndex >= 0)
                {
                    end.X = endIndex;
                    end.Y = i;
                    //input[i].Replace("E", ".");
                    input[i] = input.ElementAt(i).Replace("E", ".");
                }

                if (startIndex >= 0)
                {
                    start.X = startIndex;
                    start.Y = i;
                }

            }

            road = GetOrderedRoad(input, start, end);
            int length = road.Count;
            Dictionary<int, int> testdic = new Dictionary<int, int>();
            for (int i = 0; i < road.Count; i++)
            {
                var test = road.Skip(i).Where(f =>
                (Math.Abs(f.X - road[i].X) <= 20 && f.Y - road[i].Y == 0)
                || (f.X - road[i].X == 0 && Math.Abs(f.Y - road[i].Y) <= 20)
                || (Math.Abs(f.X - road[i].X) + Math.Abs(f.Y - road[i].Y) <= 20)).ToList();



                foreach (Point tile in test)
                {
                    int difference = Math.Abs(road[i].X - tile.X) + Math.Abs(road[i].Y - tile.Y);
                    int newRoad = road.IndexOf(tile) - i - difference;
                    if (newRoad >= 100)
                    {
                        //Console.WriteLine(road[i] + " " + tile + " " + newRoad);
                        if (!Visited.ContainsKey(road[i]))
                        {
                            Visited.Add(road[i], new List<Point>());
                        }

                        if (!Visited[road[i]].Contains(tile))
                        {
                            Visited[road[i]].Add(tile);
                            if (!testdic.ContainsKey(newRoad))
                            {
                                testdic.Add(newRoad, 1);
                            }
                            else
                            {
                                testdic[newRoad]++;
                            }
                        }
                    }

                    //counter++;
                    //}
                }

                //for(int j = i+1; j < road.Count; j++)
                //{

                //}
            }
            return testdic.Where(f => f.Key >= 100).Sum(f => f.Value);
        }
    }
}