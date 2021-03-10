using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAOD_List {
    internal class MyListNode<T> {
        internal MyListNode<T> Last { get; set; }
        internal MyListNode<T> Next { get; set; }
        internal T Value { get; set; }



        /// <param name="last"> Ссылка на предыдущий элемент <see cref="MyListNode{T}"/>.</param>
        /// <param name="next"> Ссылка на следующий элемент <see cref="MyListNode{T}"/>. </param>
        internal MyListNode(T value, MyListNode<T> last, MyListNode<T> next) {
            Value = value;
            Last = last;
            Next = next;
        }

        /// <summary>
        /// Возвращает следующий или на заданное значение элемент.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        internal MyListNode<T> Jump(int count = 1) {
            if (count < 0) {
                throw new ArgumentOutOfRangeException();
            }
            else {
                MyListNode<T> out_node = this;
                try {
                    for (int i = 0; i < count; i++) {
                        out_node = out_node.Next;
                    }
                    return out_node ?? throw new NullReferenceException();
                }
                catch (NullReferenceException) {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

    }
}
