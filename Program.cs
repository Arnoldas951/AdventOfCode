using AOC;
using Day1 = AOC._2024.Day1;
using Day2 = AOC._2024.Day2;


//Day1();
Day2();

void Day1() 
{
    Day1.Solution day1 = new Day1.Solution();
    Console.WriteLine(day1.Solution1(InputReader.ReadToList()));
    Console.WriteLine(day1.Solution2(InputReader.ReadToList()));
}

void Day2() 
{
    Day2.Solution day2 = new Day2.Solution();
    Console.WriteLine(day2.Solution1(InputReader.ReadToList()));
    Console.WriteLine(day2.Solution2(InputReader.ReadToList()));
}