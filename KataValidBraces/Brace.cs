using System.Collections.Generic;

namespace KataValidBraces
{
    public class Brace
    {
        public static bool validBraces(string input)
        {
            var brackets = new List<string>() { "[]", "{}", "()" };
            foreach (var bracket in brackets)
            {
                while (input.IndexOf(bracket[0]) != -1) 
                {
                    Erase(bracket, ref input);
                } 
            }

            return input == string.Empty;
        }

        private static void Erase(string bracket, ref string input)
        {
            foreach (var partOfBracket in bracket)
            {
                var index = input.IndexOf(partOfBracket);
                if (index != -1)
                {
                    RemoveCharAt(index, ref input);
                }
            }
        }

        private static void RemoveCharAt(int index, ref string input)
        {
            input = input.Remove(index, 1);
        }
    }
}