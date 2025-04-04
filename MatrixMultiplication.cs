using System;

public class MatrixOperations
{
    public static int[,] MultiplyMatrices(int[,] A, int[,] B)
    {
        int rowsA = A.GetLength(0);
        int columnsA = A.GetLength(1);
        int columnsB = B.GetLength(1);
        int[,] C = new int[rowsA, columnsB];

        for (int i = 0; i < rowsA; i++)
        {
            for (int j = 0; j < columnsB; j++)
            {
                C[i, j] = 0;
                for (int k = 0; k < columnsA; k++)
                {
                    C[i, j] += A[i, k] * B[k, j];
                }
            }
        }

        return C;
    }

    public static void Main()
    {
        int[,] A = { { 1, 2 }, { 3, 4 } };
        int[,] B = { { 5, 6 }, { 7, 8 } };
        int[,] C = MultiplyMatrices(A, B);

        Console.WriteLine("Product of matrices:");
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
