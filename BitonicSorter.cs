csharp
using System;

public class BitonicSorter
{
    public static void BitonicSort(int[] arr, int low, int cnt, bool dir)
    {
        if (cnt > 1)
        {
            int k = cnt / 2;

            BitonicSort(arr, low, k, true);
            BitonicSort(arr, low + k, k, false);
            BitonicMerge(arr, low, cnt, dir);
        }
    }

    public static void BitonicMerge(int[] arr, int low, int cnt, bool dir)
    {
        if (cnt > 1)
        {
            int k = cnt / 2;
            for (int i = low; i < low + k; i++)
            {
                if (dir == (arr[i] > arr[i + k]))
                {
                    Swap(arr, i, i + k);
                }
            }
            BitonicMerge(arr, low, k, dir);
            BitonicMerge(arr, low + k, k, dir);
        }
    }

    public static void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    public static void Main()
    {
        int[] arr = { 3, 7, 4, 8, 6, 2, 1, 5 };
        int n = arr.Length;
        BitonicSort(arr, 0, n, true);

        Console.WriteLine("Sorted array:");
        foreach (int x in arr)
        {
            Console.Write(x + " ");
        }
    }
}