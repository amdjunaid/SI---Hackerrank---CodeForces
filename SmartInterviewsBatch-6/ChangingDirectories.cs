using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6
{
    public class ChangingDirectories : ISolution
    {
        public string[] directories = new string[200];
        public sbyte index = -1;

        public override void Solve()
        {
            byte t = ReadByte();
            while (t-- > 0)
            {
                index = -1;

                byte n = ReadByte();
                while (n-- > 0)
                {
                    string input = ReadString();
                    if (input == "pwd")
                    {
                        output.Append("/");
                        for (int i = 0; i < directories.Length; i++)
                        {
                            output.Append(directories[i] + "/");
                        }
                        output.AppendLine();
                    }
                    else
                    {
                        string[] dirList = input.Substring(3).Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                        if (input[3] == '/')
                        {
                            index = -1;
                        }
                        for (int i = 0; i < dirList.Length; i++)
                        {
                            if (dirList[i] == "..")
                            {
                                if (index!=-1)
                                {
                                    index--;
                                }
                            }
                            else
                            {
                                directories[++index] = dirList[i];
                            }
                        }
                    }
                }
                output.AppendLine();
            }
            Console.Write(output);
        }
    }

    
}
