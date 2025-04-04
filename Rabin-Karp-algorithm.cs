using System;

public class RabinKarpStringMatcher
{
    public static void RabinKarpSearch(string text, string pattern, int prime)
    {
        int n = text.Length;
        int m = pattern.Length;
        int i, j;
        int p = 0; // hash value for pattern
        int t = 0; // hash value for text
        int h = 1;

        for (i = 0; i < m - 1; i++)
            h = (h * 256) % prime;

        for (i = 0; i < m; i++)
        {
            p = (256 * p + pattern[i]) % prime;
            t = (256 * t + text[i]) % prime;
        }

        for (i = 0; i <= n - m; i++)
        {
            if (p == t)
            {
                for (j = 0; j < m; j++)
                {
                    if (text[i + j] != pattern[j])
                        break;
                }
                if (j == m)
                    Console.WriteLine("Pattern found at index " + i);
            }

            if (i < n - m)
            {
                t = (256 * (t - text[i] * h) + text[i + m]) % prime;
                if (t < 0)
                    t = (t + prime);
            }
        }
    }

    public static void Main()
    {
        string text = "ABABDABACDABABCABAB";
        string pattern = "ABABCABAB";
        int prime = 101; // A prime number
        RabinKarpSearch(text, pattern, prime);
    }
}
