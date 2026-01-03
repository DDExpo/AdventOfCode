
class SolutionDay02
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

        int removed;
        do
        {
            removed = 0;
            char[,] temp = (char[,])grid.Clone();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i, j] != '@') continue;

                    int countRoll = 0;
                    foreach (var (di, dj) in dirs)
                    {
                        int ni = i + di;
                        int nj = j + dj;

                        if (ni < 0 || ni >= rows || nj < 0 || nj >= cols) continue;

                        if (grid[ni, nj] == '@') countRoll++;
                    }

                    if (countRoll < 4)
                    {
                        temp[i, j] = '.';
                        removed++;
                    }
                }
            }
            grid = temp;
            answer += removed;
        } while (removed > 0);

        return answer;
    }
}