using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AOC._2024.Day4
{
    public class Solution
    {
        private static string Xmas = "XMAS";
        private static string Smax = "SAMX";
        private static string Mas = "MAS";
        private static string Sam = "SAM";
        public int Solution1(List<string> input)
        {
            int count = 0;
            for (int i = 0; i < input.Count; i++)
            {
                int length = input[i].Length;
                int index = 0;
                count += Regex.Matches(input[i], Xmas).Count;
                count += Regex.Matches(input[i], Smax).Count;

                if (i <= input.Count - 4)
                {
                    foreach (char c in input[i])
                    {
                        if (index > length)
                            break;
                        if (c == 'X' || c == 'S')
                        {
                            if (IsXmasVertically(input, i, 0, index, c.ToString()))
                                count++;


                            if (IsXMASDiag(input, i, 0, index + 1, c.ToString(), true))
                                count++;

                            if (IsXMASDiag(input, i, 0, index - 1, c.ToString(), false))
                                count++;


                        }
                        index++;
                    }
                }
            }
            return count;
        }


        public bool IsXmasVertically(List<string> input, int lineIndex, int position, int index, string output)
        {
            if (position < 3)
            {
                output += input[lineIndex + 1][index];
                if (output == Xmas || output == Smax)
                    return true;

                if (Xmas.Contains(output) || Smax.Contains(output))
                {
                    return IsXmasVertically(input, lineIndex + 1, position + 1, index, output);
                }
                return false;

            }
            return false;
        }

        public bool IsXMASDiag(List<string> input, int lineIndex, int position, int index, string output, bool toRight)
        {
            int length = input.Count - 1;
            if (index > length || index < 0)
            {
                return false;
            }
            if (position < 3)
            {
                output += input[lineIndex + 1][index];
                if (output == Xmas || output == Smax)
                    return true;

                if (Xmas.Contains(output) || Smax.Contains(output))
                {
                    if (toRight)
                        return IsXMASDiag(input, lineIndex + 1, position + 1, index + 1, output, true);
                    else
                        return IsXMASDiag(input, lineIndex + 1, position + 1, index - 1, output, false);
                }
                return false;

            }
            return false;
        }

        public int Solution2(List<string> input)
        {
            int count = 0;
            for (int i = 0; i < input.Count; i++)
            {
                int length = input[i].Length;
                int index = 0;
                if (i <= input.Count - 2)
                {
                    foreach (char c in input[i])
                    {
                        if (index > length)
                            break;
                        if (c == 'A')
                        {
                            if (IsMASInX(input, i, index))
                                count++;
                        }
                        index++;
                    }
                }
            }
            return count;
        }

        public bool IsMASInX(List<string> input, int lineIndex, int index)
        {
            if (lineIndex == 0 || index == 0 || index == input[lineIndex].Length -1)
                return false;

            string leftRight = string.Empty;
            string rightLeft = string.Empty;

            leftRight += input[lineIndex - 1][index - 1].ToString() + input[lineIndex][index].ToString() + input[lineIndex + 1][index + 1].ToString();
            rightLeft += input[lineIndex - 1][index + 1].ToString() + input[lineIndex][index].ToString() + input[lineIndex + 1][index - 1].ToString();

            if ((leftRight == Sam || leftRight == Mas) && (rightLeft == Sam || rightLeft == Mas))
                return true;

            return false;
        }
    }
}
