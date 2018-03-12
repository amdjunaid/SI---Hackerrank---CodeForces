using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datastructures;
namespace SmartInterviewsBatch_6.Tries
{
    public class MaximumXOR : ISolution
    {
        public override void Solve()
        {
            var t = ReadByte();
            while (t-- > 0)
            {
                ReadInt();
                var arr = ReadArrString().Select(int.Parse).ToArray();
                output.AppendLine(MaximumNumber(arr).ToString());
            }
            Console.Write(output);
        }

        private int MaximumNumber(int[] arr)
        {
            int ans = int.MinValue;
            Trie<byte> root = new Trie<byte>();
            for (int i = 0; i < arr.Length; i++)
            {
                byte[] binaryRep = GetBinaryRep(arr[i]);
                root.Insert(binaryRep);
            }
            for (int i = 0; i < arr.Length; i++)
            {
                ans = Math.Max(ans, GetMaximumPossibleNumber(arr[i], root));
            }
            return  ans;
        }

        private int GetMaximumPossibleNumber(int n, Trie<byte> root)
        {
            int maxPossible = 0;
            var rootNode = root.root;
            for (int i = 20; i >= 0; i--)
            {
                byte ithBitToSearchFor = (byte)((n & (1 << i)) != 0 ? 0 : 1);
                if (rootNode.children.ContainsKey(ithBitToSearchFor))
                {
                    maxPossible |= 1 << i;
                }
                else
                {
                    rootNode = rootNode.children[(byte)(ithBitToSearchFor ^ 1)];
                }
            }
            return 0;
        }

        private byte[] GetBinaryRep(int n)
        {
            byte[] binaryRep = new byte[21];
            for (int j = 20; j >= 0; j--)
            {
                binaryRep[20 - j] = (byte)(n & (1 << j));
            }
            return binaryRep;
        }
    }
}
