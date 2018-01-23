using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.DynamicProgramming
{
    public class BinaryStringWithNoAdjacentOnes : ISolution
    {
        static int N = (int)(1e5 + 1);
        static int modulo = (int)(1e9 + 7);
        static long[] noOfBinaryStrings = new long[N];
        public override void Solve()
        {
            noOfBinaryStrings[1] = 2;
            noOfBinaryStrings[2] = 3;
            for (int i = 3; i < noOfBinaryStrings.Length; i++)
            {
                noOfBinaryStrings[i] = (noOfBinaryStrings[i - 1] + noOfBinaryStrings[i - 2]) % modulo;
            }
            int t = ReadInt();
            while (t-- > 0)
            {
                output.AppendLine(noOfBinaryStrings[ReadInt()].ToString());
            }
            Console.Write(output);
        }
    }
}
