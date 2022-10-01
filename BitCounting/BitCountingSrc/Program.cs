using System;

public class Kata
{
    public static int CountBits(int n)
    {
        int i = 0;
        while (n != 0)
        {
            int bin = n % 2;
            if (bin == 1)
                i += 1;
            n /= 2;
        }
        return i;
    }
}

class Program
{
    public static void Main()
    {
        Console.WriteLine(Kata.CountBits(11));
    }
}
