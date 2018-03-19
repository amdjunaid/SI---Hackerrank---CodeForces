using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.Contests
{
    public class SumOf2Numbers
    {
        public void Solve()
        {
            var t = int.Parse(Console.ReadLine().Trim());
            StringBuilder output = new StringBuilder();
            while (t-- > 0)
            {
                Console.ReadLine();
                var arr = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                output.AppendLine(Exists(arr)?"Yes":"No");
            }
            Console.Write(output);
        }

        private bool Exists(int[] arr)
        {
            long sum = 0;
            HashSet<long> hash = new HashSet<long>();
            for (int i = 0; i < arr.Length; i++) {
                sum += arr[i];
            }
            if (sum % 2 != 0) return false;
            for (int i = 0; i < arr.Length; i++)
            {
                long sumMinusB = (sum / 2) - arr[i];
                if (!hash.Contains(sumMinusB))
                {
                    hash.Add(sumMinusB);
                }
                else {
                    return true;
                }
            }
            for (int i = 0; i < arr.Length; i++) {
                if (hash.Contains(arr[i])) {
                    return true;
                }
            }
            return false;
        }
    }
}
