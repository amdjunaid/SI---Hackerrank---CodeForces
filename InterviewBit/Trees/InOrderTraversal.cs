using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewBit.Trees
{
    public class InOrderTraversal : ISolution
    {
        public override void Solve()
        {
            throw new NotImplementedException();
        }

        public List<int> inorderTraversal(TreeNode A)
        {
            HashSet<TreeNode> poppedNodes = new HashSet<TreeNode>();
            var list = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();

            if (A != null)
            {
                poppedNodes.Add(A);
                if (A.right != null)
                {
                    stack.Push(A.right);
                }
                stack.Push(A);
                if (A.left != null)
                {
                    stack.Push(A.left);
                }
            }

            while (stack.Count != 0)
            {
                var node = stack.Pop();
                if (!poppedNodes.Contains(node))
                {
                    if (node.right != null || node.left != null)
                    {
                        if (node.right != null)
                            stack.Push(node.right);
                        poppedNodes.Add(node);
                        stack.Push(node);
                        if (node.left != null)
                            stack.Push(node.left);
                    }
                    else
                    {
                        list.Add(node.val);
                    }
                    poppedNodes.Add(node);
                }
                else
                {
                    list.Add(node.val);
                }
            }
            return list;
        }
    }
}
