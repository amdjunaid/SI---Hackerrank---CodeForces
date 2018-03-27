using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datastructures;

namespace SmartInterviewsBatch_6.Tries
{
    public class Rhymes : ISolution
    {
        public override void Solve()
        {
            Trie<char> trie = new Trie<char>();
            var n = ReadInt();
            while (n-- > 0) {
               var str = ReadString().ToCharArray();
                trie.InsertRhyme(str);
            }
            var q = ReadInt();
            while (q-- > 0) {
                output.AppendLine(GetMaximumPossibleNumber(ReadString(), trie).ToString());
            }
            Console.Write(output);
        }

        private int GetMaximumPossibleNumber(string word, Trie<char> root)
        {
            int currentLevel = 0;
            var rootNode = root.root;
            for (int i = word.Length -1; i >= 0; i--)
            {
                if (rootNode.children.ContainsKey(word[i]))
                {
                    currentLevel++;
                    rootNode = rootNode.children[word[i]];
                }
                else
                {
                    if (currentLevel != 0)
                    {
                        return currentLevel + rootNode.remainingLengthOfMaxElement;
                    }
                    else {
                        return 0;
                    }
                }
            }
            return currentLevel + rootNode.remainingLengthOfMaxElement;
        }
    }
}
