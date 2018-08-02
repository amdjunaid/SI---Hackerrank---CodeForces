using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techgig.Practise.FloodFill
{
    public class MazeGame : ISolution
    {
        public override void Solve()
        {
            var PandQ = ReadArrString().Select(short.Parse).ToArray();
            var matrix = new bool[PandQ[0]][];
            for (int i = 0; i < PandQ[0]; i++)
            {
                matrix[i] = ReadArrString().Select(x => x.Equals("1") ? true : false).ToArray();
            }
            for (int i = 1; i < PandQ[0]; i++)
            {
                if (matrix[i][0])
                {
                    matrix[i][0] = matrix[i - 1][0] ? true : false;
                }
            }
            for (int j = 1; j < PandQ[1]; j++)
            {
                if (matrix[0][j])
                {
                    matrix[0][j] = matrix[0][j - 1] ? true : false;
                }
            }
            var dx = new int[] { -1, 0 };
            var dy = new int[] { 0, -1 };
            for (int i = 1; i < PandQ[0]; i++)
            {
                for (int j = 1; j < PandQ[1]; j++)
                {
                    if (matrix[i][j])
                    {
                        bool isVisitableFromNeighbors = false;
                        for (int k = 0; k < 2; k++)
                        {
                            if (matrix[i + dx[k]][j + dy[k]])
                                isVisitableFromNeighbors = true;
                        }
                        matrix[i][j] = isVisitableFromNeighbors ? true : false;
                    }
                }
            }
            Console.Write(matrix[PandQ[0] - 1][PandQ[1] - 1] ? "Yes" : "No");
        }
    }
}
