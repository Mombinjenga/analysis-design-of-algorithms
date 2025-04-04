using System;

public class MatrixOperations
{
    public static int[,] AddMatrices(int[,] A, int[,] B)
    {
        int rows = A.GetLength(0);
        int columns = A.GetLength(1);
        int[,] C = new int[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                C[i, j] = A[i, j] + B[i, j];
            }
        }

        return C;
    }

    public static void Main()
    {
        int[,] A = { { 1, 2 }, { 3, 4 } };
        int[,] B = { { 5, 6 }, { 7, 8 } };
        int[,] C = AddMatrices(A, B);

        Console.WriteLine("Sum of matrices:");
        for (int i = 0; i < C.GetLength(0); i++)
        {
            for (int j = 0; j < C.GetLength(1); j++)
            {
                Console.Write(C[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
