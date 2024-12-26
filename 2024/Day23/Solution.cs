using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Formats.Tar;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AOC._2024.Day23
{
    public class Solution
    {
        public int Solution1(List<string> input)
        {
            HashSet<(string, string, string)> setOfItems = new HashSet<(string, string, string)>();
            Dictionary<string, List<string>> pairs = new Dictionary<string, List<string>>();
            foreach (var item in input)
            {
                List<string> splitItem = item.Split('-').ToList();
                if (!pairs.ContainsKey(splitItem[0]))
                {
                    pairs.Add(splitItem[0], new List<string>() { splitItem[1] });
                }
                else
                {
                    pairs[splitItem[0]].Add(splitItem[1]);
                }

                if (!pairs.ContainsKey(splitItem[1]))
                {
                    pairs.Add(splitItem[1], new List<string>() { splitItem[0] });
                }
                else
                {
                    pairs[splitItem[1]].Add(splitItem[0]);
                }
            }


            var historians = pairs.Where(f => f.Key.StartsWith("t")).ToList();
            foreach (var pair in historians)
            {
                foreach (var value in pair.Value)
                {
                    foreach (var item in pairs[value])
                    {
                        if (pair.Key != item && pairs[item].Contains(pair.Key))
                        {
                            string[] items = [pair.Key, value, item];
                            Array.Sort(items);
                            setOfItems.Add(new(items[0], items[1], items[2]));
                        }
                    }
                }
            }

            return setOfItems.Count;
        }

        public int Solution2(List<string> input)
        {
            List<(string, string, string)> setOfItems = new List<(string, string, string)>();
            Dictionary<string, List<string>> pairs = new Dictionary<string, List<string>>();
            foreach (var item in input)
            {
                List<string> splitItem = item.Split('-').ToList();
                if (!pairs.ContainsKey(splitItem[0]))
                {
                    pairs.Add(splitItem[0], new List<string>() { splitItem[1] });
                }
                else
                {
                    pairs[splitItem[0]].Add(splitItem[1]);
                }

                if (!pairs.ContainsKey(splitItem[1]))
                {
                    pairs.Add(splitItem[1], new List<string>() { splitItem[0] });
                }
                else
                {
                    pairs[splitItem[1]].Add(splitItem[0]);
                }
            }


            foreach (var pair in pairs)
            {
                foreach (var value in pair.Value)
                {
                    foreach (var item in pairs[value])
                    {
                        if (pair.Key != item && pairs[item].Contains(pair.Key))
                        {
                            string[] items = [pair.Key, value, item];
                            Array.Sort(items);
                            setOfItems.Add(new(items[0], items[1], items[2]));
                        }
                    }
                }
            }

            return 0;
        }
    }
}