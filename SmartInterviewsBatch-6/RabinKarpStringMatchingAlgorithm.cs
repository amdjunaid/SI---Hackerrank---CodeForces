using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6
{
    public class RabinKarpStringMatchingAlgorithm : ISolution
    {
        static int firstPrime = 683, secondPrime = 677;
        static long modulo = (long)(1e9 + 7);
        static long[] firstPrimesArr = new long[(int)1e4 + 1];
        static long[] secondPrimesArr = new long[(int)1e4 + 1];
        public override void Solve()
        {
            GeneratePrimes();
            short t = ReadShort();
            while (t-- > 0)
            {
                var AandB = ReadArrString();
                output.AppendLine(IsASubsetOfB(AandB[0], AandB[1]).ToString());
            }
            Console.Write(output);
        }

        private void GeneratePrimes()
        {
            firstPrimesArr[0] = secondPrimesArr[0] = 1;
            for (int i = 1; i < firstPrimesArr.Length; i++)
            {
                firstPrimesArr[i] = (firstPrimesArr[i - 1] * firstPrime) % modulo;
                secondPrimesArr[i] = (secondPrimesArr[i - 1] * secondPrime) % modulo;
            }
        }

        private int IsASubsetOfB(string A, string B)
        {
            short noOfOccurences = 0;
            long fHvA = 0, fHvBi = 0, sHvBi = 0, sHvA = 0, fHvB = 0, sHvB = 0;
            //calculate hash value of A and B's first substring of length => Length(A)
            for (int i = 0; i < A.Length; i++)
            {
                fHvA = (fHvA + A[i] * firstPrimesArr[A.Length - i]) % modulo;
                sHvA = (sHvA + A[i] * secondPrimesArr[A.Length - i]) % modulo;
                fHvB = (fHvB + B[i] * firstPrimesArr[A.Length - i]) % modulo;
                sHvB = (sHvB + B[i] * secondPrimesArr[A.Length - i]) % modulo;
            }

            fHvBi = fHvB;
            sHvBi = sHvB;

            if (fHvA == fHvB && sHvA == sHvB)
                noOfOccurences++;
            for (int i = A.Length; i < B.Length; i++)
            {
                fHvBi = ((((long)(fHvBi - B[i - A.Length] * firstPrimesArr[A.Length]) + (long)(B[i - A.Length] * modulo)) % modulo) * firstPrime + B[i] * firstPrime) % modulo;
                sHvBi = ((((long)(sHvBi - B[i - A.Length] * secondPrimesArr[A.Length]) + (long)(B[i - A.Length] * modulo)) % modulo) * secondPrime + B[i] * secondPrime) % modulo;
                if (fHvA == fHvBi && sHvA == sHvBi)
                {
                    noOfOccurences++;
                }
            }
            return noOfOccurences;
        }
    }
}
