using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.Contests
{
    public class ConvertingAnagrams
    {
        public void Solve() {
            var t = int.Parse(Console.ReadLine().Trim());
            StringBuilder output = new StringBuilder();
            while (t-- > 0)
            {
                var str = Console.ReadLine().Trim().Split(' ').ToArray();
                output.AppendLine(Anagram(str[0], str[1]).ToString());
            }
            Console.Write(output);
        }

        private int Anagram(string A, string B)
        {
            int[] cntA = new int[26];
            int[] cntB = new int[26];
            for (int i = 0; i < A.Length; i++) {
                cntA[A[i] - 'a']++;
            }
            for (int i = 0; i < B.Length; i++)
            {
                cntB[B[i] - 'a']++;
            }
            int count = 0;
            for (int i = 0; i < 26; i++) {
                count += Math.Abs(cntA[i] - cntB[i]);
            }
            return count;
        }
    }
}
