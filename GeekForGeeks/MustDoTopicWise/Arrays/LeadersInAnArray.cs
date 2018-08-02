using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekForGeeks.MustDoTopicWise.Arrays
{
    public class LeadersInAnArray : ISolution
    {
        public override void Solve()
        {
            var t = ReadByte();
            while (t-- > 0) {
                var n = ReadInt();
                var arr = ReadArrString().Select(int.Parse).ToArray();
                var stk = new Stack<int>();
                var ans = new int[arr.Length];
                HashSet<int> leaders = new HashSet<int>();
                for (int i = arr.Length - 1; i >= 0; i--) {
                    int position = arr.Length;
                    while (stk.Count != 0) {
                        if (arr[stk.Peek()] <= arr[i])
                        {
                            stk.Pop();
                        }
                        else {
                            position = stk.Peek();
                            break;
                        }
                    }
                    ans[i] = position;
                    stk.Push(i);
                }
                for (int i = 0; i < arr.Length; i++) {
                    if (ans[i] == arr.Length) {
                        leaders.Add(arr[i]);
                    }
                }
                var enumerater = leaders.GetEnumerator();
                while (enumerater.MoveNext()) {
                    output.Append(enumerater.Current + " ");
                }
                output.AppendLine();
            }
            Console.Write(output);
        }
    }
}
