// See https://aka.ms/new-console-template for more information
using System;

namespace RomanNumerals
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Input First Roman Numeral: ");
            string numeralOne = Console.ReadLine();

            Console.Write("Input Second Roman Numeral: ");
            string numeralTwo = Console.ReadLine();

            string sum = numeralSum(numeralOne, numeralTwo); //assuming not null

            Console.WriteLine("= " + sum);
        }

        public static string numeralSum(string one, string two)
        {
            string sum;
            int numeralAsIntOne = RomanToInt(one);
            int numeralAsIntTwo = RomanToInt(two);

            sum = ToRoman(numeralAsIntOne + numeralAsIntTwo);
            return sum;
        }

        public static string ToRoman(int number) //little recursive ToRoman function i stole from stackoverflow lol
        {
            if ((number < 0) || (number > 3999)) throw new ArgumentOutOfRangeException(nameof(number), "insert value between 1 and 3999");
            if (number < 1) return string.Empty;
            if (number >= 1000) return "M" + ToRoman(number - 1000);
            if (number >= 900) return "CM" + ToRoman(number - 900);
            if (number >= 500) return "D" + ToRoman(number - 500);
            if (number >= 400) return "CD" + ToRoman(number - 400);
            if (number >= 100) return "C" + ToRoman(number - 100);
            if (number >= 90) return "XC" + ToRoman(number - 90);
            if (number >= 50) return "L" + ToRoman(number - 50);
            if (number >= 40) return "XL" + ToRoman(number - 40);
            if (number >= 10) return "X" + ToRoman(number - 10);
            if (number >= 9) return "IX" + ToRoman(number - 9);
            if (number >= 5) return "V" + ToRoman(number - 5);
            if (number >= 4) return "IV" + ToRoman(number - 4);
            if (number >= 1) return "I" + ToRoman(number - 1);
            throw new Exception("Impossible state reached");
        }

        public static int RomanToInt(string s)
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
            for (int i = 0; i < s.Length; i++)
            {
                char currentRomanChar = s[i];
                romanNumbersDictionary.TryGetValue(currentRomanChar, out int num);
                if (i + 1 < s.Length && romanNumbersDictionary[s[i + 1]] > romanNumbersDictionary[currentRomanChar])
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
        //Create a function which takes in two Roman numerals as strings, and outputs the sum as a Roman numeral.
        //plan
        //convert to numbers, add them, then convert it back to numerals and print?
        //yea that could work
        // I = 1
        // V = 5
        // X = 10
        // L = 50
        // C = 100
        // D = 500
        // M = 1000

        // to convert it back you can just use the ROMAN function lel
    }
}
