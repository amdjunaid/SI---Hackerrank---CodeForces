using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekForGeeks.MustDoTopicWise.Arrays
{
    public class SortArrayOfZeroesOnesTwos : ISolution
    {
        public override void Solve()
        {
            var t = ReadSByte();
            while (t-- > 0) {
                var n = ReadByte();
                var arr = ReadArrString().Select(byte.Parse).ToArray();
                var cnt = new byte[3];
                for (int i = 0; i < arr.Length; i++) {
                    cnt[arr[i]]++;
                }
                int k = 0;
                for (byte i = 0; i < 3; i++) {
                    for (int j = 0; j < cnt[i]; j++) {
                        output.Append(i + " ");
                    }
                }
                output.AppendLine();
            }
            Console.Write(output);
        }
    }
}
