using System;

public class MatrixOperations
{
    public static int Determinant2x2(int[,] A)
    {
        return A[0, 0] * A[1, 1] - A[0, 1] * A[1, 0];
    }

    public static void Main()
    {
        int[,] A = { { 1, 2 }, { 3, 4 } };
        int det = Determinant2x2(A);

        Console.WriteLine($"Determinant of the matrix: {det}");
    }
}
