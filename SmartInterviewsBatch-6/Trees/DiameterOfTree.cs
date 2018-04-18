using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.Trees
{
    public class DiameterOfTree : ISolution
    {
        private static int totalDiameter = int.MinValue;
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
            totalDiameter = int.MinValue;
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                tree.root = tree.Insert(tree.root, arr[i]);
            }
            TotalDiameter(tree.root);
            return totalDiameter;
        }

        private int TotalDiameter(BinarySearchTree<int>.Node root)
        {
            if (root == null)
                return 0;
            var leftDiamater = TotalDiameter(root.left);
            var rightDiamater = TotalDiameter(root.right);
            totalDiameter = Math.Max(totalDiameter, Math.Max(Math.Max(leftDiamater, rightDiamater), leftDiamater + rightDiamater + 1));
            return BinarySearchTree<int>.height(root) + 1;
        }
    }
}
