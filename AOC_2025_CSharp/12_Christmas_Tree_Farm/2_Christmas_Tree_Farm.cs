

class SolutionDay02
{
    private static readonly Dictionary<string, string[]> cables = [];
    private static readonly Dictionary<(string, string), long> memo = [];
    static void Main()
    {
        ReadInput("task_data");
        Console.WriteLine($"Solution: {Solve()}");
    }

    private static void ReadInput(string path)
    {
        foreach (string line in File.ReadAllLines(path))
        {
            var parts = line.Split(':');
            cables[parts[0]] = parts[1].Trim().Split(' ');
        }
    }

    private static long Solve()
    {
        return Dfs("svr", "fft") * Dfs("fft", "dac") * Dfs("dac", "out") +
               Dfs("svr", "dac") * Dfs("dac", "fft") * Dfs("fft", "out");
    }
    private static long Dfs(string start, string end)
    {
        if (start.SequenceEqual(end)) return 1;
        if (memo.TryGetValue((start, end), out var cached)) return cached;
        if (!cables.TryGetValue(start, out var nextNodes)) return 0;

        long total = 0;
        foreach (var next in nextNodes)
            total += Dfs(next, end);

        memo[(start, end)] = total;
        return total;
    }
}