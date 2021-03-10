using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAOD_List {
    internal class MyList<T> : IEnumerable<T> where T : IComparable<T>, IEquatable<T> {
        private MyListNode<T> first;
        private MyListNode<T> last;



        internal int Length { private set; get; }
        /// <summary>
        /// Индекс последнего элемента.
        /// </summary>
        internal int LastIndex => Length - 1;
        internal bool Empty => Length == 0;




        internal MyList() { }



        internal T this[in int index] {
            get {
                try {
                    return first.Jump(index).Value;
                }
                catch (ArgumentOutOfRangeException) {
                    throw;
                }
            }
            set {
                try {
                    first.Jump(index).Value = value;
                }
                catch (Exception) {
                    throw;
                }
            }
        }



        #region IEnumerator
        public IEnumerator<T> GetEnumerator() => new MyListEnumerator<T>(first);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        #endregion


        /// <summary>
        /// Добавляет элемент в конец списка.
        /// </summary>
        internal void Append(T item) {
            if (Empty) {
                AddFirstItem(item);
            }
            else {
                last = last.Next = new MyListNode<T>(item, last, null);
            }
            Length++;
        }
        internal void Add(T item) => Append(item);
        /// <summary>
        /// Добавляет элемент в начало списка.
        /// </summary>
        internal void Prepend(T item) {
            if (Empty) {
                AddFirstItem(item);
            }
            else {
                first = first.Last = new MyListNode<T>(item, null, first);
            }
            Length++;
        }
        private void AddFirstItem(T item) => first = last = new MyListNode<T>(item, null, null);

        /// <summary>
        /// Удалит элемент из списка по заданному индексу.
        /// </summary>
        internal void RemoveAt(in int index) {
            if (index < 0) {
                throw new ArgumentOutOfRangeException();
            }

            MyListNode<T> node;
            try {
                node = first.Jump(index);
            }
            catch (ArgumentOutOfRangeException) {
                throw;
            }

            if (Length == 1) {
                first = last = null;
            }
            else {
                if (node == first) {
                    node.Next.Last = null;
                    first = node.Next;
                }
                else
                if (node == last) {
                    node.Last.Next = null;
                    last = node.Last;
                }
                else {
                    node.Next.Last = node.Last;
                    node.Last.Next = node.Next;
                }
            }
            Length--;
        }

        /// <summary>
        /// Очистит список.
        /// </summary>
        internal void Clear() {
            first = last = null;
            Length = 0;
        }

        internal T[] ToArray() {
            var out_array = new T[Length];
            MyListNode<T> node = first;
            for (int i = 0; i < Length; i++) {
                out_array[i] = node.Value;
                node = node.Next;
            }
            return out_array;
        }

        /// <summary>
        /// Вернёт индекс заданного элемента, если он есть, иначе -1.
        /// </summary>
        internal int Find(T target) {
            MyListNode<T> node = first;
            for (int i = 0; i < Length; i++) {
                if (node.Value.Equals(target)) {
                    return i;
                }
                node = node.Next;
            }
            return -1;
        }

        /// <summary>
        /// Удалит заданный элемент из коллекции, если он есть.
        /// </summary>
        internal void Remove(T target) {
            int index = Find(target);
            if (index != -1) {
                RemoveAt(index);
            }
        }

        /// <summary>
        /// Отсортирует коллекцию.
        /// </summary>
        internal void MergeSort() {
            MergeSort(first, Length);
            while (last.Next != null) {
                last = last.Next;
            }
            while (first.Last != null) {
                first = first.Last;
            }
        }
        private void MergeSort(MyListNode<T> firstNode, in int listLength) {
            if (listLength < 1) {
                return;
            }

            int mediana = listLength / 2;
            {
                // После сортировки ссылки на первый элемент листа могут поменяьтся,
                // в то время как для алгоритма они обязаны быть вплотную и зависят от длины.
                // Единственный способ найти последний элемент - сравнить ссылку, что была у него
                // на оригинальный лист - назад.
                MyListNode<T> memoryPtr = firstNode.Last;
                MergeSort(firstNode, mediana);
                while (memoryPtr != firstNode.Last) {
                    firstNode = firstNode.Last;
                }
                MyListNode<T> secondNode = firstNode.Jump(mediana);
                memoryPtr = secondNode.Last;
                int secondLength = listLength - mediana;
                MergeSort(secondNode, secondLength);
                while (memoryPtr != secondNode.Last) {
                    secondNode = secondNode.Last;
                }
                Merge(firstNode, mediana, secondNode, secondLength);
            }
        }
        private void Merge(MyListNode<T> first, in int length1, MyListNode<T> second, in int length2) {

            #region Второй вариант
            // Указатели на списки.
            MyListNode<T> ptr1 = first;
            MyListNode<T> ptr2 = second;
            // Индексы элементов в списке относительно их длины.
            int i = 0, j = 0;

            // Находим стартовый элемент.
            if (ptr1.Value.CompareTo(ptr2.Value) != 1) {
                // Если второй элемент больше либо равен, то привязываем какой-то элемент с первого.
                goto FirstToSecond;
            }
            else {
                // Если первый элемент больше, то привязываем какой-то элемент со второго.
                // Ссылка с оригинального списка на текущий обрубок теперь за элементом второго списка, потому что он всегда справа от первого по индексу.
                if (ptr1.Last != null) {
                    ptr1.Last.Next = ptr2;
                }
                ptr2.Last = ptr1.Last;
                goto SecondToFirst;
            }


        #region Элемент второго списка привязывается к первому.
        SecondToFirst:
            // До тех пор, пока элемент второго списка не больше элемента первого списка,
            // двигаем указатель второго.
            // Нет смысла перепривязывать элементы друг к дружке во втором списке.
            while (true) {
                if (j + 1 == length2) {
                    // Надо присвоить концу первого списка, а равно уже сочленённого, ссылку на оригинальный лист,
                    // т.к. она ьудет перезаписана. Она содержалась на конце второго подсписка, потому что
                    // списки сюда попадают последовательно и вплотную (конец первого списка всегда указывает на начало второго).
                    MyListNode<T> lastFirst = ptr1.Jump(length1 - i - 1);
                    lastFirst.Next = ptr2.Next;
                    if (ptr2.Next != null) {
                        ptr2.Next.Last = lastFirst;
                    }
                    // Следующего элемента нет, т.к. список закончился.
                    // Т.е. элемент первого списка (напр. 8) больше части второго списка (с последним эелементом, напр., 6),
                    // и, т.к. второй список закончен, то его часть теперь должна сослаться на 8 и... лист отсортирован весь.
                    ptr2.Next = ptr1;
                    ptr1.Last = ptr2;
                    return;
                }
                else
                if (ptr2.Next.Value.CompareTo(ptr1.Value) == 1) {
                    break;
                }
                else {
                    ptr2 = ptr2.Next;
                    j++;
                }
            }

            // Сочленять позже будем точно ко второму листу и к его следующему элементу, т.к. его значение наибольшее.
            ptr2 = ptr2.Next;
            // ptr1 и ptr2.Last теперь должны ссылаться друг на друга.
            ptr1.Last = ptr2.Last;
            ptr2.Last.Next = ptr1;
            j++;
            goto FirstToSecond;
        #endregion

        #region Элемент первого списка привязывается ко второму.
        FirstToSecond:
            // До тех пор, пока элемент первого списка не больше элемента второго списка,
            // двигаем указатель первого.
            // Нет смысла перепривязывать элементы друг к дружке в первом списке.
            while (true) {
                if (i + 1 == length1) {
                    // Следующего элемента нет, т.к. список закончился.
                    // Т.е. элемент второго списка (напр. 8) больше части первого списка (с последним элементом, напр., 6),
                    // и, т.к. первый список закончен, то его часть теперь должна сослаться на 8 и... лист отсортирован весь.
                    ptr1.Next = ptr2;
                    ptr2.Last = ptr1;
                    return;
                }
                else
                // Если следующий элемент больше элемента во втором списке.
                if (ptr1.Next.Value.CompareTo(ptr2.Value) == 1) {
                    break;
                }
                else {
                    ptr1 = ptr1.Next;
                    i++;
                }
            }

            // Сочленять позже будем точно к первому листу и к его следующему элементу, т.к. его значение наибольшее.
            ptr1 = ptr1.Next;
            // ptr1.Last и ptr2 теперь должны ссылаться друг на друга.
            ptr2.Last = ptr1.Last;
            ptr1.Last.Next = ptr2;
            // Теперь сочленять точно будем к ptr1.Next.Next, т.к. он наибольший.
            i++;
            goto SecondToFirst;

            #region Save
            //// Последний элемент в первом списке, значит, оптимизировать ничего не нужно - привязываем его во второй и дело с концом.
            //if (length1 == i + 1) {
            //    ptr1.Next = ptr2;
            //    return;
            //}

            //// До тех пор, пока элемент первого списка не больше элемента второго списка,
            //// двигаем указатель первого.
            //// Нет смысла перепривязывать элементы друг к дружке в первом списке.
            //// Обратите внимание, что ptr1.Next обязан быть не null, т.е. первый список обязательно не единичный.
            //while (ptr1.Next.Value.CompareTo(ptr2.Value) != 1) {
            //    if (i + 1 == length1) {
            //        // Следующего элемента нет, т.к. список закончился.
            //        // Т.е. элемент второго списка (напр. 8) больше части первого списка (с последним элементом, напр., 6),
            //        // и, т.к. первый список закончен, то его часть теперь должна сослаться на 8 и... лист отсортирован весь.
            //        ptr1.Next = ptr2;
            //        return;
            //    }

            //    ptr1 = ptr1.Next;
            //    i++;
            //}

            //ptr1.Next = ptr2;
            //// Теперь сочленять точно будем к ptr1.Next, т.к. он наибольший.
            //ptr1 = ptr1.Next;
            //i++;
            //goto SecondToFirst;
            #endregion

            #endregion

            #endregion

        }

    }
}
