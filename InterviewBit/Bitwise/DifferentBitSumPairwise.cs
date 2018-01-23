using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewBit.Bitwise
{
    public class DifferentBitSumPairwise : ISolution
    {
        static int modulo = (int)1e9 + 7;
        public override void Solve()
        {
            var arr = ReadArrString().Select(int.Parse).ToList();
            Console.Write(cntBits(arr).ToString());
        }

        public int cntBits(List<int> A)
        {
            long ans = 0;
            for (int i = 0; i < 32; i++)
            {
                long count = 0;
                for (int j = 0; j < A.Count; j++)
                    if ((A[j] & (1 << i)) != 0)
                        count++;

                ans += ((count * (A.Count - count) % 1000000007) * 2);
            }

            return (int)(ans % 1000000007);
        }
    }
}
