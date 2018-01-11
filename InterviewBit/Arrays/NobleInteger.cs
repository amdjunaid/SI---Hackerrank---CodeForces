using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewBit.Arrays
{
    public class NobleInteger : ISolution
    {
        public override void Solve()
        {
            var arr = ReadArrString().Select(int.Parse).ToArray();
            Console.WriteLine(DoesNobleNumberExist(arr));
        }

        private int DoesNobleNumberExist(int[] arr)
        {
            int[] arrToSort = new int[arr.Length];
            Array.Copy(arr, arrToSort, arr.Length);
            Array.Sort(arrToSort);
            for (int i = 0; i < arr.Length; i++)
            {
                int li = FindLastIndex(arrToSort, arr[i]);
                if (arr.Length - 1 == li && arrToSort[arr.Length-1]==0) {
                    return 1;
                }
                if (arr.Length - li -1 == arr[i])
                {
                    return 1;
                }
            }
            return -1;
        }

        private int FindLastIndex(int[] arr, int key)
        {
            int lo = 0, hi = arr.Length - 1, mid, lastIndex = int.MinValue;
            while (lo <= hi)
            {
                mid = hi + (lo - hi) / 2;
                if (arr[mid] == key)
                {
                    lo = mid + 1;
                    lastIndex = mid;
                }
                else if (arr[mid] > key)
                {
                    hi = mid - 1;
                }
                else
                {
                    lo = mid + 1;
                }
            }
            return lastIndex == int.MinValue ? -1 : lastIndex;
        }
    }
}
