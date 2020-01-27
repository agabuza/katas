// https://www.codewars.com/kata/58c5577d61aefcf3ff000081
// Create two functions to encode and then decode a string using the Rail Fence Cipher.This cipher is used to encode a string by placing each character successively in a diagonal along a set of "rails". First start off moving diagonally and down.When you reach the bottom, reverse direction and move diagonally and up until you reach the top rail.Continue until you reach the end of the string. Each "rail" is then read left to right to derive the encoded string.

// For example, the string "WEAREDISCOVEREDFLEEATONCE" could be represented in a three rail system as follows: 
// W E       C R       L T       E
// E   R D   S O   E E   F E   A O   C
// A       I V       D E       N
// The encoded string would be:   
// WECRLTEERDSOEEFEAOCAIVDEN
// Write a function/method that takes 2 arguments, a string and the number of rails, and returns the ENCODED string.
// Write a second function/method that takes 2 arguments, an encoded string and the number of rails, and returns the DECODED string.
// For both encoding and decoding, assume number of rails >= 2 and that passing an empty string will return an empty string.
// Note that the example above excludes the punctuation and spaces just for simplicity.There are, however, tests that include punctuation.Don't filter out punctuation as they are a part of the string.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace katas.RailFenceCipher
{
    public static class RailFenceCipher
    {
        internal static string Encode(string s, int n)
        {
            var dict = new Dictionary<double, List<char>>();

            double A = ((double)n - 1) / 2;
            double B = (n - 1) * 2;
            double C = n % 2 == 0 ? 1.5 : 1; // shift +0.5 to match "middle" with number in case of odd N
            double D = A;                    // we put our graph on x-axis

            for (int i = 0; i < s.Length; i++)
            {
                var rIndex = Math.Round(A * Math.Sin(2 * Math.PI / B * (i - C)) + D);
                if (!dict.ContainsKey(rIndex))
                {
                    dict[rIndex] = new List<char>();
                }

                dict[rIndex].Add(s[i]);
            }

            return new string(dict.OrderBy(x => x.Key).SelectMany(x => x.Value).ToArray());
        }

        internal static string Decode(string s, int n)
        {
            var dict = new Dictionary<double, List<char>>();

            double A = ((double)n - 1) / 2;
            double B = (n - 1) * 2;
            double C = n % 2 == 0 ? 1.5 : 1; // shift +0.5 to match "middle" with number in case of odd N
            double D = A;                    // we put our graph on x-axis

            for (int i = 0; i < n; i++)
            {
                var originalIndex = Math.Round(B * Math.Asin(( - D) / A) / (2 * Math.PI) + 2 * Math.PI * C);
                if (!dict.ContainsKey(originalIndex))
                {
                    dict[originalIndex] = new List<char>();
                }

                dict[originalIndex].Add(s[i]);
            }

            return new string(dict.OrderBy(x => x.Key).SelectMany(x => x.Value).ToArray());
        }
    }
}
