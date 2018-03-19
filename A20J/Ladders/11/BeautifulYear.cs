using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A20J.Ladders._11
{
    public class BeautifulYear : ISolution
    {
        public override void Solve()
        {
            var n = ReadInt();
            HashSet<int> keys = new HashSet<int>();

            for (int i = n + 1; ; i++)
            {
                var arr = new List<int>();
                var temp = i;
                while (temp > 0)
                {
                    int rem = temp % 10;
                    arr.Add(rem);
                    temp /= 10;
                }
                arr.Sort();
                bool isUnique = true;
                for (int j = 0; j < arr.Count - 1; j++)
                {
                    if (arr[j] == arr[j + 1])
                    {
                        isUnique = false;
                        break;
                    }
                }
                if (isUnique)
                {
                    Console.Write(i);
                    break;
                }
            }
        }
    }
}
