using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace algorithms
{
    public static class Sorting
    {
        public static string InsertionSort(List<int> intList)
        {
            for (int i = 0; i < intList.Count; i++)
            {
                int current = i;
                while (current > 0 && intList[current] < intList[current - 1])
                {
                    Console.WriteLine(intList[current]);
                    int temp = intList[current];
                    intList[current] = intList[current - 1];
                    intList[current - 1] = temp;
                    current--;
                }
            }
            return string.Join(", ", intList);
        }

        public static string SelectionSort(List<int> intList)
        {
            int n = intList.Count;
            for (int i = 0; i < n; i++)
            {
                int minIndex = i;
                //Console.WriteLine($"Minindex -> {intList[minIndex]}");
                for (int j = i; j < n; j++)
                {
                    //Console.WriteLine($"j -> {intList[j]}");
                    if (intList[j] < intList[minIndex])
                    {
                        minIndex = j;
                        //Console.WriteLine($"Minindex -> {intList[minIndex]}");
                    }
                }
                int temp = intList[i];
                intList[i] = intList[minIndex];
                intList[minIndex] = temp;
                //Console.WriteLine($"Temp Array -> {string.Join(", ", intList)}");
            }
            return string.Join(", ", intList);
        }

        public static string BubbleSort(List<int> intList)
        {
            int n = intList.Count;
            for (int i = n - 1; i >= 0; i--)
            {
                bool swapped = false;
                for (int j = 0; j < i; j++)
                {
                    if (intList[j] > intList[j + 1])
                    {
                        int temp = intList[j];
                        intList[j] = intList[j + 1];
                        intList[j + 1] = temp;
                        swapped = true;
                    }
                }
                if (!swapped) return string.Join(", ", intList);
            }
            return string.Join(", ", intList);
        }
    }
}
