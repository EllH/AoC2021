using System.Linq;

public class Day01 : BaseDay
{
    private readonly string input;

    private readonly List<int> inputAsInts;

    public Day01()
    {
        this.input = File.ReadAllText(InputFilePath);
        this.inputAsInts = Array.ConvertAll(this.input.Split("\n"), int.Parse).ToList();
    }

    public override ValueTask<string> Solve_1()
    {
        return new (this.inputAsInts.Skip(1).Zip(this.inputAsInts, (curr, prev) => curr > prev)
            .Count(c => c).ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        return new (this.inputAsInts.Skip(3).Zip(this.inputAsInts, (curr, prev) => curr > prev)
            .Count(c => c).ToString());
    }
}