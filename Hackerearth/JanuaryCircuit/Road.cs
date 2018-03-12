using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackerearth.JanuaryCircuit
{
    public class Road : ISolution
    {
        public static int[,] dp = null;
        public override void Solve()
        {
            var NandK = ReadArrString().Select(int.Parse).ToArray();
            var points = ReadArrString().Select(byte.Parse).ToArray();
            dp = new int[NandK[0], NandK[1] + 1];
            for (int i = 0; i < NandK[0]; i++)
            {
                for (int j = 0; j < NandK[1] + 1; j++)
                {
                    dp[i, j] = -1;
                }
            }
            Console.Write(MaxReach(points, 0, NandK[1], NandK[1], NandK[0]).ToString());
        }

        private int MaxReach(byte[] points, int i, int remainingTime, int K, int N)
        {
            int max = 0;
            if (dp[i, remainingTime] == -1)
            {
                for (int j = i + 1; j < N; j++)
                {
                    if ((Math.Abs(points[i] - points[j]) <= K) && (remainingTime - Math.Abs(points[i] - points[j]) >= 0))
                    {
                        Math.Max(max, MaxReach(points, j, remainingTime - Math.Abs(points[i] - points[j]), K, N));
                    }
                }
                dp[i, remainingTime] = 1 + max;
            }
            return dp[i, remainingTime];
        }
    }
}
