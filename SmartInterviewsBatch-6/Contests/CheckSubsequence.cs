using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.Contests
{
    public class CheckSubsequence
    {
        public void Solve()
        {
            var t = int.Parse(Console.ReadLine().Trim());
            StringBuilder output = new StringBuilder();
            while (t-- > 0) {
                var str = Console.ReadLine().Trim().Split(' ').ToArray();
                output.AppendLine(IsSubsequence(str[0], str[1]).ToString());
            }
            Console.Write(output);
        }

        private bool IsSubsequence(string A, string B)
        {
            int j = 0, i = 0;
            for (; i < A.Length; ) {
                while (j < B.Length) {
                    if (A[i] == B[j]) {
                        i++;
                        break;
                    }
                    j++;
                }
                if (j >= B.Length) {
                    break;
                }
            }
            if (i < A.Length && j >= B.Length) {
                return false;
            }
            return true;
        }
    }
}
