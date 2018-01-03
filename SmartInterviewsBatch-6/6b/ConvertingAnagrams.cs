using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6._6b
{
    public class ConvertingAnagrams : ISolution
    {
        public override void Solve()
        {
            short t = ReadShort();
            while (t-- > 0)
            {
                string[] AandB = ReadArrString();
                output.AppendLine(MinimumNoOfDeletions(AandB[0], AandB[1]).ToString());
            }
            Console.Write(output);
        }

        private int MinimumNoOfDeletions(string A, string B)
        {
            Dictionary<char, int> hMA = new Dictionary<char, int>();
            Dictionary<char, int> hMB = new Dictionary<char, int>();
            foreach (var chr in A)
            {
                if (hMA.ContainsKey(chr))
                {
                    hMA[chr]++;
                }
                else
                {
                    hMA.Add(chr, 1);
                }
            }
            foreach (var chr in B)
            {
                if (hMB.ContainsKey(chr))
                {
                    hMB[chr]++;
                }
                else
                {
                    hMB.Add(chr, 1);
                }
            }
            int minNoOfDeletions = 0;
            foreach (var chr in hMA.Keys)
            {
                if (hMB.ContainsKey(chr))
                {
                    minNoOfDeletions += hMB[chr] != hMA[chr] ? Math.Abs(hMB[chr] - hMA[chr]) : 0;
                    hMB.Remove(chr);
                }
                else {
                    minNoOfDeletions += hMA[chr];
                }
            }
            foreach (var freq in hMB.Values)
            {
                minNoOfDeletions += freq;
            }
            return minNoOfDeletions;
        }
    }
}
