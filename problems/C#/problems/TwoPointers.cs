using problems.DS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
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

        public static int RemoveDuplicatesNonTwoPointer(int[] nums)
        {
            // Array needs to be sorted in order for this approach to work
            Array.Sort(nums);
            int count = 0;
            int prev = nums[0];
            for (int fast = 0; fast < nums.Length; fast++)
            {
                if (prev == nums[fast])
                {
                    count++;
                    if (count > 2)
                        nums[fast] = '_';
                }
                else
                {
                    prev = nums[fast];
                    count = 1;
                }
            }
            Array.Sort(nums);
            return nums.Where(x => x != '_').Count();
        }

        // Remove duplicates and return new length
        // Extra memory allowed
        public static int RemoveDuplicatesWithMemory(int[] list)
        {
            Array.Sort(list);
            int i = 1;
            foreach (int n in list)
            {
                if (list[i - 1] != n) list[i++] = n;
            }
            return i;
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

        public static string TwoSumSorted(int[] numbers, int target)
        {
            int left = 0;
            int right = numbers.Length - 1;
            int[] sum_indices = new int[2] { 0, 0 };
            while (left < right)
            {
                int sum = numbers[left] + numbers[right];
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

        public static bool IsPalindromeAlt(string s)
        {
            var clean = s.ToLower().Where(x => char.IsLetterOrDigit(x));
            return clean.Reverse().SequenceEqual(clean);
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

        public static int SubarrayLargest(List<int> nums, int target)
        {
            int window_sum = 0, length = 0;
            int left = 0;
            for (int right = 0; right < nums.Count; right++)
            {
                // Valid window because we are looking for the largest window possible
                window_sum = window_sum + nums[right];
                while (window_sum > target) // Invalid window
                {
                    window_sum = window_sum - nums[left];
                    left++; // Update left until its valid again
                }
                // Valid window again
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

        // Find the length of the shortest subarray such that the subarray sum is at least target
        public static int SubarraySmallest(int[] nums, int target)
        {
            int window_sum = 0, length = int.MaxValue;
            int left = 0;
            for (int right = 0; right < nums.Length; right++)
            {
                // Valid window because we are looking for the largest window possible
                window_sum = window_sum + nums[right];
                while (window_sum >= target) // Invalid window
                {
                    length = Math.Min(length, right - left + 1);
                    window_sum = window_sum - nums[left];
                    left++; // Update left until its valid again
                }
            }

            return length == int.MaxValue ? 0 : length;
        }

        // What's the minimum number of cards that you need to pick up to make a pair? If there is no matching pairs, return -1.
        public static int LeastConsecutiveCards(List<int> cards)
        {
            Dictionary<int, int> window = new Dictionary<int, int>();
            int shortest = cards.Count + 1; // As atleast two cards are needed to match
            int left = 0;
            for (int right = 0; right < cards.Count; right++)
            {
                window.TryGetValue(window[cards[right]], out int val);
                window[cards[right]] = val + 1;
                while (window[cards[right]] == 2)
                {
                    // Valid window
                    shortest = Math.Min(shortest, right - left + 1);
                    window[cards[left]]--;
                    left++; // Update left to make it closer to invalid
                }
            }

            return shortest != cards.Count + 1 ? shortest : -1;
        }

        // Find vowels in string and swap them 
        public static string ReverseVowels(string s)
        {
            char[] char_array = s.ToCharArray();
            char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
            int left = 0; int right = s.Length - 1;
            while (left < right)
            {
                if (!vowels.Contains(char_array[left]))
                    left++;
                else if (!vowels.Contains(char_array[right]))
                    right--;
                else
                {
                    char temp = char_array[left];
                    char_array[left] = char_array[right];
                    char_array[right] = temp;

                    left++;
                    right--;
                }
            }
            return string.Join("", char_array);
        }

        // Given an array of characters chars, compress it
        public static int Compress(char[] chars)
        {
            int w = 0, r = 0;
            int n = chars.Length;
            while (r < n)
            {
                int c = 0;
                char curr = chars[r];
                while (r < n && curr == chars[r]) 
                {
                    c++;
                    r++;
                }
                chars[w++] = curr;
                if (c > 1)
                {
                    foreach (char s in c.ToString())
                    {
                        chars[w] = s;
                        w++;
                    }
                }
            }
            return w;
        }

        // Merge nums1 and nums2 into a single array sorted in non-decreasing order.
        public static int[] MergeSortedArrays(int[] nums1, int m, int[] nums2, int n)
        {
            int i = m - 1;
            int j = n - 1;
            int k = m + n - 1;
            while (j >= 0)
            {
                if (i >= 0 && nums1[i] > nums2[j])
                    nums1[k--] = nums1[i--];
                else
                    nums1[k--] = nums2[j--];
            }
            Array.Sort(nums1);
            return nums1;
        }

        public static List<List<int>> ThreeSum(int[] nums)
        {
            List<List<int>> result = new List<List<int>>();
            if (nums.Length <= 2) return result;

            Array.Sort(nums);

            /*Here we declare 3 indexes. This is how it works. 
            -4 -2 -3 -1 0 0 0 2 3 10 21
             s  l                     r 
             
             s - start index, l - left index, r - right index */
            int start = 0, left, right;

            /*The target is that the number we are looking for to be composed out of 2 numbers from our array.
            for example, if we have the startIndex at -4, we are looking for those two numbers in the given array
            which, summed up will be the oposite of -4, which is 4, cuz -4 + 4 = 0 (duh) */
            int target;

            /*The start goes from 0 to length-2 becuse look here
             -4 -2 -3 -1 0 0 0 2 3 10 21
                                 s  l  r      */
            while (start < nums.Length - 2)
            {
                target = nums[start] * -1;
                left = start + 1;
                right = nums.Length - 1;

                /*Now, the start index is fixed and we move the left and right indexes to find those two number
                which summed up will be the oposite of nums[s]  */
                while (left < right)
                {
                    /*The array is sorted, so if we move to the left the right index, the sum will decrese */
                    if (nums[left] + nums[right] > target)
                        right--;

                    /*Here is the oposite, it the sum of nums[l] and nums[r] is less that what we are looking for,
                    then we move the left index, which means that the sum will increase due to the sorted array.
                    the left index will jump to a bigger value */
                    else if (nums[left] + nums[right] < target)
                        left++;
                    /*If none of those are true, then it means that nums[l]+nums[r] = our desired value */
                    else
                    {
                        /*Here we create the solution and add it to the list of lists which contains the result. */
                        List<int> OneSolution = new List<int>() { nums[start], nums[left], nums[right] };
                        result.Add(OneSolution);

                        /*Now, in order to generate different solutions, we have to jump over
                        repetitive values in the array.  */
                        while (left < right && nums[left] == OneSolution[1])
                            left++;
                        while (left < right && nums[right] == OneSolution[2])
                            right--;
                    }

                }
                /*Now we do the same thing to the start index. */
                int currentStartNumber = nums[start];
                while (start < nums.Length - 2 && nums[start] == currentStartNumber)
                    start++;
            }
            return result;
        }

        // Container with most water
        public static int MaxArea(int[] height)
        {
            int left = 0, right = height.Length - 1;
            int max_area = 0;
            while (left < right)
            {
                max_area = Math.Max(max_area, (right - left) * Math.Min(height[left], height[right]));
                if (height[left] < height[right])
                    left++;
                else
                    right--;
            }
            return max_area;
        }

        // Is subsequence
        public static bool IsSubsequence(string s, string t)
        {
            if (string.IsNullOrEmpty(s)) return true;
            int index = 0;
            for (int i = 0; i < t.Length && index < s.Length; i++)
            {
                if (t[i] == s[index])
                    index ++;
            }
            return index == s.Length;
        }

        // Minimum size subarray

        public static int MinSubArraySum(int[] nums, int target)
        {
            int window_sum = 0, length = nums.Length;
            int left = 0;
            for (int right = 0; right < nums.Length; right++)
            {
                // Valid window because we are looking for the largest window possible
                window_sum = window_sum + nums[right];
                while (window_sum <= target) // Invalid window
                {
                    length = Math.Min(length, right - left + 1);
                    window_sum = window_sum - nums[left];
                    left++; // Update left until its valid again
                }
            }

            return length;
        }
    }
}
