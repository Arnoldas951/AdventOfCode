using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AOC._2024.Day19
{
    public class Solution
    {
        public int Solution1(List<string> input)
        {
            int possibleCounter = 0;
            List<string> possibleTowels = new List<string>();
            List<string> requiredOutcomes = new List<string>();
            string[] splitPossibilities = input[0].Split(", ");
            input.RemoveRange(0, 2);
            foreach (string s in splitPossibilities)
                possibleTowels.Add(s);

            int maxLength = possibleTowels.Select(f => f.Length).Max();

            foreach (string s in input)
                requiredOutcomes.Add(s);

            foreach (string s in requiredOutcomes)
            {
                if (CombinationPossible(s, possibleTowels, maxLength))
                    possibleCounter++;
            }

            return possibleCounter;
        }

        private bool CombinationPossible(string combination, List<string> possibilities, int maxLength)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder intermediate = new StringBuilder();

            int index = 0;

            while (sb.Length < combination.Length && combination.Length > index)
            {
                intermediate.Append(combination[index]);
                index++;
                if (possibilities.Contains(intermediate.ToString()))
                {
                    sb.Append(intermediate);
                    intermediate.Clear();
                    continue;
                }

                if (possibilities.Contains(intermediate.ToString()) && intermediate.Length < maxLength)
                {
                    sb.Append(intermediate);
                    intermediate.Clear();
                    continue;
                }
                else
                {
                    int tempind = sb.Length;
                    string temp = intermediate.ToString();
                    while (tempind > 0 && temp.Length < maxLength)
                    {
                        temp = temp.Insert(0, sb[tempind - 1].ToString());
                        if (possibilities.Contains(temp))
                        {
                            sb.Append(intermediate);
                            intermediate.Clear();
                            break;
                        }
                        tempind--;
                    }
                }
            }

            return combination == sb.ToString();
        }


        public long Solution2(List<string> input)
        {
            long possibleCounter = 0;
            List<string> possibleTowels = new List<string>();
            List<string> requiredOutcomes = new List<string>();
            string[] splitPossibilities = input[0].Split(", ");
            input.RemoveRange(0, 2);
            foreach (string s in splitPossibilities)
                possibleTowels.Add(s);

            int maxLength = possibleTowels.Select(f => f.Length).Max();

            foreach (string s in input)
                requiredOutcomes.Add(s);

            foreach (string s in requiredOutcomes)
            {
                possibleCounter += WaysOfArrangement(s, possibleTowels, maxLength);
            }

            return possibleCounter;
        }

        private Dictionary<string, long> computedCombos = new Dictionary<string, long>();


        private long WaysOfArrangement(string combination, List<string> posibilities, int maxLength)
        {
            
            long ways = 0;
            int length = combination.Length < maxLength ? combination.Length : maxLength;
            if (combination == string.Empty)
            {
                return 1;
            }

            if (computedCombos.ContainsKey(combination))
                return computedCombos[combination];

            for (int i = 0; i < length + 1; i++)
            {
                if (posibilities.Contains(combination.Substring(0, i)))
                {
                    long computed = WaysOfArrangement(combination.Substring(i), posibilities, maxLength);

                    if (!computedCombos.ContainsKey(combination.Substring(i)))
                        computedCombos.Add(combination.Substring(i), computed);

                    //if(computed.)

                    ways += computed;
                }
            }

            return ways;
        }
    }
}