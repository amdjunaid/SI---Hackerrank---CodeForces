using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6
{
    public class DistinctElementsInWindow : ISolution
    {
        public override void Solve()
        {
            short t = ReadShort();
            while (t-- > 0)
            {
                short[] NandK = ReadArrString().Select(short.Parse).ToArray();
                short[] elements = ReadArrString().Select(short.Parse).ToArray();
                noOfElements(elements, NandK[1]);
            }
            Console.Write(output);
        }

        private void noOfElements(short[] elements, short k)
        {
            if (elements.Length == 1) {
                output.AppendLine("1");
                return;
            }
            Dictionary<short, short> window = new Dictionary<short, short>();
            for (int i = 0; i < k; i++)
            {
                if (window.ContainsKey(elements[i]))
                {
                    window[elements[i]]++;
                }
                else
                {
                    window.Add(elements[i], 1);
                }
            }
            output.Append(window.Keys.Count+" ");
            for (int i = k; i < elements.Length; i++)
            {
                if (window.ContainsKey(elements[i - k]))
                {
                    if (window[elements[i - k]] > 1)
                    {
                        window[elements[i - k]]--;
                    }
                    else
                    {
                        window.Remove(elements[i - k]);
                    }
                }
                if (window.ContainsKey(elements[i]))
                {
                    window[elements[i]]++;
                }
                else {
                    window.Add(elements[i], 1);
                }
                output.Append(window.Keys.Count + " ");
            }
            output.AppendLine();
        }
    }
}
