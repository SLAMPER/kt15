/*

using System;
using System.Collections.Generic;

namespace kt15
{
    class Program
    {
        static IEnumerable<int> GetFibonacciSequence(int count)
        {
            int a = 0;
            int b = 1;

            for (int i = 0; i < count; i++)
            {
                yield return a;

                int next = a + b;
                a = b;
                b = next;
            }
        }

        static void Main()
        {
            foreach (int number in GetFibonacciSequence(15))
            {
                Console.WriteLine(number);
            }
        }
    }
}

*/

/*

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

*/

using System;
using System.Collections;
using System.Collections.Generic;

class PrimeEnumerator : IEnumerator<int>
{
    private int current = 1;

    public int Current => current;
    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
        int next = current + 1;
        while (!IsPrime(next))
        {
            next++;
        }
        current = next;
        return true;
    }

    public void Reset()
    {
        current = 1;
    }

    public void Dispose() { }

    private bool IsPrime(int num)
    {
        if (num < 2) return false;
        if (num == 2) return true;
        if (num % 2 == 0) return false;

        for (int i = 3; i * i <= num; i += 2)
        {
            if (num % i == 0) return false;
        }
        return true;
    }
}

class Program
{
    static void Main()
    {
        PrimeEnumerator primeEnumerator = new PrimeEnumerator();
        int count = 0;

        while (count < 15)
        {
            primeEnumerator.MoveNext();
            Console.WriteLine($"prostoe num {count + 1}: {primeEnumerator.Current}");
            count++;
        }

        primeEnumerator.Dispose();
    }
}