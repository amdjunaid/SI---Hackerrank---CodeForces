using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6
{
    public class HeightOfTree : ISolution
    {
        public override void Solve()
        {
            short t = ReadShort();
            while (t-- > 0) {
                ReadShort();
                var arr = ReadArrString().Select(int.Parse).ToArray();
                output.AppendLine(Height(arr).ToString());
            }
            Console.Write(output);
        }

        private int Height(int[] arr)
        {
            var tree = new BinarySearchTree<int>();
            for (int i = 0; i < arr.Length; i++) {
                tree.root = tree.Insert(tree.root, arr[i]);
            }
            return tree.Height(tree.root);
        }
    }
}
