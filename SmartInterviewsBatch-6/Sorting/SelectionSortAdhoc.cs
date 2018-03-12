using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.Sorting
{
    public class SelectionSortAdhoc : ISolution
    {
        public override void Solve()
        {
            byte t = ReadByte();
            while (t-- > 0)
            {
                ReadByte();
                var arr = ReadArrString().Select(short.Parse).ToArray();
                SortAsPerSelection(arr);
                output.AppendLine();
            }
            Console.Write(output);
        }

        private void SortAsPerSelection(short[] arr)
        {
            for (int i = 0; i < arr.Length -1; i++)
            {
                int max = arr[0], index = 0;
                for (int j = 1; j < arr.Length - i; j++)
                {
                    if (max < arr[j])
                    {
                        max = arr[j];
                        index = j;
                    }
                }
                output.Append(index.ToString() + " ");
                arr[index] = (short)(arr[index] ^ arr[arr.Length - i - 1] ^ (arr[arr.Length - i - 1] = arr[index]));
            }
        }
    }
}
