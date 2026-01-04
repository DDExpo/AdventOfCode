
class SolutionDay02
{
    record Manual(string Indicator, IReadOnlyList<IReadOnlyList<int>> Buttons, string Joltages);
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
                parts[0], [.. parts[1..^1].Select(
                                btn => btn.TrimEnd(')').TrimStart('(')
                                          .Split(',').Select(int.Parse).ToArray()
                          )],
                parts[^1].TrimEnd('}').TrimStart('{'));
        })];
    }

    private static long Solve(Manual[] input)
    {
        long answer = 0;
        var ind = 0;
        foreach (var machine in input)
        {
            ind++;
            int countJoltages = machine.Joltages.Split(",").Length;
            var seen = new HashSet<string>();
            Queue<(int[] joltages, int steps)> queue = [];
            queue.Enqueue((new int[countJoltages], 0));
            while (queue.Count > 0)
            {
                var (joltages, steps) = queue.Dequeue();
                if (!seen.Add(joltages.ToString()!)) continue;
                if (joltages.ToString() == machine.Joltages) { answer += steps; break; }
                foreach (var buttons in machine.Buttons)
                {
                    var newJoltages = (int[])joltages.Clone();
                    foreach (int btn in buttons)
                    {
                        if (btn >= countJoltages) continue;
                        newJoltages[btn]++;
                    }
                    queue.Enqueue((newJoltages, steps + 1));
                }
            }
            Console.WriteLine(ind);
        }
        return answer;
    }
}