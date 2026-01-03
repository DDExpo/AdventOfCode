
// THANKS TO youtube@hyper-neutrino
class SolutionDay01
{
    record Box3D(int X, int Y, int Z);
    static void Main()
    {
        var input = ReadInput("task_data");

        Console.WriteLine($"Solution: {Solve(input)}");
    }

    private static Box3D[] ReadInput(string path)
    {
        return [.. File.ReadAllLines(path).Select(line =>
        {
            var parts = line.Split(',');
            return new Box3D ( int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]));
        })];
    }

    private static long Solve(Box3D[] boxes)
    {
        List<(int i, int j, double dist)> edges = [];

        for (int i = 0; i < boxes.Length; i++)
            for (int j = i + 1; j < boxes.Length; j++)
            {
                double dx = boxes[i].X - boxes[j].X;
                double dy = boxes[i].Y - boxes[j].Y;
                double dz = boxes[i].Z - boxes[j].Z;
                edges.Add((i, j, dx * dx + dy * dy + dz * dz));
            }

        edges.Sort((a, b) =>
        {
            int cmp = a.dist.CompareTo(b.dist);
            if (cmp != 0) return cmp;
            if (a.i != b.i) return a.i.CompareTo(b.i);
            return a.j.CompareTo(b.j);
        });

        List<int> parents = [.. Enumerable.Range(0, boxes.Length)];

        int FindRoot(int child)
        {
            if (parents[child] == child) return child;
            parents[child] = FindRoot(parents[child]);
            return parents[child];
        }
        void Merge(int firstTree, int secondTree)
        {
            parents[FindRoot(firstTree)] = FindRoot(secondTree);
        }

        for (int i = 0; i < 1000; i++)
        {
            var (box1, box2, _) = edges[i];
            Merge(box1, box2);
        }

        int[] circuitsSizes = new int[boxes.Length];

        for (int box = 0; box < boxes.Length; box++)
            circuitsSizes[FindRoot(box)]++;

        Array.Sort(circuitsSizes);
        Array.Reverse(circuitsSizes);

        return circuitsSizes[0] * circuitsSizes[1] * circuitsSizes[2];
    }
}