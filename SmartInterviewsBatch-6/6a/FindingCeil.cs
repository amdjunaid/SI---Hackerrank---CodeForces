using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6
{
    public class FindingCeil : ISolution
    {
        public override void Solve()
        {
            int N = ReadInt();
            long[] numbers = ReadArrString().Select(long.Parse).ToArray();
            Array.Sort(numbers);
            int Q = ReadInt();
            while (Q-- > 0)
            {
                long query = long.Parse(ReadString());
                output.AppendLine(FindTheCeil(numbers, numbers.Length, query).ToString());
            }
            Console.Write(output);
        }

        private static long FindTheCeil(long[] arr, int n, long key)
        {
            int lo = 0, hi = n - 1, mid = 0;
            long ans = 0;
            if (key < arr[lo])
                return arr[lo];
            else if (key == arr[lo] || key == arr[hi])
                return key;
            else if (key > arr[hi])
                return int.MaxValue;

            while (lo <= hi)
            {
                mid = lo + (hi - lo) / 2;
                if (arr[mid] == key)
                    return arr[mid];
                else if (arr[mid] > key)
                {
                    hi = mid - 1;
                    ans = arr[mid];
                }
                else if (arr[mid] < key)
                {
                    lo = mid + 1;
                }
            }
            return ans;
        }
    }
}
