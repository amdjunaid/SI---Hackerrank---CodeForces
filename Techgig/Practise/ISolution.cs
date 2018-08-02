using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techgig
{
    public abstract class ISolution
    {
        public static Func<int> ReadInt = () => int.Parse(Console.ReadLine().Trim());
        public static Func<long> ReadLong = () => long.Parse(Console.ReadLine().Trim());
        public static Func<short> ReadShort = () => short.Parse(Console.ReadLine().Trim());
        public static Func<string> ReadString = () => Console.ReadLine().Trim();
        public static Func<byte> ReadByte = () => byte.Parse(Console.ReadLine().Trim());
        public static Func<sbyte> ReadSByte = () => sbyte.Parse(Console.ReadLine().Trim());
        public static StringBuilder output = new StringBuilder();
        public static Func<string[]> ReadArrString = () => ReadString().Split(' ').ToArray();
        public abstract void Solve();
    }
}
