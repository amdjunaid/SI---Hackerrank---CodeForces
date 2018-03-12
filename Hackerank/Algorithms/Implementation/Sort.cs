using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datastructures;

namespace Hackerank.Algorithms.Implementation
{
    public class Sort : ISolution
    {
        public override void Solve()
        {
            var li = ReadArrString().Select(int.Parse).ToArray();
            new MergeSort().MS(li, 0, li.Length - 1);
            Console.WriteLine(string.Join(" ",li));
        }
    }
}
