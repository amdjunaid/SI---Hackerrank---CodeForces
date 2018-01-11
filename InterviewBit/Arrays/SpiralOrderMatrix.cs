using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewBit.Arrays
{
    public class SpiralOrderMatrix : ISolution
    {
        public override void Solve()
        {
            int n = ReadInt();
            ConstructSpiralMatrix(n);
        }

        private List<List<int>> ConstructSpiralMatrix(int n)
        {
            int num = 0, limit = n, j = 0, tempI = 0, tempJ = 0;
            int[,] matrix = new int[n, n];
            for (int k = 0; k < limit; k++, limit--)
            {
                // top horizontal line
                j = k;
                while (j < limit)
                {
                    matrix[k, j++] = ++num;
                }
                //right most column
                tempI = k + 1;

                while (tempI < limit) {
                    matrix[tempI++, limit - 1] = ++num;
                }
                //bottom horizontal line
                tempI--;
                tempJ = tempI-1;
                while (tempJ >= k) {
                    matrix[limit - 1, tempJ--] = ++num;
                }
                //left most column
                tempI--;
                while (tempI > k) {
                    matrix[tempI--, k] = ++num;
                }
            }
            List<List<int>> finalSpiralMatrix = new List<List<int>>();
            for (int i = 0; i < n; i++)
            {
                finalSpiralMatrix.Insert(i,new List<int>());
                for (j = 0; j < n; j++)
                {
                    finalSpiralMatrix[i].Add(matrix[i, j]);
                    //Console.Write(matrix[i, j] + " ");
                }
                //Console.WriteLine();
            }
            return finalSpiralMatrix;
        }
    }
}
