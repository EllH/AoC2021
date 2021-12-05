using System.Linq;

public class Day05 : BaseDay
{
    private readonly string Input;
    private readonly IEnumerable<int>[][] ParsedInput;

    public Day05()
    {
        this.Input = File.ReadAllText(InputFilePath);
        this.ParsedInput = ParsedInputToFormat();
    }

    public IEnumerable<int>[][] ParsedInputToFormat()
    {
        return this.Input.Split("\n").Select(row => row.Split(" -> ").Select(n => n.Split(",").Select(n => int.Parse(n))).ToArray()).ToArray();
    }

    public override ValueTask<string> Solve_1()
    {
        int[,] grid = new int[1000, 1000];

        foreach (var row in ParsedInput)
        {
            var start = row.First();
            var end = row.Last();
            var drawLineX = true;
            var drawLineY = true;
            if (start.First() != end.First()) drawLineX = false;
            if (start.Last() != end.Last()) drawLineY = false;
            if (!drawLineX && !drawLineY) continue;
            
            if (drawLineX)
            {
                var lineLength = Math.Abs(start.Last() - end.Last());
                for (int i = 0; i <= lineLength; i++)
                {
                    if (end.Last() > start.Last())
                    {
                        grid[start.First(), start.Last() + i] += 1;
                    }
                    else
                    {
                        grid[start.First(), start.Last() - i] += 1;
                    }

                }
            }

            if (drawLineY)
            {
                var lineLength = Math.Abs(start.First() - end.First());
                for (int i = 0; i <= lineLength; i++)
                {
                    if (end.First() > start.First())
                    {
                        grid[start.First() + i, start.Last()] += 1;
                    }
                    else
                    {
                        grid[start.First()-i, start.Last()] += 1;
                    }
                }
            }
        }

        var count = 0;
        for (int k = 0; k < grid.GetLength(0); k++)
        {
            for (int l = 0; l < grid.GetLength(1); l++)
            {
                if (grid[k, l] > 1) count++;
            }
        }
        
        return new(count.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        int[,] grid = new int[1000, 1000];

        foreach (var row in ParsedInput)
        {
            var start = row.First();
            var end = row.Last();
            var drawLineX = true;
            var drawLineY = true;
            if (start.First() != end.First()) drawLineX = false;
            if (start.Last() != end.Last()) drawLineY = false;

            if (drawLineX)
            {
                var lineLength = Math.Abs(start.Last() - end.Last());
                for (int i = 0; i <= lineLength; i++)
                {
                    if (end.Last() > start.Last())
                    {
                        grid[start.First(), start.Last() + i] += 1;
                    }
                    else
                    {
                        grid[start.First(), start.Last() - i] += 1;
                    }
                }
            }

            if (drawLineY)
            {
                var lineLength = Math.Abs(start.First() - end.First());
                for (int i = 0; i <= lineLength; i++)
                {
                    if (end.First() > start.First())
                    {
                        grid[start.First() + i, start.Last()] += 1;
                    }
                    else
                    {
                        grid[start.First()-i, start.Last()] += 1;
                    }
                    
                    
                }
            }

            if (!drawLineX && !drawLineY)
            {
                var lineLength1 = Math.Abs(start.First() - end.First());
                var lineLength2 = Math.Abs(start.Last() - end.Last());
                if (lineLength1 == lineLength2)
                {
                    for (int i = 0; i <= lineLength1; i++)
                    {
                        var x = 0;
                        var y = 0;
                        if (start.First() > end.First())
                        {
                            x = start.First() - i;
                        }
                        else
                        {
                            x = start.First() + i;
                        }

                        if (start.Last() > end.Last()) 
                        {
                            y = start.Last() - i;
                        }
                        else
                        {
                            y = start.Last() + i;
                        }
                        
                        grid[x, y] += 1;
                    }
                }
            }
        }

        var count = 0;
        for (int k = 0; k < grid.GetLength(0); k++)
        {
            for (int l = 0; l < grid.GetLength(1); l++)
            {
                if (grid[k, l] > 1) count++;
            }
        }
        
        return new(count.ToString());
    }
}