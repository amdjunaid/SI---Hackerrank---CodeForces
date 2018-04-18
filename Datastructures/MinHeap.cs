using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datastructures
{
    public class MinHeap<T>
    {
        T[] arr;
        int idx, size;
        public MinHeap(int size) {
            arr = new T[size + 1];
            idx = 0;
            this.size = size + 1;
        }

        public void Insert(T key) {
            if (IsFull())
                return;
            arr[++idx] = key;
            HeapifyFromBottom();
        }

        public T GetMin() {
            return arr[1];
        }

        public void DelMin() {
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
                T min = default(T);
                int minIdx = 0;
                if (2 * i <= idx)
                {
                    min = arr[2 * i];
                    minIdx = 2 * i;
                }
                else
                {
                    break;
                }
                if (2 * i + 1 <= idx)
                {
                    if (Comparer<T>.Default.Compare(min, arr[2 * i + 1]) > 0)
                    {
                        min = arr[2 * i + 1];
                        minIdx = 2 * i + 1;
                    }
                }
                if (Comparer<T>.Default.Compare(min, arr[i]) < 0)
                {
                    var temp = arr[i];
                    arr[i] = arr[minIdx];
                    arr[minIdx] = temp;
                    i = minIdx;
                }
                else
                    break;
            }
        }

        public bool IsEmpty() {
            return idx == 0;
        }

        private void HeapifyFromBottom()
        {
            int i = idx;
            while (i > 1 && Comparer<T>.Default.Compare(arr[i], arr[i / 2]) < 0) {
                var temp = arr[i / 2];
                arr[i / 2] = arr[i];
                arr[i] = temp;
                i /= 2;
            }
        }

        public bool IsFull() {
            return idx == size;
        }
    }
}
