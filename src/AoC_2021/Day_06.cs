using System.Linq;

public class Day06 : BaseDay
{
    private readonly string Input;

    public Day06()
    {
        this.Input = File.ReadAllText(InputFilePath);
    }

    private long[] ParseInput()
    {
        var hack = this.Input.Split(",").Select(s => Convert.ToInt64(s)).ToList();

        long[] output = new long[9];
        
        output[0] = hack.Count(v => v == 0);
        output[1] = hack.Count(v => v == 1);
        output[2] = hack.Count(v => v == 2);
        output[3] = hack.Count(v => v == 3);
        output[4] = hack.Count(v => v == 4);
        output[5] = hack.Count(v => v == 5);
        output[6] = hack.Count(v => v == 6);
        output[7] = hack.Count(v => v == 7);
        output[8] = hack.Count(v => v == 8);

        return output;
    }

    private static string solver(long[] fishTank, int growthDays)
    {
        var oldFishTank = new long[9];
        for (int i = 0; i < growthDays; i++)
        {
            fishTank.CopyTo(oldFishTank, 0);
            fishTank[0] = oldFishTank[1];
            fishTank[1] = oldFishTank[2];
            fishTank[2] = oldFishTank[3];
            fishTank[3] = oldFishTank[4];
            fishTank[4] = oldFishTank[5];
            fishTank[5] = oldFishTank[6];
            fishTank[6] = oldFishTank[7] + oldFishTank[0];
            fishTank[7] = oldFishTank[8];
            fishTank[8] = oldFishTank[0];
        }

        return fishTank.Sum().ToString();
    }

    public override ValueTask<string> Solve_1()
    {
        return new(solver(this.ParseInput(), 80));
    }

    public override ValueTask<string> Solve_2()
    {
        return new(solver(this.ParseInput(), 256));
    }
}