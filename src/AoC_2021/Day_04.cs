using System.Linq;

public class Day04 : BaseDay
{
    private readonly string input;

    private readonly string[] numbers =
        "50,68,2,1,69,32,87,10,31,21,78,23,62,98,16,99,65,35,27,96,66,26,74,72,45,52,81,60,38,57,54,19,18,77,71,29,51,41,22,6,58,5,42,92,85,64,94,12,83,11,17,14,37,36,59,33,0,93,34,70,97,7,76,20,3,88,43,47,8,79,80,63,9,25,56,75,15,4,82,67,39,30,89,86,46,90,48,73,91,55,95,28,49,61,44,84,40,53,13,24"
            .Split(",");

    public Day04()
    {
        this.input = File.ReadAllText(InputFilePath);
    }

    public override ValueTask<string> Solve_1()
    {
        var count = 0;
        var marked = this.input.Replace("\r\n\r\n", "\r\n").Split("\r\n")
            .Select(row => row.Replace("  ", " ").Split(" ")).ToArray();
        bool rowMatchFound = false;

        while (rowMatchFound == false)
        {
            marked = marked.Select(row => row.Select(value => value == this.numbers[count] ? "✔" : value).ToArray())
                .ToArray();
            var markedBoard = marked.Chunk(5).ToArray();
            rowMatchFound = marked.Where(board => board.Count(row => row == "✔") == 5).ToArray().Any();
            foreach (var board in markedBoard)
            {
                for (int i = 0; i < 5; i++)
                {
                    var columnMatchFound = true;
                    for (int j = 0; j < 5; j++)
                    {
                        if (board[j][i] != "✔")
                        {
                            columnMatchFound = false;
                        }
                    }

                    if (columnMatchFound || rowMatchFound)
                    {
                        var sum = board.Select(row => row.Where(s => s != "✔")).Select(r => r.Sum(x => int.Parse(x))).Sum();
                        
                        return new((sum * int.Parse(numbers[count])).ToString());
                    }
                }
            }

            ++count;
        }

        return new("Didn't Find Winner :C");
    }

    public override ValueTask<string> Solve_2()
    {
        var count = 0;
        var marked = this.input.Replace("\r\n\r\n", "\r\n").Split("\r\n")
            .Select(row => row.Split(" ")).ToList();
        int boardsCount = marked.Chunk(5).ToArray().Length;
        int completeBoards = 0;

        while (completeBoards < boardsCount)
        {
            marked = marked.Select(row => row.Select(value => value == this.numbers[count] ? "✔" : value).ToArray())
                .ToList();

            for (var q = 0; q <= marked.Count - 5; q += 5)
            {
                var columnMatchFound = true;
                for (int i = 0; i < 5; i++)
                {
                    columnMatchFound = true;
                    for (int j = q; j < q + 5; j++)
                    {
                        if (marked[j][i] != "✔")
                        {
                            columnMatchFound = false;
                            break;
                        }
                    }

                    if (columnMatchFound)
                    {
                        break;
                    }
                }

                var rowMatchFound = true;
                for (int i = q; i < q + 5; i++)
                {
                    rowMatchFound = true;
                    for (int j = 0; j < 5; j++)
                    {
                        if (marked[i][j] != "✔")
                        {
                            rowMatchFound = false;
                            break;
                        }
                    }

                    if (rowMatchFound)
                    {
                        break;
                    }
                }
                

                if (columnMatchFound || rowMatchFound)
                {
                    if (completeBoards == 99)
                    {
                        
                        var sum = marked.Chunk(5).ToArray().First().Select(row => row.Where(s => s != "✔")).Select(r => r.Sum(x => int.Parse(x)))
                            .Sum();
                        return new((sum * int.Parse(numbers[count])).ToString());
                    }

                    marked.RemoveRange(q, 5);
                    completeBoards = completeBoards + 1;
                }
            }

            count++;
        }

        return new("Didn't Find Winner :C");
    }
}