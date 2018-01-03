using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6
{
    public class CountTheTriangles : ISolution
    {
        private int CountPossibleTriangles(int[] arr) {
            Array.Sort(arr);
            int count = 0;
            for (int i = 0; i < arr.Length; i++) {
                int k = i + 2;
                for (int j = i + 1; j < arr.Length; j++) {
                    while (k < arr.Length && (arr[i] + arr[j]) > arr[k]) {
                        k++;
                    }
                    count += k - j - 1;
                }
            }
            return count;
        }

        public override void Solve()
        {
            byte t = ReadByte();
            while (t-- > 0) {
                ReadShort();
                int[] arr = ReadString().Split(' ').Select(x => int.Parse(x)).ToArray();
                output.AppendLine(CountPossibleTriangles(arr).ToString());
            }
            Console.Write(output);
        }
    }
}
