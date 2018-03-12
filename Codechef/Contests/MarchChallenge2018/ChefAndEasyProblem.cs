using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codechef.Contests.MarchChallenge2018
{
    public class Bits
    {
        public int[] bitsSet;

        public Bits()
        {
            bitsSet = new int[32];
        }
    }
    public class ChefAndEasyProblem : ISolution
    {
        static int[] arr;
        static Bits[] cntArr;
        public override void Solve()
        {
            var NandQ = ReadArrString().Select(int.Parse).ToArray();
            arr = ReadArrString().Select(int.Parse).ToArray();
            cntArr = new Bits[arr.Length];
            ProcessBitPositions();
            while (NandQ[1]-- > 0)
            {
                var LandR = ReadArrString().Select(int.Parse).ToArray();
                output.AppendLine(MinimumX(LandR[0] - 1, LandR[1] - 1).ToString());
            }
            Console.Write(output);
        }

        public void ProcessBitPositions()
        {
            cntArr[0] = new Bits();
            for (int i = 0; i < 31; i++)
            {
                cntArr[0].bitsSet[i] = (((arr[0] & (1 << i)) != 0) ? 1 : 0);
            }
            for (int i = 1; i < arr.Length; i++)
            {
                cntArr[i] = new Bits();
                for (int j = 0; j < 31; j++)
                {
                    cntArr[i].bitsSet[j] = cntArr[i - 1].bitsSet[j] + (((arr[i] & (1 << j)) != 0) ? 1 : 0);
                }
            }
        }

        private int MinimumX(int L, int R)
        {
            int x = 0;
            for (int i = 0; i < 31; i++)
            {
                int maxcountSetBitsInIthPosition = cntArr[R].bitsSet[i] - (L != 0 ? cntArr[L - 1].bitsSet[i] : 0);
                if (maxcountSetBitsInIthPosition < Math.Ceiling((double)(R - L + 1) / 2))
                {
                    x |= (1 << i);
                }
            }
            return x;
        }
    }
}
