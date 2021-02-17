using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAOD_Stack {
    internal sealed class MyStack<T> {
        internal int Capability { get => stack.Length; }
        internal int Length { get; private set; } = 0;
        internal bool IsEmpty { get => Length == 0; }
        private readonly T[] stack;


        /// <summary>
        /// Забирает элемент из стека.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"> </exception>
        internal T Pop => IsEmpty ? throw new ArgumentOutOfRangeException() : stack[--Length];
        /// <summary>
        /// Возвращает элемент из стека.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        internal T Top => IsEmpty ? throw new ArgumentOutOfRangeException() : stack[Length - 1];



        internal MyStack(int length) {
            stack = new T[length];
        }



        /// <summary>
        /// Добавляет элемент в стек.
        /// </summary>
        /// <exception cref="StackOverflowException"> Стек переполнен. </exception>
        internal void Push(T t) {
            if (Capability == Length) {
                throw new StackOverflowException();
            }

            stack[Length++] = t;
        }

        internal void Clear() => Length = 0;

    }
}
