using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.DynamicProgramming
{
    public class ComputeNCR : ISolution
    {
        int[,] dp = new int[1001, 1001];
        static int modulo = (int)1e9 + 7;
        public override void Solve()
        {
            NCRIs(1001, 1001);
            int t = ReadInt();
            while (t-- > 0)
            {
                var NandR = ReadArrString().Select(short.Parse).ToArray();
                output.AppendLine(dp[NandR[0], NandR[1]].ToString());
            }
            Console.Write(output);
        }

        private void NCRIs(short n, short r)
        {
            for (int i = 0; i < n; i++)
            {
                dp[i, 0] = 1;
            }
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < r; j++)
                {
                    dp[i, j] = (dp[i - 1, j - 1] + dp[i - 1, j]) % modulo;
                }
            }
        }
    }
}
