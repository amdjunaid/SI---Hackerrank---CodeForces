using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekForGeeks.MustDoTopicWise.Arrays
{
    public class EquillibriumPt : ISolution
    {
        static int[] prefix = null;
        public override void Solve()
        {
            var t = ReadByte();
            while (t-- > 0) {
                var n = ReadInt();
                var arr = ReadArrString().Select(int.Parse).ToArray();
                prefix = new int[arr.Length];
                prefix[0] = arr[0];
                int i = 1;
                for (; i < arr.Length; i++) {
                    prefix[i] = arr[i] + prefix[i - 1];
                }
                bool found = false;
                i = 0;
                for (; i < arr.Length; i++) {
                    var ls = leftSum(i);
                    var rs = rightSum(i);
                    if (ls == rs)
                    {
                        found = true;
                        break;
                    }
                }
                if (found)
                    output.AppendLine((i+1).ToString());
                else
                    output.AppendLine("-1");
            }
            Console.Write(output);
        }

        public int leftSum(int i) {
            if (i == 0)
                return 0;
            return prefix[i - 1];
        }

        public int rightSum(int i)
        {
            if (i == prefix.Length - 1)
                return 0;
            return prefix[prefix.Length -1] - prefix[i];
        }
    }
}
