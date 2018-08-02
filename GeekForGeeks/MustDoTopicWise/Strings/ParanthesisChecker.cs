using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekForGeeks.MustDoTopicWise.Strings
{
    public class ParanthesisChecker : ISolution
    {
        public override void Solve()
        {
            var t = ReadSByte();
            while (t-- > 0){
                var str = ReadString();
                Stack<char> stk = new Stack<char>();
                bool invalid = false;
                for (int i = 0; i < str.Length; i++) {
                    if (str[i] == '(' || str[i] == '{' || str[i] == '[')
                    {
                        stk.Push(str[i]);
                    }
                    else {
                        if (stk.Count == 0)
                        {
                            invalid = true;
                            break;
                        }
                        if (str[i] == ')') {
                            if (stk.Peek() == '(')
                            {
                                stk.Pop();
                            }
                            else
                            {
                                invalid = true;
                                break;
                            }
                        }
                        else if (str[i] == ']')
                        {
                            if (stk.Peek() == '[')
                            {
                                stk.Pop();
                            }
                            else
                            {
                                invalid = true;
                                break;
                            }
                        }
                        else
                        {
                            if (stk.Peek() == '{')
                            {
                                stk.Pop();
                            }
                            else
                            {
                                invalid = true;
                                break;
                            }
                        }
                    }
                }
                if (invalid || stk.Count != 0)
                {
                    output.AppendLine("not balanced");
                }
                else
                    output.AppendLine("balanced");
            }
            Console.Write(output);
        }
    }
}
