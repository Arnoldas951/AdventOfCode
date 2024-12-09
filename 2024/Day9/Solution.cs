using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AOC._2024.Day9
{
    public class Solution
    {
        public long Solution1(string input)
        {
            int id = 0;
            int index = 0;
            long sum = 0;
            List<string> chars = new List<string>();
            foreach (char c in input)
            {
                if (index == 0 || index % 2 == 0)
                {
                    FillString(c, chars, id.ToString());
                    id++;
                }

                if (index % 2 != 0)
                {
                    FillString(c, chars, ".");
                }
                index++;
            }

            int r = chars.Count - 1;
            int l = 0;
            while (l <= r)
            {


                string left = chars[l];
                string right = chars[r];
                if (l == r)
                {
                    if (left != ".")
                    {
                        sum += int.Parse(chars[l]) * l;
                    }
                    break;
                }
                if (left == "." && right != ".")
                {
                    chars[l] = right;
                    chars[r] = left;
                    sum += int.Parse(chars[l]) * l;
                    r--;
                    l++;
                    continue;
                }

                if (left != ".")
                {
                    sum += int.Parse(chars[l]) * l;
                    l++;
                }

                if (right == ".")
                    r--;
            }

            return sum;
        }

        public List<string> FillString(char c, List<string> fragment, string id)
        {
            int i = c - '0';
            while (i > 0)
            {
                fragment.Add(id);
                i--;
            }
            return fragment;
        }

        public List<string> FillString2(char c, List<string> fragment, string id)
        {
            int i = c - '0';
            if (id != ".")
            {
                fragment.Add(i + "," + id);
            }
            else 
            {
                while (i > 0) 
                {
                    fragment.Add(id);
                        i--;
                }
            }
                return fragment;
        }

        public long Solution2(string input) 
        {
            int id = 0;
            int index = 0;
            long sum = 0;
            List<string> chars = new List<string>();
            foreach (char c in input)
            {
                if (index == 0 || index % 2 == 0)
                {
                    FillString2(c, chars, id.ToString());
                    id++;
                }

                if (index % 2 != 0)
                {
                    FillString2(c, chars, ".");
                }
                index++;
            }

            for (int i = chars.Count - 1; i >= 0; i--)
            {
                if (!chars[i].Contains("."))
                {
                    var fileToMove = chars[i];
                    var split = fileToMove.Split(',');
                    int length = int.Parse(split[0]);
                    string fileId = split[1];
                    int spaceRequired = 0;
                    for(int j = 0; j < i; j++) 
                    {
                        spaceRequired = 0;
                        if (chars[j]  == ".")
                        {
                            int jIndex = j;
                            while (chars[jIndex++] == ".")
                            {
                                spaceRequired++;
                            }
                            if (spaceRequired == length || spaceRequired > length)
                            {
                                chars[j] = fileToMove;
                                chars[i] = length + ",.";
                                chars.RemoveRange(j + 1, length - 1);
                                i = i - (length -1) +1;
                                break;
                            }
                        }
                    }
                }
            }
            int counter = 0;
            foreach(var item in chars)
            {
                if (item != ".")
                {
                    var split = item.Split(',');
                    int length = int.Parse(split[0]);
                    int tempCount = counter;
                    if (split[1] == ".")
                    {
                        counter = counter + length;
                        continue;
                    }
                    
                    int fileId = int.Parse(split[1]);
                    
                    while(counter < tempCount + length)
                    {
                        sum += fileId * counter;
                        counter++;
                    }
                    
                }
                else {  counter++; }
            }

            return sum;
        }
    }
}