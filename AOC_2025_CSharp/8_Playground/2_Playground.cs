
// THANKS TO youtube@hyper-neutrino
class SolutionDay02
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
        long answer = 0;

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
        int circuits = boxes.Length;

        int FindRoot(int child)
        {
            if (parents[child] == child) return child;
            parents[child] = FindRoot(parents[child]);
            return parents[child];
        }
        void merge(int firstTree, int secondTree)
        {
            parents[FindRoot(firstTree)] = FindRoot(secondTree);
        }

        foreach (var (box1, box2, _) in edges)
        {
            if (FindRoot(box1) == FindRoot(box2)) continue;
            merge(box1, box2);
            circuits--;
            if (circuits == 1)
            {
                answer = (long)boxes[box1].X * boxes[box2].X;
                break;
            }
        }
        return answer;
    }
}