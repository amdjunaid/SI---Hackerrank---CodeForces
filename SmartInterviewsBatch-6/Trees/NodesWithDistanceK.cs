using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.Trees
{
    public class NodesWithDistanceK : ISolution
    {
        static int count = 0;
        public override void Solve()
        {
            var t = ReadShort();
            while (t-- > 0)
            {
                var NandSandK = ReadArrString().Select(int.Parse).ToArray();
                var arr = ReadArrString().Select(int.Parse).ToArray();
                output.AppendLine(NumberOfNodes(arr, NandSandK[1], NandSandK[2]).ToString());
            }
            Console.Write(output);
        }

        private int NumberOfNodes(int[] arr, int S, int K)
        {
            count = 0;
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                tree.root = tree.Insert(tree.root, arr[i]);
            }
            NodesWithKD(tree.root, false, K, S);
            return count;
        }

        private Tuple<bool, int> NodesWithKD(BinarySearchTree<int>.Node root, bool found, int K, int S)
        {
            if (root == null)
                return new Tuple<bool, int>(false, -1);
            if (K == 0)
            {
                count++;
                return new Tuple<bool, int>(false, -1);
            }
            if (found || S == root.data)
            {
                NodesWithKD(root.left, true, K - 1, S);
                NodesWithKD(root.right, true, K - 1, S);
                return new Tuple<bool, int>(true, K - 1);
            }
            else
            {
                if (S < root.data)
                {
                    var result = NodesWithKD(root.left, false, K, S);
                    if (result.Item1)
                    {
                        if (result.Item2 > 0)
                        {
                            NodesWithKD(root.right, true, result.Item2 - 1, S);
                            return new Tuple<bool, int>(true, result.Item2 - 1);
                        }
                        else if (result.Item2 == 0)
                            count++;
                        return new Tuple<bool, int>(true, result.Item2 - 1);
                    }
                    else {
                        return new Tuple<bool, int>(false, -1);
                    }
                }
                else
                {
                    var result = NodesWithKD(root.right, false, K, S);
                    if (result.Item1)
                    {
                        if (result.Item2 > 0)
                        {
                            NodesWithKD(root.left, true, result.Item2 - 1, S);
                            return new Tuple<bool, int>(true, result.Item2 - 1);
                        }
                        else if (result.Item2 == 0)
                            count++;
                        return new Tuple<bool, int>(true, result.Item2 - 1);
                    }
                    else
                    {
                        return new Tuple<bool, int>(false, -1);
                    }
                }
            }
        }
    }
}
