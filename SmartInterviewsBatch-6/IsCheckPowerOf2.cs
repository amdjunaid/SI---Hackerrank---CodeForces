using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6
{
    public class IsCheckPowerOf2
    {
        public static void Solve() {
            short t = Convert.ToInt16(Console.ReadLine().Trim());
            while (t-- > 0) {
                ulong n = Convert.ToUInt64(Console.ReadLine().Trim());
                Console.WriteLine(IsPowerOf2(n).ToString());
            }
        }

        private static bool IsPowerOf2(ulong n)
        {
            return (n & (n - 1)) == 0;
        }
    }
}
