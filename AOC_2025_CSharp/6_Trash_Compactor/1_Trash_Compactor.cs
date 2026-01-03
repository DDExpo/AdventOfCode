
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

    private static long Solve(string[] input)
    {
        Dictionary<char, Func<long, long, long>> ops = new()
        {
            ['+'] = (a, b) => a + b,
            ['*'] = (a, b) => a * b,
        };

        long answer = 0;
        string[][] result = [.. input.Select(line => line.Split([' '], StringSplitOptions.RemoveEmptyEntries))];
        int rows = result.Length;

        for (int i = 0; i < result[0].Length; i++)
        {
            char oprtr = result[rows - 1][i][0];
            long curSum = oprtr == '+' ? 0 : 1;
            for (int ii = rows - 2; ii > -1; ii--)
                curSum = ops[oprtr](curSum, long.Parse(result[ii][i]));

            answer += curSum;
        }
        return answer;
    }
}