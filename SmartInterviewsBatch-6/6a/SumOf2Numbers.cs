using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6
{
    public class SumOf2Numbers : ISolution
    {
        public override void Solve()
        {
            short t = ReadShort();
            while (t-- > 0)
            {
                int n = ReadInt();
                int[] arr = ReadArrString().Select(int.Parse).ToArray();
                output.AppendLine(CheckIfPairExists(arr, n) ? "Yes" : "No");
            }
            Console.Write(output);
        }

        private bool CheckIfPairExists(int[] arr, int n)
        {
            Array.Sort(arr);
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += arr[i];
            }

            if (n > 2)
            {
                int p1 = 0, p2 = 1;
                while (p1 < p2 && p1 < n && p2 >= 0 && p2<n)
                {
                    if (arr[p1] + arr[p2] < sum - arr[p1] - arr[p2])
                    {
                        if (p2 < n)
                        {
                            p2++;
                        }
                        else {
                            p1++;
                        }
                    }
                    else if (arr[p1] + arr[p2] > sum - arr[p1] - arr[p2])
                    {
                        p2--;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
