
class SolutionDay01
{
    record Manual(string Indicator, int[][] Buttons, string Joltage);
    static void Main()
    {
        var input = ReadInput("test");

        Console.WriteLine($"Solution: {Solve(input)}");
    }

    private static Manual[] ReadInput(string path)
    {
        return [.. File.ReadAllLines(path).Select(line =>
        {
            var parts = line.Split(' ');

            return new Manual(
                parts[0], [.. parts[1..^1].Select(
                                btn => btn.TrimEnd(')').TrimStart('(')
                                          .Split(',').Select(int.Parse).ToArray()
                          )],
                parts[^1]);
        })];
    }

    private static long Solve(Manual[] input)
    {
        long answer = 0;
        return answer;
    }
}