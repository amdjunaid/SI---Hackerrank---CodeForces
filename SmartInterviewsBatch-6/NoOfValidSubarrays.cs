using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6
{
    public class NoOfValidSubarrays : ISolution
    {
        public override void Solve()
        {
            sbyte t = ReadSByte();
            while (t-- > 0)
            {
                int N = ReadInt();
                byte[] arr = Array.ConvertAll<string, byte>(ReadArrString(), byte.Parse);
                output.AppendLine(ValidNoOfSubarrays(arr).ToString());
            }
            Console.Write(output);
        }

        private long ValidNoOfSubarrays(byte[] arr)
        {
            int[] prefixSum = new int[arr.Length];
            prefixSum[0] = arr[0] == 0 ? -1 : arr[0];
            int max = prefixSum[0], min = prefixSum[0];
            for (int i = 1; i < arr.Length; i++)
            {
                prefixSum[i] = prefixSum[i - 1] + (arr[i] == 0 ? -1 : 1);
                max = Math.Max(max, prefixSum[i]);
                min = Math.Min(min, prefixSum[i]);
            }

            int[] cntArray = new int[max - min + 1];

            if (min <= 0 && max>=0) {
                cntArray[Math.Abs(min)]++;//represents 0
            }
            
            for (int i = 0; i < arr.Length; i++)
            {
                cntArray[prefixSum[i] - min]++;
            }

            long noOfValidSubarrays = 0;
            for (int i = 0; i < cntArray.Length; i++)
            {
                if (cntArray[i] >= 2)
                {
                    noOfValidSubarrays += (long)(cntArray[i] * (cntArray[i] - 1)) / 2;
                }
            }
            return noOfValidSubarrays;
        }
    }
}
