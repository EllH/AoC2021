using System.Linq;

public class Day06 : BaseDay
{
    private readonly string Input;

    public Day06()
    {
        this.Input = File.ReadAllText(InputFilePath);
    }

    private long FishCountAfterNDays(string input, int days)
    {
        var fishCountByInternalTimer = new long[9];
        foreach (var ch in input.Split(','))
        {
            fishCountByInternalTimer[int.Parse(ch)]++;
        }

        for (var t = 0; t < days; t++)
        {
            fishCountByInternalTimer[(t + 7) % 9] += fishCountByInternalTimer[t % 9];
        }

        return fishCountByInternalTimer.Sum();
    }

    public override ValueTask<string> Solve_1()
    {
        return new(FishCountAfterNDays(this.Input, 80).ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        return new(FishCountAfterNDays(this.Input, 256).ToString());
    }
}