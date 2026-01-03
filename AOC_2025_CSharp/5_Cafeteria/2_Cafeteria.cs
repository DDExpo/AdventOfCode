
class SolutionDay02
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

    private static long Solve(string[] input)
    {
        long answer = 0;

        List<(long Start, long End)> numPositiveRanges = [];

        for (int i = 0; i < input.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(input[i])) break;
            var parts = input[i].Split('-');
            numPositiveRanges.Add((long.Parse(parts[0]), long.Parse(parts[1])));
        }

        numPositiveRanges.Add((long.MaxValue, 0));
        numPositiveRanges.Sort();
        var (LowerBound, UpperBound) = (numPositiveRanges[0].Start, numPositiveRanges[0].End);

        for (int i = 1; i < numPositiveRanges.Count; i++)
        {
            var (Start, End) = numPositiveRanges[i];
            if (UpperBound >= Start)
            {
                LowerBound = Math.Min(LowerBound, Start);
                UpperBound = Math.Max(UpperBound, End);
            }
            else
            {
                answer += UpperBound - LowerBound + 1;
                UpperBound = End;
                LowerBound = Start;
            }
        }
        return answer;
    }
}