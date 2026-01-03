
class SolutionDay01
{
    static void Main()
    {
        var input = ReadInput("task_data");

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

        for (int i = 0; i < tiles.Length; i++)
            for (int ii = i + 1; ii < tiles.Length; ii++)
            {
                var(x, y, x2, y2) = (tiles[i].Item1, tiles[i].Item2, tiles[ii].Item1, tiles[ii].Item2);
                answer = Math.Max(answer, (Math.Abs(x - x2) + 1) * (Math.Abs(y - y2) + 1));
            }
        return answer;
    }
}