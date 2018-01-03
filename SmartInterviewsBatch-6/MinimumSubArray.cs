using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6
{
    public class MinimumSubArray : ISolution
    {
        static int[] prefixSum;
        static short[] arr;
        public override void Solve()
        {
            int t = ReadInt();
            while (t-- > 0)
            {
                int[] NandD = ReadArrString().Select(int.Parse).ToArray();
                arr = ReadArrString().Select(short.Parse).ToArray();
                output.AppendLine(MinSubArrayLength(NandD[1]).ToString());
            }
            Console.Write(output);
        }

        private int MinSubArrayLength(int d)
        {
                int max = arr[0];
                prefixSum = new int[arr.Length];
                prefixSum[0] = arr[0];
                for (int i = 1; i < arr.Length; i++)
                {
                    max = Math.Max(max, arr[i]);
                    prefixSum[i] = arr[i] + prefixSum[i - 1];
                }
                if (arr.Length == 1)
                {
                    if (arr[0] >= d)
                    {
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    if (d <= 0)
                    {
                        if (max >= d)
                        {
                            return 1;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                    int lo = 1, hi = arr.Length, mid, ans = -1;
                    while (lo <= hi)
                    {
                        mid = lo + (hi - lo) / 2;
                        if (IsValid(mid, d))
                        {
                            ans = mid;
                            hi = mid - 1;
                        }
                        else
                        {
                            lo = mid + 1;
                        }
                    }
                    return ans;
                }
        }

        private bool IsValid(int windowSize, int d)
        {
            for (int i = 0; i < arr.Length - windowSize + 1; i++)
            {
                int sum = prefixSum[i + windowSize - 1] - (i == 0 ? 0 : prefixSum[i - 1]);
                if (sum >= d)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
