﻿using System;
using System.Collections.Generic;
using System.Linq;

public class Brace
{
    public static bool validBraces(string input)
    {
        Console.WriteLine(input);
        var brackets = new List<string>() { "[]", "{}", "()" }.Select(bracket => new Bracket(bracket)).ToList();
        var openBrackets = new Stack<char>();

        foreach (var charactor in input.ToArray())
        {
            if (brackets.Any(x => x.Open == charactor))
            {
                openBrackets.Push(charactor);
            }
            else if (!openBrackets.Any() && brackets.Any(bracket => bracket.Close == charactor))
            {
                return false;
            }
            else if (openBrackets.Any() && brackets.First(bracket => bracket.Close == charactor).Open != openBrackets.Pop())
            {
                return false;
            }
        }

        return !openBrackets.Any();
    }
}

internal class Bracket
{
    public char Open;

    public char Close;

    public Bracket(string bracket)
    {
        Open = bracket[0];
        Close = bracket[1];
    }
}