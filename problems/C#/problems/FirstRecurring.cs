using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problems
{
    public static class FirstRecurring
    {
        public static int ReturnFirstRecurring(int[] int_array)
        {
            Dictionary<int, int> kv = new Dictionary<int, int>();
            for (int i = 0; i < int_array.Length; i++)
            {
                Console.WriteLine(int_array[i]);
                if (kv.ContainsKey(int_array[i]))
                    return int_array[i];
                else
                {
                    kv[int_array[i]] = int_array[i];
                }
            }
            return 0;
        }
    }
}
