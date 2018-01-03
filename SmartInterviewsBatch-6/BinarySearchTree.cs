using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6
{
    public class BinarySearchTree<T>
    {
        public class Node
        {
            public T data;
            public Node left;
            public Node right;
            public int depth;

            public Node(T data)
            {
                this.data = data;
                left = right = null;
            }

            public Node()
            {
                left = right = null;
            }
        }

        public Node root;

        public BinarySearchTree()
        {
            root = null;
        }

        public Node Insert(Node root, T data)
        {
            dynamic value = data;
            if (root == null)
            {
                return new Node(data);
            }
            if (root.data < value)
            {
                root.right = Insert(root.right, data);
            }
            else if (root.data > value)
            {
                root.left = Insert(root.left, data);
            }
            return root;
        }

        public void InOrder(Node root, StringBuilder output)
        {
            if (root == null)
            {
                return;
            }
            InOrder(root.left, output);
            output.Append(root.data + " ");
            InOrder(root.right, output);
        }

        public void PreOrder(Node root, StringBuilder output)
        {
            if (root == null)
            {
                return;
            }
            output.Append(root.data + " ");
            PreOrder(root.left, output);
            PreOrder(root.right, output);
        }

        public void PostOrder(Node root, StringBuilder output)
        {
            if (root == null)
            {
                return;
            }
            PostOrder(root.left, output);
            PostOrder(root.right, output);
            output.Append(root.data + " ");
        }

        public int Height(Node root, int height)
        {
            if (root == null)
                return -1;
            return Math.Max(Math.Max(Height(root.left, height + 1), Height(root.right, height + 1)), height);
        }

        public int Depth(Node root, int depth)
        {
            if (root == null)
            {
                return -1;
            }
            root.depth = ++depth;
            Depth(root.left, depth);
            Depth(root.right, depth);
            return root.depth;
        }

        public int GetDepth(Node root, T data) {
            dynamic value = data;
            if (root == null) {
                return -1;
            }
            if (root.data < value)
            {
                return GetDepth(root.right, data);
            }
            else if (root.data > value)
            {
                return GetDepth(root.left, data);
            }
            else
                return root.depth;
        }

        public string LevelOrder(Node root) {
            StringBuilder levelOrder = new StringBuilder();
            Queue<Node> queue = new Queue<Node>(10000);
            queue.Enqueue(root);
            while (!queue.IsEmpty()) {
                Node current = queue.Dequeue();
                if (current != null)
                {
                    levelOrder.Append(current.data.ToString()+" ");
                    queue.Enqueue(null);
                    if (current.left != null)
                        queue.Enqueue(current.left);
                    if (current.right != null)
                        queue.Enqueue(current.right);
                }
                else {
                    levelOrder.AppendLine();
                }
            }
            return levelOrder.ToString();
        }
    }
}
