
class SolutionDay01
{
    private static int _startCol;
    static void Main()
    {
        var input = ReadInput("task_data");

        Console.WriteLine($"Solution: {Solve(input)}");
    }

    private static char[,] ReadInput(string path)
    {
        var lines = File.ReadAllLines(path);
        int rows = lines.Length;
        int cols = lines[0].Length;

        char[,] grid = new char[rows, cols];

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
            {
                grid[i, j] = lines[i][j];
                if (grid[i, j] == 'S') _startCol = j;
            }

        return grid;
    }

    private static int Solve(char[,] grid)
    {
        int answer = 0;
        int rows = grid.GetLength(0);

        HashSet<(int, int)> uniqueBeams = [];
        Queue<(int, int)> queue = [];
        queue.Enqueue((1, _startCol));

        while (queue.Count > 0)
        {
            var (curRows, curCol) = queue.Dequeue();
            curRows += 1;

            if (!uniqueBeams.Add((curRows, curCol)) || curRows >= rows) continue;

            if (grid[curRows, curCol] == '^')
            {
                queue.Enqueue((curRows, curCol - 1));
                queue.Enqueue((curRows, curCol + 1));
                answer += 1;
            }
            else { queue.Enqueue((curRows, curCol)); }
        }
        return answer;
    }
}