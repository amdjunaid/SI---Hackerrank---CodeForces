using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codeforces.Div2.Hello2018
{
    public class ChristmasSpruce : ISolution
    {
        public override void Solve()
        {
            short n = ReadShort();
            Dictionary<short, List<short>> tree = new Dictionary<short, List<short>>();
            tree.Add(1, new List<short>());
            for (short i = 2; i <= n; i++)
            {
                short parentIndex = ReadShort();
                if (tree.ContainsKey(parentIndex))
                {
                    tree[parentIndex].Add(i);
                }
                else
                {
                    tree.Add(parentIndex, new List<short> {
                        i
                    });
                }
            }
            bool isSpruce = true;
            var parents = tree.Keys.ToArray();
            for (short i = 0; i < parents.Length; i++)
            {
                var children = tree[parents[i]];
                short leafChildrenCount = (short)children.Count;
                if (leafChildrenCount < 3) {
                    isSpruce = false;
                    break;
                }
                for (int j = 0; j < children.Count; j++)
                {
                    if (tree.ContainsKey(children[j])) {
                        leafChildrenCount--;
                    }
                    if (leafChildrenCount < 3) {
                        isSpruce = false;
                        break;
                    }
                }
            }
            Console.Write(isSpruce?"Yes":"No");
        }
    }
}
