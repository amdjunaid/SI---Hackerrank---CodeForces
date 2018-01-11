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
            public int height;
            public int verticalLevel;

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

        public class Queue
        {
            T[] _arr;
            int f, r, _size = 0;

            public Queue(int size)
            {
                f = r = -1;
                _arr = new T[size];
                _size = 0;
            }

            public void Enqueue(T data)
            {
                if (!IsFull())
                {
                    r = (r + 1) % _arr.Length;
                    _arr[r] = data;
                    ++_size;
                }
            }

            private bool IsFull()
            {
                return _size == _arr.Length;
                //return (f + 1) % _arr.Length == r % _arr.Length;
            }

            public bool IsEmpty()
            {
                return _size == 0;
                //return (f == r) && r == -1;
            }

            public T Peek()
            {
                if (!IsEmpty())
                {
                    return _arr[f + 1];
                }
                return default(T);
            }

            public T Dequeue()
            {
                if (!IsEmpty())
                {
                    --_size;
                    return _arr[++f];
                }
                else
                    return default(T);
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

        public int Height(Node root)
        {
            if (root == null)
                return -1;
            int maxHeight = Math.Max(Height(root.left), Height(root.right));
            root.height = maxHeight == -1 ? 0 : maxHeight;
            return root.height + 1;
        }

        public bool IsBalancedBST(Node root)
        {
            if (root == null)
            {
                return true;
            }
            if (IsBalancedBST(root.left) && IsBalancedBST(root.right))
            {
                int leftHeight = 0, rightHeight = 0;
                if (root.left != null)
                {
                    leftHeight = root.left.height + 1;
                }
                if (root.right != null)
                {
                    rightHeight = root.right.height + 1;
                }
                return Math.Abs(leftHeight - rightHeight) <= 1;
            }
            return false;
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

        public int GetDepth(Node root, T data)
        {
            dynamic value = data;
            if (root == null)
            {
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

        public string LevelOrder(Node root)
        {
            StringBuilder levelOrder = new StringBuilder();
            Queue<Node> queue = new Queue<Node>(10000);
            queue.Enqueue(root);
            while (!queue.IsEmpty())
            {
                Node current = queue.Dequeue();
                if (current.left != null)
                    queue.Enqueue(current.left);
                if (current.right != null)
                    queue.Enqueue(current.right);
                if (queue.Peek() != null && queue.Peek().depth == current.depth)
                {
                    levelOrder.Append(current.data + " ");
                }
                else
                {
                    levelOrder.AppendLine(current.data.ToString());
                }
            }
            return levelOrder.ToString();
        }

        public string ZigZagBottomsUpTraverse(Node root, int n)
        {
            StringBuilder output = new StringBuilder();
            StringBuilder evenLevelNodes = new StringBuilder();
            Queue<Node> queue = new Queue<Node>(n);
            queue.Enqueue(root);
            while (!queue.IsEmpty())
            {
                var node = queue.Dequeue();
                //odd level
                if (node.depth % 2 == 0)
                {
                    output.Append(string.Join("", node.data.ToString().Reverse()) + " ");
                }
                else
                {
                    evenLevelNodes.Append(node.data + " ");
                    if (queue.Peek() != null)
                    {
                        //next element is of odd level
                        if (queue.Peek().depth % 2 == 0)
                        {
                            string evenLevelNodesStr = " " + evenLevelNodes.ToString().TrimEnd();
                            output.Append(string.Join("", evenLevelNodesStr.Reverse()));
                            evenLevelNodes = new StringBuilder();
                        }
                    }
                    else
                    {
                        string evenLevelNodesStr = " " + evenLevelNodes.ToString().TrimEnd();
                        evenLevelNodes = new StringBuilder();
                        output.Append(string.Join("", evenLevelNodesStr.Reverse()));
                    }
                }
                if (node.left != null)
                    queue.Enqueue(node.left);
                if (node.right != null)
                    queue.Enqueue(node.right);
            }
            return string.Join("", output.ToString().Trim().Reverse());
        }

        public string ZigZagTraverse(Node root, int n)
        {
            StringBuilder output = new StringBuilder();
            StringBuilder oddLevelNodes = new StringBuilder();
            Queue<Node> queue = new Queue<Node>(n);
            queue.Enqueue(root);
            while (!queue.IsEmpty())
            {
                var node = queue.Dequeue();
                //even level
                if (node.depth % 2 != 0)
                {
                    output.Append(node.data + " ");
                }
                else //odd level
                {
                    oddLevelNodes.Append(string.Join("", node.data.ToString().Reverse()) + " ");
                    if (queue.Peek() != null)
                    {
                        //next element is of even level
                        if (queue.Peek().depth % 2 != 0)
                        {
                            string oddLevelNodesStr = " " + oddLevelNodes.ToString().TrimEnd();
                            output.Append(string.Join("", oddLevelNodesStr.Reverse()));
                            oddLevelNodes = new StringBuilder();
                        }
                    }
                    else
                    {
                        string oddLevelNodesStr = " " + oddLevelNodes.ToString().TrimEnd();
                        oddLevelNodes = new StringBuilder();
                        output.Append(string.Join("", oddLevelNodesStr.Reverse()));
                    }
                }
                if (node.left != null)
                    queue.Enqueue(node.left);
                if (node.right != null)
                    queue.Enqueue(node.right);
            }
            return string.Join("", output.ToString().Trim());
        }

        public string BottomUpLevelOrder(Node root, int n)
        {
            StringBuilder output = new StringBuilder();
            StringBuilder sameLevelNodes = new StringBuilder();
            Queue<Node> queue = new Queue<Node>(n);
            queue.Enqueue(root);
            while (!queue.IsEmpty())
            {
                var node = queue.Dequeue();
                sameLevelNodes.Append(node.data + " ");
                if (queue.Peek() != null)
                {
                    //next element is of different level
                    if (queue.Peek().depth != node.depth)
                    {
                        string sameLevelNodesStr = sameLevelNodes.ToString().TrimEnd();
                        output.AppendLine(string.Join("", sameLevelNodesStr.Reverse()));
                        sameLevelNodes = new StringBuilder();
                    }
                }
                else
                {
                    string sameLevelNodesStr = sameLevelNodes.ToString().TrimEnd();
                    sameLevelNodes = new StringBuilder();
                    output.AppendLine(string.Join("", sameLevelNodesStr.Reverse()));
                }

                if (node.left != null)
                    queue.Enqueue(node.left);
                if (node.right != null)
                    queue.Enqueue(node.right);
            }
            return string.Join("", output.ToString().Trim().Reverse());
        }

        public bool IsFullBT(Node root)
        {
            if (root == null)
                return true;
            if (root.left == null && root.right == null)
            {
                return true;
            }
            if (root.left != null && root.right != null)
            {
                return IsFullBT(root.left) && IsFullBT(root.right);
            }
            else
            {
                return false;
            }
        }

        public int LeftView(Node root, Dictionary<int, int> levels, int currentMaxDepth)
        {
            if (root == null)
                return currentMaxDepth;
            dynamic value = root.data;
            currentMaxDepth = Math.Max(root.depth, currentMaxDepth);
            if (!levels.ContainsKey(root.depth))
            {
                levels.Add(root.depth, value);
            }
            var leftDepth = LeftView(root.left, levels, currentMaxDepth);
            var rightDepth = LeftView(root.right, levels, currentMaxDepth);
            return Math.Max(Math.Max(leftDepth, rightDepth), currentMaxDepth);
        }

        public int RightView(Node root, Dictionary<int, int> levels, int currentMaxDepth)
        {
            if (root == null)
                return currentMaxDepth;
            dynamic value = root.data;
            currentMaxDepth = Math.Max(root.depth, currentMaxDepth);
            if (!levels.ContainsKey(root.depth))
            {
                levels.Add(root.depth, value);
            }
            var rightDepth = RightView(root.right, levels, currentMaxDepth);
            var leftDepth = RightView(root.left, levels, currentMaxDepth);
            return Math.Max(Math.Max(leftDepth, rightDepth), currentMaxDepth);
        }

        public bool IsCompleteBT(Node root)
        {
            HashSet<int> indexedElements = new HashSet<int>();
            Queue<Node> que = new Queue<Node>(1000);
            que.Enqueue(root);
            int nodeSequentialNumber = 1, totalElements = 1;
            indexedElements.Add(1);
            while (!que.IsEmpty())
            {
                var node = que.Dequeue();
                if (node.left != null)
                {
                    que.Enqueue(node.left);
                    totalElements++;
                    indexedElements.Add(++nodeSequentialNumber);
                }
                else
                {
                    nodeSequentialNumber++;
                }
                if (node.right != null)
                {
                    que.Enqueue(node.right);
                    totalElements++;
                    indexedElements.Add(++nodeSequentialNumber);
                }
                else
                {
                    nodeSequentialNumber++;
                }
            }
            for (int i = 1; i <= totalElements; i++)
            {
                if (!indexedElements.Contains(i))
                    return false;
            }
            for (int i = totalElements + 1; i <= nodeSequentialNumber; i++)
            {
                if (indexedElements.Contains(i))
                    return false;
            }
            return true;
        }

        public void ComputeVerticalLevels(Node root, int verticalLevel)
        {
            if (root == null)
                return;
            root.verticalLevel = verticalLevel;
            ComputeVerticalLevels(root.left, verticalLevel + 1);
            ComputeVerticalLevels(root.right, verticalLevel - 1);
        }

        /// <summary>
        /// default level assuming one element always is 0
        /// </summary>
        /// <param name="root"></param>
        /// <param name="verticalLevel"></param>
        /// <returns></returns>
        public int GetMaxVerticalLevel(Node root)
        {
            if (root == null)
                return int.MinValue;
            return Math.Max(Math.Max(GetMaxVerticalLevel(root.left), GetMaxVerticalLevel(root.right)), root.verticalLevel);
        }

        /// <summary>
        /// default level assuming one element always is 0
        /// </summary>
        /// <param name="root"></param>
        /// <param name="verticalLevel"></param>
        /// <returns></returns>
        public int GetMinVerticalLevel(Node root)
        {
            if (root == null)
                return int.MaxValue;
            return Math.Min(Math.Min(GetMinVerticalLevel(root.left), GetMinVerticalLevel(root.right)), root.verticalLevel);
        }

        public void CombineNodesOfSameVerticalLevel(Node root, Dictionary<int, List<int>> nodesList)
        {
            if (root == null)
                return;
            CombineNodesOfSameVerticalLevel(root.left, nodesList);
            dynamic value = root.data;
            if (nodesList.ContainsKey(root.verticalLevel))
            {
                nodesList[root.verticalLevel].Add(value);
            }
            else
            {
                nodesList.Add(root.verticalLevel, new List<int> { value });
            }
            CombineNodesOfSameVerticalLevel(root.right, nodesList);
        }
    }
}
