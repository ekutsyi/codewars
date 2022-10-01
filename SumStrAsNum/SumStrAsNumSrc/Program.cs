using System;
using System.Numerics;

public class Kata
{
    public static string sumStrings(string a, string b)
    {
        if (String.IsNullOrEmpty(a))
        {
            BigInteger onlyB = BigInteger.Parse(b);
            return onlyB.ToString();
        } else if (String.IsNullOrEmpty(b))
        {
            BigInteger onlyA = BigInteger.Parse(a);
            return onlyA.ToString();
        }

        BigInteger result = BigInteger.Parse(a) + BigInteger.Parse(b);
        return result.ToString();
    }
}

class Program
{
    public static void Main()
    {
        Console.WriteLine(Kata.sumStrings("1212234563767373376736736733", "1212234563767373376736736733"));
        Console.WriteLine(Kata.sumStrings("999", "211"));
        Console.WriteLine(Kata.sumStrings("13", "999"));
        Console.WriteLine(Kata.sumStrings("-99", "-9"));
    }
}
