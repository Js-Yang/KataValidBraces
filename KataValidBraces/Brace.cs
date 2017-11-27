using System;
using System.Collections.Generic;
using System.Linq;

public class Brace
{
    public static bool validBraces(string input)
    {
        var brackets = new List<string>() { "[]", "{}", "()" }.Select(bracket => new Bracket(bracket)).ToList();
        var result = input;
        foreach (var bracket in brackets)
        {
            var paragraph = new Paragraph(result);
            if (paragraph.IsValid(bracket))
            {
                result = paragraph.Remove(bracket);
            }
        }

        return result == string.Empty;
    }
}

internal class Paragraph
{
    private string input;

    public Paragraph(string input)
    {
        this.input = input;
    }

    public string Remove(Bracket bracket)
    {
        while (Find(bracket))
        {
            input = input.Remove(bracket.PositionOfOpen(input), 1);
            input = input.Remove(bracket.PositionOfClose(input), 1);
        }
        return input;
    }
    
    public bool IsValid(Bracket bracket)
    {
        return Find(bracket) && IsValidDistinct(bracket) && IsValidOrder(bracket);
    }

    public bool Find(Bracket bracket)
    {
        return bracket.PositionOfOpen(input) != -1 && bracket.PositionOfClose(input) != -1;
    }

    private bool IsValidDistinct(Bracket bracket)
    {
        return (input.IndexOf(bracket.Close, bracket.PositionOfOpen(input)) - bracket.PositionOfOpen(input)) % 2 == 1;
    }

    private bool IsValidOrder(Bracket bracket)
    {
        return input.IndexOf(bracket.Close, bracket.PositionOfOpen(input)) != -1;
    }
}

internal class Bracket
{
    private char Open;

    public char Close;

    public Bracket(string bracket)
    {
        Open = bracket[0];
        Close = bracket[1];
    }

    public int PositionOfOpen(string input)
    {
        return input.LastIndexOf(Open);
    }

    public int PositionOfClose(string input)
    {
        return input.IndexOf(Close);
    }
}