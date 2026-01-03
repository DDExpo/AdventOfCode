

class SolutionDay02
{
    static void Main()
    {
        var input = ReadInput("task_data");

        Console.WriteLine($"Solution: {Solve(input)}");
    }

    private static string[] ReadInput(string path)
    {
        var input = File.ReadAllText(path);
        return input.Split(',');
    }

    private static long Solve(string[] ranges)
    {
        long answer = 0;

        foreach (string range in ranges)
        {
            string[] parts = range.Split('-');
            long start = long.Parse(parts[0]);
            long end = long.Parse(parts[1]);

            for (var i = start; i <= end; i++)
            {
                var spanSeq = i.ToString().AsSpan();
                int len = spanSeq.Length;
                int half = len / 2;
                for (var ii = 1; ii < half + 1; ii++)
                {
                    if (len % ii == 0)
                    {
                        bool flagCathBreak = false;

                        var subseq = spanSeq[..ii];
                        for (int pos = ii; pos < len; pos += ii)
                        {
                            if (!subseq.SequenceEqual(spanSeq[pos..(pos + ii)])) { flagCathBreak = true; break; }
                        }
                        if (flagCathBreak) continue;
                        answer += i;
                        break;
                    }
                }
            }
        }
        return answer;
    }
}
