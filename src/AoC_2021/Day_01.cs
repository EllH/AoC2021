using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AoCHelper;

public class Day01 : BaseDay
{
    private readonly string input;

    private readonly List<int> inputAsInts;

    public Day01()
    {
        input = File.ReadAllText(InputFilePath);
        inputAsInts = Array.ConvertAll(input.Split("\n"), int.Parse).ToList();
    }

    public override ValueTask<string> Solve_1()
    {
        return new ValueTask<string>(inputAsInts.Skip(1).Zip(inputAsInts, (curr, prev) => curr > prev)
            .Count(c => c).ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        return new ValueTask<string>(inputAsInts.Skip(3).Zip(inputAsInts, (curr, prev) => curr > prev)
            .Count(c => c).ToString());
    }
}