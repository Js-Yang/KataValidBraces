using System.Collections.Generic;

public class Brace
{
    public static bool validBraces(string input)
    {
        var brackets = new List<string>() { "[]", "{}", "()" };
        foreach (var bracket in brackets)
        {
            if ((input.IndexOf(bracket[1]) - input.LastIndexOf(bracket[0]) + 1) % 2 == 1)
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