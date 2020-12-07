using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HuffmanTree
{
    public class Tree
    {
        private Node root;
        private List<Node> nodes;
        private Dictionary<char, int> fequencies;

        public Tree()
        {
            nodes = new List<Node>();
            fequencies = new Dictionary<char, int>();
        }

        public void Build(string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                return;
            }

            foreach (char ch in source)
            {
                if (fequencies.TryGetValue(ch, out int value))
                {
                    fequencies[ch]++;
                }
                else
                {
                    fequencies.Add(ch, 1);
                }
            }

            foreach (var keyValue in fequencies)
            {
                nodes.Add(new Node() { Symbol = keyValue.Key, Frequency = keyValue.Value });
            }

            while (nodes.Count > 1)
            {
                var sortedNodes = nodes.OrderBy(each => each.Frequency).ToList();

                if (sortedNodes.Count >= 2)
                {
                    Node parent = new Node()
                    {
                        Symbol = '*',
                        Frequency = sortedNodes[0].Frequency + sortedNodes[1].Frequency,
                        Left = sortedNodes[0],
                        Right = sortedNodes[1]
                    };

                    nodes.Remove(sortedNodes[0]);
                    nodes.Remove(sortedNodes[1]);
                    nodes.Add(parent);
                }

                root = nodes.FirstOrDefault();
            }
        }

        public BitArray Encode(string source)
        {
            List<bool> encodedSource = new List<bool>();
            foreach (char ch in source)
            {
                List<bool> encodedSymbol = this.root.Traverse(ch, new List<bool>());
                encodedSource.AddRange(encodedSymbol);
            }

            return new BitArray(encodedSource.ToArray());
        }

        public string Decode(BitArray encoded)
        {
            string decodedOutput = string.Empty;
            Node current = this.root;

            foreach (bool bit in encoded)
            {
                if (bit)
                {
                    if (current.Right != null)
                    {
                        current = current.Right;
                    }
                }
                else
                {
                    if (current.Left != null)
                    {
                        current = current.Left;
                    }
                }

                if (IsLeaf(current))
                {
                    decodedOutput += current.Symbol;
                    current = this.root;
                }
            }

            return decodedOutput;
        }

        private bool IsLeaf(Node current)
        {
            return current.Left == null && current.Right == null;
        }
    }
}
