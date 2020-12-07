using System;
using System.Collections;

namespace HuffmanTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter the string: ");
            string input = Console.ReadLine();
            Tree huffmanTree = new Tree();

            // Build the Huffman tree
            huffmanTree.Build(input);

            // Encode
            BitArray encoded = huffmanTree.Encode(input);

            Console.Write("Encoded: ");
            foreach (bool bit in encoded)
            {
                Console.Write((bit ? 1 : 0) + "");
            }
            Console.WriteLine();

            // Decode
            string decoded = huffmanTree.Decode(encoded);

            Console.WriteLine("Decoded: " + decoded);

            Console.ReadLine();
        }
    }
}
