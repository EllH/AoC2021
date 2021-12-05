using System.Linq;
using System.Text.RegularExpressions;

public class Day05 : BaseDay
{
    private readonly string Input;
    private readonly IEnumerable<(int x1, int y1, int x2, int y2)> ParsedInput;

    public Day05()
    {
        this.Input = File.ReadAllText(InputFilePath);
        this.ParsedInput = ParsedInputToFormat();
    }

    public IEnumerable<(int x1, int y1, int x2, int y2)> ParsedInputToFormat()
    {
        return this.Input.Split("\n")
            .Select(l => Regex.Match(l, @"(\d+),(\d+) -> (\d+),(\d+)"))
            .Select(m => (
                x1: int.Parse(m.Groups[1].Value),
                y1: int.Parse(m.Groups[2].Value),
                x2: int.Parse(m.Groups[3].Value),
                y2: int.Parse(m.Groups[4].Value)))
            .ToList();
    }

    private int CountLineOverlaps(bool skipDiagonals = false) =>
        this.ParsedInput.Where(x => !skipDiagonals || x.x1 == x.x2 || x.y1 == x.y2)
            .SelectMany(x => GetPointsForLine(x.x1, x.y1, x.x2, x.y2)).GroupBy(x => x).Count(g => g.Count() > 1);
    
    private IEnumerable<(int x, int y)> GetPointsForLine(int x1, int y1, int x2, int y2)
    {
        var xDir = Math.Sign(x2 - x1);
        var yDir = Math.Sign(y2 - y1);
        for (int x = x1, y = y1; x != (x2 + xDir) || y != (y2 + yDir); x += xDir, y += yDir)
        {
            yield return (x, y);
        }
    }

    public override ValueTask<string> Solve_1()
    {
        return new(CountLineOverlaps(skipDiagonals: true).ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        return new(CountLineOverlaps().ToString());
    }
}