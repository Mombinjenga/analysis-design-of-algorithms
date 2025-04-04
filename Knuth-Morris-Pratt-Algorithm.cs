using System;

public class KMPStringMatcher
{
    public static void KMPSearch(string text, string pattern)
    {
        int n = text.Length;
        int m = pattern.Length;
        int[] lps = new int[m];

        ComputeLPSArray(pattern, m, lps);

        int i = 0;
        int j = 0;
        while (i < n)
        {
            if (pattern[j] == text[i])
            {
                j++;
                i++;
            }
            if (j == m)
            {
                Console.WriteLine("Pattern found at index " + (i - j));
                j = lps[j - 1];
            }
            else if (i < n && pattern[j] != text[i])
            {
                if (j != 0)
                    j = lps[j - 1];
                else
                    i++;
            }
        }
    }

    private static void ComputeLPSArray(string pattern, int m, int[] lps)
    {
        int length = 0;
        int i = 1;
        lps[0] = 0;

        while (i < m)
        {
            if (pattern[i] == pattern[length])
            {
                length++;
                lps[i] = length;
                i++;
            }
            else
            {
                if (length != 0)
                {
                    length = lps[length - 1];
                }
                else
                {
                    lps[i] = 0;
                    i++;
                }
            }
        }
    }

    public static void Main()
    {
        string text = "ABABDABACDABABCABAB";
        string pattern = "ABABCABAB";
        KMPSearch(text, pattern);
    }
}
