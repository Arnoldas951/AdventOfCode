using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AOC._2024.Day25
{
    public class Solution
    {
        public int Solution1(List<string> input)
        {
            Queue<int> emptyLines = new Queue<int>();
            List<int[]> keys = new List<int[]>();
            List<int[]> locks = new List<int[]>();
            int fitTogether = 0;
            int startingIndex = 0;
            for (int i = 0; i<input.Count; i++)
            {
                if (input[i] == string.Empty)
                    emptyLines.Enqueue(i);
            }
            emptyLines.Enqueue(input.Count);
            while(emptyLines.Count !=0)
            {
                int range = emptyLines.Dequeue();
                string firstLine = input[startingIndex];
                int[] counts = new int[firstLine.Length];
                int height = 0;
                
                for (int i = startingIndex; i< range; i++)
                {
                    for (int j = 0; j < input[i].Length; j++) {
                        if (firstLine.Contains("."))
                        {
                            if (input[i][j] == '.')
                                counts[j] = range - startingIndex-2 - height;
                        }
                        else
                        {
                            if (input[i][j] == '#')
                                counts[j] = height;
                        }
                    }
                    height++;
                }

                if (firstLine.Contains("."))
                {
                    keys.Add(counts);
                }
                else
                {
                    locks.Add(counts);
                }

                startingIndex = range + 1;
            }

            foreach(var item in locks)
            {
                
                for(int i = 0; i<keys.Count; i++)
                {
                    bool fits = true;
                    for (int j = 0; j < keys[i].Length; j++)
                    {
                        if (item[j] + keys[i][j] > 5)
                        {
                            fits = false;
                            break;
                        }
                    }
                    if(fits)
                        fitTogether++;
                }
            }

            return fitTogether;
        }

        public int Solution2() { return 0; }
    }
}