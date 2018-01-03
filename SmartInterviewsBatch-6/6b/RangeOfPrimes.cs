using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6._6b
{
    public class RangeOfPrimes : ISolution
    {
        static bool[] primes = new bool[10000001];
        static int[] primeCount = new int[10000001];
        public override void Solve()
        {
            for (int i = 2; i < primes.Length; i++)
            {
                primes[i] = true;
            }
            primeCount[0] = primeCount[1] = 0;

            GeneratePrimes();
            int t = ReadInt();
            while (t-- > 0)
            {
                int[] AandB = ReadArrString().Select(int.Parse).ToArray();
                output.AppendLine(NoOfPrimes(AandB[0],AandB[1]).ToString());
            }
            Console.Write(output);
        }

        private int NoOfPrimes(int A,int B)
        {
            return primeCount[B] - primeCount[A - 1];
        }

        private void GeneratePrimes()
        {
            int count = 0;
            for (int i = 2; i < Math.Ceiling(Math.Sqrt(primes.Length)); i++)
            {
                if (primes[i] == true)
                {
                    //primeCount[i] = ++count;
                    for (int j = i * i; j < primes.Length; j += i)
                    {
                        primes[j] = false;
                    }
                }
            }
            for (int i = 2; i < primes.Length; i++) {
                primeCount[i] = primes[i] ? ++count : count;
            }
        }
    }
}
