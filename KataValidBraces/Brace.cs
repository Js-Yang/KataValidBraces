using System.Collections.Generic;

namespace KataValidBraces
{
    public class Brace
    {
        public static bool validBraces(string input)
        {
            var brackets = new List<string>() { "[]", "{}" , "()" };
            foreach (var bracket in brackets)
            {
                if (input.IndexOf(bracket[0]) != -1 && input.IndexOf(bracket[1]) != -1)
                {
                    RemoveCharAt(input.IndexOf(bracket[0]), ref input);
                    RemoveCharAt(input.IndexOf(bracket[1]), ref input);
                }
            }

            return input == string.Empty;
        }

        private static void RemoveCharAt(int index, ref string input)
        {
            input = input.Remove(index, 1);
        }
    }
}