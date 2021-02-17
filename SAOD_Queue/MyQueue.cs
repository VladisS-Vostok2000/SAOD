using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAOD_Queue {
    internal sealed class MyQueue<T> {
        /// <summary>
        /// Вместимость очереди.
        /// </summary>
        internal int Capability { get => queue.Length; }
        /// <summary>
        /// Текущее наполнение очереди.
        /// </summary>
        internal int Length { get; private set; } = 0;
        internal bool IsEmpty => top == -1;


        /// <summary>
        /// Индекс первого элемента на очереди.
        /// </summary>
        private int top = -1;
        /// <summary>
        /// Индекс последнего элемента в очереди.
        /// </summary>
        private int last = -1;
        private readonly T[] queue;


        /// <summary>
        /// Забирает элемент из очереди.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"> </exception>
        internal T Pop {
            get {
                if (IsEmpty) {
                    throw new ArgumentOutOfRangeException();
                }

                Length--;
                if (top == last) {
                    int tempIndex = top;
                    Clear();
                    return queue[tempIndex];
                }
                else {
                    int tempIndex = top;
                    top = (top + 1) % Capability;
                    return queue[tempIndex];
                }
            }
        }
        /// <summary>
        /// Возвращает первый элемент на очереди.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        internal T Top => IsEmpty ? throw new ArgumentOutOfRangeException() : queue[top];



        internal MyQueue(int length) {
            queue = new T[length];
        }



        /// <summary>
        /// Добавляет элемент в очередь.
        /// </summary>
        /// <exception cref="StackOverflowException"> Очередь переполнена. </exception>
        internal void Push(T t) {
            if (IsEmpty) {
                top = last = 0;
                queue[last] = t;
            }
            else {
                // Очередь так долго пополнялась, что
                // по кругу от начала (top) дошла до него
                // же и хочет его перезаписать.
                // "<...> % Capability" означает движение по массиву по кругу.
                int newLast = (last + 1) % Capability;
                if (newLast == top) {
                    throw new StackOverflowException();
                }

                last = (last + 1) % Capability;
                queue[last] = t;
            }

            Length += 1;
        }

        internal void Clear() {
            top = -1;
            last = -1;
            Length = 0;
        }

    }
}
