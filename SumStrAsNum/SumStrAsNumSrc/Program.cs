using System;
public static class Kata
{
    public static Tuple<string, bool> equalStr(int length, string a, string b)
    {
        string answer = "";
        bool rmndr = false;
        for (int i = length - 1; i > -1; --i)
        {
            double x = Char.GetNumericValue(a[i]) + Char.GetNumericValue(b[i]);
            if (rmndr)
                x += 1;
            if (x >= 10)
            {
                x %= 10;
                rmndr = true;
            }
            else
            {
                rmndr = false;
            }
            answer = answer.Insert(0, x.ToString());
        }
        return Tuple.Create(answer, rmndr);
    }

    public static string notEqual(string a, string b, int bLength, int aLength)
    {
        bLength -= aLength;
        var tpl = equalStr(a.Length, a, b.Substring(bLength));
        string answer = tpl.Item1;
        bool rmndr = tpl.Item2;
        bLength -= 1;
        while (bLength != -1)
        {
            double x = Char.GetNumericValue(b[bLength]);
            if (rmndr)
                x += 1;
            if (x >= 10)
            {
                x %= 10;
                rmndr = true;
            }
            else
                rmndr = false;
            answer = answer.Insert(0, x.ToString());
            --bLength;
        }
        if (rmndr)
            answer = answer.Insert(0, 1.ToString());
        return answer;
    }

    public static string positiveNums(string a, string b)
    {
        int aLength = a.Length;
        int bLength = b.Length;
        if (aLength == bLength)
        {
            var tpl = equalStr(a.Length, a, b);
            string answer = tpl.Item1;
            if (tpl.Item2)
                answer = answer.Insert(0, 1.ToString());
            return answer;
        }
        else if (bLength > aLength)
        {
            return notEqual(a, b, bLength, aLength);
        }
        else if (aLength > bLength)
        {
            return notEqual(b, a, aLength, bLength);
        }
        return "";
    }
    public static string sumStrings(string a, string b)
    {
        //int result = Int64.Parse(a) + Int32.Parse(b);
        //return result.ToString();

        // all this one solution works only for positive values
        //BigInteger
        if (a[0] != '-' && b[0] != '-')
        {
            return positiveNums(a, b);
        }
        else if (a[0] == '-' && b[0] == '-')
        {
            a = a.Remove(0, 1);
            b = b.Remove(0, 1);
            string answer = positiveNums(a, b);
            answer = answer.Insert(0, '-'.ToString());
            return answer;
        }
        return "";

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
