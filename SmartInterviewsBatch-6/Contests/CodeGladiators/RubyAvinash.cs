using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.Contests.CodeGladiators
{
    public class RubyAvinash
    {
        public void Solve()
        {
            int blue = 0, red = 0, green = 0, yellow = 0;

            //Console.WriteLine("How many blue rubies ?");
            Int32.TryParse(Console.ReadLine(), out blue);

            //Console.WriteLine("How many red rubies ?");
            Int32.TryParse(Console.ReadLine(), out red);

            //Console.WriteLine("How many yellow rubies ?");
            Int32.TryParse(Console.ReadLine(), out yellow);

            //Console.WriteLine("How many green rubies ?");
            Int32.TryParse(Console.ReadLine(), out green);

            if (blue >= 0 && blue <= 2000 && red >= 0 && red <= 2000 && green >= 0 && green <= 2000 && yellow >= 0 && yellow <= 2000)
            {
                CreateNecklace(blue, red, yellow, green);
            }
            else
            {

                Console.WriteLine(0);
            }

            //int num = 0;
            //while (num < 2000)
            //{
            //    Random r = new Random();
            //    StringBuilder necklace = new StringBuilder();
            //    red = r.Next(0,900);
            //    green = r.Next(0, 900);
            //    blue = r.Next(0, 900);
            //    yellow = r.Next(0, 900);

            //    Console.WriteLine("red= {0} green = {1} blue= {2} yellow = {3} ", red, green, blue, yellow);
            //    necklace = CreateNecklace(blue, red, yellow, green);
            //    Console.WriteLine("[{0}] : {1}", necklace.Length,necklace);
            //    if (necklace.Length > red + blue + green + yellow)
            //    {
            //        break;
            //    }
            //    if(Regex.Matches(necklace.ToString(), @"by|bg|gr|gb|rb|rr|yy|yg").Count > 0)
            //    {
            //        break;
            //    }
            //    Console.WriteLine();
            //    num++;
            //}
        //    Console.ReadLine();
        }

        static StringBuilder CreateNecklace(int blue, int red, int yellow, int green)
        {

            int Length = 0;
            StringBuilder necklace = new StringBuilder();


            if (red > 0 && blue > 0)
            {
                var x = BuildNecklace(new StringBuilder("b"), blue - 1, red, yellow, green);
                var y = BuildNecklace(new StringBuilder("r"), blue, red - 1, yellow, green);
                necklace = x.Length > y.Length ? x : y;
                Length = necklace.Length;
            }
            else
            {
                if (red > 0 || blue > 0)
                {
                    if (red > 0)
                    {
                        necklace = BuildNecklace(new StringBuilder("r"), blue, red - 1, yellow, green);
                        Length = necklace.Length;
                    }
                    if (blue > 0)
                    {
                        necklace = BuildNecklace(new StringBuilder("b"), blue - 1, red, yellow, green);
                        Length = necklace.Length;
                    }
                }
                else
                {
                    if (green > 0)
                    {
                        necklace = BuildNecklace(new StringBuilder("g"), blue, red, yellow, green - 1);
                        Length = necklace.Length;
                    }
                    if (yellow > 0)
                    {
                        var x = BuildNecklace(new StringBuilder("y"), blue, red, yellow - 1, green);
                        necklace = x.Length > necklace.Length ? x : necklace;
                        Length = necklace.Length;
                    }

                    if (green > necklace.Length || yellow > necklace.Length)
                    {
                        if (green > yellow)
                            Length = green;
                        else
                            Length = yellow;
                    }
                }

            }


            Console.WriteLine(Length);
            return necklace;


        }

        static StringBuilder BuildNecklace(StringBuilder initial, int blue, int red, int yellow, int green)
        {
            StringBuilder necklace = new StringBuilder();
            necklace.Append(initial);
            bool added = true;
            int r = red;
            int b = blue;
            int g = green;
            int y = yellow;



            while (added && (g > 0 || b > 0 || r > 0 || y > 0))
            {
                added = false;
                for (int i = 0; i < b; i++)
                {
                    if (necklace.ToString().IndexOf('b') != -1)
                    {
                        necklace.Insert(necklace.ToString().IndexOf('b'), 'b');
                        b--;
                        added = true;
                    }
                    else if (necklace.ToString().IndexOf('y') != -1)
                    {
                        necklace.Insert(necklace.ToString().IndexOf('y') + 1, 'b');
                        b--;
                        added = true;
                    }
                    else if (necklace.ToString().IndexOf('r') != -1)
                    {
                        necklace.Insert(necklace.ToString().IndexOf('r'), 'b');
                        b--;
                        added = true;
                    }
                }

                for (int i = 0; i < g; i++)
                {
                    if (necklace.ToString().IndexOf('g') != -1)
                    {
                        necklace.Insert(necklace.ToString().IndexOf('g'), 'g');
                        g--;
                        added = true;
                    }
                    else if (necklace.ToString().IndexOf('r') != -1)
                    {
                        necklace.Insert(necklace.ToString().IndexOf('r') + 1, 'g');
                        g--;
                        added = true;
                    }
                    else if (necklace.ToString().IndexOf('y') != -1)
                    {
                        necklace.Insert(necklace.ToString().IndexOf('y'), 'g');
                        g--;
                        added = true;
                    }
                }

                for (int i = 0; i < r; i++)
                {

                    if (necklace.ToString().IndexOf("by") != -1)
                    {
                        necklace.Insert(necklace.ToString().IndexOf("by") + 1, 'r'); r--; added = true;
                    }
                    else if (necklace.ToString().IndexOf("yg") != -1)
                    {
                        necklace.Insert(necklace.ToString().IndexOf("yg") + 1, 'r');
                        r--;
                        added = true;
                    }
                    else if (necklace.ToString().LastIndexOf("y") != -1 && (necklace.ToString().LastIndexOf("y") == necklace.Length - 1))
                    {
                        necklace.Insert(necklace.ToString().LastIndexOf("y") + 1, 'r');
                        r--;
                        added = true;
                    }
                    else if (necklace.ToString().LastIndexOf("b") != -1 && (necklace.ToString().LastIndexOf("b") == necklace.Length - 1))
                    {
                        necklace.Insert(necklace.ToString().LastIndexOf("b") + 1, 'r');
                        r--;
                        added = true;
                    }

                }

                for (int i = 0; i < y; i++)
                {

                    if (necklace.ToString().IndexOf("gb") != -1)
                    {
                        necklace.Insert(necklace.ToString().IndexOf("gb") + 1, 'y');
                        y--;
                        added = true;
                    }
                    else if (necklace.ToString().IndexOf("gr") != -1)
                    {
                        necklace.Insert(necklace.ToString().IndexOf("gr") + 1, 'y');
                        y--;
                        added = true;
                    }
                    else if (necklace.ToString().IndexOf("rb") > 0)
                    {
                        necklace.Insert(necklace.ToString().IndexOf("rb") + 1, 'y');
                        y--;
                        added = true;
                    }
                    else if (necklace.ToString().LastIndexOf("r") != -1 && (necklace.ToString().LastIndexOf("r") == necklace.Length - 1))
                    {
                        necklace.Insert(necklace.ToString().LastIndexOf("r") + 1, 'y');
                        y--;
                        added = true;
                    }
                    else if (necklace.ToString().LastIndexOf("g") != -1 && (necklace.ToString().LastIndexOf("g") == necklace.Length - 1))
                    {
                        necklace.Insert(necklace.ToString().LastIndexOf("g") + 1, 'y');
                        y--;
                        added = true;
                    }
                }
            }

            return necklace;
        }


    }
}
