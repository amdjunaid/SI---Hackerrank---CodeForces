using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6._6c
{
    public class ContinuousHeightOfTree : ISolution
    {
        public override void Solve()
        {
            var t = ReadShort();
            while (t-- > 0)
            {
                ReadInt();
                var arr = ReadArrString().Select(int.Parse).ToArray();
                Height(arr);
            }
            Console.Write(output);
        }

        private void Height(int[] arr)
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                tree.root = tree.Insert(tree.root, arr[i]);
                output.Append(tree.Height(tree.root) - 1 + " ");
            }
            output.AppendLine();
        }
    }
}
