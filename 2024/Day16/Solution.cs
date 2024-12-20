using System.Drawing;

namespace AOC._2024.Day16
{

    public class Solution
    {

        public static Point[] WithoutDiagonals { get; } =
  [
        new Point (0, 1),
        new Point (1, 0),
        new Point (0, -1),
        new Point (-1, 0),
    ];
        public int Solution1(List<string> input)
        {
            Point end = new Point(0, 0);
            Point start = new Point(0, 0);

            for (int i = 0; i < input.Count; i++)
            {
                int endIndex = input[i].IndexOf("E");
                int startIndex = input[i].IndexOf("S");
                if (endIndex >= 0)
                {
                    end.X = endIndex;
                    end.Y = i;
                }

                if (startIndex >= 0)
                {
                    start.X = startIndex;
                    start.Y = i;
                }
            }

            return Move(input, start, end);
        }

        private int Move(List<string> input, Point start, Point end)
        {
            PriorityQueue<PointInLab, int> priorityQueue = new PriorityQueue<PointInLab, int>();
            var minimumCosts = new Dictionary<PointInLab, int>();
            var SeenPointsInLab = new List<PointInLab>();

            priorityQueue.Enqueue(new PointInLab(start, new Point(1, 0)),0);
            minimumCosts.Add(new PointInLab(start, new Point(1,0)), 0);
            while (priorityQueue.Count > 0)
            {
                PointInLab item = priorityQueue.Dequeue();
                SeenPointsInLab.Add(item);

                var next = new Point(item.Position.X + item.Direction.X, item.Position.Y + item.Direction.Y);
                var nextState = new PointInLab(next, item.Direction);
                CheckNextMove(nextState, minimumCosts[item] + 1);

                nextState = new PointInLab(item.Position, new Point(-item.Direction.Y, item.Direction.X));
                CheckNextMove(nextState, minimumCosts[item] + 1000);

                nextState = new PointInLab(item.Position, new Point(item.Direction.Y, -item.Direction.X));
                CheckNextMove(nextState, minimumCosts[item] + 1000);

                void CheckNextMove(PointInLab nextState, int cost)
                {
                    if (nextState.Position.X < 0 || nextState.Position.X >= input[0].Length || nextState.Position.Y < 0 || nextState.Position.Y >= input.Count)
                    {
                        return;
                    }

                    if (input[nextState.Position.X][nextState.Position.Y] == '#')
                    {
                        return;
                    }

                    if (!SeenPointsInLab.Contains(nextState))
                    {
                        if (!minimumCosts.TryGetValue(nextState, out var nextCost) || nextCost > cost)
                        {
                            minimumCosts[nextState] = cost;
                            priorityQueue.Remove(nextState, out _, out _);
                            priorityQueue.Enqueue(nextState, minimumCosts[nextState]);
                        }
                    }
                }
            }
            var bestEndState = int.MaxValue;
            foreach (var direction in WithoutDiagonals)
            {
                bestEndState = Math.Min(bestEndState, minimumCosts.GetValueOrDefault(new PointInLab(end, direction), int.MaxValue));
            }
            return bestEndState;

        }


        private record PointInLab(Point Position, Point Direction);

        public int Solution2() { return 0; }
    }
}