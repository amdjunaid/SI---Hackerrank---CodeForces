using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartInterviewsBatch_6;

namespace SmartInterviewsBatch_6
{
    public class RectangularAreaUnderHistogram : ISolution
    {
        public enum FirstMinimumDirection
        {
            Left = 1,
            Right = -1
        }
        public override void Solve()
        {
            byte t = ReadByte();
            while (t-- > 0)
            {
                ReadString();
                arr = ReadArrString().Select(short.Parse).ToArray();
                output.AppendLine(MaxRectangularArea().ToString());
            }
            Console.Write(output);
        }

        public static short[] arr = null;
        public static short[] fMRi = null;
        public static short[] fMLi = null;

        private short[] GenerateFirstMins(FirstMinimumDirection dirOfFirstMin)
        {
            Stack<short> findingFirstMinimums = new Stack<short>(arr.Length);
            short[] fMi = new short[arr.Length];
            short i = (short)(dirOfFirstMin == FirstMinimumDirection.Left ? 0 : (arr.Length - 1));

            for (; dirOfFirstMin == FirstMinimumDirection.Left ? i < arr.Length : i >= 0; i = (short)(dirOfFirstMin == FirstMinimumDirection.Left ? i + 1 : i - 1))
            {
                if (findingFirstMinimums.IsEmpty())
                {
                    fMi[i] = i;
                    findingFirstMinimums.Push(i);
                }
                else
                {
                    short prevPoppedElement = short.MinValue;
                    bool isMinimumFound = false;
                    while (!findingFirstMinimums.IsEmpty())
                    {
                        if (arr[findingFirstMinimums.Peek()] >= arr[i])
                        {
                            prevPoppedElement = findingFirstMinimums.Pop();
                        }
                        else
                        {
                            fMi[i] = findingFirstMinimums.Peek();
                            findingFirstMinimums.Push(i);
                            isMinimumFound = true;
                            break;
                        }
                    }
                    if (!isMinimumFound)
                    {
                        fMi[i] = prevPoppedElement != short.MinValue ? prevPoppedElement : i;
                        findingFirstMinimums.Push(i);
                    }
                }
            }
            return fMi;
        }

        private int MaxRectangularArea()
        {
            short MaxRectangularArea = short.MinValue;

            fMRi = GenerateFirstMins(FirstMinimumDirection.Right);
            fMLi = GenerateFirstMins(FirstMinimumDirection.Left);

            for (short i = 0; i < arr.Length; i++)
            {
                MaxRectangularArea = Math.Max(MaxRectangularArea, (short)(arr[i] * PossibleReachOnBothDirections(i)));
            }
            return MaxRectangularArea;
        }

        private short PossibleReachOnBothDirections(short i)
        {
            if (fMLi[i] == i && fMRi[i] == i)
            {
                return 1;
            }
            else
            {
                short noOfBlocks = (short)Math.Abs(fMLi[i] - fMRi[i]);//b-a

                if (arr[fMLi[i]] >= arr[i] && arr[fMRi[i]] >= arr[i])//b-a+1(including when mins could not be found, but found equal or greater heighted building
                {
                    noOfBlocks++;
                }
                else if (fMLi[i] != i && fMRi[i] != i)//b-a-1(excluding mins on both ends)
                {
                    noOfBlocks--;
                }
                return Math.Abs(noOfBlocks);
            }
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
