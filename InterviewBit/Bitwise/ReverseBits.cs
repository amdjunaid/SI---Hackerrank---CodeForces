using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewBit.Bitwise
{
    public class ReverseBits : ISolution
    {
        public override void Solve()
        {
            var n = Convert.ToInt64(ReadString());
            Console.WriteLine(Reverse(n).ToString());
        }

        private long Reverse(long n)
        {
            long number = 0;
            for (byte i = 0; i < 32; i++) {
                if ((n & 1 << i) > 0)
                {
                    number ^= 1;
                }
                number <<= 1;
            }
            number >>= 1;
            return number;
        }
    }
}
