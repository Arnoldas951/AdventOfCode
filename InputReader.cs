using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC
{
    public class InputReader
    {
        private static string demoInput = "D:\\AOC\\Input\\DemoInput.txt";
        private static string input = "D:\\AOC\\Input\\Input.txt";
        public static string Read() 
        {
            StreamReader sr = new StreamReader(input);
            return sr.ReadToEnd();
        }

        public static List<string> ReadToList() 
        {
            List<string> listOfStrings = File.ReadLines(input).ToList();
            return listOfStrings;
        }
    }
}
