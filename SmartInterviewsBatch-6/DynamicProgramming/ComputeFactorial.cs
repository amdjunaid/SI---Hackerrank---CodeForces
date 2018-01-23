using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.DynamicProgramming
{
    public class ComputeFactorial : ISolution
    {
        static int N = (int)(1e6 + 1);
        static int modulo = (int)(1e9 + 7);
        static long[] factorial = new long[N];
        public override void Solve()
        {
            factorial[0] = 1;
            for (int i = 1; i < factorial.Length; i++)
            {
                factorial[i] = (i * factorial[i - 1]) % modulo;
            }
            int t = ReadInt();
            while (t-- > 0) {
                output.AppendLine(factorial[ReadInt()].ToString());
            }
            Console.Write(output);
        }
    }
}
