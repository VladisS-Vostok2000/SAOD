using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAOD_Tree {
    internal sealed class MyTreeNode<T> where T : IComparable {
        internal T Value { get; set; }
        internal MyTreeNode<T> Left { get; set; }
        internal MyTreeNode<T> Right { get; set; }



        internal MyTreeNode(T value, MyTreeNode<T> left, MyTreeNode<T> right) {
            Value = value;
            Left = left;
            Right = right;
        }

    }
}
