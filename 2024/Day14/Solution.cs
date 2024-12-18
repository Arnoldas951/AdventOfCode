using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AOC._2024.Day14
{
    public class Solution
    {
        public int Solution1(List<string> input)
        {
            int width = 101;
            int height = 103;
            WithDuplicateValues robotList = new WithDuplicateValues();
            List<Point> robotPositions = new List<Point>();
            int vm = (height - 1) / 2;
            int hm = (width - 1) / 2;
            int[] quadrants = new int[4];

            int total = 1;

            foreach (string s in input)
            {
                string[] split = s.Split(' ');
                Point Velocity = new Point();
                Point Position = new Point();
                Position.X = int.Parse(split[0].Substring(2).Split(',')[0]);
                Position.Y = int.Parse(split[0].Substring(2).Split(',')[1]);
                Velocity.X = int.Parse(split[1].Substring(2).Split(',')[0]);
                Velocity.Y = int.Parse(split[1].Substring(2).Split(',')[1]);

                robotList.Add(Velocity, Position);
            }

            foreach (var item in robotList)
            {
                //int xMoves = item.Key.X * 100;
                //int yMoves = item.Key.Y * 100;
                int xposition = (item.Value.X + item.Key.X * 100) % width;
                int yposition = (item.Value.Y + item.Key.Y * 100) % height;
                if (xposition < 0)
                    xposition += width;
                if (yposition < 0)
                    yposition += height;
                Point newValue = new Point(xposition, yposition);
                robotPositions.Add(newValue);
                //item.Value = newValue;
            }

            foreach (var item in robotPositions)
            {
                if (item.X < hm && item.Y < vm)
                    quadrants[0]++;
                else if (item.X > hm && item.Y < vm)
                    quadrants[1]++;
                else if (item.X < hm && item.Y > vm)
                    quadrants[2]++;
                else if (item.X > hm && item.Y > vm)
                    quadrants[3]++;
            }

            for (int i = 0; i < quadrants.Length; i++)
            {
                total = total * quadrants[i];
            }

            return total;
        }

        public int Solution2(List<string> input)
        {

            int width = 101;
            int height = 103;
            WithDuplicateValues robotList = new WithDuplicateValues();
            List<Point> robotPositions = new List<Point>();
            int vm = (height - 1) / 2;
            int hm = (width - 1) / 2;

            long sf = 1;
            long min_sf = long.MaxValue;
            int bestSecond = 0;
            int[] quadrants = new int[4];
            foreach (string s in input)
            {
                string[] split = s.Split(' ');
                Point Velocity = new Point();
                Point Position = new Point();
                Position.X = int.Parse(split[0].Substring(2).Split(',')[0]);
                Position.Y = int.Parse(split[0].Substring(2).Split(',')[1]);
                Velocity.X = int.Parse(split[1].Substring(2).Split(',')[0]);
                Velocity.Y = int.Parse(split[1].Substring(2).Split(',')[1]);

                robotList.Add(Velocity, Position);
            }
            for (int i = 1; i <= width*height*2; i++)
            {
                robotPositions.Clear();
                quadrants = new int[4];
                sf = 1;
                foreach (var item in robotList)
                {
                    int xposition = (item.Value.X + item.Key.X * i) % width;
                    int yposition = (item.Value.Y + item.Key.Y * i) % height;
                    if (xposition < 0)
                        xposition += width;
                    if (yposition < 0)
                        yposition += height;
                    Point newValue = new Point(xposition, yposition);
                    robotPositions.Add(newValue);
                }

                foreach (var robot in robotPositions)
                {
                    if (robot.X < hm && robot.Y < vm)
                        quadrants[0]++;
                    else if (robot.X > hm && robot.Y < vm)
                        quadrants[1]++;
                    else if (robot.X < hm && robot.Y > vm)
                        quadrants[2]++;
                    else if (robot.X > hm && robot.Y > vm)
                        quadrants[3]++;
                }

                for (int j = 0; j < quadrants.Length; j++)
                {
                    sf = sf * quadrants[j];
                }

                if (sf < min_sf)
                {
                    min_sf = sf;
                    bestSecond = i;
                }
            }



            return bestSecond;
        }

        private class WithDuplicateValues : List<KeyValuePair<Point, Point>>
        {
            public void Add(Point key, Point value)
            {
                var item = new KeyValuePair<Point, Point>(key, value);
                this.Add(item);
            }
        }
    }
}