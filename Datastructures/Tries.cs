using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datastructures
{
    public class Trie<T>
    {
        public TrieNode root;

        public Trie()
        {
            root = new TrieNode(default(T));
        }
        public class TrieNode
        {
            public T character;
            public int remainingLengthOfMaxElement;
            public int prefixes;
            public bool isLeaf;
            public Dictionary<T, TrieNode> children = null;
            public TrieNode(T c)
            {
                prefixes = remainingLengthOfMaxElement = 0;
                isLeaf = false;
                character = c;
                children = new Dictionary<T, TrieNode>();
            }
        }

        public void Insert(T[] word)
        {
            TrieNode rootNode = root;
            for (int i = 0; i < word.Length; i++)
            {
                TrieNode node;
                var c = word[i];
                //char c = Convert.ToChar(word[i]);
                if (!rootNode.children.TryGetValue(c, out node))
                {
                    node = new TrieNode(c);
                    node.prefixes += 1;
                    if (node.remainingLengthOfMaxElement < i)
                    {
                        node.remainingLengthOfMaxElement = i;
                    }
                    rootNode.children.Add(c, node);
                }
                else
                {
                    node.prefixes += 1;
                    // custom logic
                    //if ((node.prefixes > 1 && node.isLeaf) | (node.prefixes > 1 && i == (word.Length - 1)))
                    //{
                    //    badSet = true;
                    //    break;
                    //}
                }
                rootNode = node;
            }
            rootNode.isLeaf = true;
        }

        public void InsertRhyme(T[] word)
        {
            TrieNode rootNode = root;
            for (int i = word.Length-1; i >=0; i--)
            {
                TrieNode node;
                var c = word[i];
                //char c = Convert.ToChar(word[i]);
                if (!rootNode.children.TryGetValue(c, out node))
                {
                    node = new TrieNode(c);
                    node.prefixes += 1;
                    if (node.remainingLengthOfMaxElement < i)
                    {
                        node.remainingLengthOfMaxElement = i;
                    }
                    rootNode.children.Add(c, node);
                }
                else
                {
                    node.prefixes += 1;
                    if (node.remainingLengthOfMaxElement < i)
                    {
                        node.remainingLengthOfMaxElement = i;
                    }
                    // custom logic
                    //if ((node.prefixes > 1 && node.isLeaf) | (node.prefixes > 1 && i == (word.Length - 1)))
                    //{
                    //    badSet = true;
                    //    break;
                    //}
                }
                rootNode = node;
            }
            rootNode.isLeaf = true;
        }
    }
}
