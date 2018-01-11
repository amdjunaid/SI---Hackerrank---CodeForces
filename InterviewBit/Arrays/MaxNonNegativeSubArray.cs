using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewBit.Arrays
{
    public class MaxNonNegativeSubArray : ISolution
    {
        public override void Solve()
        {
            var arr = ReadArrString().Select(int.Parse).ToList();
            Console.Write(string.Join(Environment.NewLine, MaxSubArray(arr)));
        }

        private List<int> MaxSubArray(List<int> A)
        {
            if (A.Count == 1)
            {
                if (A[0] < 0)
                {
                    return new List<int>();
                }
                else
                {
                    return A;
                }
            }
            int maxSum = int.MinValue, maxLength = int.MinValue, startingIndex = int.MaxValue;
            int[] ps = new int[A.Count];
            ps[0] = A[0];
            for (int i = 1; i < A.Count; i++)
            {
                ps[i] = ps[i - 1] + A[i];
            }
            for (int i = 0; i < A.Count;)
            {
                bool isNegative = false;
                for (int j = i; j < A.Count; j++)
                {
                    if (A[j] < 0)
                    {
                        isNegative = true;
                        i = j + 1;
                        break;
                    }
                    int currentSum = ps[j] - (i == 0 ? 0 : ps[i - 1]);
                    if (maxSum < currentSum)
                    {
                        maxSum = currentSum;
                        maxLength = j - i + 1;
                        startingIndex = i;
                    }
                    else if (maxSum == currentSum)
                    {
                        if (maxLength < j - i + 1)
                        {
                            maxLength = j - i + 1;
                            startingIndex = i;
                        }
                        else if (maxLength == j - i + 1)
                        {
                            if (startingIndex > i)
                            {
                                startingIndex = i;
                            }
                        }
                    }
                }
                if (!isNegative)
                    i++;
            }
            var B = new List<int>();
            while (maxLength-- > 0)
            {
                B.Add(A[startingIndex++]);
            }
            return B;
        }

        private List<int> MaxSubArrayOptimised(List<int> A)
        {
            if (A.Count == 1)
            {
                return A[0] < 0 ? new List<int>() : A;
            }
            long maxSum = long.MinValue; int maxLength = int.MinValue, startingIndex = int.MaxValue;
            long[] ps = new long[A.Count];
            ps[0] = A[0];
            for (int i = 1; i < A.Count; i++)
            {
                ps[i] = ps[i - 1] + A[i];
            }

            int p1 = 0, p2 = 0;
            while (p2 < A.Count)
            {
                if (A[p2] < 0)
                {
                    p1 = ++p2;
                    continue;
                }
                long currentSum = ps[p2] - (p1 == 0 ? 0 : ps[p1 - 1]);
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    maxLength = p2 - p1 + 1;
                    startingIndex = p1;
                }
                else if (currentSum == maxSum)
                {
                    if (maxLength < p2 - p1 + 1)
                    {
                        maxLength = p2 - p1 + 1;
                        startingIndex = p1;
                    }
                    else if (maxLength == p2 - p1 + 1)
                    {
                        startingIndex = p1;
                    }
                }
                p2++;
            }
            var B = new List<int>();
            while (maxLength-- > 0)
            {
                B.Add(A[startingIndex++]);
            }
            return B;
        }
    }
}
