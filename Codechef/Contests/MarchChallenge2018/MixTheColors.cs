using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codechef.Contests.MarchChallenge2018
{
    public class MixTheColors : ISolution
    {
        public override void Solve()
        {
            var t = ReadByte();
            while (t-- > 0) {
                var n = ReadInt();
                var arr = ReadArrString().Select(int.Parse).ToArray();
                output.AppendLine(MinNumberOfSteps(arr).ToString());
            }
            Console.Write(output);
        }

        private long MinNumberOfSteps(int[] arr)
        {
            long minSteps = 0;
            int max = arr.Max();
            Array.Sort(arr);
            for (int i = 1; i < arr.Length; i++) {
                if (arr[i - 1] == arr[i]) {
                    arr[i - 1] += max;
                    if (arr[i - 1] > max) {
                        max = arr[i - 1];
                    }
                    minSteps++;
                }
            }
            return minSteps;
        }
    }
}
