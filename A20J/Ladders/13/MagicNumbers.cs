using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A20J.Ladders._13
{
    public class MagicNumbers : ISolution
    {
        public override void Solve()
        {
            var step = ReadString();
            bool invalid = false;
            for (int i = step.Length - 1; i >= 0;)
            {
                if (step[i] == '1')
                {
                    i--;
                }
                else if (step[i] == '4')
                {
                    if (i - 1 >= 0)
                    {
                        if (step[i - 1] == '1')
                        {
                            i -= 2;
                        }
                        else if (step[i - 1] == '4')
                        {
                            if (i - 2 < 0)
                            {
                                invalid = true;
                                break;
                            }
                            else
                            {
                                if (step[i - 2] == '1')
                                {
                                    i -= 3;
                                }
                                else
                                {
                                    invalid = true;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            invalid = true;
                            break;
                        }
                    }
                    else
                    {
                        invalid = true;
                        break;
                    }
                }
                else
                {
                    invalid = true;
                    break;
                }
            }
            Console.Write(invalid ? "NO" : "YES");
        }
    }
}
