
class SolutionDay01
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
        string start = "you";
        string end = "out";

        Queue<string> queue = [];
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            if (current.Equals(end)) { answer++; continue; }
                 
            foreach (var next in cabels[current])
                queue.Enqueue(next);
        }
        return answer;
    }
}