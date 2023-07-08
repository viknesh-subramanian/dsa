// See https://aka.ms/new-console-template for more information
using algorithms;

Console.WriteLine("Hello, World!");
List<int> unsortedList = SplitWords("6, 2, 7, 3, 4, 9, 8, 1, 5").Select(int.Parse).ToList();

// Insertion Sort
// string sortedString = Sorting.InsertionSort(unsortedList);
// Console.WriteLine($"Sorted string -> {sortedString}");

// Selection Sort
// string sortedString = Sorting.SelectionSort(unsortedList);
// Console.WriteLine($"Sorted string -> {sortedString}");

// Bubble Sort
string sortedString = Sorting.BubbleSort(unsortedList);
Console.WriteLine($"Sorted string -> {sortedString}");

static List<string> SplitWords(string s)
{
    Console.WriteLine($"Unsorted string -> {s}");
    return string.IsNullOrEmpty(s) ? new List<string>() : s.Trim().Split(',').ToList();
}