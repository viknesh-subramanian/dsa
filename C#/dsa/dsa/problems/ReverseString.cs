using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsa.problems
{
    public class ReverseString
    {
        static string Reverse(string str)
        {
            string result = string.Empty;
            for (int i = str.Length - 1; i >= 0; i--)
            {
                result += str[i];
            }
            return result;
        }
    }
}
