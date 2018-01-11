using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.Trees
{
    public class RightView : ISolution
    {
        public override void Solve()
        {
            short t = ReadShort();
            while (t-- > 0)
            {
                ReadShort();
                var arr = ReadArrString().Select(int.Parse).ToArray();
                PrintRightView(arr);
                output.AppendLine();
            }
            Console.Write(output);
        }

        private void PrintRightView(int[] arr)
        {
            Dictionary<int, int> levels = new Dictionary<int, int>();
            var tree = new BinarySearchTree<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                tree.root = tree.Insert(tree.root, arr[i]);
            }
            tree.Depth(tree.root, -1);
            int maxDepth = tree.RightView(tree.root, levels, -1);
            for (int minDepth = 0; minDepth <= maxDepth; minDepth++)
            {
                output.Append(levels[minDepth] + " ");
            }
        }
    }
}
