using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewBit.Backtracking
{
    public class Subsets2 : ISolution
    {
        public override void Solve()
        {
            var arr = ReadArrString().Select(int.Parse).ToList();
            var li = subsetsWithDup(arr);
        }

        public List<List<int>> subsetsWithDup(List<int> A)
        {
            List<List<int>> subsets = new List<List<int>>();
            int subsetsLength = 1 << A.Count;
            for (int i = 0; i < subsetsLength; i++)
            {
                var currentSubset = new List<int>();
                if (i != 0) {
                    int subsetSize = (int)System.Math.Ceiling(System.Math.Log(i, 2));
                    for (int j = 0; j <= subsetSize; j++)
                    {
                        if ((i & (1 << j)) != 0)
                        {
                            currentSubset.Add(A[j]);
                        }
                    }
                }
                subsets.Add(currentSubset);
            }
            int[][] subsetArr = new int[subsets.Count][];
            for (int i = 0; i < subsets.Count; i++)
            {
                subsetArr[i] = new int[subsets[i].Count];
                for (int j = 0; j < subsets[i].Count; j++)
                {
                    subsetArr[i][j] = subsets[i][j];
                }
            }
            Array.Sort(subsetArr, delegate (int[] x, int[] y)
            {
                for (int i = 0; i < System.Math.Min(x.Length, y.Length); i++)
                {
                    if (x[i].Equals(y[i]))
                        continue;
                    return x[i].CompareTo(y[i]);
                }
                return x.Length.CompareTo(y.Length);
            });
            subsets = new List<List<int>>();
            for (int i = 0; i < subsetArr.Length; i++)
            {
                subsets[i] = new List<int>(subsetArr[i].Length);
                for (int j = 0; j < subsetArr[i].Length; j++)
                {
                    subsets[i].Add(subsetArr[i][j]);
                }
            }
            return subsets;
        }
    }
}
