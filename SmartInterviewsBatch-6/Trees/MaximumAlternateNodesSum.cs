﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.Trees
{
    public class MaximumAlternateNodesSum : ISolution
    {
        public override void Solve()
        {
            var t = ReadShort();
            while (t-- > 0) {
                ReadShort();
                var arr = ReadArrString().Select(int.Parse).ToArray();
                output.AppendLine(MaxSum(arr).ToString());
            }
            Console.Write(output);
        }

        private int MaxSum(int[] arr)
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            for (int i = 0; i < arr.Length; i++) {
                tree.root = tree.Insert(tree.root, arr[i]);
            }
            return MaxSumAlternate(tree.root).Item1;
        }

        /// <summary>
        /// Item1 is the current max of the node
        /// Item2 is the excluded max of the node which doesn't include the current node in the sum.
        /// Excluded Max(Node) is Max(CurrentMax(L),CurrentMax(R),CurrentMax(L) + CurrentMax(R))
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public Tuple<int, int> MaxSumAlternate(BinarySearchTree<int>.Node root) {
            if (root == null)
                return new Tuple<int, int>(int.MinValue, int.MinValue);

            //result from left subtree
            var leftResult = MaxSumAlternate(root.left);
            //result from right subtree
            var rightResult = MaxSumAlternate(root.right);
            //excluded max for current node
            var currentExcludedMax = Math.Max(Math.Max(leftResult.Item1, rightResult.Item1), leftResult.Item1 + rightResult.Item1);
            //current max for current node
            var includedMax = Math.Max(Math.Max(leftResult.Item2, rightResult.Item2), leftResult.Item2 + rightResult.Item2);
            includedMax = Math.Max(Math.Max(includedMax, root.data), includedMax + root.data);
            var currentMax = Math.Max(includedMax, currentExcludedMax);
            return new Tuple<int, int>(currentMax, currentExcludedMax);
        }
    }
}
