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
                fragment.Add(i+","+id);
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

            int r = chars.Count - 1;
            int l = 0;
            while (l <= r)
            {
                if (l % 2 != 0)
                {
                    string left = chars[l];
                    var splitLeft = left.Split(',');
                    int lastElement = chars.Count() - 1;
                    int spacesToFill = int.Parse(splitLeft[0]);
                    while (lastElement > l && spacesToFill != 0)
                    {
                        if (lastElement % 2 != 0)
                        {
                            lastElement--;
                            continue;
                        }
                        else
                        {
                            string right = chars[lastElement];
                            var splitRight = right.Split(',');
                            int spaceToTake = int.Parse(splitRight[0]);
                            if (splitRight[1] != "." && (spaceToTake <= spacesToFill))
                            {
                                chars[l] = right;
                                chars[lastElement] = left;
                                sum += int.Parse(splitRight[1]) * l;
                                spacesToFill = spacesToFill - spaceToTake;
                            }
                        }
                        lastElement--;
                    }
                }
                l++;
            }

            return sum;
        }
    }
}