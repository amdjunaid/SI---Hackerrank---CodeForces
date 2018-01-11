using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.Trees
{
    public class VerticalOrderOfTree : ISolution
    {
        public override void Solve()
        {
            short t = ReadShort();
            while (t-- > 0)
            {
                ReadInt();
                var arr = ReadArrString().Select(int.Parse).ToArray();
                PrintVerticalOrder(arr);
                output.AppendLine();
            }
            Console.Write(output);
        }

        private void PrintVerticalOrder(int[] arr)
        {
            Dictionary<int, List<int>> nodesList = new Dictionary<int, List<int>>();
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                tree.root = tree.Insert(tree.root, arr[i]);
            }
            tree.ComputeVerticalLevels(tree.root, 0);
            int maxVerticalLevel = tree.GetMaxVerticalLevel(tree.root);
            int minVerticalLevel = tree.GetMinVerticalLevel(tree.root);
            tree.CombineNodesOfSameVerticalLevel(tree.root, nodesList);

            for (int i = maxVerticalLevel; i >= minVerticalLevel; i--)
            {
                var nodes = nodesList[i];
                foreach (var node in nodes)
                {
                    output.Append(node + " ");
                }
                output.AppendLine();
            }
        }
    }
}
