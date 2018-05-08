using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datastructures
{
    public class MaxHeap<T>
    {
        T[] arr;
        int idx, size;
        public MaxHeap(int size)
        {
            arr = new T[size + 1];
            idx = 0;
            this.size = size + 1;
        }

        public void Insert(T key)
        {
            if (IsFull())
                return;
            arr[++idx] = key;
            HeapifyFromBottom();
        }

        public T GetMax()
        {
            return arr[1];
        }

        public int Size()
        {
            return idx;
        }

        public void DelMax()
        {
            if (IsEmpty())
                return;
            arr[1] = arr[idx--];
            HeapifyFromTop();
        }

        private void HeapifyFromTop()
        {
            int i = 1;
            while (i <= idx)
            {
                //var min = typeof(T).GetProperties().First(x => x.Name.Contains("MaxValue")).GetValue(typeof(T));
                T max = default(T);
                int maxIdx = 0;
                if (2 * i <= idx)
                {
                    max = arr[2 * i];
                    maxIdx = 2 * i;
                }
                else
                {
                    break;
                }
                if (2 * i + 1 <= idx)
                {
                    if (Comparer<T>.Default.Compare(max, arr[2 * i + 1]) < 0)
                    {
                        max = arr[2 * i + 1];
                        maxIdx = 2 * i + 1;
                    }
                }
                if (Comparer<T>.Default.Compare(max, arr[i]) > 0)
                {
                    var temp = arr[i];
                    arr[i] = arr[maxIdx];
                    arr[maxIdx] = temp;
                    i = maxIdx;
                }
                else
                    break;
            }
        }

        public bool IsEmpty()
        {
            return idx == 0;
        }

        private void HeapifyFromBottom()
        {
            int i = idx;
            while (i > 1 && Comparer<T>.Default.Compare(arr[i], arr[i / 2]) > 0)
            {
                var temp = arr[i / 2];
                arr[i / 2] = arr[i];
                arr[i] = temp;
                i /= 2;
            }
        }

        public bool IsFull()
        {
            return idx == size;
        }
    }
}
