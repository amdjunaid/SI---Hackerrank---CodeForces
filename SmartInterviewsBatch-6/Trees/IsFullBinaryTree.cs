using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.Trees
{
    public class IsFullBinaryTree : ISolution
    {
        public override void Solve()
        {
            short t = ReadShort();
            while (t-- > 0) {
                ReadInt();
                var arr = ReadArrString().Select(int.Parse).ToArray();
                output.AppendLine(IsFullBT(arr).ToString());
            }
            Console.Write(output);
        }

        private bool IsFullBT(int[] arr)
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            for (int i = 0; i < arr.Length; i++) {
                tree.root = tree.Insert(tree.root, arr[i]);
            }
            return tree.IsFullBT(tree.root);
        }
    }
}
