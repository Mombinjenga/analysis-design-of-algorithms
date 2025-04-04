using System;
public class CountingSort
{
 public void Sort(int[] arr)
 {
 int max = arr[0];
 for (int i = 1; i < arr.Length; i++)
 {
 if (arr[i] > max)
 max = arr[i];
 }
 int[] count = new int[max + 1];
 int[] output = new int[arr.Length];
 for (int i = 0; i < arr.Length; i++)
 {
 count[arr[i]]++;
 }
 for (int i = 1; i <= max; i++)
 {
 count[i] += count[i - 1];
 }
 for (int i = arr.Length - 1; i >= 0; i--)
 {
 output[count[arr[i]] - 1] = arr[i];
 count[arr[i]]--;
 }
 for (int i = 0; i < arr.Length; i++)
 {
 arr[i] = output[i];
 }
 }
 public static void Main()
 {
 int[] arr = { 4, 2, 2, 8, 3, 3, 1 };
 CountingSort cs = new CountingSort();
 cs.Sort(arr);
 Console.WriteLine("Sorted array is");
 foreach (var item in arr)
 Console.Write(item + " ");
 }
}