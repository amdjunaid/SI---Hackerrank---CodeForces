using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6
{
    public class TreeTraversals : ISolution
    {
        public override void Solve()
        {
            short t = ReadShort();
            while (t-- > 0) {
                ReadShort();
                var arr = ReadArrString().Select(int.Parse).ToArray();
                TraverseTree(arr);
                output.AppendLine();
                output.AppendLine();
            }
            Console.Write(output);
        }

        private void TraverseTree(int[] arr)
        {
            var tree = new BinarySearchTree<int>();
            var root = tree.root;
            for (int i = 0; i < arr.Length; i++) {
                root = tree.Insert(root, arr[i]);
            }
            tree.PreOrder(root, output);
            output.AppendLine();
            tree.InOrder(root, output);
            output.AppendLine();
            tree.PostOrder(root, output);
        }
    }

    
}
