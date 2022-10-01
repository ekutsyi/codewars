using System;
using System.Linq;
using System.Text.RegularExpressions;

public class Kata
{
    public static string FirstNonRepeatingLetter(string s)
    {
        foreach (char c in s)
        {
            int freq = 0;
            if (Char.IsLetter(c))
                freq = Regex.Matches(s, c.ToString(), RegexOptions.IgnoreCase).Count;
            else
                freq = s.Count(f => (f == c));
            if (freq == 1)
                return s.Substring(s.IndexOf(c), 1);
        }
        return "";
    }
}

class Program
{
    public static void Main()
    {
        Console.WriteLine(Kata.FirstNonRepeatingLetter("ssssSS"));
    }
}
