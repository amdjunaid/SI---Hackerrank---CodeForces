using System;
using System.Linq;
using System.Text;

namespace SmartInterviewsBatch_6.Trees
{
    public class LeastCommonAncestor : ISolution
    {
        public static Parent[] parents;
        public override void Solve()
        {
            var t = ReadShort();
            while (t-- > 0)
            {
                var NandQ = ReadArrString().Select(short.Parse).ToArray();
                parents = new Parent[(int)1e4 + 1];
                var arr = ReadArrString().Select(int.Parse).ToArray();
                LCA(arr, NandQ[1]);
                output.AppendLine();
            }
            Console.Write(output);
        }

        private void LCA(int[] arr, short Q)
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                tree.root = tree.Insert(tree.root, arr[i]);
            }
            CreateParentArr(tree.root, -1, -1);
            while (Q-- > 0)
            {
                var UandV = ReadArrString().Select(int.Parse).ToArray();
                int u = UandV[0], v = UandV[1];
                if (u == v)
                    output.Append(u+" ");
                else
                {
                    if (parents[u].depth > parents[v].depth)
                    {
                        int extraDepth = parents[u].depth - parents[v].depth;
                        while (extraDepth-- > 0)
                        {
                            u = parents[u].parent;
                        }
                    }
                    else if (parents[u].depth < parents[v].depth)
                    {
                        int extraDepth = parents[v].depth - parents[u].depth;
                        while (extraDepth-- > 0)
                        {
                            v = parents[v].parent;
                        }
                    }
                    if (u == v)
                    {
                        output.Append(u + " ");
                    }
                    else {
                        while (parents[u].parent != parents[v].parent)
                        {
                            u = parents[u].parent;
                            v = parents[v].parent;
                        }
                        output.Append(parents[u].parent + " ");
                    }
                }
            }
        }

        public void CreateParentArr(BinarySearchTree<int>.Node root, int parent, int depth)
        {
            if (root == null)
                return;
            parents[root.data] = new Parent
            {
                parent = parent,
                depth = depth + 1
            };
            CreateParentArr(root.left, root.data, depth + 1);
            CreateParentArr(root.right, root.data, depth + 1);
        }
    }

    public class Parent
    {
        public int parent { get; set; }
        public int depth { get; set; }
    }
}
