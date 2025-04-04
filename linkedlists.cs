using System;
public class LinkedListNode
{
 public int Value;
 public LinkedListNode Next;
 public LinkedListNode(int value)
 {
 Value = value;
 Next = null;
 }
}
public class LinkedList
{
 public LinkedListNode Head;
 public void Add(int value)
 {
 LinkedListNode newNode = new LinkedListNode(value);
 if (Head == null)
 {
 Head = newNode;
 }
 else
 {
 LinkedListNode current = Head;
 while (current.Next != null)
 {
 current = current.Next;
 }
 current.Next = newNode;
 }
 }
 public void Print()
 {
 LinkedListNode current = Head;
 while (current != null)
 {
 Console.WriteLine(current.Value);
 current = current.Next;
 }
 }
}
public class LinkedListExample
{
 public static void Main()
 {
 LinkedList list = new LinkedList();
 list.Add(1);
 list.Add(2);
 list.Add(3);
 list.Print();
 }
}