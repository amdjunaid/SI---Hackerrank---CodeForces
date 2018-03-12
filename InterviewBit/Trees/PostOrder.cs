using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewBit.Trees
{
    public class PostOrder : ISolution
    {
        public override void Solve()
        {
            
        }

        public List<int> postorderTraversal(TreeNode A)
        {
            HashSet<TreeNode> poppedNodes = new HashSet<TreeNode>();
            var list = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();

            if (A != null) {
                poppedNodes.Add(A);
                if (A.right != null)
                {
                    stack.Push(A.right);
                }
                if (A.left != null)
                {
                    stack.Push(A.left);
                }
                stack.Push(A);
            }
            
            while (stack.Count != 0)
            {
                var node = stack.Peek();
                if (!poppedNodes.Contains(node))
                {
                    if (node.right != null || node.left != null)
                    {
                        if (node.right != null)
                            stack.Push(node.right);
                        if (node.left != null)
                            stack.Push(node.left);
                    }
                    else
                    {
                        var poppedNode = stack.Pop();
                        list.Add(poppedNode.val);
                    }
                    poppedNodes.Add(node);
                }
                else {
                    var poppedNode = stack.Pop();
                    list.Add(poppedNode.val);
                }
            }
            return list;
        }
    }
}
