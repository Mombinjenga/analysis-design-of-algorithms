using System;
using System.Collections.Generic;
public class HashTableExample
{
 public static void Main()
 {
 Dictionary<string, int> hashTable = new Dictionary<string, 
int>();
 hashTable["apple"] = 1;
 hashTable["banana"] = 2;
 hashTable["cherry"] = 3;
 foreach (var item in hashTable)
 {
 Console.WriteLine($"Key: {item.Key}, Value: 
{item.Value}");
 }
 }
}