

class SolutionDay01
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

    private static int Solve(string[] input)
    {
        int answer = 0;
        int startPositon = 50;

        foreach (var turn in input)
        {
            int dir = turn[0] == 'L' ? -1 : 1;
            startPositon = (dir * int.Parse(turn[1..]) + startPositon) % 100;
            if (startPositon == 0) answer++;
        }

        return answer;
    }
}