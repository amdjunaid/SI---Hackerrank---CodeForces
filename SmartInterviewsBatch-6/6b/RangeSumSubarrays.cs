using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6._6b
{
    public class RangeSumSubarrays : ISolution
    {
        static int[] prefixSum;
        static int[] arr;
        public override void Solve()
        {
            byte t = ReadByte();
            while (t-- > 0)
            {
                int[] NAB = ReadArrString().Select(int.Parse).ToArray();
                arr = ReadArrString().Select(int.Parse).ToArray();
                output.AppendLine(NoOfSubarrays(arr, NAB[1], NAB[2]).ToString());
            }
            Console.Write(output);
        }

        private int NoOfSubarrays(int[] arr, int A, int B)
        {
            int noOfSubArrays = 0;
            prefixSum = new int[arr.Length];
            prefixSum[0] = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                prefixSum[i] = arr[i] + prefixSum[i - 1];
            }
            for (int i = 1; i <= arr.Length; i++)
            {
                noOfSubArrays += NoOfSubArraysOfWindowSize(i, A, B);
            }
            return noOfSubArrays;
        }

        private int NoOfSubArraysOfWindowSize(int windowSize, int A, int B)
        {
            int count = 0;
            for (int i = 0; i < arr.Length - windowSize + 1; i++)
            {
                int sum = prefixSum[i + windowSize - 1] - (i == 0 ? 0 : prefixSum[i - 1]);
                if (sum >= A && sum <= B)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
