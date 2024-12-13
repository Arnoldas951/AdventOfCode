using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AOC._2024.Day13
{
    public class Solution
    {
        public int Solution1(List<string> input)
        {
            Point prize = new Point();
            Point aButton = new Point();
            Point bButton = new Point();
            int coins = 0;
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] == "")
                {
                    prize = new Point();
                    aButton = new Point();
                    bButton = new Point();
                }
                else 
                {
                    string[] splitItem = input[i].Split(":");
                    switch(splitItem[0])
                    {
                        case "Button A":
                            var coordA = splitItem[1].Split(',');
                            aButton.X = int.Parse(coordA[0].Trim().Substring(2));
                            aButton.Y = int.Parse(coordA[1].Trim().Substring(2));
                            break;
                        case "Button B":
                            var coordB = splitItem[1].Split(',');
                            bButton.X = int.Parse(coordB[0].Trim().Substring(2));
                            bButton.Y = int.Parse(coordB[1].Trim().Substring(2));
                            break;
                        default:
                            var coordPrize = splitItem[1].Split(',');
                            prize.X = int.Parse(coordPrize[0].Trim().Substring(2));
                            prize.Y = int.Parse(coordPrize[1].Trim().Substring(2));
                            coins += IsPossible(prize, aButton, bButton);
                            break;
                    }
                }
            }
            return coins;
        }

        private int IsPossible(Point prize, Point buttonA, Point buttonB)
        {
           double movesA = (prize.X * buttonB.Y - prize.Y * buttonB.X) / (buttonA.X * buttonB.Y - buttonA.Y * buttonB.X);
            double movesB = (prize.X - buttonA.X * movesA) / buttonB.X;

            //Console.WriteLine("A " + movesA);
            //Console.WriteLine("B " + movesB + Environment.ne);

            if (movesA * buttonA.X + movesB * buttonB.X == prize.X 
                && movesA * buttonA.Y + movesB * buttonB.Y == prize.Y
                && movesA > 0
                && movesB > 0)
            {

                return (int)(movesA * 3 + movesB);
            }

            return 0;
        }

        public long Solution2(List<string> input)
        {
            Point aButton = new Point();
            Point bButton = new Point();
            long coins = 0;
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] == "")
                {
                    aButton = new Point();
                    bButton = new Point();
                }
                else
                {
                    string[] splitItem = input[i].Split(":");
                    switch (splitItem[0])
                    {
                        case "Button A":
                            var coordA = splitItem[1].Split(',');
                            aButton.X = int.Parse(coordA[0].Trim().Substring(2));
                            aButton.Y = int.Parse(coordA[1].Trim().Substring(2));
                            break;
                        case "Button B":
                            var coordB = splitItem[1].Split(',');
                            bButton.X = int.Parse(coordB[0].Trim().Substring(2));
                            bButton.Y = int.Parse(coordB[1].Trim().Substring(2));
                            break;
                        default:
                            var coordPrize = splitItem[1].Split(',');
                            coins += IsPossible2(long.Parse(coordPrize[0].Trim().Substring(2)) + 10000000000000,
                                long.Parse(coordPrize[1].Trim().Substring(2)) + 10000000000000,
                                aButton,
                                bButton);
                            break;
                    }
                }
            }
            return coins;
        }

        private long IsPossible2(long x, long y, Point buttonA, Point buttonB)
        {
            double movesA = (x * buttonB.Y - y * buttonB.X) / (buttonA.X * buttonB.Y - buttonA.Y * buttonB.X);
            double movesB = (x - buttonA.X * movesA) / buttonB.X;

            //Console.WriteLine("A " + movesA);
            //Console.WriteLine("B " + movesB + Environment.ne);

            if (movesA * buttonA.X + movesB * buttonB.X == x
                && movesA * buttonA.Y + movesB * buttonB.Y == y
                && movesA > 0
                && movesB > 0)
            {

                return (long)(movesA * 3 + movesB);
            }

            return 0;
        }
    }
}