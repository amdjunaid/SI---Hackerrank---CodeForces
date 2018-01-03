using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6
{
    public class PrimeFear : ISolution
    {
        static bool[] primes = new bool[10000001];
        public override void Solve()
        {
            for (int i = 2; i < primes.Length; i++)
            {
                primes[i] = true;
            }
            GeneratePrimes();
            for (int i = 1000; i >=500; i--) {
                if (primes[i]) {
                    Console.WriteLine(i);
                }
            }
            //int t = ReadInt();
            //while (t-- > 0)
            //{
            //    int n = ReadInt();
            //    output.AppendLine(NoOfPrimesFeared(n).ToString());
            //}
            //Console.Write(output);
        }

        private int NoOfPrimesFeared(int n)
        {
            int count = 0;
            for (int i = n; i >= 2; i--)
            {
                if (primes[i])
                {
                    int num = i;

                    int prospectivePrime = 0;
                    int power = 0;
                    bool isPrime = true;
                    while (num > 0)
                    {
                        int rem = num % 10;
                        if (rem == 0)
                        {
                            isPrime = false;
                            //break;
                        }
                        num /= 10;
                        prospectivePrime += rem * (int)Math.Pow(10, power++);
                        if (!primes[prospectivePrime])
                        {
                            primes[prospectivePrime] = false;
                            isPrime = false;
                            break;
                        }
                    }
                    if (isPrime)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        private void GeneratePrimes()
        {
            for (int i = 2; i < Math.Ceiling(Math.Sqrt(primes.Length)); i++)
            {
                if (primes[i] == true)
                {
                    for (int j = i * i; j < primes.Length; j += i)
                    {
                        primes[j] = false;
                    }
                }
            }
        }
    }
}
