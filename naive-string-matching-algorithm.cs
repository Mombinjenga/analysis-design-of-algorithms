using System;

public class NaiveStringMatcher
{
    public static void NaiveSearch(string text, string pattern)
    {
        int n = text.Length;
        int m = pattern.Length;

        for (int i = 0; i <= n - m; i++)
        {
            int j;
            for (j = 0; j < m; j++)
            {
                if (text[i + j] != pattern[j])
                    break;
            }
            if (j == m)
            {
                Console.WriteLine("Pattern found at index " + i);
            }
        }
    }

    public static void Main()
    {
        string text = "ABABDABACDABABCABAB";
        string pattern = "ABABCABAB";
        NaiveSearch(text, pattern);
    }
}
