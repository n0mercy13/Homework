using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Task01
{
    public class Tree
    {
        private List<Node> _tree;

        public Tree(List<Node> tree)
        {
            this._tree = new List<Node>(tree);
        }

        public Tree()
        {
            _tree = new List<Node>();
        }

        public void AddNode(int number, int level) => _tree.Add(new Node(number, level));

        public void ClearAll() => _tree.Clear();

        public int GetLevelOfNode(int key)
        {
            return _tree
                .OrderBy(node => node.Level)
                .FirstOrDefault(node => node.Key == key)
                .Level;
        }
    }

    public class Node
    {
        public int Key { get; private set; }
        public int Level { get; private set; }

        public Node(int key, int level)
        {
            Key = key;
            Level = level;
        }
    }
}
