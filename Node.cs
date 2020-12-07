using System.Collections.Generic;

namespace HuffmanTree
{
    public class Node
    {
        public char Symbol { get; set; }
        public int Frequency { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public List<bool> Traverse(char symbol, List<bool> data)
        {
            if (this.Left == null && this.Right == null)
            {
                if (this.Symbol.Equals(symbol))
                {
                    return data;
                }

                return null;
            }
            else
            {
                List<bool> left = null;
                List<bool> right = null;

                if (this.Left != null)
                {
                    List<bool> leftPath = new List<bool>();
                    leftPath.AddRange(data);
                    leftPath.Add(false);

                    left = this.Left.Traverse(symbol, leftPath);
                }

                if (this.Right != null)
                {
                    List<bool> rightPath = new List<bool>();
                    rightPath.AddRange(data);
                    rightPath.Add(true);

                    right = this.Right.Traverse(symbol, rightPath);
                }

                return left ?? right;
            }
        }
    }
}
