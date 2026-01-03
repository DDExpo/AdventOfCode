
class SolutionDay01
{
    static void Main()
    {
        var input = ReadInput("task_data");

        Console.WriteLine($"Solution: {Solve(input)}");
    }

    private static string[] ReadInput(string path)
    {
        return File.ReadAllLines(path);
    }

    private static int Solve(string[] input)
    {
        int answer = 0;
        int i = 0;
        List<(long Start, long End)> numPositiveRanges = [];

        for (; i < input.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(input[i])) break;
            var parts = input[i].Split('-');
            numPositiveRanges.Add((long.Parse(parts[0]), long.Parse(parts[1])));
        }
        i++;

        for (; i < input.Length; i++)
        {
            long value = long.Parse(input[i]);
            answer += numPositiveRanges.Any(r => r.Start <= value && value <= r.End) ? 1 : 0;
        }
        return answer;
    }
}