using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AOC._2024.Day15
{
    public class Solution
    {
        private Dictionary<char, List<Point>> objects = new Dictionary<char, List<Point>>();
        public int Solution1(List<string> input)
        {
            int sum = 0;
            string directions = input[input.Count - 1];
            Point startingPosition = new Point();
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] == "")
                    break;

                for (int j = 0; j < input[i].Length; j++)
                {
                    if (input[i][j] == '@')
                    {
                        startingPosition.X = j;
                        startingPosition.Y = i;
                    }
                    else
                    {
                        if (input[i][j] != '.')
                        {
                            if (!objects.ContainsKey(input[i][j]))
                            {
                                objects.Add(input[i][j], new List<Point>() { new Point(j, i) });
                            }
                            else
                            {
                                objects[input[i][j]].Add(new Point(j, i));
                            }
                        }
                    }
                }
            }

            foreach (char c in directions)
            {
                startingPosition = canMove(c, startingPosition);
            }

            foreach (var item in objects['O'])
            {
                sum += 100 * item.Y + item.X;
            }

            return sum;
        }

        private Point canMove(char c, Point startingPos)
        {
            switch (c)
            {
                case '^':
                    if (canMove1(c, startingPos))
                        startingPos.Y -= 1;
                    break;
                case 'v':
                    if (canMove1(c, startingPos))
                        startingPos.Y += 1;
                    break;
                case '>':
                    if (canMove1(c, startingPos))
                        startingPos.X += 1;
                    break;
                default:
                    if (canMove1(c, startingPos))
                        startingPos.X -= 1;
                    break;
            }

            return startingPos;
        }

        private bool canMove1(char dir, Point startingPos)
        {
            var pushableObjects = objects['O'];
            Point newCoord = new Point();
            switch (dir)
            {
                case '^':
                    if (!objects['#'].Any(f => f.Y == startingPos.Y - 1 && f.X == startingPos.X))
                    {
                        var dictItem = pushableObjects.Where(f => f.Y == startingPos.Y - 1 && f.X == startingPos.X).Select(f => f).FirstOrDefault();
                        if (dictItem == Point.Empty)
                        {
                            return true;
                        }
                        else
                        {
                            startingPos.Y -= 1;
                            if (canMove1(dir, startingPos))
                            {
                                newCoord = dictItem;
                                newCoord.Y -= 1;
                                pushableObjects.Remove(dictItem);
                                pushableObjects.Add(newCoord);
                                return true;
                            }
                        }
                    }
                    return false;
                case 'v':
                    if (!objects['#'].Any(f => f.Y == startingPos.Y + 1 && f.X == startingPos.X))
                    {
                        var dictItem = pushableObjects.Where(f => f.Y == startingPos.Y + 1 && f.X == startingPos.X).Select(f => f).FirstOrDefault();
                        if (dictItem == Point.Empty)
                        {
                            return true;
                        }
                        else
                        {
                            startingPos.Y += 1;
                            if (canMove1(dir, startingPos))
                            {
                                newCoord = dictItem;
                                newCoord.Y += 1;
                                pushableObjects.Remove(dictItem);
                                pushableObjects.Add(newCoord);
                                return true;
                            }
                            return false;
                        }
                    }
                    return false;
                case '>':
                    if (!objects['#'].Any(f => f.Y == startingPos.Y && f.X == startingPos.X + 1))
                    {
                        var dictItem = pushableObjects.Where(f => f.Y == startingPos.Y && f.X == startingPos.X + 1).Select(f => f).FirstOrDefault();
                        if (dictItem == Point.Empty)
                        {
                            return true;
                        }
                        else
                        {
                            startingPos.X += 1;
                            if (canMove1(dir, startingPos))
                            {
                                newCoord = dictItem;
                                newCoord.X += 1;
                                pushableObjects.Remove(dictItem);
                                pushableObjects.Add(newCoord);
                                return true;
                            }
                            return false;
                        }
                    }
                    return false;
                default:
                    if (!objects['#'].Any(f => f.Y == startingPos.Y && f.X == startingPos.X - 1))
                    {
                        var dictItem = pushableObjects.Where(f => f.Y == startingPos.Y && f.X == startingPos.X - 1).Select(f => f).FirstOrDefault();
                        if (dictItem == Point.Empty)
                        {
                            return true;
                        }
                        else
                        {
                            startingPos.X -= 1;
                            if (canMove1(dir, startingPos))
                            {
                                newCoord = dictItem;
                                newCoord.X -= 1;
                                pushableObjects.Remove(dictItem);
                                pushableObjects.Add(newCoord);
                                objects['O'] = pushableObjects;
                                return true;
                            }
                            return false;
                        }
                    }
                    return false;
            }
        }

        private char[,] globalMap;
        public long Solution2(List<string> input)
        {
            long sum = 0;
            char[,] map = new char[input[0].Length * 2, input.Count];
            int lastIndex = 0;
            string directions = string.Empty;
            Point startingPosition = new Point();
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] == "")
                {
                    lastIndex = i;
                    break;
                }

                for (int j = 0; j < input[i].Length; j++)
                {
                    if (input[i][j] == '@')
                    {
                        startingPosition.X = j * 2;
                        startingPosition.Y = i;
                        map[j * 2, i] = '@';
                        map[j * 2 + 1, i] = '.';
                        continue;
                    }

                    if (input[i][j] == '.')
                    {
                        map[j * 2, i] = '.';
                        map[j * 2 + 1, i] = '.';
                        continue;
                    }

                    if (input[i][j] == '#')
                    {
                        map[j * 2, i] = '#';
                        map[j * 2 + 1, i] = '#';
                        continue;
                    }

                    if (input[i][j] == 'O')
                    {
                        map[j * 2, i] = '[';
                        map[j * 2 + 1, i] = ']';
                        continue;
                    }
                }
            }

            for(int i = lastIndex; i < input.Count; i++)
            {
                directions += input[i];
            }
            globalMap = map;
            for (int i = 0; i < globalMap.GetLength(1); i++)
            {
                for (int j = 0; j < globalMap.GetLength(0); j++)
                {
                    Console.Write(globalMap[j, i]);
                }
                Console.WriteLine();
            }

            foreach (char c in directions)
            {
                startingPosition = canMove2(c, startingPosition);

                Console.WriteLine(startingPosition + " " + c);
                for (int i = 0; i < globalMap.GetLength(1); i++)
                {
                    for (int j = 0; j < globalMap.GetLength(0); j++)
                    {
                        Console.Write(map[j, i]);
                    }
                    Console.WriteLine();
                }
            }

            for (int i = 0; i < globalMap.GetLength(1); i++)
            {
                for (int j = 0; j < globalMap.GetLength(0); j++)
                {
                    Console.Write(globalMap[j, i]);
                }
                Console.WriteLine();
            }


            for (int i = 0; i < globalMap.GetLength(0); i++)
            {
                for (int j = 0; j < globalMap.GetLength(1); j++)
                {
                    if (globalMap[i, j] == '[')
                        sum += 100 * j + i;
                }
            }

            return sum;
        }

        private Point canMove2(char direction, Point startingPos)
        {
            switch (direction)
            {
                case '^':
                    if (canMoveSquares(direction, startingPos))
                    {
                        startingPos.Y -= 1;
                        globalMap[startingPos.X, startingPos.Y] = '@';
                        globalMap[startingPos.X, startingPos.Y + 1] = '.';
                    }
                    break;
                case 'v':
                    if (canMoveSquares(direction, startingPos))
                    {
                        startingPos.Y += 1;
                        globalMap[startingPos.X, startingPos.Y] = '@';
                        globalMap[startingPos.X, startingPos.Y - 1] = '.';
                    }
                    break;
                case '>':
                    if (canMoveSquares(direction, startingPos))
                    {
                        startingPos.X += 1;
                        globalMap[startingPos.X, startingPos.Y] = '@';
                        globalMap[startingPos.X - 1, startingPos.Y] = '.';
                    }
                    break;
                default:
                    if (canMoveSquares(direction, startingPos))
                    {
                        startingPos.X -= 1;
                        globalMap[startingPos.X, startingPos.Y] = '@';
                        globalMap[startingPos.X + 1, startingPos.Y] = '.';
                    }
                    break;
            }

            return startingPos;
        }

        private bool canMoveSquares(char dir, Point startingPos, char? prev = null)
        {
            Point oldPos = startingPos;
            char currentItem = globalMap[startingPos.X, startingPos.Y];
            switch (dir)
            {
                case '^':
                    char nextItemUp = globalMap[startingPos.X, startingPos.Y - 1];
                    if (nextItemUp != '#')
                    {
                        if (prev == '[' && nextItemUp == '.')
                        {
                            if (globalMap[startingPos.X + 1, startingPos.Y - 1] == '.')
                                return true;
                        }

                        if (prev == ']' && nextItemUp == '.')
                        {
                            if (globalMap[startingPos.X - 1, startingPos.Y - 1] == '.')
                                return true;
                        }
                        if (nextItemUp == '.')
                        {
                            return true;
                        }
                        else
                        {
                            startingPos.Y -= 1;
                            if (nextItemUp == '[')
                            {

                                if (canMoveSquares(dir, startingPos, nextItemUp) && canMoveSquares(dir, new Point(startingPos.X + 1, startingPos.Y), ']'))
                                {
                                    globalMap[startingPos.X, startingPos.Y - 1] = '[';
                                    globalMap[startingPos.X + 1, startingPos.Y - 1] = ']';
                                    globalMap[startingPos.X, startingPos.Y] = '.';
                                    globalMap[startingPos.X + 1, startingPos.Y] = '.';

                                    return true;
                                }
                            }
                            else
                            {
                                if (canMoveSquares(dir, startingPos, nextItemUp) && canMoveSquares(dir, new Point(startingPos.X - 1, startingPos.Y), '['))
                                {
                                    globalMap[startingPos.X, startingPos.Y - 1] = ']';
                                    globalMap[startingPos.X - 1, startingPos.Y - 1] = '[';
                                    globalMap[startingPos.X, startingPos.Y] = '.';
                                    globalMap[startingPos.X - 1, startingPos.Y] = '.';
                                    return true;
                                }
                            }
                        }
                        //return false;
                    }
                    return false;
                case 'v':
                    char nextItemDown = globalMap[startingPos.X, startingPos.Y + 1];


                    if (nextItemDown != '#')
                    {
                        if (prev == '[' && nextItemDown == '.')
                        {
                            if (globalMap[startingPos.X + 1, startingPos.Y + 1] == '.')
                                return true;
                        }

                        if (prev == ']' && nextItemDown == '.')
                        {
                            if (globalMap[startingPos.X - 1, startingPos.Y + 1] == '.')
                                return true;
                        }
                        if (nextItemDown == '.')
                        {
                            return true;
                        }
                        else
                        {
                            startingPos.Y += 1;
                            if (nextItemDown == '[')
                            {

                                if (canMoveSquares(dir, startingPos, nextItemDown) && canMoveSquares(dir, new Point(startingPos.X + 1, startingPos.Y), ']'))
                                {
                                    globalMap[startingPos.X, startingPos.Y + 1] = '[';
                                    globalMap[startingPos.X + 1, startingPos.Y + 1] = ']';
                                    globalMap[startingPos.X, startingPos.Y] = '.';
                                    globalMap[startingPos.X + 1, startingPos.Y] = '.';

                                    return true;
                                }
                            }
                            else
                            {
                                if (canMoveSquares(dir, startingPos, nextItemDown) && canMoveSquares(dir, new Point(startingPos.X - 1, startingPos.Y), '['))
                                {
                                    globalMap[startingPos.X, startingPos.Y + 1] = ']';
                                    globalMap[startingPos.X - 1, startingPos.Y + 1] = '[';
                                    globalMap[startingPos.X, startingPos.Y] = '.';
                                    globalMap[startingPos.X - 1, startingPos.Y] = '.';
                                    return true;
                                }
                            }
                        }
                        //canPush = false;
                        //return false;
                    }
                    return false;
                case '>':
                    char nextItemRight = globalMap[startingPos.X + 1, startingPos.Y];
                    if (nextItemRight != '#')
                    {
                        if (nextItemRight == '.')
                        {
                            return true;
                        }
                        else
                        {
                            startingPos.X += 1;
                            if (canMoveSquares(dir, startingPos))
                            {
                                globalMap[startingPos.X + 1, startingPos.Y] = globalMap[startingPos.X, startingPos.Y];
                                globalMap[startingPos.X, startingPos.Y] = '.';
                                return true;
                            }
                            return false;
                        }
                    }
                    return false;
                default:
                    char nextItemLeft = globalMap[startingPos.X - 1, startingPos.Y];
                    if (nextItemLeft != '#')
                    {
                        if (nextItemLeft == '.')
                        {
                            return true;
                        }
                        else
                        {
                            startingPos.X -= 1;
                            if (canMoveSquares(dir, startingPos))
                            {
                                globalMap[startingPos.X - 1, startingPos.Y] = globalMap[startingPos.X, startingPos.Y];
                                globalMap[startingPos.X, startingPos.Y] = '.';
                                return true;
                            }
                            return false;
                        }
                    }
                    return false;
            }
        }

    }
}