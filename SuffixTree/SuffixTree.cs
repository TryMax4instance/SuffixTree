using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuffixTree
{
    public struct Tree
    {
        public List<char> value; // значение в ребре
        public List<Tree> subTree; // поддерево при разбиении ребра
    }

    public class SuffixTree
    {
        int n = 1;
        List<char> str = new List<char>(); // строка для сравнения с деревом
        List<Tree> suffixTree = new List<Tree>(); // дерево
        Tree tree = new Tree(); //

        public void Add(char a)
        {
            str.Add(a);

            if (n == 1)
            {
                suffixTree = new List<Tree>();
                tree.value = new List<char>();
                tree.subTree = new List<Tree>();
            }

            tree.value = new List<char>();
            tree.subTree = new List<Tree>();
            suffixTree.Add(tree);

            for (int i = 0; i < n; i++)
            {

                for (int j = 0; j < i - 1; j++)
                {
                    if (Find(suffixTree, j, str))
                    {
                        if (str[i] == a)
                        {
                            suffixTree[j].subTree.Add(tree);
                            suffixTree[j].subTree[j].value.Add(a);
                        }
                    }

                }
                suffixTree[i].value.Add(a);
            }

            n++;
        }

        bool Find(List<Tree> suffixTree, int index, List<char> str)
        {
            int lastIndex = 0;

            if (suffixTree[index].value.Count == 0) return false;

            for (int i = 0; i + index < str.Count; i++) // i + index - индекс ребра
            {
                if (suffixTree[index].value.IndexOf(str[i + index], lastIndex) == lastIndex) // если индекс значения в ребре = последнему индексу
                {
                    lastIndex++;
                    continue;
                }
                else return false;
            }
            return true;
        }
    }
}
