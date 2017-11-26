using System.Collections.Generic;

public class Brace
{
    public static bool validBraces(string input)
    {
        var brackets = new List<string>() { "[]", "{}", "()" };
        foreach (var bracket in brackets)
        {
            if (((input.IndexOf(bracket[1]) - input.IndexOf(bracket[0])) + 1) % 2 == 1)
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
        return input.IndexOf(bracket[0]) != -1 && input.IndexOf(bracket[1]) != -1;
    }

    private static void Erase(string bracket, ref string input)
    {
        foreach (var partOfBracket in bracket)
        {
            var index = input.IndexOf(partOfBracket);
            if (index != -1)
            {
                input = input.Remove(index, 1);
            }
        }
    }
}