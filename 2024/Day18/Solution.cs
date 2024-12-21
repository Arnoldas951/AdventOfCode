using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AOC._2024.Day18
{
    public class Solution
    {
        public int Solution1(List<string> input)
        {
            Point start = new(0, 0);
            Point end = new(70, 70);
            char[,] grid = new char[71, 71];
            int index = 0;
            foreach (string s in input)
            {
                string[] split = s.Split(',');
                int x = int.Parse(split[0]);
                int y = int.Parse(split[1]);
                if (index < 1024)
                {
                    grid[x, y] = '#';
                    index++;
                }
                else
                {
                    grid[x, y] = '.';
                }
            }

            for (int i = 0; i < 71; i++)
            {
                for (int j = 0; j < 71; j++)
                {
                    if (grid[j, i] == '\0')
                    {
                        grid[j, i] = '.';
                    }
                    Console.Write(grid[j, i]);
                }
                Console.WriteLine();
            }

            Queue<Traveled> mapPoint = new Queue<Traveled>();

            List<Point> visited = new List<Point>();

            mapPoint.Enqueue(new Traveled(start, 0));
            //visited.Add(start);

            while (mapPoint.Count > 0)
            {
                Traveled item = mapPoint.Dequeue();
                if (!visited.Contains(item.tile))
                {
                    int x = item.tile.X;
                    int y = item.tile.Y;

                    if (item.tile == end)
                    {
                        return item.stepsTaken;
                    }

                    if (x > 0)
                    {
                        if (grid[x - 1, y] != '#')
                        {
                            mapPoint.Enqueue(new Traveled(new Point(x - 1, y), item.stepsTaken + 1));
                        }
                    }

                    if (x < 70)
                    {
                        if (grid[x + 1, y] != '#')
                        {
                            mapPoint.Enqueue(new Traveled(new Point(x + 1, y), item.stepsTaken + 1));
                        }
                    }

                    if (y > 0)
                    {
                        if (grid[x, y - 1] != '#')
                        {
                            mapPoint.Enqueue(new Traveled(new Point(x, y - 1), item.stepsTaken + 1));
                        }
                    }

                    if (y < 70)
                    {
                        if (grid[x, y + 1] != '#')
                        {
                            mapPoint.Enqueue(new Traveled(new Point(x, y + 1), item.stepsTaken + 1));
                        }
                    }

                }
                visited.Add(item.tile);
            }

            return 0;
        }

        private record Traveled(Point tile, int stepsTaken);

        public string Solution2(List<string> input)
        {

            int lowest = 0;
            int highest = input.Count();

            //linear search
            //for(int i = 0; i < input.Count; i++)
            //{
            //    if (!CanTravel(i, input))
            //        return input[i];
            //}

            // binary search
            while (lowest < highest)
            {
                int middle = (lowest + highest) / 2;
                if (CanTravel(middle + 1, input))
                {
                    lowest = middle + 1;
                }
                else
                {
                    highest = middle;
                }
            }

            return input[highest];
        }

        // explained by HyperNeutrino, checking which item will block from the input list
        private bool CanTravel(int blockingItems, List<string> input)
        {

            char[,] grid = new char[71, 71];
            foreach (string s in input)
            {
                string[] split = s.Split(',');
                int x = int.Parse(split[0]);
                int y = int.Parse(split[1]);
                if (blockingItems != 0)
                {
                    grid[x, y] = '#';
                    blockingItems--;
                }
                else
                {
                    grid[x, y] = '.';
                }
            }

            Queue<Point> mapPoint = new Queue<Point>();

            List<Point> visited = new List<Point>();

            mapPoint.Enqueue(new(0, 0));
            Point end = new(70, 70);
            //visited.Add(start);

            while (mapPoint.Count > 0)
            {
                Point item = mapPoint.Dequeue();
                if (!visited.Contains(item))
                {
                    int x = item.X;
                    int y = item.Y;

                    if (item == end)
                    {
                        return true;
                    }

                    if (x > 0)
                    {
                        if (grid[x - 1, y] != '#')
                        {
                            mapPoint.Enqueue(new Point(x - 1, y));
                        }
                    }

                    if (x < 70)
                    {
                        if (grid[x + 1, y] != '#')
                        {
                            mapPoint.Enqueue(new Point(x + 1, y));
                        }
                    }

                    if (y > 0)
                    {
                        if (grid[x, y - 1] != '#')
                        {
                            mapPoint.Enqueue(new Point(x, y - 1));
                        }
                    }

                    if (y < 70)
                    {
                        if (grid[x, y + 1] != '#')
                        {
                            mapPoint.Enqueue(new Point(x, y + 1));
                        }
                    }

                }
                visited.Add(item);
            }

            return false;
        }
    }
}