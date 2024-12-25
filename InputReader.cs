using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC
{
    public class InputReader
    {
        private static string demoInput = "F:\\AOC\\AdventOfCode\\Input\\DemoInput.txt";
        private static string input = "F:\\AOC\\AdventOfCode\\Input\\Input.txt";
        public static string Read() 
        {
            StreamReader sr = new StreamReader(demoInput);
            return sr.ReadToEnd();
        }

        public static List<string> ReadToList() 
        {
            List<string> listOfStrings = File.ReadLines(demoInput).ToList();
            return listOfStrings;
        }

        public static Dictionary<string, string> ReadToDictionay(string splitBy)
        {
            Dictionary<string,string> dictionary = new Dictionary<string,string>();
            var list = ReadToList();
            list.ForEach(item =>
            {
                var splitItem = item.Split(splitBy);
                dictionary.Add(splitItem[0], splitItem[1]);
            });

            return dictionary;
        }
    }
}
