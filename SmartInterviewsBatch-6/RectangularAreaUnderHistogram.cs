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
        public enum Direction
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
        public static int[] fMRi = null;
        public static int[] fMLi = null;

        private int[] GenerateFirstMins(Direction dirOfFirstMin)
        {
            Stack<int> findingFirstMinimums = new Stack<int>(arr.Length);
            int[] fMi = new int[arr.Length];
            int i = dirOfFirstMin == Direction.Left ? 0 : (arr.Length - 1);

            for (; dirOfFirstMin == Direction.Left ? i < arr.Length : i >= 0; i = (dirOfFirstMin == Direction.Left ? i + 1 : i - 1))
            {
                if (findingFirstMinimums.IsEmpty())
                {
                    fMi[i] = i;
                    findingFirstMinimums.Push(i);
                }
                else
                {
                    bool isMinimumFound = false;
                    while (!findingFirstMinimums.IsEmpty())
                    {
                        if (arr[findingFirstMinimums.Peek()] >= arr[i])
                        {
                            findingFirstMinimums.Pop();
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
                        fMi[i] = i;
                        findingFirstMinimums.Push(i);
                    }
                }
            }
            return fMi;
        }

        private uint MaxRectangularArea()
        {
            uint MaxRectangularArea = uint.MinValue;

            fMRi = GenerateFirstMins(Direction.Right);
            fMLi = GenerateFirstMins(Direction.Left);

            for (int i = 0; i < arr.Length; i++)
            {
                MaxRectangularArea = Math.Max(MaxRectangularArea, (uint)(arr[i] * PossibleReachOnBothDirections(i)));
            }
            return MaxRectangularArea;
        }

        /// <summary>
        /// Algorithm:
        /// given the index of the current building, max possible reach on left side is first occuring min, if not found, then last occuring max or equal heighted building.
        /// similarly, max possible reach on right side is first occuring min, if not found, last occuring max or equal heighted building..
        /// now, if we encounter shorter on left or right side, we exclude that building when computing max reach on the respective direction.
        /// if we do not find max on left or right side, we include that building when computing max reach on the respecive direction.
        /// if we do not find min and max or equal heighted building on either side, then the valid answer for the building is the building itself as we cannot expand on both sides.
        /// we apply apply above rules below and compute the answer.
        /// (a,b] | [a,b) = b-a, [a,b] = b-a + 1, (a,b) = b-a -1
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private int PossibleReachOnBothDirections(int i)
        {
            int maxPossibleLeft = fMLi[i], maxPossibleRight = fMRi[i];
            bool IsLeftMinFound = true, IsRightMinFound = true;
            if (fMLi[i] == i && fMRi[i] == i)
            {
                if (i == 0) // the only building in histogram
                    return 1;
            }
            if (maxPossibleLeft == i)
            {
                IsLeftMinFound = false;
                maxPossibleLeft = 0;
            }
            if (maxPossibleRight == i)
            {
                IsRightMinFound = false;
                maxPossibleRight = (arr.Length - 1);
            }
            int noOfBlocks = Math.Abs(maxPossibleLeft - maxPossibleRight) + 1;//b-a + 1 assuming both are taller or equal to current building

            if ((!IsLeftMinFound && IsRightMinFound) || (IsLeftMinFound && !IsRightMinFound))//if one of them is of a shorter height, then (a,b] or [a,b)
            {
                noOfBlocks--;
            }
            else if (IsLeftMinFound && IsRightMinFound)//if both of them are of short height, then (a,b)
            {
                noOfBlocks -= 2;
            }
            return noOfBlocks;
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
