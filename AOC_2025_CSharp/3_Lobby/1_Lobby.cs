
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

    private static long Solve(string[] linesBatteries)
    {
        long answer = 0;

        foreach (string batterieRow in linesBatteries)
        {
            int firstMaxBatterie = 0;
            int secondMaxBatterie = 0;
            int index = 0;

            for (int i = 0; i < batterieRow.Length - 1; i++)
            {
                int batterie = batterieRow[i] - '0';
                if (firstMaxBatterie < batterie)
                {
                    firstMaxBatterie = batterie;
                    index = i;
                }
            }

            for (int ii = index+1; ii < batterieRow.Length; ii++)
            {
                secondMaxBatterie = Math.Max(secondMaxBatterie, batterieRow[ii] - '0');
            }
            answer += int.Parse(firstMaxBatterie.ToString() + secondMaxBatterie.ToString()); 
        }
        return answer;
    }
}