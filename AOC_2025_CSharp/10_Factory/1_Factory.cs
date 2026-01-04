
class SolutionDay01
{
    record Manual(string Indicator, IReadOnlyList<IReadOnlyList<int>> Buttons, string Joltage);
    static void Main()
    {
        var input = ReadInput("task_data");

        Console.WriteLine($"Solution: {Solve(input)}");
    }

    private static Manual[] ReadInput(string path)
    {
        return [.. File.ReadAllLines(path).Select(line =>
        {
            var parts = line.Split(' ');

            return new Manual(
                parts[0][1..^1], [.. parts[1..^1].Select(
                                btn => btn.TrimEnd(')').TrimStart('(')
                                          .Split(',').Select(int.Parse).ToArray()
                          )],
                parts[^1]);
        })];
    }

    private static long Solve(Manual[] input)
    {
        long answer = 0;

        foreach (var machine in input)
        {
            var seen = new HashSet<string>();
            Queue<(char[] indicator, int steps)> queue = [];
            queue.Enqueue((new string('.', machine.Indicator.Length).ToCharArray(), 0));

            while (queue.Count > 0)
            {
                var (indicator, steps) = queue.Dequeue();
                if (!seen.Add(new(indicator))) continue;

                if (indicator.AsSpan().SequenceEqual(machine.Indicator)) { answer += steps; break; }
                foreach (var buttons in machine.Buttons)
                {
                    var newIndicator = (char[])indicator.Clone();
                    foreach (int btn in buttons)
                    {
                        if (btn >= newIndicator.Length) continue;
                        newIndicator[btn] = newIndicator[btn] == '.' ? '#' : '.';
                    }
                    queue.Enqueue((newIndicator, steps + 1));
                }
            }
        }
        return answer;
    }
}