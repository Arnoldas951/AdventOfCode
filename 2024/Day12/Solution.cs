using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AOC._2024.Day12
{
    public class Solution
    {
        public int Solution1(List<string> input)
        {
            int totalSum = 0;
            char currentChar = '0';
            List<Point> visited = new List<Point>();
            int rowLength = input[0].Length - 1;
            int columnLength = input.Count - 1;
            for (int i = 0; i < input.Count; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    Queue<Point> queue = new Queue<Point>();
                    Point currentNode = new Point(j, i);
                    char plant = input[i][j];
                    List<Point> neighbour = new List<Point>();
                    if (!visited.Contains(currentNode))
                    {
                        visited.Add(currentNode);
                        queue.Enqueue(currentNode);
                        neighbour.Add(currentNode);
                        while (queue.Count > 0)
                        {
                            var item = queue.Dequeue();
                            if (item.X != rowLength && input[item.Y][item.X + 1] == plant)
                            {
                                if (!neighbour.Contains(new Point(item.X + 1, item.Y)))
                                {
                                    visited.Add(new Point(item.X + 1, item.Y));
                                    queue.Enqueue(new Point(item.X + 1, item.Y));
                                    neighbour.Add(new Point(item.X + 1, item.Y));
                                }
                            }

                            if (item.Y != columnLength && input[item.Y + 1][item.X] == plant)
                            {

                                if (!neighbour.Contains(new Point(item.X, item.Y + 1)))
                                {
                                    visited.Add(new Point(item.X, item.Y + 1));
                                    queue.Enqueue(new Point(item.X, item.Y + 1));
                                    neighbour.Add(new Point(item.X, item.Y + 1));
                                }
                            }

                            if (item.Y > 0 && input[item.Y - 1][item.X] == plant)
                            {
                                if (!neighbour.Contains(new Point(item.X, item.Y - 1)))
                                {
                                    visited.Add(new Point(item.X, item.Y - 1));
                                    queue.Enqueue(new Point(item.X, item.Y - 1));
                                    neighbour.Add(new Point(item.X, item.Y - 1));
                                }
                            }

                            if (item.X > 0 && input[item.Y][item.X - 1] == plant)
                            {
                                if (!neighbour.Contains(new Point(item.X - 1, item.Y)))
                                {
                                    visited.Add(new Point(item.X - 1, item.Y));
                                    queue.Enqueue(new Point(item.X - 1, item.Y));
                                    neighbour.Add(new Point(item.X - 1, item.Y));
                                }
                            }

                            if (queue.Count == 0)
                            {
                                int area = 0;
                                for (int neigh = 0; neigh < neighbour.Count; neigh++)
                                {
                                    var nei = neighbour[neigh];
                                    area += 4;
                                    var test = neighbour.Where(f => (f.X - 1 == nei.X && f.Y == nei.Y)
                                    || (f.X + 1 == nei.X && f.Y == nei.Y)
                                    || (f.X == nei.X && f.Y - 1 == nei.Y)
                                    || (f.X == nei.X && f.Y + 1 == nei.Y)).Count();
                                    area -= neighbour.Where(f => (f.X - 1 == nei.X && f.Y == nei.Y)
                                    || (f.X + 1 == nei.X && f.Y == nei.Y)
                                    || (f.X == nei.X && f.Y - 1 == nei.Y)
                                    || (f.X == nei.X && f.Y + 1 == nei.Y)).Count();
                                }
                                totalSum += area * neighbour.Count;
                            }

                        }

                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return totalSum;
        }


        public long Solution2(List<string> input)
        {

            long totalSum = 0;
            char currentChar = '0';
            List<Point> visited = new List<Point>();
            int rowLength = input[0].Length - 1;
            int columnLength = input.Count - 1;
            for (int i = 0; i < input.Count; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    Queue<Point> queue = new Queue<Point>();
                    Point currentNode = new Point(j, i);
                    char plant = input[i][j];
                    List<Point> neighbour = new List<Point>();
                    if (!visited.Contains(currentNode))
                    {
                        visited.Add(currentNode);
                        queue.Enqueue(currentNode);
                        neighbour.Add(currentNode);
                        while (queue.Count > 0)
                        {
                            var item = queue.Dequeue();
                            if (item.X != rowLength && input[item.Y][item.X + 1] == plant)
                            {
                                if (!neighbour.Contains(new Point(item.X + 1, item.Y)))
                                {
                                    visited.Add(new Point(item.X + 1, item.Y));
                                    queue.Enqueue(new Point(item.X + 1, item.Y));
                                    neighbour.Add(new Point(item.X + 1, item.Y));
                                }
                            }

                            if (item.Y != columnLength && input[item.Y + 1][item.X] == plant)
                            {

                                if (!neighbour.Contains(new Point(item.X, item.Y + 1)))
                                {
                                    visited.Add(new Point(item.X, item.Y + 1));
                                    queue.Enqueue(new Point(item.X, item.Y + 1));
                                    neighbour.Add(new Point(item.X, item.Y + 1));
                                }
                            }

                            if (item.Y > 0 && input[item.Y - 1][item.X] == plant)
                            {
                                if (!neighbour.Contains(new Point(item.X, item.Y - 1)))
                                {
                                    visited.Add(new Point(item.X, item.Y - 1));
                                    queue.Enqueue(new Point(item.X, item.Y - 1));
                                    neighbour.Add(new Point(item.X, item.Y - 1));
                                }
                            }

                            if (item.X > 0 && input[item.Y][item.X - 1] == plant)
                            {
                                if (!neighbour.Contains(new Point(item.X - 1, item.Y)))
                                {
                                    visited.Add(new Point(item.X - 1, item.Y));
                                    queue.Enqueue(new Point(item.X - 1, item.Y));
                                    neighbour.Add(new Point(item.X - 1, item.Y));
                                }
                            }

                            if (queue.Count == 0)
                            {
                                long corners = 0;
                                int minheight = neighbour.Select(f => f.Y).Min();
                                int maxHeigth = neighbour.Select(f => f.Y).Max();
                                List<Point> prevList = new List<Point>();
                                while (minheight <= maxHeigth)
                                {
                                    var items = neighbour.Where(f => f.Y == minheight).OrderBy(f => f.X).ToList();
                                    if (prevList.Count == 0)
                                    {
                                        corners += 4;
                                        prevList = items;
                                        minheight++;
                                        continue;
                                    }

                                    for(int ind = 1; ind < items.Count; ind++)
                                    {
                                        if (items[ind].X - items[ind-1].X > 1)
                                        {
                                            corners += 2;
                                        }
                                    }

                                    if (items.First().X != prevList.First().X)
                                        corners += 2;

                                    if (items.Last().X != prevList.Last().X)
                                        corners += 2;

                                    prevList = items;
                                    minheight++;
                                }
                                Console.WriteLine(plant+ " " + corners +" "+ neighbour.Count);
                                totalSum += corners * neighbour.Count;
                            }

                        }

                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return totalSum;
        }
    }
}