using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SmartInterviewsBatch_6.DynamicProgramming
{
    public class ArrangingDominos:ISolution
    {
        static long[] hor;
        static long[] ways;
        const int height = 5;
        const int mod = (int)1e9 + 7;
        static long horizontal(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            else if (n < 0)
            {
                return 0;
            }
            else
            {
                if (hor[n] == 0)
                {
                    hor[n] = horizontal(n - 1) + horizontal(n - 2);
                }
                return hor[n];
            }
        }
        static long numOfWays(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            else if (n < 0)
            {
                return 0;
            }
            else
            {
                if (ways[n] == 0)
                {
                    ways[n] = (numOfWays(n - 1) + numOfWays(n - 2) + (horizontal(height) % mod) * (numOfWays(n - 5) % mod)) % mod;
                }
                return ways[n];
            }
        }

        public override void Solve()
        {
            hor = new long[6];
            ways = new long[1000001];
            numOfWays(1000000);
            int t = Convert.ToInt32(Console.ReadLine().Trim());
            StringBuilder sb = new StringBuilder("");
            for (int i = 0; i < t; i++)
            {
                int n = Convert.ToInt32(Console.ReadLine().Trim());
                sb.Append(numOfWays(n)).Append("\n");
            }
            Console.Write(sb);
        }
    }
}
