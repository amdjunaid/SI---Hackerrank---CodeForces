using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.Trees
{
    public class DiameterOfTree : ISolution
    {
        public override void Solve()
        {
            var t = ReadShort();
            while (t-- > 0)
            {
                var N = ReadInt();
                var arr = ReadArrString().Select(int.Parse).ToArray();
                output.AppendLine(Diameter(arr).ToString());
            }
            Console.Write(output);
        }

        private int Diameter(int[] arr)
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                tree.root = tree.Insert(tree.root, arr[i]);
            }
            var totalDiameter = tree.height(tree.root.left) + tree.height(tree.root.right) + 3;
            return totalDiameter;
        }
    }
}
