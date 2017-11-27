using System;
using System.Collections.Generic;

public class Brace
{
    public static bool validBraces(string input)
    {
        Console.WriteLine(input);
        var brackets = new List<string>() { "[]", "{}", "()" };
        foreach (var bracket in brackets)
        {
            if (ValidDistinct(bracket, input) || ValidOrder(bracket, input))
            {
                continue;
            }
            while (Contains(bracket, input))
            {
                Erase(bracket, ref input);
            }
        }

        return input == string.Empty;
    }

    private static bool ValidOrder(string bracket, string input)
    {
        return (input.LastIndexOf(bracket[1]) < input.IndexOf(bracket[0]));
    }

    private static bool ValidDistinct(string bracket, string input)
    {
        return (input.LastIndexOf(bracket[1]) - input.IndexOf(bracket[0]) + 1) % 2 == 1;
    }

    private static bool Contains(string bracket, string input)
    {
        return input.IndexOf(bracket[0]) != -1 && input.LastIndexOf(bracket[1]) != -1;
    }

    private static void Erase(string bracket, ref string input)
    {
        var start = bracket[0];
        var end = bracket[1];
        if (input.IndexOf(start) != -1)
        {
            input = input.Remove(input.IndexOf(start), 1);
            input = input.Remove(input.LastIndexOf(end), 1);
        }
    }
}