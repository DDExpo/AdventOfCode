

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

    private static int Solve(string[] input)
    {
        int answer = 0;
        int startPosition = 50;

        foreach (var turn in input)
        {
            int dir = turn[0] == 'L' ? -1 : 1;
            int val = int.Parse(turn[1..]);
            int quotient = Math.DivRem(val, 100, out int remainder);
            int newPosition = startPosition + (remainder * dir);
            answer += quotient;

            if (startPosition != 0)
            {
                if (dir == -1 && newPosition <= 0) { answer++; }
                else if (dir == 1 && newPosition >= 100) { answer++; }
            }

            startPosition = ((newPosition % 100) + 100) % 100;
        }
        return answer;
    }
}