using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.Trees
{
    public class SumOfNumbersFromRootToLeaf : ISolution
    {
        static long sum = 0;
        static int modulo = (int)1e9 + 7;
        public override void Solve()
        {
            short t = ReadShort();
            while (t-- > 0)
            {
                ReadShort();
                var arr = ReadArrString().Select(int.Parse).ToArray();
                output.AppendLine(SumOfNumbers(arr).ToString());
            }
            Console.Write(output);
        }

        private long SumOfNumbers(int[] arr)
        {
            sum = 0;
            var tree = new BinarySearchTree<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                tree.root = tree.Insert(tree.root, arr[i]);
            }
            SumOfNumbers(tree.root, 0);
            return sum;
        }

        private void SumOfNumbers(BinarySearchTree<int>.Node root, long value)
        {
            if (root == null)
                return;
            int noOfDigits = 0;
            if (root.data != 0)
            {
                int n = root.data;
                while (n > 0)
                {
                    n /= 10;
                    noOfDigits++;
                }
            }
            else {
                noOfDigits = 1;
            }
            long newValue = (long)(value * Math.Pow(10, noOfDigits) + root.data) % modulo;
            if (root.left != null || root.right != null)
            {
                if (root.left != null)
                    SumOfNumbers(root.left, newValue);
                if (root.right != null)
                    SumOfNumbers(root.right, newValue);
            }
            else
            {
                sum = (sum + newValue) % modulo;
            }
        }
    }
}
