using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AOC._2024.Day7
{
    public class Solution
    {
        public long Solution1(string[] input)
        {
            long sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                string[] splitLine = input[i].Split(':');
                long requiredAnsw = long.Parse(splitLine[0]);
                var possibleNumbers = splitLine[1].TrimStart().Split(" ").Select(long.Parse).ToArray();
                if (isValid(requiredAnsw, possibleNumbers))
                    sum = sum + requiredAnsw;
            }
            return sum;
        }

        public bool isValid(long answ, long[] numbers)
        {
            if(numbers.Length == 0) 
                return answ == 0;
            int length = numbers.Length ;
            long lastNumber = numbers.Last();
            Array.Resize(ref numbers, numbers.Length-1);
            return isValid(answ - lastNumber, numbers) || (answ % lastNumber == 0 && isValid(answ / lastNumber, numbers));
        }

        //29229114137295
        public long Solution2(string[] input)
        {
            long sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                string[] splitLine = input[i].Split(':');
                long requiredAnsw = long.Parse(splitLine[0]);
                var possibleNumbers = splitLine[1].TrimStart().Split(" ").Select(long.Parse).ToArray();
                if (isValid2(requiredAnsw, possibleNumbers))
                    sum = sum + requiredAnsw;
            }
            return sum;
        }

        public bool isValid2(long answ, long[] numbers)
        {
            if (numbers.Length == 1)
                return answ == numbers[0];

            long firstElement = numbers[0];
            long secondElement = numbers[1];
            numbers[1] = firstElement + secondElement;
            if (isValid2(answ, numbers.Skip(1).ToArray()))
                return true;

            numbers[1] = firstElement*secondElement;
            if (isValid2(answ, numbers.Skip(1).ToArray()))
                return true;

            long newNumber = long.Parse(firstElement.ToString() + secondElement.ToString());
            numbers[1] = newNumber;
            if (isValid2(answ, numbers.Skip(1).ToArray()))
                return true;

            return false;
        }
    }
}
