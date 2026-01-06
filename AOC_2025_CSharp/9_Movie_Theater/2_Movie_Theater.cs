
// CLAUDE CODE, HOLY FUCK ITS SECOND HARD ONE TO UNDERSTAND AND IMPLEMENT PROBLEM IN THIS YEAR
class SolutionDay02
{
    record Point(int X, int Y);
    static void Main()
    {
        var input = ReadInput("task_data");
        Console.WriteLine($"Solution: {Solve(input)}");
    }

    private static List<Point> ReadInput(string path)
    {
        return [
            .. File.ReadAllLines(path).Select(line => {
            var p = line.Split(',');
            return new Point(int.Parse(p[0]), int.Parse(p[1]));
        })];
    }

    private static long Solve(List<Point> redTiles)
    {

        // Step 1: Compress only red tile coordinates
        // So cords like this [100, 5, 50, 100, 5] will compress to [2, 0, 1, 2, 0]]
        // 100 is two because its the biggest one, as we map them in sorted order -> 5, 50, 100 to 0, 1, 2
        var xs = redTiles.SelectMany(p => new[] { p.X - 1, p.X, p.X + 1 }).Distinct().OrderBy(x => x).ToList();
        var ys = redTiles.SelectMany(p => new[] { p.Y - 1, p.Y, p.Y + 1 }).Distinct().OrderBy(y => y).ToList();
        
        var xToIndex = xs.Select((x, i) => (x, i)).ToDictionary(t => t.x, t => t.i);
        var yToIndex = ys.Select((y, i) => (y, i)).ToDictionary(t => t.y, t => t.i);
        
        int gridWidth = xs.Count;
        int gridHeight = ys.Count;
        
        // Compress red tiles
        var compressedRed = redTiles.Select(p => new Point(xToIndex[p.X], yToIndex[p.Y])).ToList();
        
        // Step 2: Build boundary on grid
        var grid = new bool[gridWidth, gridHeight];
        
        for (int i = 0; i < compressedRed.Count; i++)
        {
            var from = compressedRed[i];
            var to = compressedRed[(i + 1) % compressedRed.Count];
            
            if (from.X == to.X) // Vertical line
            {
                int minY = Math.Min(from.Y, to.Y);
                int maxY = Math.Max(from.Y, to.Y);

                for (int y = minY; y <= maxY; y++)
                    grid[from.X, y] = true;
            }
            else if (from.Y == to.Y) // Horizontal line
            {
                int minX = Math.Min(from.X, to.X);
                int maxX = Math.Max(from.X, to.X);

                for (int x = minX; x <= maxX; x++)
                    grid[x, from.Y] = true;
            }
        }
        
        // Step 3: Flood fill from outside
        var outside = new HashSet<Point> { new(-1, -1) };
        var queue = new Queue<Point>();
        queue.Enqueue(new Point(-1, -1));
        
        int[] dx = [-1, 1, 0, 0];
        int[] dy = [0, 0, -1, 1];
        
        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            
            for (int i = 0; i < 4; i++)
            {
                int nx = current.X + dx[i];
                int ny = current.Y + dy[i];
                
                if (nx < -1 || ny < -1 || nx >= gridWidth || ny >= gridHeight) continue;
                if (nx >= 0 && ny >= 0 && grid[nx, ny]) continue;
                
                var next = new Point(nx, ny);
                if (outside.Contains(next)) continue;
                
                outside.Add(next);
                queue.Enqueue(next);
            }
        }
        
        // Step 5: Build prefix sum array for O(1) rectangle queries
        var psa = new int[gridWidth, gridHeight];
        for (int x = 0; x < gridWidth; x++)
            for (int y = 0; y < gridHeight; y++)
            {
                int left = x > 0 ? psa[x - 1, y] : 0;
                int top = y > 0 ? psa[x, y - 1] : 0;
                int topLeft = (x > 0 && y > 0) ? psa[x - 1, y - 1] : 0;
                psa[x, y] = left + top - topLeft + (!outside.Contains(new Point(x, y)) ? 1 : 0);
            }
        
        // Step 6: Find largest valid rectangle using O(1) queries
        long maxArea = 0;
        
        for (int i = 0; i < redTiles.Count; i++)
            for (int j = i + 1; j < redTiles.Count; j++)
            {
                var cp1 = compressedRed[i];
                var cp2 = compressedRed[j];
                
                int cx1 = Math.Min(cp1.X, cp2.X);
                int cx2 = Math.Max(cp1.X, cp2.X);
                int cy1 = Math.Min(cp1.Y, cp2.Y);
                int cy2 = Math.Max(cp1.Y, cp2.Y);
                
                // O(1) validation using prefix sum
                int left = cx1 > 0 ? psa[cx1 - 1, cy2] : 0;
                int top = cy1 > 0 ? psa[cx2, cy1 - 1] : 0;
                int topLeft = (cx1 > 0 && cy1 > 0) ? psa[cx1 - 1, cy1 - 1] : 0;
                int count = psa[cx2, cy2] - left - top + topLeft;
                int expectedCount = (cx2 - cx1 + 1) * (cy2 - cy1 + 1);
                
                if (count == expectedCount)
                {
                    // Calculate area using original coordinates
                    var op1 = redTiles[i];
                    var op2 = redTiles[j];
                    long width = Math.Abs(op1.X - op2.X) + 1;
                    long height = Math.Abs(op1.Y - op2.Y) + 1;
                    maxArea = Math.Max(maxArea, width * height);
                }
            }
        return maxArea;
    }
}