using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.DynamicProgramming
{
    public class ArrangingDominos : ISolution
    {
        static long[] dp = new long[(int)1e6 + 1];
        static int modulo = (int)1e9 + 7;
        public override void Solve()
        {
            PreCompute();
            var t = ReadInt();
            while (t-- > 0)
            {
                output.AppendLine(dp[ReadInt()].ToString());
            }
            Console.Write(output);
        }

        private void PreCompute()
        {
            dp[1] = 1;
            dp[2] = 2;
            dp[3] = 3;
            dp[4] = 5;
            dp[5] = 16;// 8 for horizontal + 8 for vertical

            for (int i = 6; i < dp.Length; i++)
            {
                dp[i] = (dp[i - 1] + dp[i - 2] + dp[i - 5] * 8) % modulo;
            }
        }
    }
}
