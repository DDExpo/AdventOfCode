
class SolutionDay02
{
static void Main()
    {
        var input = ReadInput("task_data");
        Console.WriteLine($"Solution: {Solve(input)}");
    }

    private static string[] ReadInput(string path)
    {
        return File.ReadAllLines(path);
    }

    private static long Solve(string[] lines)
    {
        Dictionary<char, Func<long, long, long>> ops = new()
        {
            ['+'] = (a, b) => a + b,
            ['*'] = (a, b) => a * b,
        };

        int rowCount = lines.Length;

        long answer = 0;
        long total = -1;
        char opr = ' ';

        for (int col = 0; col < lines[0].Length; col++)
        {
            if (Enumerable.Range(0, rowCount).All(i => lines[i][col] == ' '))
            {
                answer += total;
                total = -1;
                continue;
            }

            if (lines[rowCount - 1][col] == '+' || lines[rowCount - 1][col] == '*') opr = lines[rowCount - 1][col];
           
            string num = "";
            for (int row = 0; row < rowCount - 1; row++)
            {
                char chr = lines[row][col];
                if (chr == ' ') continue;
                num += chr;
            }
            if (total == -1) total = opr == '+' ? 0 : 1;
            
            total = ops[opr](total, int.Parse(num));
        }
        return answer + total;
    }
}