using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datastructures
{
    public static class ManacherLargestPalindromicSubString
    {
        public static int LargestPalindromicSubstring(string input)
        {
            //preprocess the string to insert # characters
            StringBuilder T = new StringBuilder();
            T.Append('^');
            for (int i = 0; i < input.Length; i++)
            {
                T.Append('#' + input[i].ToString());
            }
            T.Append("#$");
            var P = new int[T.Length];
            int C = 0, R = 0, leftMirrorIndex = 0, maxLength = 1;
            for (int i = 1; i < T.Length - 1; i++)
            {
                //get the index of the left mirror of i in palindrome centered at C
                leftMirrorIndex = 2 * C - i;
                //if next prospective candidate extends right margin of current palindrome centered at C, then take the minimum
                if (i < R)
                {
                    P[i] = Math.Min(R - i, P[leftMirrorIndex]);
                }
                if (R >= T.Length - 1)
                {
                    break;
                }
                // expand from the current size of the palindrome centered at i and see if you can extend beyond it
                while (((i + P[i]) < T.Length -1 && (i - P[i]) > 0) && (T[i - (1 + P[i])] == T[i + (1 + P[i])]))
                {
                    P[i]++;
                }
                maxLength = Math.Max(maxLength, P[i]);
                //if the size of the prospective palindrome at index i extends right margin of current palindrome centered at C, then new Center should be at I as it is greater.
                if (i + P[i] > R)
                {
                    C = i;
                    R = i + P[i];
                }
            }
            return maxLength;
        }
    }
}
