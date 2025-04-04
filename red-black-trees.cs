using System;
using System.Collections.Generic;
public class RedBlackTreeExample
{
 public static void Main()
 {
 SortedDictionary<int, string> redBlackTree = new 
SortedDictionary<int, string>();
 redBlackTree.Add(5, "five");
 redBlackTree.Add(3, "three");
 redBlackTree.Add(7, "seven");
 redBlackTree.Add(2, "two");
 redBlackTree.Add(4, "four");
 redBlackTree.Add(6, "six");
 redBlackTree.Add(8, "eight");
 foreach (var item in redBlackTree)
 {
 Console.WriteLine($"Key: {item.Key}, Value: 
{item.Value}");
 }
 }
}