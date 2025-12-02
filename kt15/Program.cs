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