using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackerearth.SocietyGeneralHiringChallenge
{
    public class TheTallestStudent : ISolution
    {
        public override void Solve()
        {
            var t = ReadInt();
            while (t-- > 0)
            {
                ReadInt();
                var arr = ReadArrString().Select(int.Parse).ToArray();
                output.AppendLine(FindTallest(arr).ToString());
            }
            Console.Write(output);
        }

        private int FindTallest(int[] arr)
        {
            var maxTallestStudentIndex = new int[arr.Length];
            for (int i = 0; i < maxTallestStudentIndex.Length; i++)
            {
                maxTallestStudentIndex[i] = maxTallestStudentIndex.Length;
            }
            Stack<int> stack = new Stack<int>();
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                while (stack.Count != 0)
                {
                    if (arr[i] > arr[stack.Peek()])
                    {
                        stack.Pop();
                    }
                    else
                    {
                        maxTallestStudentIndex[i] = stack.Peek();
                        break;
                    }
                }
                stack.Push(i);
            }
            int tallestStudentPos = 0, maxHeight = int.MinValue;
            for (int i = maxTallestStudentIndex.Length - 1; i >= 0; i--) {
                var maxStudentsReach = 0;
                if (maxTallestStudentIndex[i] == arr.Length)
                {
                    maxStudentsReach = arr.Length - 1 - i;
                }
                else {
                    maxStudentsReach = maxTallestStudentIndex[i] - i;
                }
                if (maxHeight < maxStudentsReach)
                {
                    maxHeight = maxStudentsReach;
                    tallestStudentPos = i+1;
                }
            }
            return tallestStudentPos;
        }
    }
}
