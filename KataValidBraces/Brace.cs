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
            bracket.SetInput(input);
            if (bracket.IsValid())
            {
                input = bracket.RemoveInInput();
            }
        }

        return input == string.Empty;
    }
}

internal class Bracket
{
    private char Open;

    private char Close;

    private string input;

    private int PositionOfOpen => input.LastIndexOf(Open);

    private int PositionOfClose => input.IndexOf(Close);

    public void SetInput(string input)
    {
        this.input = input;
    }

    public Bracket(string bracket)
    {
        Open = bracket[0];
        Close = bracket[1];
    }

    public bool IsFindIn(string input)
    {
        return PositionOfOpen != -1 && PositionOfClose != -1;
    }

    public bool IsValid()
    {
        return IsFindIn(input) && ValidDistinct() && ValidOrder();
    }

    private bool ValidDistinct()
    {
        return (input.IndexOf(Close, PositionOfOpen) - PositionOfOpen + 1) % 2 == 0;
    }

    private bool ValidOrder()
    {
        return input.IndexOf(Close, PositionOfOpen) != -1;
    }

    public string RemoveInInput()
    {
        while (IsFindIn(input))
        {
            input = input.Remove(PositionOfOpen, 1);
            input = input.Remove(PositionOfClose, 1);
        }
        return input;
    }
}