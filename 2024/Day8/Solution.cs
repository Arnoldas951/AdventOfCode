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
        public long Solution1(string[] input)
        {
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

            foreach(var pair in pairs) 
            {
                var test = pair.Value;
                for(int i = 0; i < test.Count-1; i++)
                {
                    Point difference = new Point(test[i+1].X - test[i].X, test[i+1].Y - test[i].Y);
                }
            }
            
            return 0;  
        }

        public long Solution2(string[] input)
        {
            return 0;
        }
    }
}
