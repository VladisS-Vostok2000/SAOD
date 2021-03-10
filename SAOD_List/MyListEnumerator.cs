using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAOD_List {
    internal sealed class MyListEnumerator<T> : IEnumerator<T> {
        public T Current => currentNode.Value;
        object IEnumerator.Current => currentNode.Value;
        private MyListNode<T> currentNode;



        internal MyListEnumerator(MyListNode<T> myListNode) {
            currentNode = new MyListNode<T>(default, null, myListNode);
        }



        public void Dispose() {
            
        }
        public bool MoveNext() {
            switch (currentNode.Next) {
                case null:
                    return false;
                default:
                    currentNode = currentNode.Next;
                    return true;
            }
        }
        public void Reset() {
            while (currentNode.Last != null) {
                currentNode = currentNode.Last;
            }
            currentNode = new MyListNode<T>(default, null, currentNode);
        }

    }
}
