using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC._2024.Day5
{
    public class Solution
    {
        private WithDuplicateValues orderingList = new WithDuplicateValues();
        public int Solution1(List<string> input)
        {
            int countOfCorrectPages = 0;
            List<string> printPages = new List<string>();
            foreach (var item in input)
            {
                if (!string.IsNullOrEmpty(item) && item.Contains("|"))
                {
                    var splitItem = item.Split("|");
                    orderingList.Add(int.Parse(splitItem[0]), int.Parse(splitItem[1]));
                }
                else
                {
                    if (!string.IsNullOrEmpty(item))
                        printPages.Add(item);
                }
            }

            for (int i = 0; i < printPages.Count; i++)
            {
                countOfCorrectPages += isOrderCorrect(printPages[i]);
            }

            return countOfCorrectPages;
        }

        private int isOrderCorrect(string pages)
        {
            var splitPages = pages.Split(",");
            for (int i = 0; i < splitPages.Length; i++)
            {
                int parsedI = int.Parse(splitPages[i]);
                for (int j = i + 1; j < splitPages.Length; j++)
                {
                    int parsedJ = int.Parse(splitPages[j]);
                    if (orderingList.Where(f => f.Key == parsedI && f.Value == parsedJ).Any())
                    {
                        continue;
                    }
                    else
                        return 0;
                }
            }

            int mid = splitPages.Length / 2;

            return int.Parse(splitPages[mid]);
        }

        public int Solution2(List<string> input)
        {
            int countOfIncorrectPages = 0;
            List<string> printPages = new List<string>();
            foreach (var item in input)
            {
                if (!string.IsNullOrEmpty(item) && item.Contains("|"))
                {
                    var splitItem = item.Split("|");
                    orderingList.Add(int.Parse(splitItem[0]), int.Parse(splitItem[1]));
                }
                else
                {
                    if (!string.IsNullOrEmpty(item))
                        printPages.Add(item);
                }
            }

            for (int i = 0; i < printPages.Count; i++)
            {
                if (!isPageOrderCorrect(printPages[i]))
                    countOfIncorrectPages += isOrderIncorrect(printPages[i]);
            }

            return countOfIncorrectPages;
        }

        private bool isPageOrderCorrect(string pages)
        {
            var splitPages = pages.Split(",");
            for (int i = 0; i < splitPages.Length; i++)
            {
                int parsedI = int.Parse(splitPages[i]);
                for (int j = i + 1; j < splitPages.Length; j++)
                {
                    int parsedJ = int.Parse(splitPages[j]);
                    if (orderingList.Where(f => f.Key == parsedI && f.Value == parsedJ).Any())
                    {
                        continue;
                    }
                    else
                        return false;
                }
            }
            return true;
        }

        private int isOrderIncorrect(string pages)
        {
            var splitPages = pages.Split(",");
            int[] tempArray = new int[splitPages.Length];
            var listOfRules = new WithDuplicateValues();
            for (int i = 0; i < splitPages.Length; i++)
            {
                int parsedI = int.Parse(splitPages[i]);
                for (int j = 0; j < splitPages.Length; j++)
                {

                    if (i != j)
                    {
                        int parsedJ = int.Parse(splitPages[j]);
                        var orders = orderingList.Where(f => f.Key == parsedI && f.Value == parsedJ).ToList();
                        listOfRules.AddRange(orders);
                    }
                }
                int ruleCount = listOfRules.Where(f => f.Key == parsedI).Count();
                tempArray[(tempArray.Length - 1) - ruleCount] = parsedI;
            }



            int mid = tempArray.Length / 2;

            return tempArray[mid];
        }


        private class WithDuplicateValues : List<KeyValuePair<int, int>>
        {
            public void Add(int key, int value)
            {
                var item = new KeyValuePair<int, int>(key, value);
                this.Add(item);
            }
        }
    }
}
