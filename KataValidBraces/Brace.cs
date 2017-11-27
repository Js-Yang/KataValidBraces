using System;
using System.Collections.Generic;
using System.Linq;

public class Brace
{
    public static bool validBraces(string input)
    {
        var brackets = new List<string>() { "[]", "{}", "()" }.Select(bracket => new Bracket(bracket)).ToList();

        foreach (var bracket in brackets)
        {
            if (bracket.IsValid(input))
            {
                break;
            }

            EraseBy(bracket, ref input);
        }

        return input == string.Empty;
    }

    private static void EraseBy(Bracket bracket, ref string input)
    {
        while (bracket.Contains(input))
        {
            bracket.Erase(ref input);
        }
    }
}

internal class Bracket
{
    private string bracket;

    public char Open => bracket[0];

    public char Close => bracket[1];

    public Bracket(string bracket)
    {
        this.bracket = bracket;
    }

    public void Erase(ref string input)
    {
        input = input.Remove(input.LastIndexOf(Open), 1);
        input = input.Remove(input.IndexOf(Close), 1);
    }

    public bool Contains(string input)
    {
        return input.LastIndexOf(Open) != -1 && input.IndexOf(Close) != -1;
    }

    public bool IsValid(string input)
    {
        if (!Contains(input))
        {
            return false;
        }

        return ValidDistinct(input) || ValidOrder(input);
    }

    public bool ValidDistinct(string input)
    {
        return (input.IndexOf(Close) - input.LastIndexOf(Open) + 1) % 2 == 1;
    }

    public bool ValidOrder(string input)
    {
        return (input.IndexOf(Close, input.LastIndexOf(Open)) < input.LastIndexOf(Open));
    }

}