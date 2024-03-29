﻿using System.Linq;

public class Day02 : BaseDay
{
    private readonly string input;

    public Day02()
    {
        this.input = File.ReadAllText(InputFilePath);
    }

    public override ValueTask<string> Solve_1()
    {
        return new (ParsedInput().Aggregate(new State(0, 0, 0), (state, parsedInput) =>
            parsedInput.direction switch
            {
                "forward" => state with
                {
                    depth = state.depth + parsedInput.amount,
                },
                "up" => state with
                {
                    horizontal = state.horizontal - parsedInput.amount
                },
                "down" => state with
                {
                    horizontal = state.horizontal + parsedInput.amount
                },
                _ => throw new Exception("Direction Not Found.")
            }, state => state.horizontal * state.depth).ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        return new (ParsedInput().Aggregate(new State(0, 0, 0), (state, parsedInput) =>
            parsedInput.direction switch
            {
                "forward" => state with
                {
                    horizontal = state.horizontal + parsedInput.amount,
                    depth = state.depth + parsedInput.amount * state.aim,
                },
                "up" => state with
                {
                    aim = state.aim - parsedInput.amount
                },
                "down" => state with
                {
                    aim = state.aim + parsedInput.amount
                },
                _ => throw new Exception("Direction Not Found.")
            }, state => state.horizontal * state.depth).ToString());
    }

    IEnumerable<Input> ParsedInput() =>
        from
            line in this.input.Split('\n')
        let parts = line.Split()
        select
            new Input(parts[0], int.Parse(parts[1]));
}

record Input(string direction, int amount);

record State(int depth, int horizontal, int aim);