

class SolutionDay01
{
    static void Main()
    {
        var input = ReadInput("task_data");

        Console.WriteLine($"Solution: {Solve(input)}");
    }

    private static string[] ReadInput(string path)
    {
        var input = File.ReadAllText(path);
        return input.Split(',');
    }

    private static long Solve(string[] ranges)
    {
        long answer = 0;

        foreach (string range in ranges)
        {
            string[] parts = range.Split('-');
            long start = long.Parse(parts[0]);
            long end = long.Parse(parts[1]);

            for (var i = start; i <= end; i++)
            {
                var strI = i.ToString().AsSpan();
                var len = strI.Length;

                if (len % 2 != 0) continue;
                if (strI[..(len / 2)].SequenceEqual(strI[(len / 2)..])) answer += i;
            }
        }

        return answer;
    }
}