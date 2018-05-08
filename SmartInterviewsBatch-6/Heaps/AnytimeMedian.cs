using Datastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.Heaps
{
    public class AnytimeMedian : ISolution
    {
        public override void Solve()
        {
            var t = ReadByte();
            while (t-- > 0) {
                ReadInt();
                var arr = ReadArrString().Select(int.Parse).ToArray();
                Median(arr);
                output.AppendLine();
            }
            Console.Write(output);
        }

        private void Median(int[] arr)
        {
            MinHeap<int> minHeap = new MinHeap<int>(arr.Length);
            MaxHeap<int> maxHeap = new MaxHeap<int>(arr.Length);

            for (int i = 0; i < arr.Length; i++) {
                if (maxHeap.GetMax().CompareTo(arr[i]) > 0)
                {
                    maxHeap.Insert(arr[i]);
                }
                else {
                    minHeap.Insert(arr[i]);
                }
                var diffElements = maxHeap.Size() - minHeap.Size();
                if (diffElements < 0)
                {
                    var min = minHeap.GetMin();
                    minHeap.DelMin();
                    maxHeap.Insert(min);
                }
                else if(diffElements > 1){
                    var max = maxHeap.GetMax();
                    maxHeap.DelMax();
                    minHeap.Insert(max);
                }
                output.Append(maxHeap.GetMax() + " ");
            }
        }
    }
}
