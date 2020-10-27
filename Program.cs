using System;
using System.Collections.Generic;
using System.Linq;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 89, 12, 45, 112, 1, 1009, 2345, 4, 18, 543 };
            var sortedArr = MergeSort(arr.ToList());

            Console.WriteLine(string.Join(", ", sortedArr));
        }

        private static List<int> MergeSort(List<int> arr)
        {
            if (arr.Count <= 1)
            {
                return arr;
            }
            var middle = arr.Count / 2;

            var left = MergeSort(arr.GetRange(0, middle));
            var right = MergeSort(arr.GetRange(middle, arr.Count - middle));

            return CombineArrays(left, right);
        }

        private static List<int> CombineArrays(List<int> left, List<int> right)
        {
            var sorted = new List<int>();
            var leftIndex = 0;
            var rightIndex = 0;

            while (leftIndex < left.Count && rightIndex < right.Count)
            {
                if (left[leftIndex] < right[rightIndex])
                {
                    sorted.Add(left[leftIndex]);
                    leftIndex++;
                }
                else
                {
                    sorted.Add(right[rightIndex]);
                    rightIndex++;
                }

            }

            for (int i = leftIndex; i < left.Count; i++)
            {
                sorted.Add(left[i]);
            }

            for (int i = rightIndex; i < right.Count; i++)
            {
                sorted.Add(right[i]);
            }

            return sorted;
        }
    }
}
