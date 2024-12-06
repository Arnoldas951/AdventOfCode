using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC._2024.Day6
{
    public class Solution
    {
        public Dictionary<string, string> directionChange = new Dictionary<string, string>() { { "F", "R" }, { "R", "B" }, { "B", "L" }, { "L", "F" } };
        public int Solution1(string[] input)
        {
            List<string> visitedNodes = new List<string>();
            int[,] startingPosition = new int[1, 2];
            bool inbounds = true;
            string direction = "F";
            char Obsticle = '#';
            int lineLength = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].Contains("^"))
                {
                    startingPosition[0, 0] = input[i].IndexOf("^");
                    startingPosition[0, 1] = i;
                    lineLength = input[i].Length - 1;
                }
            }
            int horizontal = startingPosition[0, 0];
            int vertical = startingPosition[0, 1];

            while (inbounds)
            {

                if ((vertical - 1 < 0 && direction == "F")
                    || (vertical + 1 > input.Length - 1 && direction == "B")
                    || (horizontal - 1 < 0 && direction == "L")
                    || (horizontal + 1 > lineLength && direction == "R"))
                    inbounds = false;
                else
                {
                    switch (direction)
                    {
                        case "F":
                            if (input[vertical - 1][horizontal] != Obsticle)
                            {
                                vertical--;
                                if (!visitedNodes.Contains($"{horizontal},{vertical}"))
                                {
                                    visitedNodes.Add($"{horizontal},{vertical}");
                                }
                            }
                            else
                                direction = directionChange[direction];
                            break;
                        case "R":
                            if (input[vertical][horizontal + 1] != Obsticle)
                            {
                                horizontal++;
                                if (!visitedNodes.Contains($"{horizontal},{vertical}"))
                                {
                                    visitedNodes.Add($"{horizontal},{vertical}");
                                }
                            }
                            else
                                direction = directionChange[direction];
                            break;
                        case "B":
                            if (input[vertical + 1][horizontal] != Obsticle)
                            {
                                vertical++;
                                if (!visitedNodes.Contains($"{horizontal},{vertical}"))
                                {
                                    visitedNodes.Add($"{horizontal},{vertical}");
                                }
                            }
                            else
                                direction = directionChange[direction];
                            break;
                        case "L":
                            if (input[vertical][horizontal - 1] != Obsticle)
                            {
                                horizontal--;
                                if (!visitedNodes.Contains($"{horizontal},{vertical}"))
                                {
                                    visitedNodes.Add($"{horizontal},{vertical}");
                                }
                            }
                            else
                                direction = directionChange[direction];
                            break;
                    }
                }
            }
            return visitedNodes.Count + 1;
        }

        public int Solution2(string[] input)
        {
            List<string> visitedNodes = new List<string>();
            int[,] startingPosition = new int[1, 2];
            bool inbounds = true;
            string direction = "F";
            char Obsticle = '#';
            int lineLength = 0;
            int possibleLoops = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].Contains("^"))
                {
                    startingPosition[0, 0] = input[i].IndexOf("^");
                    startingPosition[0, 1] = i;
                    lineLength = input[i].Length - 1;
                }
            }
            int horizontal = startingPosition[0, 0];
            int vertical = startingPosition[0, 1];
            //visitedNodes.Add($"{horizontal},{vertical}");

            while (inbounds)
            {

                if ((vertical - 1 < 0 && direction == "F")
                    || (vertical + 1 > input.Length - 1 && direction == "B")
                    || (horizontal - 1 < 0 && direction == "L")
                    || (horizontal + 1 > lineLength && direction == "R"))
                    inbounds = false;
                else
                {
                    switch (direction)
                    {
                        case "F":
                            if (input[vertical - 1][horizontal] != Obsticle)
                            {
                                vertical--;
                                if (!visitedNodes.Contains($"{horizontal},{vertical}"))
                                {
                                    visitedNodes.Add($"{horizontal},{vertical}");
                                }
                            }
                            else
                                direction = directionChange[direction];
                            break;
                        case "R":
                            if (input[vertical][horizontal + 1] != Obsticle)
                            {
                                horizontal++;
                                if (!visitedNodes.Contains($"{horizontal},{vertical}"))
                                {
                                    visitedNodes.Add($"{horizontal},{vertical}");
                                }
                            }
                            else
                                direction = directionChange[direction];
                            break;
                        case "B":
                            if (input[vertical + 1][horizontal] != Obsticle)
                            {
                                vertical++;
                                if (!visitedNodes.Contains($"{horizontal},{vertical}"))
                                {
                                    visitedNodes.Add($"{horizontal},{vertical}");
                                }
                            }
                            else
                                direction = directionChange[direction];
                            break;
                        case "L":
                            if (input[vertical][horizontal - 1] != Obsticle)
                            {
                                horizontal--;
                                if (!visitedNodes.Contains($"{horizontal},{vertical}"))
                                {
                                    visitedNodes.Add($"{horizontal},{vertical}");
                                }
                            }
                            else
                                direction = directionChange[direction];
                            break;
                    }
                }
            }
            foreach(var block in visitedNodes) 
            {
                var split = block.Split(",");
                if (WillLoop(input, startingPosition[0,0], startingPosition[0,1], block, lineLength))
                    possibleLoops++;
            }
            return possibleLoops;
        }

        public bool WillLoop(string[] input, int startingPositionX, int startingPositionY, string blockSquare, int lineLength)
        {
            List<string> visitedNodes = new List<string>();
            int horizontal = startingPositionX;
            int vertical = startingPositionY;
            bool inbounds = true;
            string direction = "F";

            while (inbounds)
            {
                if (visitedNodes.Contains($"{horizontal},{vertical},{direction}"))
                {
                    return true;
                }
                else
                {
                    visitedNodes.Add($"{horizontal},{vertical},{direction}");
                }

                if ((vertical - 1 < 0 && direction == "F")
                    || (vertical + 1 > input.Length - 1 && direction == "B")
                    || (horizontal - 1 < 0 && direction == "L")
                    || (horizontal + 1 > lineLength && direction == "R"))
                    inbounds = false;
                else
                {
                    switch (direction)
                    {
                        case "F":
                            if (input[vertical - 1][horizontal] != '#' && blockSquare != $"{horizontal},{vertical-1}")
                            {
                                vertical--;
                            }
                            else
                                direction = directionChange[direction];
                            break;
                        case "R":
                            if (input[vertical][horizontal + 1] != '#' && blockSquare != $"{horizontal+1},{vertical}")
                            {
                                horizontal++;
                            }
                            else
                                direction = directionChange[direction];
                            break;
                        case "B":
                            if (input[vertical + 1][horizontal] != '#' && blockSquare != $"{horizontal},{vertical+1}")
                            {
                                vertical++;
                            }
                            else
                                direction = directionChange[direction];
                            break;
                        case "L":
                            if (input[vertical][horizontal - 1] != '#' && blockSquare != $"{horizontal-1},{vertical}")
                            {
                                horizontal--;
                            }
                            else
                                direction = directionChange[direction];
                            break;
                    }
                }
            }

            return false;
        }

    }
}
