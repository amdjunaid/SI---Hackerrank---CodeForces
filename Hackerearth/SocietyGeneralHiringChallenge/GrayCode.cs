using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackerearth.SocietyGeneralHiringChallenge
{
    public class GrayCode : ISolution
    {
        public override void Solve()
        {
            var t = ReadInt();
            while (t-- > 0) {
                ReadInt();
                var arr = ReadArrString().Select(int.Parse).ToArray();
                for (int i = 0; i < arr.Length; i++) {
                    output.Append(BinToGrayToDecimal(arr[i])+" ");
                }
                output.AppendLine();
            }
            Console.Write(output);
        }

        private int BinToGrayToDecimal(int n)
        {
            int finalNum = 0;
            int msbBit =  (int)Math.Ceiling(Math.Log((double)n, 2));
            for (int i = msbBit; i >= 0; i--) {
                var bit = (((n & (1 << i)) > 0) ? 1 : 0) ^ (((n & (1 << i + 1)) > 0) ? 1 : 0);
                if (bit == 1) {
                    finalNum |= 1 << i;
                }
            }
            return finalNum;
        }
    }
}
