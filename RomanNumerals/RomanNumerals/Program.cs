using System;

public class RomanNumerals
{
    public static string ToRoman(int num)
    {
        string romanResult = string.Empty;
        string[] romanLetters = {
        "M",
        "CM",
        "D",
        "CD",
        "C",
        "XC",
        "L",
        "XL",
        "X",
        "IX",
        "V",
        "IV",
        "I"
    };
        int[] numbers = {
        1000,
        900,
        500,
        400,
        100,
        90,
        50,
        40,
        10,
        9,
        5,
        4,
        1
    };
        int i = 0;
        while (num != 0)
        {
            if (num >= numbers[i])
            {
                num -= numbers[i];
                romanResult += romanLetters[i];
            }
            else
            {
                i++;
            }
        }
        return romanResult;
    }

    public static int FromRoman(string romanNumeral)
    {
        int sum = 0;
        Dictionary<char, int> romanNumbersDictionary = new()
         {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };
        for (int i = 0; i < romanNumeral.Length; i++)
        {
            char currentRomanChar = romanNumeral[i];
            romanNumbersDictionary.TryGetValue(currentRomanChar, out int num);
            if (i + 1 < romanNumeral.Length && romanNumbersDictionary[romanNumeral[i + 1]] > romanNumbersDictionary[currentRomanChar])
            {
                sum -= num;
            }
            else
            {
                sum += num;
            }
        }
        return sum;
    }
}

class Program
{
    public static void Main()
    {}
}
