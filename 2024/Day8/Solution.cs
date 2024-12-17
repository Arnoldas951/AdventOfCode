using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AOC._2024.Day8
{
    public class Solution
    {
        private Dictionary<char, List<Point>> pairs = new Dictionary<char, List<Point>>();
        private List<Point> antiNodes = new List<Point>();
        public long Solution1(string[] input)
        {
            int height = input.Length;
            int width = input[0].Length;
            for (int i = 0; i < input.Length; i++)
            {
                var line = input[i];
                for (int j = 0; j < line.Length; j++)
                {
                    if (input[i][j] != '.')
                    {
                        if (!pairs.ContainsKey(input[i][j]))
                        {
                            pairs.Add(input[i][j], new List<Point>() { new Point(j, i) });
                        }
                        else
                        {
                            pairs[input[i][j]].Add(new Point(j, i));
                        }
                    }
                }
            }

            foreach (var pair in pairs)
            {
                var values = pair.Value;
                for (int i = 0; i < values.Count; i++)
                {
                    for (int j = i + 1; j < values.Count; j++)
                    {
                        antiNodes.Add(new Point(2 * values[i].X - values[j].X, 2 * values[i].Y - values[j].Y));
                        antiNodes.Add(new Point(2 * values[j].X - values[i].X, 2 * values[j].Y - values[i].Y));
                    }
                }
            }

            return antiNodes.Where(f => f.X >= 0 && f.X < height && f.Y >= 0 && f.Y < width).Distinct().Count();
        }

        public long Solution2(string[] input)
        {
            return 0;
        }
    }
}
