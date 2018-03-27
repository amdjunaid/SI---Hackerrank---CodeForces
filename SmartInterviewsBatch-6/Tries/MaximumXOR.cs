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
            return ans;
        }

        private int GetMaximumPossibleNumber(int n, Trie<byte> root)
        {
            int bestAvailablePair = 0;
            var rootNode = root.root;
            for (int i = 20; i >= 0; i--)
            {
                byte ithBitOfN = (byte)((n & (1 << i)) != 0 ? 1 : 0);
                // if ithBit is set, it searches for unset bit child and updates root, else, the other child.
                // if ithBit is unset, it searches for set bit child and updates the pair value and updates root with set bit child, else the other child.
                if (rootNode.children.ContainsKey((byte)(ithBitOfN ^ 1)))
                {
                    bestAvailablePair |= (1 ^ ithBitOfN) << i;
                    rootNode = rootNode.children[(byte)(ithBitOfN ^ 1)];
                }
                else
                {
                    bestAvailablePair |= ithBitOfN << i;
                    rootNode = rootNode.children[ithBitOfN];
                }
            }
            return bestAvailablePair ^ n;
        }

        private byte[] GetBinaryRep(int n)
        {
            byte[] binaryRep = new byte[21];
            for (int j = 20; j >= 0; j--)
            {
                binaryRep[20 - j] = (byte)((n & (1 << j)) != 0 ? 1 : 0);
            }
            return binaryRep;
        }
    }
}
