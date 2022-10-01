using System;
public static class Kata
{
    public static Tuple<bool, int, int> ifBiggerA(int length, string a, string b)
    {
        //a negative, b positive
        int similarity = 0;
        for (int i = 0; i < length; i++)
        {
            if (Char.GetNumericValue(a[i]) > Char.GetNumericValue(b[i]))
                return Tuple.Create(true, 1, similarity);
            else if (Char.GetNumericValue(a[i]) < Char.GetNumericValue(b[i]))
                return Tuple.Create(false, 1, similarity);
            else if (Char.GetNumericValue(a[i]) == Char.GetNumericValue(b[i]))
                similarity += 1;
        }

        return Tuple.Create(false, 0, similarity);
    }

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

    public static string equalStrSub(int length, string a, string b)
    {
        //a negative, b positive
        var decision = ifBiggerA(length, a, b);
        if (decision.Item2 == 0)
            return "0";
        if (!decision.Item1)
        {
            string tmp = b;
            b = a;
            a = tmp;
        }
        string answer = "";
        bool flag = false;
        for (int i = length - 1; i > decision.Item3; --i)
        {
            double xA = Char.GetNumericValue(a[i]);
            if (flag)
                xA -= 1;
            double xB = Char.GetNumericValue(b[i]);
            double x = xA - xB;
            if (x < 0)
            {
                x += 10;
                flag = true;
            }
            answer = answer.Insert(0, x.ToString());
        }

        if (Char.GetNumericValue(a[decision.Item3]) != Char.GetNumericValue(b[decision.Item3]))
        {
            double x = Char.GetNumericValue(a[decision.Item3]) - Char.GetNumericValue(b[decision.Item3]);
            if (flag)
                x -= 1;
            if (x != 0)
                answer = answer.Insert(0, x.ToString());
        }

        if (decision.Item1)
            answer = answer.Insert(0, '-'.ToString());

        return answer;
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

    public static string notEqualDiffSigns(string a, string b, int lengthA, int lengthB)
    {
        //a longer, b shorter
        string answer = "";
        bool flag = false;
        int i = lengthA - 1;
        for (int q = lengthB - 1; q > -1; --q, --i)
        {
            double xA = Char.GetNumericValue(a[i]);
            if (flag)
                xA -= 1;
            double xB = Char.GetNumericValue(b[q]);
            double x = xA - xB;
            if (x < 0)
            {
                x += 10;
                flag = true;
            }
            answer = answer.Insert(0, x.ToString());
        }

        for (; i > -1; --i)
            answer = answer.Insert(0, Char.GetNumericValue(a[i]).ToString());

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

    public static string diffSigns(string a, string b)
    {
        //a negative, b positive
        int lengthA = a.Length;
        int lengthB = b.Length;

        if (lengthA == lengthB)
            return equalStrSub(lengthB, a, b);
        else if (lengthA > lengthB)
        {
            string answer = notEqualDiffSigns(a, b, lengthA, lengthB);
            answer = answer.Insert(0, '-'.ToString());

            return answer;
        }
        else if (lengthB > lengthA)
            return notEqualDiffSigns(b, a, lengthB, lengthA);
        return "";
    }

    public static string sumStrings(string a, string b)
    {
        if (String.IsNullOrEmpty(a))
            return b;
        else if (String.IsNullOrEmpty(b))
            return a;

        if (a[0] != '-' && b[0] != '-')
        {
            //very brute
            string answer = sameSigns(a, b);
            if (answer[0] == '0')
                return answer.Substring(1);
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
            a = a.Remove(0, 1);
            return diffSigns(a, b);
        }
        else if (b[0] == '-')
        {
            b = b.Remove(0, 1);
            return diffSigns(b, a);
        }
        return "";
    }
}

class Program
{
    public static void Main()
    {
        Console.WriteLine(Kata.sumStrings("1212234563767373376736736753", "-1212234563767373376736736733"));
        Console.WriteLine(Kata.sumStrings("999", "211"));
        Console.WriteLine(Kata.sumStrings("13", "999"));
        Console.WriteLine(Kata.sumStrings("-99", "-9"));
        Console.WriteLine(Kata.sumStrings("-999", "19"));
        Console.WriteLine(Kata.sumStrings("133", "-13"));
        Console.WriteLine(Kata.sumStrings("-32", "12"));
        Console.WriteLine(Kata.sumStrings("-9872", "9853"));
        Console.WriteLine(Kata.sumStrings("872", "-853"));
        Console.WriteLine(Kata.sumStrings("12", "-12"));
        Console.WriteLine(Kata.sumStrings("-12", "12"));
        Console.WriteLine(Kata.sumStrings("-11112", "11111"));
    }
}
