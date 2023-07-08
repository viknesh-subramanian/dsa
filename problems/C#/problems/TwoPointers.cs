using problems.DS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace problems
{
    public static class TwoPointers
    {
        // Remove duplicates and return new length
        // No extra memory allowed
        public static int RemoveDuplicates(int[] list)
        {
            // Array needs to be sorted in order for this approach to work
            List<int> sortedlist = list.ToList();
            sortedlist.Sort();
            list = sortedlist.ToArray();

            int slow = 0;
            for (int fast = 0; fast < list.Length; fast++)
            {
                if (list[fast] != list[slow])
                {
                    slow++;
                    list[slow] = list[fast];
                }
            }
            return slow + 1;
        }

        // Remove duplicates and return new length
        // Extra memory allowed
        public static int RemoveDuplicatesWithMemory(int[] list)
        {
            Dictionary<int, int> distinct_list = new Dictionary<int, int>();
            for (int i = 0; i < list.Length; i++)
            {
                if (!distinct_list.ContainsKey(list[i]))
                    distinct_list.Add(list[i], list[i]);
            }
            return distinct_list.Count;
        }

        // Find middle of linked list
        // If the linked list has even length, return middle + 1

        public static int LLMiddle(Node head)
        {
            Node slow, fast;
            slow = fast = head;
            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }
            return slow.val;
        }

        public static Node BuildList(List<int> strs)
        {
            Node node = null;

            for (int i = strs.Count - 1; i >= 0; i--)
                node = new Node(strs[i], node);

            return node;
        }

        // Move zeros to the end of the array/list
        // No additional data strucure to be used

        public static string MoveZeroes(int[] array)
        {
            int slow = 0;
            for (int fast = 0; fast < array.Length; fast++)
            {
                if (array[fast] != 0)
                {
                    int temp = array[fast];
                    array[fast] = array[slow];
                    array[slow] = temp;
                    slow++;
                }
            }
            return string.Join(",", array);
        }

        public static string MoveZeroesNonTwoPointer(int[] array)
        {
            int i = 0;
            foreach (int x in array)
            {
                if (x != 0)
                {
                    array[i] = x;
                    i++;
                }
            }
            for (; i < array.Length; i++)
                array[i] = 0;

            return string.Join(",", array);
        }

        // Two sum sorted
        // Check which two integers return the target sum. Return the index of the two integers

        public static string TwoSumSorted(int[] array, int target)
        {
            int left = 0;
            int right = array.Length - 1;
            int[] sum_indices = new int[2] { 0, 0 };
            while (left < right)
            {
                int sum = array[left] + array[right];
                if (sum == target)
                {
                    sum_indices[0] = left;
                    sum_indices[1] = right;
                    break;
                }
                if (sum < target)
                    left++;
                else
                    right--;
            }

            return string.Join(",", sum_indices);
        }

        // Palindrome
        // Check if the string is palindrome. Return true if palindrome, false if not. Ignore cases and special characters (including spaces)

        public static bool IsPalindrome(string s)
        {
            int left = 0;
            int right = s.Length - 1;
            while (left < right)
            {
                while (left < right && !isAlphaNumeric(s[left]))
                    left++;
                while (left < right && !isAlphaNumeric(s[right]))
                    right--;
                if (s[left].ToString().ToLower() != s[right].ToString().ToLower())
                    return false;

                left++;
                right--;
            }
            return true;
        }

        private static bool isAlphaNumeric(char s)
        {
            Regex rg = new Regex(@"^[a-zA-Z0-9]*$");
            return rg.IsMatch(s.ToString());
        }

        // Given an array (list) nums consisted of only non-negative integers, find the largest sum among all subarrays of length 'size' in nums.

        public static int SubarraySum(List<int> ints, int size)
        {
            int window_sum = 0;
            for (int i = 0; i < size; i++)
                window_sum += ints[i];
            int largest_sum = window_sum;
            for (int right = size; right < ints.Count; right++)
            {
                int left = right - size;
                window_sum = window_sum - ints[left];
                window_sum = window_sum + ints[right];
                largest_sum = Math.Max(largest_sum, window_sum);
            }
            return largest_sum;
        }

        // Find the length of the longest subarray with sum smaller than or equal to a target

        public static int SubarrayLargest(List<int> ints, int target)
        {
            int window_sum = 0, length = 0;
            int left = 0;
            for (int right = 0; right < ints.Count; right++)
            {
                window_sum = window_sum + ints[right];
                while (window_sum > target)
                {
                    window_sum = window_sum - ints[left];
                    left++;
                }
                length = Math.Max(length, right - left + 1);
            }

            return length;
        }
        // Find the length of the longest substring of a given string without repeating characters.
        public static int LongestWithoutCharRepeat(string s)
        {
            var letters = new Dictionary<char, int>(); // key:letter, val: latest index
            int maxCount = 0, left = 0;
            for (int right = 0; right < s.Length; right++)
            {
                char letter = s[right];
                if (letters.ContainsKey(letter))
                { // End the window
                    left = Math.Max(left, letters[letter] + 1); // Update left of window
                }
                letters[letter] = right; //Update index of letter on map
                maxCount = Math.Max(maxCount, right - left + 1); // Get the longest window length 
            }

            return maxCount;
        }
    }
}
