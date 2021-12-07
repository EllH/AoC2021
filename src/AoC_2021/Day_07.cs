using System.Linq;

public class Day07 : BaseDay
{
    private readonly string Input;

    public Day07()
    {
        this.Input = File.ReadAllText(InputFilePath);
    }

    private List<int> parseInput()
    {
        return this.Input.Split(",").Select(int.Parse).ToList();
    }

    private IEnumerable<IEnumerable<int>> getFuelBaseUsage(IEnumerable<int> crabs)
    {
        return Enumerable.Range(0, crabs.Max()).Select(position => crabs.Select(crab2 => Math.Abs(crab2 - position))).ToList();
    }

    public override ValueTask<string> Solve_1()
    {
        return new(getFuelBaseUsage(parseInput()).Min(i => i.Sum()).ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        return new(getFuelBaseUsage(parseInput()).Min(i => i.Sum(c => c * (c + 1) / 2)).ToString());
    }
}