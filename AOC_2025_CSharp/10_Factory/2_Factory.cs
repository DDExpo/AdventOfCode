
class SolutionDay02
{
    record Manual(string Indicator, IReadOnlyList<IReadOnlyList<int>> Buttons, IReadOnlyList<int> Joltages);
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
                [.. parts[^1].Trim('{', '}').Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)]
                );
        })];
    }

    private static long Solve(Manual[] input)
    {
        long answer = 0;
        foreach (var machine in input)
        {
            int countJoltages = machine.Joltages.Count;
            var seen = new HashSet<string>();
            var nndjol = string.Join("", machine.Joltages);
            
            Queue<(int[] joltages, int steps)> queue = [];
            queue.Enqueue((new int[countJoltages], 0));

            while (queue.Count > 0)
            {
                var (joltages, steps) = queue.Dequeue();

                if (nndjol.SequenceEqual(string.Join("", joltages))) { break; }
                if (joltages.SequenceEqual(machine.Joltages))
                {
                    answer += steps;
                    break;
                }
                var invalidJoltage = false;

                foreach (var buttons in machine.Buttons)
                {
                    var newJoltages = joltages.ToArray();
                    foreach (int btn in buttons)
                    {
                        if (btn >= countJoltages) continue;
                        newJoltages[btn]++;
                        if (newJoltages[btn] > machine.Joltages[btn])
                        {
                            invalidJoltage = true;
                            break;
                        }
                    }
                    if (invalidJoltage) { invalidJoltage = false; continue; }

                    queue.Enqueue((newJoltages, steps + 1));
                }
                Console.WriteLine(queue.Count);
            }
            Console.WriteLine();
            break;
        }
        return answer;
    }
}