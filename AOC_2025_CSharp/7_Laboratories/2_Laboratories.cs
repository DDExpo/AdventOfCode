
class SolutionDay02
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

    private static long Solve(char[,] grid)
    {
        int rows = grid.GetLength(0);

        var memo = new Dictionary<(int, int), long>();

        long Dfs(int curRows, int curCols)
        {
            if (curRows == rows - 1) return 1;
            if (memo.TryGetValue((curRows, curCols), out var val)) return val;

            long total = 0;
            char cell = grid[curRows, curCols];

            if      (cell == '.') total += Dfs(curRows + 1, curCols); 
            else if (cell == '^') total += Dfs(curRows + 1, curCols - 1) + Dfs(curRows + 1, curCols + 1);

            memo[(curRows, curCols)] = total;
            return total;
        }

        return Dfs(1, _startCol);
    }
}