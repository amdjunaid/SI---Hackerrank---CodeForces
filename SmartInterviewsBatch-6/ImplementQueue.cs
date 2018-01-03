using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6
{
    public class ImplementQueue : ISolution
    {
        public override void Solve()
        {
            Queue<sbyte> queue = new Queue<sbyte>((int)1e4);
            int t = ReadInt();
            while (t-- > 0)
            {
                string operation = ReadString();
                if (operation[0] == 'E')
                {
                    var number = sbyte.Parse(operation.Split(' ')[1]);
                    queue.Enqueue(number);
                }
                else
                {
                    if (queue.IsEmpty())
                    {
                        output.AppendLine("Empty");
                    }
                    else {
                        output.AppendLine(queue.Dequeue().ToString());
                    }
                }
            }
            Console.Write(output);
        }
    }

    public class Queue<T>
    {
        T[] _arr;
        int f, r, _size = 0;

        public Queue(int size)
        {
            f = r = -1;
            _arr = new T[size];
            _size = 0;
        }

        public void Enqueue(T data)
        {
            if (!IsFull())
            {
                r = (r + 1) % _arr.Length;
                _arr[r] = data;
                ++_size;
            }
        }

        private bool IsFull()
        {
            return _size == _arr.Length;
            //return (f + 1) % _arr.Length == r % _arr.Length;
        }

        public bool IsEmpty()
        {
            return _size == 0;
            //return (f == r) && r == -1;
        }

        public T Dequeue()
        {
            if (!IsEmpty())
            {
                --_size;
                return _arr[++f];
            }
            else
                return default(T);
        }
    }
}
