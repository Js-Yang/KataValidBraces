using System;
using System.Collections.Generic;
using System.Linq;

public class Brace
{
    public static bool validBraces(string input)
    {
        Console.WriteLine(input);
        var brackets = new List<string>() { "[]", "{}", "()" }.Select(bracket => new Bracket(bracket)).ToList();

        foreach (var bracket in brackets)
        {
            if (bracket.IsValid(input))
            {
                bracket.EraseIn(ref input);
            }
        }

        return input == string.Empty;
    }
}

internal class Bracket
{
    private char Open;

    private char Close;

    public Bracket(string bracket)
    {
        Open = bracket[0];
        Close = bracket[1];
    }

    public bool IncludeIn(string input)
    {
        return input.LastIndexOf(Open) != -1 && input.IndexOf(Close) != -1;
    }

    public bool IsValid(string input)
    {
        return IncludeIn(input) && ValidDistinct(input) && ValidOrder(input);
    }

    private bool ValidDistinct(string input)
    {
        return (input.IndexOf(Close, input.LastIndexOf(Open)) - input.LastIndexOf(Open) + 1) % 2 == 0;
    }

    private bool ValidOrder(string input)
    {
        return input.IndexOf(Close, input.LastIndexOf(Open)) != -1;
    }

    public void EraseIn(ref string input)
    {
        while (IncludeIn(input))
        {
            input = input.Remove(input.LastIndexOf(Open), 1);
            input = input.Remove(input.IndexOf(Close), 1);
        }
    }
}