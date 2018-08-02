using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A20J.Ladders._13
{
    public class ArrayModified : ISolution
    {
        public override void Solve()
        {
            var n = ReadInt();
            var arr = ReadArrString().Select(int.Parse).ToArray();
            SortedDictionary<int, HashSet<int>> sets = new SortedDictionary<int, HashSet<int>>();
            for (int i = 0; i < arr.Length; i++) {
                if (arr[i] < 0)
                {
                    if (!sets.ContainsKey(1))
                    {
                        sets.Add(1, new HashSet<int>());
                    }
                    if (!sets[1].Contains(arr[i]))
                    {
                        sets[1].Add(arr[i]);
                    }
                }
                else if (arr[i] == 0)
                {
                    if (!sets.ContainsKey(3))
                    {
                        sets.Add(3, new HashSet<int>());
                    }
                    if (!sets[3].Contains(arr[i]))
                    {
                        sets[3].Add(arr[i]);
                    }
                }
                else
                {
                    if (!sets.ContainsKey(2))
                    {
                        sets.Add(2, new HashSet<int>());
                    }
                    if (!sets[2].Contains(arr[i]))
                    {
                        sets[2].Add(arr[i]);
                    }
                }
            }
            if (!sets.ContainsKey(2) || sets[2].Count==0) {
                if (!sets.ContainsKey(2))
                {
                    sets.Add(2, new HashSet<int>());
                }
                var enumerater = sets[1].GetEnumerator();
                int cnt = 0;
                var removedArr = new int[2];
                while (enumerater.MoveNext() && cnt<2) {
                    sets[2].Add(enumerater.Current);
                    removedArr[cnt++] = enumerater.Current;
                }
                while (cnt > 0) {
                    sets[1].Remove(removedArr[--cnt]);
                }
            }
            if (sets[1].Count % 2 == 0)
            {
                var x = sets[1].First();
                sets[3].Add(x);
                sets[1].Remove(x);
            }
            var setNos = sets.GetEnumerator();
            while (setNos.MoveNext()) {
                output.Append(sets[setNos.Current.Key].Count + " ");
                var elementsEnum = sets[setNos.Current.Key].GetEnumerator();
                while (elementsEnum.MoveNext()) {
                    output.Append(elementsEnum.Current + " ");
                }
                output.AppendLine();
            }
            Console.Write(output);
        }
    }
}
