using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6
{
    public class ImplementStack : ISolution
    {
        public override void Solve()
        {

        }
    }

    public class Stack<T>
    {
        int i;
        T[] _arr;
        public Stack(int size)
        {
            _arr = new T[size];
            i = -1;
        }

        public void Push(T data)
        {
            _arr[++i] = data;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                return default(T);
            }
            else
            {
                T poppedElement = _arr[i--];
                return poppedElement;
            }
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                return default(T);
            }
            else
            {
                T peekedElement = _arr[i];
                return peekedElement;
            }
        }

        public bool IsEmpty()
        {
            return i == -1;
        }

        public void Empty()
        {
            i = -1;
        }

    }
}
