using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codeforces.Div2.Round448
{
    public class XKSegments : ISolution
    {
        private int count;

        public override void Solve()
        {
            var NXK = ReadArrString().Select(int.Parse).ToArray();
            var elements = ReadArrString().Select(int.Parse).ToArray();
            NoOfXKSegments(elements, NXK[0], NXK[1], NXK[2]);
            Console.Write(count);
        }

        private void NoOfXKSegments(int[] elements, int n, int x, int k)
        {
            Array.Sort(elements);
            int p = 0;
            while (p < elements.Length)
            {
                int fi, li;
                fi = FindFirstIndex(elements, p, p, k);
                if (fi != -1)
                {
                    li = FindLastIndex(elements, p, fi, k);
                    if (countDivisibles(elements[p], elements[fi], x) == NoOfElements(elements, p, fi))
                    {
                        if (countDivisibles(elements[p], elements[li], x) == NoOfElements(elements, p, li))
                        {
                            count += li - fi + 1;
                        }
                    }
                }
                p++;
            }
        }

        private int NoOfElements(int[] arr, int startIndex, int endIndex)
        {
            return arr[endIndex] - arr[startIndex] - (startIndex == endIndex ? 0 : 1);
        }

        private int countDivisibles(int A, int B, int M)
        {
            // Add 1 explicitly as A is divisible by M
            if (A % M == 0)
                return (B / M) - (A / M) + 1;

            // A is not divisible by M
            return (B / M) - (A / M);
        }

        private int FindLastIndex(int[] arr, int p, int startIndex, int k)
        {
            int liIndex = 0;
            bool found = false;
            int lo = startIndex, hi = arr.Length - 1, mid = 0;
            while (lo <= hi)
            {
                mid = lo + (hi - lo) / 2;
                var noOfElements = NoOfElements(arr, p, mid);
                if (noOfElements == k)
                {
                    lo = mid + 1;
                    liIndex = mid;
                    found = true;
                }
                else if (noOfElements < k)
                {
                    lo = mid + 1;
                }
                else
                {
                    hi = mid - 1;
                }
            }
            if (!found)
                return -1;
            else
                return liIndex;
        }

        private int FindFirstIndex(int[] arr, int p, int startIndex, int k)
        {
            bool found = false;
            int lo = startIndex, hi = arr.Length - 1, mid = 0, fIndex = 0;
            while (lo <= hi)
            {
                mid = lo + (hi - lo) / 2;
                var noOfElements = NoOfElements(arr, p, mid);
                if (noOfElements == k)
                {
                    hi = mid - 1;
                    fIndex = mid;
                    found = true;
                }
                else if (noOfElements < k)
                {
                    lo = mid + 1;
                }
                else
                {
                    hi = mid - 1;
                }
            }
            if (!found)
                return -1;
            else
                return fIndex;
        }

        private int FindFirstEqualIndex(int[] arr, int p, int startIndex, int k)
        {
            bool found = false;
            int lo = startIndex, hi = arr.Length - 1, mid = 0, fIndex = 0;
            while (lo <= hi)
            {
                mid = lo + (hi - lo) / 2;
                var noOfElements = NoOfElements(arr, p, mid);
                if (noOfElements == k)
                {
                    hi = mid - 1;
                    fIndex = mid;
                    found = true;
                }
                else if (noOfElements < k)
                {
                    lo = mid + 1;
                }
                else
                {
                    hi = mid - 1;
                }
            }
            if (!found)
                return -1;
            else
                return fIndex;
        }
    }
}
