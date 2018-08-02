using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A20J.Ladders._13
{
    public class Arrays : ISolution
    {
        public override void Solve()
        {
            var n = ReadInt();
            var arr = ReadArrString().Select(int.Parse).ToArray();
            var prefixNgtv = new int[arr.Length];
            prefixNgtv[0] = arr[0] < 0 ? 1 : 0;
            for (int i = 1; i < arr.Length; i++)
            {
                prefixNgtv[i] = prefixNgtv[i - 1] + arr[i] < 0 ? 1 : 0;
            }
            int thirdStStrt = arr.Length - 1, scndStStrt = 0;
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (arr[i] == 0)
                    thirdStStrt = i;
            }
            for (int i = thirdStStrt - 1; i > 0; i--)
            {
                    var noOfNgtvsIn2nd = prefixNgtv[thirdStStrt - 1] - prefixNgtv[i - 1];
                    var noOfNgtvsIn1st = prefixNgtv[i - 1];
                    if (noOfNgtvsIn2nd % 2 == 0 && noOfNgtvsIn1st % 2 != 0) {
                        scndStStrt = i;
                        break;
                    }
            }
            output.Append(scndStStrt + " ");
            for (int i = 0; i != scndStStrt; i++) {
                output.Append(arr[i] + " ");
            }
            output.Append("\n");
            output.Append(thirdStStrt - scndStStrt + " ");
            for (int i = scndStStrt; i != thirdStStrt; i++)
            {
                output.Append(arr[i] + " ");
            }
            output.Append("\n");
            output.Append(arr.Length - thirdStStrt + " ");
            for (int i = thirdStStrt; i <arr.Length; i++)
            {
                output.Append(arr[i] + " ");
            }
            Console.Write(output);
        }
    }
}
