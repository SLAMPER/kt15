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