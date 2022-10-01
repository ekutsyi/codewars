using System;
public static class Kata
{
    public static Tuple<string, bool> equalStrAdd(int length, string a, string b)
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

    public static string notEqualSameSign(string a, string b, int bLength, int aLength)
    {
        bLength -= aLength;
        var tpl = equalStrAdd(a.Length, a, b.Substring(bLength));
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
    public static string sameSigns(string a, string b)
    {
        int aLength = a.Length;
        int bLength = b.Length;
        if (aLength == bLength)
        {
            var tpl = equalStrAdd(a.Length, a, b);
            string answer = tpl.Item1;
            if (tpl.Item2)
                answer = answer.Insert(0, 1.ToString());
            return answer;
        }
        else if (bLength > aLength)
        {
            return notEqualSameSign(a, b, bLength, aLength);
        }
        else if (aLength > bLength)
        {
            return notEqualSameSign(b, a, aLength, bLength);
        }
        return "";
    }

    public static string sumStrings(string a, string b)
    {
        if (a[0] != '-' && b[0] != '-')
        {
            return sameSigns(a, b);
        }
        else if (a[0] == '-' && b[0] == '-')
        {
            a = a.Remove(0, 1);
            b = b.Remove(0, 1);
            string answer = sameSigns(a, b);
            answer = answer.Insert(0, '-'.ToString());
            return answer;
        }
        else if (a[0] == '-')
        {
            
        }
        else if (b[0] == '-')
        {
            
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
        Console.WriteLine(Kata.sumStrings("-999", "19"));
        Console.WriteLine(Kata.sumStrings("133", "-13"));
        Console.WriteLine(Kata.sumStrings("-32", "12"));
    }
}
