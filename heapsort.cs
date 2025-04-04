using System;
public class HeapSort
{
 public void Sort(int[] arr)
 {
 int n = arr.Length;
 // Build a max heap
 for (int i = n / 2 - 1; i >= 0; i--)
 Heapify(arr, n, i);
 // One by one extract elements
 for (int i = n - 1; i > 0; i--)
 {
 // Move current root to end
 int temp = arr[0];
 arr[0] = arr[i];
 arr[i] = temp;
 // Call max heapify on the reduced heap
 Heapify(arr, i, 0);
 }
 }
 void Heapify(int[] arr, int n, int i)
 {
 int largest = i; // Initialize largest as root
 int left = 2 * i + 1; // left = 2*i + 1
 int right = 2 * i + 2; // right = 2*i + 2
 // If left child is larger than root
 if (left < n && arr[left] > arr[largest])
 largest = left;
 // If right child is larger than largest so far
 if (right < n && arr[right] > arr[largest])
 largest = right;
 // If largest is not root
 if (largest != i)
 {
 int swap = arr[i];
 arr[i] = arr[largest];
 arr[largest] = swap;
 // Recursively heapify the affected sub-tree
 Heapify(arr, n, largest);
 }
 }
 public static void Main()
 {
 int[] arr = { 12, 11, 13, 5, 6, 7 };
 HeapSort hs = new HeapSort();
 hs.Sort(arr);
 Console.WriteLine("Sorted array is");
 foreach (var item in arr)
 Console.Write(item + " ");
 }
}