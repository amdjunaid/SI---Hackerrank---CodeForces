using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6._6b
{
    public class IsSubsequence : ISolution
    {
        public override void Solve()
        {
            short t = ReadShort();
            while (t-- > 0)
            {
                string[] AandB = ReadArrString();
                output.AppendLine(IsASubsequence(AandB[0], AandB[1]) ? "Yes" : "No");
            }
            Console.Write(output);
        }

        private bool IsASubsequence(string A, string B)
        {
            if (A.Length > B.Length)
                return false;
            else if (A.Length == B.Length)
            {
                return A == B ? true : false;
            }
            int p1 = 0, p2 = 0;
            while (p1 < A.Length && p2 < B.Length) {
                if (A[p1] == B[p2])
                {
                    p1++;
                }
                p2++;
            }
            return p1 == A.Length ? true : false;
        }
    }
}
