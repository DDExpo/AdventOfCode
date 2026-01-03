using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class SolutionDay02
{
static void Main()
    {
        var input = ReadInput("test");

        Console.WriteLine($"Solution: {Solve(input)}");
    }

    private static string[] ReadInput(string path)
    {
        return File.ReadAllLines(path);
    }

    private static long Solve(string[] input)
    {
        Dictionary<char, Func<long, long, long>> ops = new()
        {
            ['+'] = (a, b) => a + b,
            ['*'] = (a, b) => a * b,
        };

        long answer = 0;
        var result = new List<List<string>>();
        var operators = input[^1].Split(' ', StringSplitOptions.RemoveEmptyEntries);


        return answer;
    }
}