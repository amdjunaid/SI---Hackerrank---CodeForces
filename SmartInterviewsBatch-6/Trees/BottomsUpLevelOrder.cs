using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.Trees
{
    public class BottomsUpLevelOrder : ISolution
    {
        public override void Solve()
        {
            short t = ReadShort();
            while (t-- > 0)
            {
                ReadShort();
                var arr = ReadArrString().Select(int.Parse).ToArray();
                output.AppendLine(Traverse(arr));
                output.AppendLine();
            }
            Console.Write(output);
        }

        private string Traverse(int[] arr)
        {
            var tree = new BinarySearchTree<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                tree.root = tree.Insert(tree.root, arr[i]);
            }
            tree.Depth(tree.root, -1);
            return tree.BottomUpLevelOrder(tree.root, arr.Length);
        }
    }
}
