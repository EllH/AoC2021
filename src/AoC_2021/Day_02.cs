using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AoCHelper;

namespace AoC_2021
{
    public class Day02 : BaseDay
    {
        private readonly string input;

        public Day02()
        {
            input = File.ReadAllText(InputFilePath);
        }
    
        public override ValueTask<string> Solve_1()
        {
            string[] inputSplit = input.Split("\n").ToArray();
            var depth = 0;
            var horizontal = 0;
            foreach (var row in inputSplit)
            {
                var line = row.Split(" ");

                switch (line.First())
                {
                    case "forward":
                        depth += int.Parse(line.Last());
                        break;
                    case "up":
                        horizontal -= int.Parse(line.Last());
                        break;
                    case "down":
                        horizontal += int.Parse(line.Last());
                        break;
                }
            }
            return new ValueTask<string>((horizontal * depth).ToString());
        }
    
        public override ValueTask<string> Solve_2()
        {
            string[] inputSplit = input.Split("\n").ToArray();
            var depth = 0;
            var horizontal = 0;
            var aim = 0;
            foreach (var row in inputSplit)
            {
                var line = row.Split(" ");

                switch (line.First())
                {
                    case "forward":
                        horizontal += int.Parse(line.Last());
                        depth += int.Parse(line.Last()) * aim;
                        break;
                    case "up":
                        aim -= int.Parse(line.Last());
                        break;
                    case "down":
                        aim += int.Parse(line.Last());
                        break;
                }
            }
            return new ValueTask<string>((horizontal * depth).ToString());
        }
    }
}