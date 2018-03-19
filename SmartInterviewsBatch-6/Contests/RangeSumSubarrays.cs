using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.Contests
{
    public class RangeSumSubarrays
    {
        public void Solve() {
            var t = int.Parse(Console.ReadLine().Trim());
            StringBuilder output = new StringBuilder();
            while (t-- > 0)
            {
                var NandAandB = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                var arr = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                output.AppendLine(HowMany(arr,NandAandB[0],NandAandB[1]).ToString());
            }
            Console.Write(output);
        }

        private int HowMany(int[] arr, int A, int B)
        {
            int[] prefix = new int[arr.Length];
            prefix[0] = arr[0];
            for (int i = 1; i < prefix.Length; i++) {
                prefix[i] = prefix[i - 1] + arr[i];
            }
            int count = 0;
            for (int i = 0; i < arr.Length; i++) {
                for (int j = i; j < arr.Length; j++) {
                     int sum = prefix[j] - (i != 0 ? prefix[i - 1] : 0);
                    if (sum >= A && sum <= B) {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
