using System;
using System.Collections.Generic;

class SimpleMatrix
{
    private double[,] data;

    public SimpleMatrix(int rows, int cols)
    {
        data = new double[rows, cols];

        double value = 1;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                data[i, j] = value++;
            }
        }
    }

    public IEnumerable<double> GetRow(int rowIndex)
    {
        for (int j = 0; j < data.GetLength(1); j++)
        {
            yield return data[rowIndex, j];
        }
    }

    public IEnumerable<double> GetColumn(int colIndex)
    {
        for (int i = 0; i < data.GetLength(0); i++)
        {
            yield return data[i, colIndex];
        }
    }
}

class Program
{
    static void Main()
    {
        SimpleMatrix matrix = new SimpleMatrix(2, 3);

        Console.WriteLine("строки");
        for (int i = 0; i < 2; i++)
        {
            Console.Write($"строка {i}: ");
            foreach (var element in matrix.GetRow(i))
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("\nстолбцы ");
        for (int j = 0; j < 3; j++)
        {
            Console.Write($"столбец {j}: ");
            foreach (var element in matrix.GetColumn(j))
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }
    }
}
