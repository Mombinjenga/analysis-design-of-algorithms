using System;
public class QuickSort
{
 public void Sort(int[] arr, int low, int high)
 {
 if (low < high)
 {
 int pi = Partition(arr, low, high);
 // Recursively sort elements before partition and after 
partition
 Sort(arr, low, pi - 1);
 Sort(arr, pi + 1, high);
 }
 }
 int Partition(int[] arr, int low, int high)
 {
 int pivot = arr[high];
 int i = (low - 1);
 for (int j = low; j < high; j++)
 {
 if (arr[j] <= pivot)
 {
 i++;
 int temp = arr[i];
 arr[i] = arr[j];
 arr[j] = temp;
 }
 }
 int temp1 = arr[i + 1];
 arr[i + 1] = arr[high];
 arr[high] = temp1;
 return i + 1;
 }
 public static void Main()
 {
 int[] arr = { 10, 7, 8, 9, 1, 5 };
 int n = arr.Length;
 QuickSort qs = new QuickSort();
 qs.Sort(arr, 0, n - 1);
 Console.WriteLine("Sorted array is:");
 foreach (var item in arr)
 Console.Write(item + " ");
 }
}