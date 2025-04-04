using System;
using System.Collections.Generic;
public class BucketSort
{
 public void Sort(float[] arr)
 {
 int n = arr.Length;
 List<float>[] buckets = new List<float>[n];
 for (int i = 0; i < n; i++)
 {
 buckets[i] = new List<float>();
 }
 for (int i = 0; i < n; i++)
 {
 int index = (int)(n * arr[i]);
 buckets[index].Add(arr[i]);
 }
 for (int i = 0; i < n; i++)
 {
 buckets[i].Sort();
 }
 int k = 0;
 for (int i = 0; i < n; i++)
 {
 foreach (float value in buckets[i])
 {
 arr[k] = value;
 k++;
 }
 }
 }
 public static void Main()
 {
 float[] arr = { 0.897f, 0.565f, 0.656f, 0.123f, 0.665f, 
0.343f };
 BucketSort bs = new BucketSort();
 bs.Sort(arr);
 Console.WriteLine("Sorted array is");
 foreach (var item in arr)
 Console.Write(item + " ");
 }
}