using System;

public class Kata
{
    public static int[] MoveZeroes(int[] arr)
    {
        int i = 0;
        int[] answer = new int[arr.Length];

        foreach (int num in arr)
        {
            if (num != 0)
                answer[i++] = num;
        }

        return answer;
    }
}

public class Program
{
    public static void Main()
    {}
}