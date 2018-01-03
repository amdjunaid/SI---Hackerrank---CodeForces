using System;
using System.Linq;

namespace SmartInterviewsBatch_6
{
    public static class FindingMissingNumber
    {
        public static Func<int> ReadInt = () => int.Parse(Console.ReadLine().Trim());
        public static Func<short> ReadShort = () => short.Parse(Console.ReadLine().Trim());
        public static Func<string> ReadString = () => Console.ReadLine().Trim();

        public static void Solve()
        {
            short t = ReadShort();
            while (t-- > 0) {
                short n = ReadShort();
                short[] arr = ReadString().Split(' ').Select(x => short.Parse(x)).ToArray<short>();
                Console.WriteLine(FindMissingElement(arr));
            }
        }

        private static short FindMissingElement(short[] arr)
        {
            short missingElement = (short)(arr[0] ^ 1);
            for (short i = 1; i < arr.Length; i++) {
                missingElement ^= (short)(arr[i] ^ (i + 1));
            }
            missingElement ^= (short)(arr.Length + 1);
            return missingElement;
        }
    }
}
