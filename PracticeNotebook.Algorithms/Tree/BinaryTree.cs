using System;

namespace PracticeNotebook.Algorithms.Tree
{
    public class BinaryTree<T>
    {
        public T Value { get; set; }
        public BinaryTree<T> Left { get; set; }
        public BinaryTree<T> Right { get; set; }

        public int Height
        {
            get => GetHeight(this);
        }

        public BinaryTree(T value)
        {
            Value = value;
        }

        public void InsertLeft(BinaryTree<T> node, T leftValue)
        {
            node.Left = new BinaryTree<T>(leftValue);
        }

        public void InsertRight(BinaryTree<T> node, T rightValue)
        {
            node.Right = new BinaryTree<T>(rightValue);
        }

        private int GetHeight(BinaryTree<T> node)
        {
            if (node is null) return 0;
            if (node.Left is null && node.Right is null) return 1;
            return Math.Max(node.Left?.Height ?? 0, node.Right?.Height ?? 0) + 1;
        }

        public override string ToString()
        {
            return $"Current node's value: ${Value}. Left child's value: ${Left?.Value.ToString()}. Right child's value: ${Right?.Value.ToString()}";
        }
    }
}