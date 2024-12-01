using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC._2024.Day1
{
    public class Solution
    {
        public int Solution1(List<string> input) 
        {
            int length = input.Count;
            int[] leftArray = new int[length];
            int[] rightArray = new int[length];
            int index = 0;
            int difference = 0;
            input.ForEach(line =>
            {
                var splitLine = line.Split(' ');
                leftArray[index] = int.Parse(splitLine[0]);
                rightArray[index] = int.Parse(splitLine[3]);
                index++;
            });

            Array.Sort(leftArray);
            Array.Sort(rightArray);

            for (int i = 0; i<length; i++) 
            {
                int tempDif = rightArray[i] - leftArray[i];
                if (tempDif < 0)
                    tempDif = tempDif * -1;

                difference = difference + tempDif;
            }


            return difference;

        }

        public int Solution2(List<string> input)
        {
            int length = input.Count;
            List<int> leftList = new List<int>();
            List<int> rightList = new List<int>();
            int similarity = 0;
            input.ForEach(line =>
            {
                var splitLine = line.Split(' ');
                leftList.Add(int.Parse(splitLine[0]));
                rightList.Add(int.Parse(splitLine[3]));
            });

            leftList.ForEach(number =>
            {
                var count = rightList.Where(f => f == number).Count();
                int numberSimilarity = count * number;
                similarity += numberSimilarity;
            });

            return similarity;
        }

    }
}
