

using System.Xml.Serialization;

class SolutionDay02
{
    static void Main()
    {
        var input = ReadInput("task_data");

        Console.WriteLine($"Solution: {Solve(input)}");
    }

    private static Dictionary<string, string[]> ReadInput(string path)
    {
        Dictionary<string, string[]> cables = [];

        foreach (string line in File.ReadAllLines(path))
        {
            var parts = line.Split(':');
            cables[parts[0]] = parts[1].Trim().Split(' ');
        }
        return cables;
    }

    private static long Solve(Dictionary<string, string[]> cabels)
    {
        long answer  = 0;
        string start = "svr";
        string end = "out";
        var allSubpaths = new HashSet<string>();
        var path = new List<string>();
        Queue<(string, (int, int))> queue = [];
        queue.Enqueue((start, (0, 0)));
        path.Add(start);

        while (queue.Count > 0)
        {
            var (current, valid) = queue.Dequeue();

            if (current.Equals("dac")) valid.Item1 = 1;
            else if (current.Equals("fft")) valid.Item2 = 1;

            if (current.Equals(end))
            {
                if (valid.Item1 + valid.Item2 == 2) answer++;
                continue;
            }
            foreach (var next in cabels[current])
                queue.Enqueue((next, valid));
        }
        return answer;
    }
}