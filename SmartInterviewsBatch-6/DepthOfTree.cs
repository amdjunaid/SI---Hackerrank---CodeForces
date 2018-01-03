using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6
{
    public class DepthOfTree : ISolution
    {
        public override void Solve()
        {
            short t = ReadShort();
            while (t-- > 0)
            {
                ReadShort();
                var arr = ReadArrString().Select(int.Parse).ToArray();
                Depth(arr);
                output.AppendLine();
            }
        }

        private void Depth(int[] arr)
        {
            var tree = new BinarySearchTree<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                tree.root = tree.Insert(tree.root, arr[i]);
            }
            tree.Depth(tree.root, -1);
            for (int i = 0; i < arr.Length; i++) {
                output.Append(tree.GetDepth(tree.root, arr[i]) + " ");
            }
        }
    }
}
