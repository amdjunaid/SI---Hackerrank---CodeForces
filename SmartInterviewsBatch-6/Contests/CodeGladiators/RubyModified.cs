using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.Contests.CodeGladiators
{
    public class RubyModified : ISolution
    {
        public override void Solve()
        {
            var ruby = new Ruby
            {
                Blue = ReadInt(),
                Red = ReadInt(),
                Yellow = ReadInt(),
                Green = ReadInt()
            };

            var refRuby = new Ruby
            {
                Blue = ruby.Blue,
                Green = ruby.Green,
                Red = ruby.Red,
                Yellow = ruby.Yellow
            };

            int length = 0;
            var info = ProcessInfo(ruby, 0);
            var cpinfo = ProcessInfo(refRuby, 0);
            if (info.Item1 == 4)//no of quadraples
            {
                length += 4 * info.Item2;
                info = ProcessInfo(ruby, info.Item2);
            }
            if (info.Item1 == 3)// no of triplets
            {
                var tripletInfo = GetTripletInfo(ruby);
                if (tripletInfo.Item1)
                {
                    if (tripletInfo.Item2 == 'R')
                    {
                        length += ruby.Blue + 1 + ruby.Green;
                    }
                    else // Y
                    {
                        //length += ruby.Blue + ruby.Green + 1;//earlier
                        length += ruby.Blue + (refRuby.Red > 0 ? ruby.Green: 0);
                    }
                }
                else
                {
                    var min = Math.Min(ruby.Red, ruby.Yellow);
                    length += ruby.Blue + 2 * min + ruby.Green + (refRuby.Red > refRuby.Yellow?1:0);
                }
            }
            else if (info.Item1 == 2)
            {
                var pairInfo = GetPairInfo(ruby);
                if (pairInfo.Item1 == 1)
                {
                    length += ruby.Blue;
                }
                else if (pairInfo.Item1 == 2)
                {
                    length += 2 * info.Item2 + (ruby.Red > ruby.Yellow ? 1 : 0);
                }
                else
                {
                    if (pairInfo.Item2 == 'B')
                    {
                        if (pairInfo.Item3 == 'R')
                        {
                            length += ruby.Blue + 1;
                        }
                        else
                        {
                            length += ruby.Blue;
                        }
                    }
                    else
                    {
                        length += ruby.Green + (cpinfo.Item1 == 4 ? 0 : 1);
                        //length += ruby.Green + 1;
                    }
                }
            }
            else if (info.Item1 == 1)
            {
                if (ruby.Blue > 0)
                {
                    length += ruby.Blue;
                }
                else if (ruby.Green > 0)
                {
                    length += ruby.Green;
                }
                else// if (ruby.Red > 0)
                {
                    length += 1;
                }
            }
            Console.Write(length);
        }

        public ITuple<int, char, char> GetPairInfo(Ruby rubies)
        {
            var pairType = 0;
            char firstSymbol = ' ', scndSymbol = ' ';
            if (rubies.Blue > 0 && rubies.Green > 0)
            {
                pairType = 1;
            }
            else if (rubies.Red > 0 && rubies.Yellow > 0)
            {
                pairType = 2;
            }
            else
            {
                pairType = 3;
                if (rubies.Blue > 0)
                {
                    firstSymbol = 'B';
                }
                else
                {
                    firstSymbol = 'G';
                }
                if (rubies.Red > 0)
                {
                    scndSymbol = 'R';
                }
                else
                {
                    scndSymbol = 'Y';
                }
            }
            return new ITuple<int, char, char>(pairType, firstSymbol, scndSymbol);
        }

        public ITuple<bool, char> GetTripletInfo(Ruby rubies)
        {
            int count = 0;
            char symbol = ' ';
            bool isOccuringCntHIgh = false;
            if (rubies.Blue > 0 && rubies.Green > 0)
            {
                count = 2;
                isOccuringCntHIgh = true;
            }
            if (count == 2)
            {
                if (rubies.Red > 0)
                {
                    symbol = 'R';
                }
                else if (rubies.Yellow > 0)
                {
                    symbol = 'Y';
                }
            }
            else
            {
                if (rubies.Blue > 0)
                {
                    symbol = 'B';
                }
                else
                {
                    symbol = 'G';
                }
            }
            return new ITuple<bool, char>(isOccuringCntHIgh, symbol);
        }

        public ITuple<int, int> ProcessInfo(Ruby rubies, int subtract)
        {
            rubies.Blue -= subtract;
            rubies.Green -= subtract;
            rubies.Red -= subtract;
            rubies.Yellow -= subtract;

            int count = 0, min = int.MaxValue;
            if (rubies.Blue > 0)
            {
                count++;
                min = Math.Min(rubies.Blue, min);
            }
            if (rubies.Red > 0)
            {
                min = Math.Min(rubies.Red, min);
                count++;
            }
            if (rubies.Green > 0)
            {
                count++;
                min = Math.Min(rubies.Green, min);
            }
            if (rubies.Yellow > 0)
            {
                count++;
                min = Math.Min(rubies.Yellow, min);
            }
            return new ITuple<int, int>(count, min);
        }
    }
}
