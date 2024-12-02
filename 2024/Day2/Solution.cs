using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC._2024.Day2
{
    public class Solution
    {
        public int Solution1(List<string> input)
        {
            int safeReports = 0;
            foreach (var item in input)
            {
                int[] reportData = item.Split(" ").Select(Int32.Parse).ToArray();
                bool isDecreasing = false;
                for (int i = 1; i < reportData.Length; i++)
                {

                    int diff = reportData[i] - reportData[i - 1];

                    if (i == 1)
                    {
                        isDecreasing = diff < 0 ? true : false;
                    }

                    if (isDecreasing && diff >= 0 || diff < -3)
                        break;
                    else if (!isDecreasing && diff <= 0 || diff > 3)
                        break;

                    if (i == reportData.Length - 1)
                        safeReports++;

                }
            }
            return safeReports;
        }

        public int Solution2(List<string> input)
        {
            int safeReports = 0;
            foreach (var item in input)
            {
                List<int> reportData = item.Split(" ").Select(Int32.Parse).ToList();
                if(Check(reportData))
                    safeReports++;
                else 
                {
                    for(int i = 0; i < reportData.Count; i++)
                    {
                        var removedDupe = reportData.ToList();
                        removedDupe.RemoveAt(i);
                        if(Check(removedDupe))
                        {
                            safeReports++;
                            break;
                        }
                    }
                }
                
            }
            return safeReports;
        }

        private bool Check(List<int> input) 
        {
            bool isDecreasing = false;
            for (int i = 1; i < input.Count; i++)
            {

                int diff = input[i] - input[i - 1];

                if (i == 1)
                {
                    isDecreasing = diff < 0 ? true : false;
                }

                if (isDecreasing && diff >= 0 || diff < -3)
                    return false;
                else if (!isDecreasing && diff <= 0 || diff > 3)
                    return false;
            }

            return true;
        }
    }
}
