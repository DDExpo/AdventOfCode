
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

    private static long Solve(string[] linesBatteries)
    {
        long answer = 0;

        foreach (string batterieRow in linesBatteries)
        {
            var batterieCharges = new List<string>();
            int prevIndex = 0;

            for (int i = 11; i >= 0; i--)
            {
                var (charge, ind) = FindMaxString(batterieRow, prevIndex, i);
                prevIndex = ind;
                batterieCharges.Add(charge);
            }
            answer += long.Parse(string.Concat(batterieCharges));
        }
        return answer;
    }
    private static (string, int) FindMaxString(string text, int start, int offset)
    {
        int maxNum = 0;
        int index = -1;

        for (int i = start; i < text.Length - offset; i++)
        {
            int textNum = text[i] - '0';
            if (textNum > maxNum)
            {
                maxNum = textNum;
                index = i;
            }
        }
        return (maxNum.ToString(), index+1);
    }
}