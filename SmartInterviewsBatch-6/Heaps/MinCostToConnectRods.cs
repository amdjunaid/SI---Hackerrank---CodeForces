using Datastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.Heaps
{
    public class MinCostToConnectRods : ISolution
    {
        public override void Solve()
        {
            var t = ReadShort();
            while (t-- > 0) {
                ReadInt();
                var arr = ReadArrString().Select(short.Parse).ToArray();
                output.AppendLine(MinCost(arr).ToString());
            }
            Console.Write(output);
        }

        private long MinCost(short[] arr)
        {
            long totalCost = 0;
            MinHeap<int> minheap = new MinHeap<int>(arr.Length);
            for (int i = 0; i < arr.Length; i++) {
                minheap.Insert(arr[i]);
            }
            for (int i = 0; i < arr.Length - 1; i++) {
                var rod1 = minheap.GetMin();
                minheap.DelMin();
                var rod2 = minheap.GetMin();
                minheap.DelMin();
                totalCost += rod1 + rod2;
                minheap.Insert(rod1 + rod2);
            }
            return totalCost;
        }
    }
}
