using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataValidBraces
{
    public class Brace
    {
        public static bool validBraces(string input)
        {
            if (input.StartsWith("[") && input.EndsWith("]"))
            {
                return true;
            }
            return false;
        }
    }
}
