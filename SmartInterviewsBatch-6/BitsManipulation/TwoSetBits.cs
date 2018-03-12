using System;
using System.Text;

namespace SmartInterviewsBatch_6
{
    public class TwoSetBits
    {
        static Func<int> ReadInt = () => int.Parse(Console.ReadLine().Trim());
        static Func<short> ReadShort = () => short.Parse(Console.ReadLine().Trim());
        static Func<byte> ReadByte = () => byte.Parse(Console.ReadLine().Trim());
        static Func<string> ReadString = () => Console.ReadLine().Trim();
        static Func<long> ReadLong = () => long.Parse(Console.ReadLine().Trim());

        public static void Solve() {
            int t = ReadInt();
            StringBuilder ans = new StringBuilder();
            while (t-- > 0) {
                long n = ReadLong();
                int r1 = (int)Math.Ceiling((double)(1 + Math.Ceiling(Math.Sqrt(1 + 8 * n))) / 2);
                int r2 = (int)Math.Ceiling((double)(((Math.Ceiling(Math.Sqrt(1 + 8 * n))) - 1) / 2));
                //checking purpose
                long ncr1 = ((long)((long)r1 * (long)(r1 - 1)) / 2), ncr2 = ((long)((long)r2 * (long)(r2 - 1)) / 2);
                

                if (n == ncr1)
                {
                    ans.Append((APowBModM(2, r1 - 1, 1e9 + 7) + APowBModM(2, r1 - 2, 1e9 + 7)) % (1e9 + 7));
                }

                else if (n < ncr1 && n >= ncr2)
                {
                    ans.Append((APowBModM(2, r1 - 1, 1e9 + 7) + APowBModM(2, (long)(n - ncr2 - 1), 1e9 + 7)) % (1e9 + 7));
                }
                else
                {
                    Console.WriteLine("wrong logic stupid");
                }
                if (t != 1) {
                    ans.AppendLine();
                }
            }
            Console.Write(ans);
        }

        public static int APowBModM(int a, long n,double mod) {
            long ans = 1, x = a;
            if (n > 1)
            {
                for (int i = 0; i <= (int)Math.Ceiling(Math.Log((double)n, 2)); i++)
                {
                    if (((n & (1 << i)) > 0))
                    {
                        ans = (long)((ans*x) % mod);
                    }
                    x = (long)((x*x)%mod);
                }
            }
            else {
                return (n == 1 ? 2 : 1);
            }
            
            return (int)(ans % mod);
        }
    }
}
