using Datastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.Heaps
{
    public class ImplementMinHeap : ISolution
    {
        public override void Solve()
        {
            var heap = new MinHeap<int>((int)1e6);
            var t = ReadInt();
            while (t-- > 0)
            {
                var command = ReadArrString();
                if (command[0].Equals("insert"))
                {
                    heap.Insert(int.Parse(command[1]));
                }
                else if (command[0].Equals("getMin"))
                {
                    output.AppendLine(heap.IsEmpty() ? "Empty" : heap.GetMin().ToString());
                }
                else
                {
                    if (!heap.IsEmpty())
                        heap.DelMin();
                }
            }
            Console.Write(output);
        }
    }
}
