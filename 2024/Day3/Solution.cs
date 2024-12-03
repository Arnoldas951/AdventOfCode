using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AOC._2024.Day3
{
    public class Solution
    {
        public int Solution1(string input) 
        {
            int answer = 0;
            input = input.Replace(Environment.NewLine, "");
            string pattern = "(?:mul\\(\\d{1,3},\\d{1,3}\\))";
            string paramPattern = "\\d{1,3}";
            Regex regex = new Regex(pattern);
            Regex paramRegex = new Regex(paramPattern);
            MatchCollection commands = regex.Matches(input);


            foreach (Match match in commands) {
                var parameters = paramRegex.Matches(match.ToString());
                answer += mul(int.Parse(parameters[0].ToString()), int.Parse(parameters[1].ToString()));
             }

            return answer;
        }


        public int Solution2(string input)
        {
            int answer = 0;
            input = input.Replace(Environment.NewLine, "");
            input = Regex.Replace(input, "(?:don't\\(\\))(.*?)(?:do\\(\\))", string.Empty);

            string pattern = "(?:mul\\(\\d{1,3},\\d{1,3}\\))";
            string paramPattern = "\\d{1,3}";
            Regex regex = new Regex(pattern);
            Regex paramRegex = new Regex(paramPattern);
            MatchCollection commands = regex.Matches(input);

            foreach (Match match in commands)
            {
                var parameters = paramRegex.Matches(match.ToString());
                answer += mul(int.Parse(parameters[0].ToString()), int.Parse(parameters[1].ToString()));
            }

            return answer;
        }

        public int mul(int x, int y) 
        {
            return x * y;
        }

    }
}
