using System.Linq;

public record struct ParsedData(IEnumerable<int> draw, IEnumerable<BingoBoard> boards);

public record BingoBoard(int Id, string[][] Board)
{
    public bool IsWinner(IEnumerable<int> drawnNumbers)
    {
        for (int i = 0; i < 5; i++)
        {
            var colMatches = 0;
            var rowMatches = 0;
            for (int j = 0; j < 5; j++)
            {
                rowMatches += drawnNumbers.Contains(int.Parse(Board[i][j])) ? 1 : 0;
                colMatches += drawnNumbers.Contains(int.Parse(Board[j][i])) ? 1 : 0;
            }

            if (rowMatches == 5 || colMatches == 5)
            {
                return true;
            }
        }

        return false;
    }
    
    public int SumOfRemaining(IEnumerable<int> drawnNumbers)
    {
        return Board.Select(row => row.Where(s => !drawnNumbers.Contains(int.Parse(s))).Sum(value => int.Parse(value)))
            .Sum();
    }
}


public class Day04 : BaseDay
{
    private readonly string Input;

    private ParsedData ParsedInput;

    public Day04()
    {
        this.Input = File.ReadAllText(InputFilePath);
        this.ParsedInput = ParseInput();
    }

    private ParsedData ParseInput()
    {
        var parts = this.Input.Split("\n", StringSplitOptions.RemoveEmptyEntries);
        
        var boards = parts.Skip(1).Select((s, i) => s.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray()).Chunk(5)
            .ToArray();

        return new(
                parts[0].Split(',').Select(int.Parse).ToArray(),
                boards.Select((board, i) => new BingoBoard(i ,board))
        );
    }

    public override ValueTask<string> Solve_1()
    {
        List<int> drawnNumbers = new ();

        foreach (int number in this.ParsedInput.draw)
        {
            drawnNumbers.Add(number);
            foreach (var bingoBoard in this.ParsedInput.boards)
            {
                if (bingoBoard.IsWinner(drawnNumbers))
                {
                    return new((bingoBoard.SumOfRemaining(drawnNumbers) * number).ToString());
                }

                
            }
        }
        
        return new("Didn't Find Winner :C");
    }

    public override ValueTask<string> Solve_2()
    {
        
        List<int> drawnNumbers = new ();
        List<int> winners = new();
        foreach (int number in this.ParsedInput.draw)
        {
            drawnNumbers.Add(number);
            foreach (var bingoBoard in this.ParsedInput.boards)
            {
                if (winners.Contains(bingoBoard.Id)) continue;
                if (!bingoBoard.IsWinner(drawnNumbers)) continue;
                
                winners.Add(bingoBoard.Id);
        
                if (winners.Count == this.ParsedInput.boards.Count())
                {
                    return new((bingoBoard.SumOfRemaining(drawnNumbers) * number).ToString());
                }
            }
        }

        return new("Didn't Find Winner :C");
    }
}