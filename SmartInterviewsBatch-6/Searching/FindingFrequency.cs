using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.Searching
{
    public class FindingFrequency : ISolution
    {
        public override void Solve()
        {
            ReadInt();
            var arr = ReadArrString().Select(int.Parse).ToArray();
            Array.Sort(arr);
            int[] compressedArr = new int[arr.Length];
            int[] freqArr = new int[arr.Length];
            for (int i = 0; i < compressedArr.Length; i++) {
                compressedArr[i] = int.MinValue;
            }
            int p1 = 0, p2 = 0, index = 0;
            if (arr.Length != 1)
            {
                while (p2 < arr.Length - 1)
                {
                    if (arr[p2] != arr[p2 + 1])
                    {
                        compressedArr[index] = arr[p1];
                        freqArr[index] = p2 - p1 + 1;
                        p2++;
                        p1 = p2;
                        index++;
                    }
                    else
                    {
                        p2++;
                    }
                    if (p2 == arr.Length - 1)
                    {
                        compressedArr[index] = arr[p2];
                        freqArr[index] = p2 - p1 + 1;
                        index++;
                    }
                }
            }
            else {
                compressedArr[0] = arr[0];
                freqArr[0] = 1;
            }
            var queries = ReadInt();
            while (queries-- > 0) {
                int i = Search(compressedArr,index, ReadInt());
                if (i != -1)
                {
                    output.AppendLine(freqArr[i].ToString());
                }
                else {
                    output.AppendLine("0");
                }
            }
            Console.Write(output);
        }

        private int Search(int[] compressedArr, int high, int v)
        {
            if (compressedArr.Length == 1) {
                if (v == compressedArr[0])
                    return 0;
                else {
                    return -1;
                }
            }
            int lo = 0, hi = high - 1, mid = 0;
            while (lo <= hi) {
                mid = lo + (hi - lo) / 2;
                if (compressedArr[mid] < v)
                {
                    lo = mid + 1;
                }
                else if (compressedArr[mid] > v)
                {
                    hi = mid - 1;
                }
                else {
                    return mid;
                }
            }
            return -1;
        }
    }
}




//if (index != 1) {
//    if (arr[p2] != compressedArr[index - 1])
//    {
//        compressedArr[index] = arr[p2];
//        freqArr[index] = 1;
//    }
//}