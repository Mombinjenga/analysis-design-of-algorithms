using System;

public class GreedyAlgorithmExample
{
    public static int MinCoins(int[] coins, int amount)
    {
        Array.Sort(coins, (a, b) => b.CompareTo(a));  // Sort coins in descending order
        int count = 0;

        for (int i = 0; i < coins.Length; i++)
        {
            while (amount >= coins[i])
            {
                amount -= coins[i];
                count++;
            }
        }

        return count;
    }

    public static void Main()
    {
        int[] coins = { 1, 2, 5, 10, 20, 50 };
        int amount = 93;
        int result = MinCoins(coins, amount);
        Console.WriteLine($"Minimum coins needed: {result}");
    }
}