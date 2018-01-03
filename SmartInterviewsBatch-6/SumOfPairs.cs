using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6
{
    public class SumOfPairs
    {
        public static Func<int> ReadInt = () => int.Parse(Console.ReadLine().Trim());
        public static Func<short> ReadShort = () => short.Parse(Console.ReadLine().Trim());
        public static Func<string> ReadString = () => Console.ReadLine().Trim();

        static StringBuilder output = new StringBuilder();
        public static void Solve() {
            short t = ReadShort();
            while (t-- > 0) {
                var NandK = ReadString().Split(' ').ToArray();
                var elements = ReadString().Split(' ').Select(x => int.Parse(x)).ToArray();
                output.AppendLine(DoesSumOfPairsExist(elements,int.Parse(NandK[1])));
            }
            Console.WriteLine(output);
        }

        private static string DoesSumOfPairsExist(int[] elements,int K)
        {
            Array.Sort(elements);
            sbyte P1 = 0;
            sbyte P2 = (sbyte)(elements.Length - 1);
            while (P1 < P2) {
                if (elements[P1] + elements[P2] == K) {
                    return "True";
                }
                else if (elements[P1] + elements[P2] < K)
                {
                    P1++;
                }
                else if (elements[P1] + elements[P2] > K) {
                    P2--;
                }
            }
            return "False";
        }
    }
}
