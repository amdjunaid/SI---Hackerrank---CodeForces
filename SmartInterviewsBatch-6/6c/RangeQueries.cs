using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6._6c
{
    public class RangeQueries : ISolution
    {
        public override void Solve()
        {
            byte t = ReadByte();
            while (t-- > 0)
            {
                var NandK = ReadArrString().Select(int.Parse).ToArray();
                var arr = ReadArrString().Select(int.Parse).ToArray();
                Array.Sort(arr);
                int Q = ReadInt();
                while (Q-- > 0)
                {
                    var AandB = ReadArrString().Select(int.Parse).ToArray();
                    output.AppendLine(TotalElements(arr, arr.Length, AandB[0], AandB[1]).ToString());
                }
            }
            Console.Write(output);
        }

        int TotalElements(int[] arr, int n, int A, int B)
        {
            int totalElements = 0;
            totalElements = FindLastIndex(arr, n, B) - FindFirstIndex(arr, n, A) + 1;
            return totalElements;
        }

        int FindFirstIndex(int[] arr, int n, int key)
        {
            int lo = 0, hi = n - 1;
            while (lo <= hi)
            {
                int mid = (lo + hi) / 2;
                if (arr[mid] >= key)
                    hi = mid - 1;
                else
                    lo = mid + 1;
            }
            return lo;
        }

        int FindLastIndex(int[] arr, int n, int key)
        {
            int lo = 0, hi = n - 1;
            while (lo <= hi)
            {
                int mid = (lo + hi) / 2;
                if (arr[mid] <= key)
                    lo = mid + 1;
                else
                    hi = mid - 1;
            }
            return hi;
        }
    }
}
