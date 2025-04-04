using System;

public class MatrixOperations
{
    public static double[,] Inverse2x2(int[,] A)
    {
        int det = A[0, 0] * A[1, 1] - A[0, 1] * A[1, 0];
        if (det == 0)
        {
            throw new InvalidOperationException("Matrix is not invertible.");
        }

        double invDet = 1.0 / det;
        double[,] inverse = new double[2, 2];
        inverse[0, 0] = A[1, 1] * invDet;
        inverse[0, 1] = -A[0, 1] * invDet;
        inverse[1, 0] = -A[1, 0] * invDet;
        inverse[1, 1] = A[0, 0] * invDet;

        return inverse;
    }

    public static void Main()
    {
        int[,] A = { { 1, 2 }, { 3, 4 } };
        double[,] inverse = Inverse2x2(A);

        Console.WriteLine("Inverse of the matrix:");
        for (int i = 0; i < inverse.GetLength(0); i++)
        {
            for (int j = 0; j < inverse.GetLength(1); j++)
            {
                Console.Write(inverse[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}