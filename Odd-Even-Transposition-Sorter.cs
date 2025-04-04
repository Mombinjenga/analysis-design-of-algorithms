using System;

public class OddEvenTranspositionSorter
{
    public static void OddEvenSort(int[] arr)
    {
        int n = arr.Length;
        bool isSorted = false;

        while (!isSorted)
        {
            isSorted = true;

            // Odd indexed positions (1, 3, 5, ...)
            for (int i = 1; i <= n - 2; i += 2)
            {
                if (arr[i] > arr[i + 1])
                {
                    Swap(arr, i, i + 1);
                    isSorted = false;
                }
            }

            // Even indexed positions (0, 2, 4, ...)
            for (int i = 0; i <= n - 2; i += 2)
            {
                if (arr[i] > arr[i + 1])
                {
                    Swap(arr, i, i + 1);
                    isSorted = false;
                }
            }
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
        int[] arr = { 8, 3, 4, 2, 1, 5, 7, 6 };
        OddEvenSort(arr);

        Console.WriteLine("Sorted array:");
        foreach (int x in arr)
        {
            Console.Write(x + " ");
        }
    }
}