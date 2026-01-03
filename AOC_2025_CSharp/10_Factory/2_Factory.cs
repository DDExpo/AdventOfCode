

class SolutionDay02
{
    static void Main()
    {
        var input = ReadInput("test");

        Console.WriteLine($"Solution: {Solve(input)}");
    }

    private static (long, long)[] ReadInput(string path)
    {
        return [.. File.ReadAllLines(path).Select(line =>
        {
            var parts = line.Split(',');
            return ( long.Parse(parts[0]), long.Parse(parts[1]));
        })];
    }

    private static long Solve((long, long)[] tiles)
    {
        long answer = 0;

        var xs = tiles.Select(p => p.Item1).Distinct().OrderBy(x => x).ToArray();
        var ys = tiles.Select(p => p.Item2).Distinct().OrderBy(y => y).ToArray();

        var xMap = xs.Select((value, index) => (value, index))
                     .ToDictionary(p => p.value, p => p.index);

        var yMap = ys.Select((value, index) => (value, index))
                     .ToDictionary(p => p.value, p => p.index);

        var compressed = tiles
            .Select(p => (x: xMap[p.Item1], y: yMap[p.Item2]))
            .ToArray();

        Console.WriteLine("Compressed coordinates:");
        foreach (var (x, y) in compressed)
            Console.WriteLine($"({x}, {y})");
        return answer;
    }
}