using System.Collections.Generic;

namespace KataValidBraces
{
    public class Brace
    {
        public static bool validBraces(string input)
        {
            var brackets = new List<string>() { "[]", "{}" };
            foreach (var bracket in brackets)
            {
                var start = bracket[0];
                var end = bracket[1];
                if (input.IndexOf(start) != -1 && input.IndexOf(end) != -1)
                {
                    input.Remove(input.IndexOf(start));
                    input.Remove(input.IndexOf(end));
                }
            }

            return input != string.Empty;
        }
    }
}