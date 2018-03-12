using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.Trees
{
    public class PreOrderInOrderToPostOrder : ISolution
    {
        static int index = 0;
        public override void Solve()
        {
            var t = ReadShort();
            while (t-- > 0)
            {
                ReadShort();
                var pre = ReadArrString().Select(int.Parse).ToArray();
                var ino = ReadArrString().Select(int.Parse).ToArray();
                index = 0;
                Node<int> root = ConstructTree(0, pre.Length - 1, pre, ino);
                PostOrder(root);
                output.AppendLine();
            }
            Console.Write(output);
        }

        private Node<int> ConstructTree(int lo, int hi, int[] pre, int[] ino)
        {
            if (lo > hi) return null;
            var position = getIndex(ino, lo, hi, pre[index]);
            Node<int> newNode = new Node<int>(pre[index]);
            index++;
            newNode.prev = ConstructTree(lo, position - 1, pre, ino);
            newNode.next = ConstructTree(position + 1, hi, pre, ino);
            return newNode;
        }

        private int getIndex(int[] ino, int lo, int hi, int key)
        {
            int index = lo;
            for (int i = index + 1; i <= hi; i++)
            {
                if (ino[i] == key)
                {
                    index = i;
                }
            }
            return index;
        }

        public void PostOrder(Node<int> root)
        {
            if (root == null)
                return;
            PostOrder(root.prev);
            PostOrder(root.next);
            output.Append(root.data + " ");
        }
    }
}
