
class SolutionDay01
{
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
                grid[i, j] = lines[i][j];

        return grid;
    }

    private static int Solve(char[,] grid)
    {
        int answer = 0;
        (int di, int dii)[] dirs =
        [
            (1, 0), (-1, 0),
            (0, 1), (0, -1),
            (1, 1), (-1, -1),
            (1, -1), (-1, 1)
        ];
        int rows = grid.GetLength(0);
        int cols = grid.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int ii = 0; ii < cols; ii++)
            {
                if (grid[i, ii] != '@') continue;

                int countRoll = 0;

                foreach (var (di, dii) in dirs)
                {
                    int nextI = i + di;
                    int nextII = ii + dii;

                    if (nextI < 0 || nextI >= rows || nextII < 0 || nextII >= cols) continue;
                    if (grid[nextI, nextII] == '@') countRoll++;
                }

                if (countRoll < 4) answer++;
            }
        }
        return answer;
    }
}