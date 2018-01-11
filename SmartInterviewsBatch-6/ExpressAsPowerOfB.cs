using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6
{
    public class ExpressAsPowerOfB : ISolution
    {
        public static bool[] expressableAsPower = new bool[(int)1e8+1];
        public override void Solve()
        {
            PrecomputeAPowerB();
            int t = ReadInt();
            while (t-- > 0)
            {
                int n = ReadInt();
                output.AppendLine(expressableAsPower[n] ? "Yes" : "No");
            }
            Console.Write(output);
        }

        private void PrecomputeAPowerB()
        {
            for (int i = 2; i <= 10000; i++) {
                for (long j = i * i; j <= (int)1e8; j*=i) {
                    expressableAsPower[j] = true;
                }
            }
        }
    }
}
