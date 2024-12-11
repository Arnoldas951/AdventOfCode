using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AOC._2024.Day11
{
    public class Solution
    {
        public int Solution1(string input)
        {
            var ItemArray = input.Split(' ').ToList();
            for (int i = 0; i < 75; i++)
            {
                ItemArray = AfterBlink(ItemArray);
            }
            return ItemArray.Count();
        }

        private List<string> AfterBlink(List<string> inputArray)
        {
            List<string> newList = new List<string>();
            for (int i = 0; i < inputArray.Count; i++)
            {
                if (inputArray[i] == "0")
                {
                    newList.Add("1");
                    //inputArray[i] = "1";
                }
                else if (inputArray[i].Length % 2 == 0)
                {
                    string firstHalf = long.Parse(inputArray[i].Substring(0, inputArray[i].Length / 2)).ToString();
                    string secondHalf = long.Parse(inputArray[i].Substring(inputArray[i].Length / 2)).ToString();
                    newList.Add(firstHalf);
                    newList.Add(secondHalf);
                }
                else
                {
                    long number = long.Parse(inputArray[i]);
                    newList.Add((number * 2024).ToString());
                }
            }
            return newList;
        }



        public long Solution2(string input)
        {
            Dictionary<string, long> repeats = new Dictionary<string, long>();
            var split = input.Split(' ').ToList();
            foreach (string s in split)
            {
                if (!repeats.ContainsKey(s))
                    repeats.Add(s, 0);

                repeats[s]++;
            }

            for (int i = 0; i < 25; i++)
            {
                repeats = AfterBlink2(repeats);
            }
            return repeats.Sum(f => f.Value);
        }

        private Dictionary<string, long> AfterBlink2(Dictionary<string, long> items)
        {
            Dictionary<string, long> newDict = new Dictionary<string, long>();

            foreach (var item in items)
            {
                if (item.Key == "0")
                {
                    if (!newDict.ContainsKey("1"))
                    {
                        newDict.Add("1", 0);
                    }
                    newDict["1"] += item.Value;
                }
                else if (item.Key.Length % 2 == 0)
                {
                    string firstHalf = long.Parse(item.Key.Substring(0, item.Key.Length / 2)).ToString();
                    string secondHalf = long.Parse(item.Key.Substring(item.Key.Length / 2)).ToString();
                    if (!newDict.ContainsKey(firstHalf))
                    {
                        newDict.Add(firstHalf, 0);
                    }
                    if (!newDict.ContainsKey(secondHalf))
                    {
                        newDict.Add(secondHalf, 0);
                    }

                    newDict[firstHalf] += item.Value;
                    newDict[secondHalf] += item.Value;

                }
                else
                {
                    long number = long.Parse(item.Key);
                    string newNumber = (number * 2024).ToString();
                        if (!newDict.ContainsKey(newNumber))
                            newDict.Add(newNumber, 0);

                        newDict[newNumber] += item.Value;
                }
            }
            return newDict;
        }
    }
}