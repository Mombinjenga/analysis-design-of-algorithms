using System;

public class MatrixOperations
{
    public static int[,] TransposeMatrix(int[,] A)
    {
        int rows = A.GetLength(0);
        int columns = A.GetLength(1);
        int[,] transpose = new int[columns, rows];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                transpose[j, i] = A[i, j];
            }
        }

        return transpose;
    }

    public static void Main()
    {
        int[,] A = { { 1, 2 }, { 3, 4 }, { 5, 6 } };
        int[,] transpose = TransposeMatrix(A);

        Console.WriteLine("Transpose of the matrix:");
        for (int i = 0; i < transpose.GetLength(0); i++)
        {
            for (int j = 0; j < transpose.GetLength(1); j++)
            {
                Console.Write(transpose[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
