using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC
{
    public class InputReader
    {
        public static string Read() 
        {
            StreamReader sr = new StreamReader("D:\\AOC\\Input\\DemoInput.txt");
            return sr.ReadToEnd();
        }
    }
}
