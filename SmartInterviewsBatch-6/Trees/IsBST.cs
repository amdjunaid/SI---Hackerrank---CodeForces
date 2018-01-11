using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.Trees
{
    public class IsBST : ISolution
    {
        public override void Solve()
        {
            short t = ReadShort();
            while (t-- > 0)
            {
                ReadShort();
                var arr = ReadArrString().Select(int.Parse).ToArray();
                output.AppendLine(CheckIfBST(arr, 1).ToString());
            }
            Console.Write(output);
        }

        private int GetMax(int[] arr, int pI)
        {
            int lI = pI * 2 - 1;
            int rI = pI * 2;
            if (pI - 1 >= arr.Length)
                return int.MinValue;
            return Math.Max(Math.Max(GetMax(arr, lI + 1), GetMax(arr, rI + 1)), arr[pI - 1]);
        }

        private int GetMin(int[] arr, int pI)
        {
            int lI = pI * 2 - 1;
            int rI = pI * 2;
            if (pI - 1 >= arr.Length)
                return int.MaxValue;
            return Math.Min(Math.Min(GetMin(arr, lI + 1), GetMin(arr, rI + 1)), arr[pI - 1]);
        }

        private bool CheckIfBST(int[] arr, int pI)
        {
            int lI = pI * 2 - 1;
            int rI = pI * 2;
            if (pI - 1 >= arr.Length)
                return true;
            if (CheckIfBST(arr, lI + 1) && CheckIfBST(arr, rI + 1))
            {
                int leftValue = GetMax(arr, lI + 1);
                int rightValue = GetMin(arr, rI + 1);
                return leftValue < arr[pI - 1] && arr[pI - 1] < rightValue;
            }
            return false;
        }
    }
}
