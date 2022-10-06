using System;
using System.Collections.Generic;
using System.Text;

public class Permutations
{
    private static void permute(List<string> list, StringBuilder stringBuilder,
                                int l, int r)
    {
        if (l == r)
            list.Add(stringBuilder.ToString());
        else
        {
            
            for (int i = l; i <= r; i++)
            {
                (stringBuilder[l], stringBuilder[i]) = (stringBuilder[i], stringBuilder[l]);
                permute(list, stringBuilder, l + 1, r);
                (stringBuilder[l], stringBuilder[i]) = (stringBuilder[i], stringBuilder[l]);
            }
        }
    }
    public static List<string> SinglePermutations(string s)
    {
        List<string> list = new List<string>();
        int n = s.Length;
        StringBuilder stringBuilder = new StringBuilder(s);
        permute(list, stringBuilder, 0, n - 1);
        list = list.Distinct().ToList();
        return list;
    }
}
public class Program
{
    public static void Main()
    {

    }

}