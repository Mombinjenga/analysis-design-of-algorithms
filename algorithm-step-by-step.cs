using System;
public class Program
{
 public static void Main()
 {
 int[] numbers = { 3, 1, 4, 1, 5, 9, 2, 6, 5 };
 int maxNumber = FindMax(numbers);
 Console.WriteLine("The maximum number is: " + maxNumber);
 }
 public static int FindMax(int[] numbers)
 {
 int max = numbers[0];
 for (int i = 1; i < numbers.Length; i++)
 {
 if (numbers[i] > max)
 {
 max = numbers[i];
 }
 }
 return max;
 }
}