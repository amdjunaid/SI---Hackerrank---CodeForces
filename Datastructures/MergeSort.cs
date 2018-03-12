using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datastructures
{
    public class MergeSort
    {
        public void MS(int[] A, int lo, int hi) {
            if (lo == hi)
                return;
            int mid = (lo + hi) / 2;
            MS(A, lo, mid);
            MS(A, mid + 1, hi);
            Merge(A, lo, mid, hi);    
        }

        public void Merge(int[] A, int lo, int mid, int hi) {
            int[] temp = new int[hi - lo + 1];
            int p1 = lo, p2 = mid + 1, k = 0;
            while (p1 <= mid && p2 <= hi) {
                temp[k++] = A[p1] <= A[p2] ? A[p1++] : A[p2++];
            }
            while (p1 <= mid)
                temp[k++] = A[p1++];
            while (p2 <= hi)
                temp[k++] = A[p2++];
            for (int i = 0; i < temp.Length; i++) {
                A[i + lo] = temp[i];
            }
        }
    }
}
