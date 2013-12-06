using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathProgramming
{
    class matrix
    {
        public static void print(double[,] matrix)
        {
            double[,] m;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    System.Console.Write(matrix[i, j] + "\t");
                System.Console.WriteLine();
            }

        }

        public static double Det(double[,] Matrix)
        {
            return Det(Matrix, Math.Min(Matrix.GetLength(0), Matrix.GetLength(1)));
        }

        private static double Det(double[,] Matrix, int squareSize)
        {
            double determinant = 0;
            int mark;
            double[,] tempMatrix = new double[Matrix.GetLength(0), Matrix.GetLength(1)];

            if (squareSize == 2)
                determinant = Matrix[0, 0] * Matrix[1, 1] - Matrix[0, 1] * Matrix[1, 0];
            else
            {
                determinant = 0;
                for (int k = 0; k < squareSize; k++)
                {
                    for (int i = 1; i < squareSize; i++)
                    {
                        mark = 0;
                        for (int j = 0; j < squareSize; j++)
                        {
                            if (j == k)
                                continue;
                            tempMatrix[i - 1, mark] = Matrix[i, j];
                            mark++;
                        }

                    }
                    determinant += Math.Pow(-1.0, k) * Matrix[0, k] * Det(tempMatrix, squareSize - 1);
                }
            }

            return determinant;
        }

        public static int Rank(double[,] Matrix)
        {
            if (Matrix.GetLength(0) <= Matrix.GetLength(1))
            {
                for (int s = Matrix.GetLength(0); s > 0; s--)
                {
                    for (int i = 0; i <= Matrix.GetLength(0) - s; i++)
                        for (int j = 0; j <= Matrix.GetLength(1) - s; j++)
                        {
                            double[,] t = subMatrix(Matrix, j, i, s, s);
                            double d = Det(t);
                            if (d != 0)
                                return s;
                        }
                }
            }
            else
            {
                for (int s = Matrix.GetLength(1); s > 0; s--)
                {
                    for (int i = 0; i <= Matrix.GetLength(0) - s; i++)
                        for (int j = 0; j <= Matrix.GetLength(1) - s; j++)
                        {
                            double[,] t = subMatrix(Matrix, j, i, s, s);
                            double d = Det(t);
                            if (d != 0)
                                return s;
                        }
                }
            }

            return -1;
        }

        public static double[,] subMatrix(double[,] matrix, int x, int y, int l, int w)
        {
            double[,] m = new double[w, l];
            for (int i = 0; i < w; i++)
                for (int j = 0; j < l; j++)
                    m[i, j] = matrix[i + y, j + x];
            return m;
        }

        public static double[,] jordan(double[,] a, int k, int s)
        {
            double[,] d = new double[a.GetLength(0), a.GetLength(1)];

            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    d[i, j] = bij(a[k, s], a[i, j], a[i, s], a[k, j]);
                }
            }

            for (int i = 0; i < a.GetLength(1); i++)
                d[k, i] = a[k, i] / a[k, s];

            for (int i = 0; i < a.GetLength(0); i++)
                d[i, s] = -a[i, s] / a[k, s];

            d[k, s] = 1 / a[k, s];

            return d;
        }

        private static double bij(double aks, double aij, double ais, double akj)
        {
            return (aij * aks - ais * akj) / aks;
        }

        public static double[,] removeColumn(double[,] matrix, int col)
        {
            double[,] tmp = new double[matrix.GetLength(0), matrix.GetLength(1) - 1];
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    int k = j < col ? j : j + 1;
                    tmp[i, j] = matrix[i, k];
                }
            return tmp;
        }

        public static void printMatrix(int[,] a) 
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                Console.WriteLine("\t");
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write(a[i, j] + " ");
                }
            }
        }
    }
}
