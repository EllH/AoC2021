using System.Linq;

public class Day03 : BaseDay
{
    private readonly string[] input;

    public Day03()
    {
        this.input = File.ReadAllLines(InputFilePath);
    }

    public override ValueTask<string> Solve_1()
    {
        string gammaAsBinaryString = "";
        string epsilonAsBinaryString = "";
        
        for (int i = 0; i < this.input.First().Length; i++)
        {
            IEnumerable<int> slice = this.input.Select(bit => bit[i] - '0');
            if (slice.Sum() < this.input.Length / 2)
            {
                gammaAsBinaryString += "0";
                epsilonAsBinaryString += "1";
            }
            else
            {
                gammaAsBinaryString += "1";
                epsilonAsBinaryString += "0";
            }
        }

        return new((Convert.ToInt32(gammaAsBinaryString, 2) * Convert.ToInt32(epsilonAsBinaryString, 2)).ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        return new((FindRating(this.input, true) * FindRating(this.input, false)).ToString());
    }

    public int FindRating(string[] input, bool isOxygen, int bitPosition = 0)
    {
        if (input.Length == 1)
        {
            return Convert.ToInt32(input[0], 2);
        }
    
        IEnumerable<int> slice = input.Select(bit => bit[bitPosition] - '0');
    
        char mostCommonChar = 2 * slice.Sum() >= input.Length ? isOxygen ? '1' : '0' : isOxygen ? '0' : '1';
    
        return FindRating(input.Where(number => number[bitPosition] == mostCommonChar).ToArray(), isOxygen,
            bitPosition + 1);
    }
}
