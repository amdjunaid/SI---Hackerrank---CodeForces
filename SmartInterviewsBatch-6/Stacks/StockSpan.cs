using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.Stacks
{
    public class StockSpan : ISolution
    {
        public override void Solve()
        {
            byte t = ReadByte();
            while (t-- > 0)
            {
                ReadInt();
                var arr = ReadArrString().Select(int.Parse).ToArray();
                StockSpanForEachDay(arr);
                output.AppendLine();
            }
            Console.Write(output);
        }

        private void StockSpanForEachDay(int[] arr)
        {
            Stack<int> stack = new Stack<int>(arr.Length);
            //int[] MLi = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                int firstOccuringMaxOnLeftSide = 0;
                //bool isFirstMaxFound = false;
                if (!stack.IsEmpty())
                {
                    while (!stack.IsEmpty())
                    {
                        if (arr[stack.Peek()] > arr[i])
                        {
                            firstOccuringMaxOnLeftSide = stack.Peek();
                            //MLi[i] = stack.Peek();
                            break;
                        }
                        else
                        {
                            stack.Pop();
                        }
                    }
                }
                stack.Push(i);
                if (firstOccuringMaxOnLeftSide == 0)
                {
                    if (arr[firstOccuringMaxOnLeftSide] <= arr[i])
                        output.Append(i + 1 + " ");
                    else
                    {
                        output.Append(i + " ");
                    }
                }
                else //if max found, (a,b] = so, we want to include elements after max, so, [a+1,b] = b-a-1+1 => b-a
                    output.Append(Math.Abs(i - firstOccuringMaxOnLeftSide) + " ");
            }
        }
        // if max on left - fMLi != i & !=0 ->
        //if no max on left - 0
    }
}
