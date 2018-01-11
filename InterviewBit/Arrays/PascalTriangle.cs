using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewBit.Arrays
{
    public class PascalTriangle : ISolution
    {
        public override void Solve()
        {
            int n = ReadInt();
            GeneratePascalTriangle(n);
        }

        private List<List<int>> GeneratePascalTriangle(int n)
        {
            List<List<int>> finalMatrix = new List<List<int>>();
            int[,] matrix = new int[n, n];
            for (int i = 0; i < n; i++) {
                matrix[i, 0] = matrix[i,i] = 1;
            }
            for (int i = 2; i < n; i++) {
                for (int j = 1; j < i; j++) {
                    matrix[i, j] = matrix[i - 1, j] + matrix[i - 1, j - 1];
                }
            }
            for (int i = 0; i < n; i++) {
                finalMatrix.Insert(i, new List<int>());
                for (int j = 0; j <= i; j++) {
                    finalMatrix[i].Add(matrix[i, j]);
                }
            }
            return finalMatrix;
        }
    }
}
