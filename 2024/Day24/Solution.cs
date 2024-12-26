using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AOC._2024.Day24
{
    public class Solution
    {
        public long Solution1(List<string> input)
        {
            Dictionary<int, List<string>> givenValues = new Dictionary<int, List<string>>() { { 0, new List<string>() }, { 1, new List<string>() } };
            List<Operation> operationsToFind = new List<Operation>();
            int solved = 0;
            bool reachedPuzzle = false;
            foreach (string s in input)
            {
                if (s == string.Empty)
                {
                    reachedPuzzle = true;

                }
                else
                {
                    if (reachedPuzzle)
                    {
                        string[] split = s.Split(" ");
                        Operation op = new Operation(split[0], split[1], split[2], split[4]);
                        operationsToFind.Add(op);
                    }
                    else
                    {
                        string[] split = s.Split(": ");
                        givenValues[int.Parse(split[1])].Add(split[0]);
                    }
                }
            }

            while (solved < operationsToFind.Count)
            {
                var currentValues = givenValues.SelectMany(f => f.Value);
                var opperations = operationsToFind.Where(f => currentValues.Contains(f.variable1)
                && currentValues.Contains(f.variable2) && !currentValues.Contains(f.value)).ToList();
                solved += opperations.Count;
                foreach(var operation in opperations)
                {
                    int val1 = givenValues[0].Contains(operation.variable1) ? 0 : 1;
                    int val2 = givenValues[0].Contains(operation.variable2) ? 0 : 1;
                    if (GetValue(operation.operation, val1, val2) == 0)
                        givenValues[0].Add(operation.value);
                    else
                        givenValues[1].Add(operation.value);
                }
                
            }

            var solvedZeros = givenValues[0].Where(f => f.StartsWith("z")).OrderBy(f => f).Select(f => f + " 0").ToList();
            var solvedOnes = givenValues[1].Where(f => f.StartsWith("z")).OrderBy(f => f).Select(f => f + " 1").ToList();
            var joinedList = solvedOnes.Concat(solvedZeros).OrderByDescending(f => f);
            string binaryCode = "";
            foreach(var s in joinedList)
            {
                var split = s.Split(' ');
                binaryCode += split[1];
            }

            return Convert.ToInt64(binaryCode, 2);
        }

        private int GetValue(string operation, int variableValue1, int variableValue2)
        {

            switch(operation)
            {
                case "AND":
                    if (variableValue1 == 1 && variableValue2 == 1)
                        return 1;
                    return 0;
                case "OR":
                    if (variableValue1 == 1 || variableValue2 == 1)
                        return 1;
                    return 0;
                default:
                    if (variableValue1 != variableValue2)
                        return 1;
                    return 0;
            }
        }

        public int Solution2() { return 0; }

        private record Operation(string variable1, string operation, string variable2, string value);
    }
}