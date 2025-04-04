using System;

public class DynamicStack
{
    private int[] stack;
    private int count;
    private int capacity;

    public DynamicStack()
    {
        capacity = 2;
        stack = new int[capacity];
        count = 0;
    }

    public void Push(int value)
    {
        if (count == capacity)
        {
            Resize();
        }
        stack[count] = value;
        count++;
    }

    public int Pop()
    {
        if (count == 0) throw new InvalidOperationException("Stack is empty");
        int value = stack[count - 1];
        count--;
        return value;
    }

    private void Resize()
    {
        capacity *= 2;
        int[] newStack = new int[capacity];
        Array.Copy(stack, newStack, count);
        stack = newStack;
    }

    public static void Main()
    {
        DynamicStack stack = new DynamicStack();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        stack.Push(4);
        Console.WriteLine("Stack contents after pushing: 1, 2, 3, 4");

        while (true)
        {
            try
            {
                Console.WriteLine($"Popped: {stack.Pop()}");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Stack is empty");
                break;
            }
        }
    }
}
