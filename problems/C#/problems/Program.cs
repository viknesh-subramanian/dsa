// See https://aka.ms/new-console-template for more information
using problems;
using problems.DS;

Console.WriteLine("Hello, World!");


// First Recurring Integer
// int[] array = new int[] { 2, 5, 1, 9, 3, 6, 7, 8, 4 };
// int output = FirstRecurring.ReturnFirstRecurring(array);
// if (output == 0)
//     Console.WriteLine("No recurring integers");
// else
//     Console.WriteLine($"{output} is the first recurring integer");


// Remove Duplicates
// int[] array = new int[] { 2, 1, 1, 0, 0, 1, 2, 2, 2 };
// Console.WriteLine($"{array.Length} is the old length");
// int output = TwoPointers.RemoveDuplicates(array);
// Console.WriteLine($"{output} is the new length");


// Middle of linked list
// int[] array = new int[] { 2, 5, 1, 9, 6, 7, 8, 4 };
// Node head = TwoPointers.BuildList(array.ToList());
// int output = TwoPointers.LLMiddle(head);
// Console.WriteLine($"{output} is the middle of linked list");

// Move Zeroes
// int[] array = new int[] { 0, 0, 0, 1, 0, 7, 2, 4 };
// string output = TwoPointers.MoveZeroesNonTwoPointer(array);
// Console.WriteLine($"{output} is the modified array");

// Two sums
// int[] array = new int[] { 1, 2, 3, 6, 8, 9, 12, 14, 18 };
// string output = TwoPointers.TwoSumSorted(array, 21);
// Console.WriteLine($"{output} are the indices");

// Valid Palindrome
// string text = "A brown fox jumping over";
// bool output = TwoPointers.IsPalindrome(text);
// Console.WriteLine(output);

// Largest Subarray sum
// List<int> list = new List<int> { 1, 2, 3, 0, 8, 9, 12, 0, 1 };
// int size = 4;
// int output = TwoPointers.SubarraySum(list, size);
// Console.WriteLine($"{output} is the largest sum of the subarray with size of {size}");

// Largest Subarray
// List<int> list = new List<int> { 1, 2, 3, 0, 8, 9, 12, 0, 1 };
// int target = 21;
// int output = TwoPointers.SubarrayLargest(list, target);
// Console.WriteLine($"{output} is the largest size of the subarray");

// Longest length without repeat characters
string text = "aawerttty";
int output = TwoPointers.LongestWithoutCharRepeat(text);
Console.WriteLine($"{output} is the largest size without character repeat");