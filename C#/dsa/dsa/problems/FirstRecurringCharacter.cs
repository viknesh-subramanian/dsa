using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsa.problems
{
    public class FirstRecurringCharacter
    {
        // Given an array [2,5,1,2,3,5,1,2,4]
        // It should return 2 - the first recurring character
        static int Find(int[] input)
        {
            Hashtable map = new Hashtable();
            for (int i = 0; i < input.Length; i++) // O(n) time complexity
            {
                if (map.ContainsKey(input[i]))
                {
                    return input[i];
                }
                map[input[i]] = input[i]; // O(n) space complexity
            }
            return 0;
        }
    }
}
