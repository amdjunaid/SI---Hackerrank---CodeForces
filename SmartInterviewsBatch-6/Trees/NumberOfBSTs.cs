using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.Trees
{
    public class NumberOfBSTs : ISolution
    {
        static HashSet<int> rootes;
        public override void Solve()
        {
            var t = ReadShort();
            while (t-- > 0)
            {
                ReadShort();
                var arr = ReadArrString().Select(int.Parse).ToArray();
                output.AppendLine(CountOfBSTs(arr).ToString());
            }
            Console.Write(output);
        }

        private int CountOfBSTs(int[] arr)
        {
            rootes = new HashSet<int>();
            CountOfBSTs(arr, 0);
            return rootes.Count;
        }

        private Tuple<int, int, bool> CountOfBSTs(int[] arr, int pI)
        {
            if (pI >= arr.Length)
            {
                return new Tuple<int, int, bool>(int.MinValue, int.MaxValue, true);
            }
            var left = CountOfBSTs(arr, pI * 2 + 1);
            var right = CountOfBSTs(arr, pI * 2 + 2);
            bool AreSubTreesValid = true;
            if (left.Item3 && right.Item3)
            {
                if (left.Item1 < arr[pI] && arr[pI] < right.Item2)
                {
                    rootes.Add(arr[pI]);
                }
                else
                {
                    AreSubTreesValid = false;
                }
            }
            else
            {
                AreSubTreesValid = false;
            }

            return new Tuple<int, int, bool>(Math.Max(Math.Max(left.Item1, right.Item1), arr[pI]), Math.Min(Math.Min(left.Item2, right.Item2), arr[pI]), AreSubTreesValid);
        }
    }
}
