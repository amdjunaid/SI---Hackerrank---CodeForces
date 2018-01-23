using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewBit.Trees
{
    public class PreOrderTraversal : ISolution
    {
        public override void Solve()
        {
            var arr = ReadArrString().Select(int.Parse).ToList();

        }

        public List<int> preorderTraversal(TreeNode A)
        {
            var list = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(A);
            while (stack.Count != 0)
            {
                var node = stack.Pop();
                if (node != null)
                {
                    list.Add(node.val);
                }
                if (node.right != null)
                    stack.Push(node.right);
                if (node.left != null)
                    stack.Push(node.left);
            }
            return list;
        }
    }
}
