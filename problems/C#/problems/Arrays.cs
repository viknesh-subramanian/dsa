using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problems
{
    public static class Arrays
    {
        public static int RomanToInt(string s)
        {
            char[] chars = s.ToCharArray();
            int result = 0;
            int current = 0;
            for (int i = 0; i < chars.Length - 1; i++)
            {
                current = RomanNumerals(chars[i]);
                result += (RomanNumerals(chars[i + 1]) > current ? -1 : 1) * current;
            }
            return result + RomanNumerals(chars[chars.Length - 1]);
        }

        private static int RomanNumerals(char c)
        {
            switch (c)
            {
                case 'I': return 1;
                case 'V': return 5;
                case 'X': return 10;
                case 'L': return 50;
                case 'C': return 100;
                case 'D': return 500;
                case 'M': return 1000;
            };
            return 0;
        }

        public static string IntToRoman(int num)
        {
            var result = new StringBuilder();
            var roman_kv = new Dictionary<int, string>
            {
                { 1000, "M" },
                { 900, "CM" },
                { 500, "D" },
                { 400, "CD" },
                { 100, "C" },
                { 90, "XC" },
                { 50, "L" },
                { 40, "XL" },
                { 10, "X" },
                { 9, "IX" },
                { 5, "V" },
                { 4, "IV" },
                { 1, "I" },
            };

            foreach (var kv in roman_kv)
            {
                while (num >= kv.Key)
                {
                    num -= kv.Key;
                    result.Append(kv.Value);
                }
            }

            return result.ToString();
        }

        public static int LengthOfLastWord(string s)
        {
            s = s.Trim();
            string[] val = s.Split(' ');
            return val[val.Length - 1].Length;
        }

        public static string ReverseWords(string s)
        {
            s = s.Trim();
            string[] val = s.Split(' ');
            int left = 0, right = val.Length - 1;
            while (left < right)
            {
                string temp = val[left];
                val[left] = val[right];
                val[right] = temp;
                left++;
                right--;
            }
            var result = new StringBuilder();
            foreach (string item in val)
            {
                if (!string.IsNullOrWhiteSpace(item))
                {
                    result.Append(" ");
                    result.Append(item);
                }
            }
            return result.ToString().Trim();
        }

        public static void ReverseWords(char[] s)
        {
            int length = s.Length;
            if (length <= 1) return;
            int start = 0;
            for (int i = 0; i < length; i++)
            {
                if (s[i] == ' ')
                {
                    // Reverse word when encountering space
                    ReverseUtil(s, start, i - 1);
                    start = i + 1;
                }
            }
            // Reverse last word
            ReverseUtil(s, start, length - 1);

            // Reverse entire char array
            ReverseUtil(s, 0, length - 1);

            Console.WriteLine(string.Join("", s));
        }

        private static void ReverseUtil(char[] s, int start, int end)
        {
            while (start < end)
            {
                char temp = s[start];
                s[start++] = s[end];
                s[end--] = temp;
            }
        }

        // Best time to sell stock
        public static int MaxProfit(int[] prices)
        {
            int max = 0;
            int min = prices[0];
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] < min)
                    min = prices[i];
                else
                    max = Math.Max(max, prices[i] - min);
            }
            return max;
        }
    }
}
