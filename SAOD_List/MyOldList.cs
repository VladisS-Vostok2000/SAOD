using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAOD_List {
    /// <summary>
    /// Двусвязный линейный список.
    /// </summary>
    internal sealed class MyOldList<T> where T : IEquatable<T>, IComparable<T> {
        internal int Length { get; private set; }
        /// <summary>
        /// Индекс последнего элемента списка.
        /// </summary>
        internal int Last => Empty ? -1 : Length - 1;
        /// <summary>
        /// Индекс первого элемента списка.
        /// </summary>
        internal int First => Empty ? -1 : 0;
        internal int Capability => list.Length;
        private bool Empty => Length == 0;


        private T[] list;
        private int[] prew;
        private int[] next;
        /// <summary>
        /// Индекс массива входной точки листа.
        /// </summary>
        private int top;
        /// <summary>
        /// Индекс массива последнего элемента листа.
        /// </summary>
        private int last;



        internal MyOldList() => Initialize(10);
        internal MyOldList(in int capability) {
            if (capability < 1) {
                throw new ArgumentOutOfRangeException();
            }

            Initialize(capability);
        }
        private void Initialize(in int capability) {
            list = new T[capability];
            next = new int[capability];
            prew = new int[capability];
            for (int i = 0; i < next.Length; i++) {
                next[i] = -1;
                prew[i] = -1;
            }
        }



        internal T this[in int index] {
            get => At(index);
            set => list[AtList(index)] = value;
        }



        /// <summary>
        /// Добавляет элемент в конец списка.
        /// </summary>
        internal void Append(T item) {
            if (Empty) {
                AddFirstElement(item);
            }
            else {
                int newItemIndex = FindFreeIndex();
                Create(item, newItemIndex, last, -1);
                next[last] = newItemIndex;
                last = newItemIndex;
            }
            Length++;
        }
        /// <summary>
        /// Добавляет элемент в начало списка.
        /// </summary>
        internal void Prepend(T item) {
            if (Empty) {
                AddFirstElement(item);
            }
            else {
                int newItemIndex = FindFreeIndex();
                Create(item, newItemIndex, -1, top);
                prew[top] = newItemIndex;
                top = newItemIndex;
            }
            Length++;
        }
        private void Create(T item, in int index, in int prewIndex, in int nextIndex) {
            list[index] = item;
            next[index] = nextIndex;
            prew[index] = prewIndex;
        }
        private void AddFirstElement(T item) {
            Create(item, 0, -1, -1);
            top = last = 0;
        }
        private int FindFreeIndex() {
            if (Length == 1) {
                return (top + 1) % Capability;
            }
            else
            if (Length == Capability) {
                int freeIndex = Capability;
                AllocateMemory();
                return freeIndex;
            }
            else {
                for (int i = 0; i < Capability; i++) {
                    if (next[i] == -1 && prew[i] == -1) {
                        return i;
                    }
                }
            }
            throw new Exception();
        }
        private void AllocateMemory() {
            int newCapability = Capability * 2;
            var newArray = new T[newCapability];
            var newNext = new int[newCapability];
            var newPrew = new int[newCapability];
            for (int i = 0; i < Capability; i++) {
                newArray[i] = list[i];
                newNext[i] = next[i];
                newPrew[i] = prew[i];
            }
            list = newArray;
            next = newNext;
            prew = newPrew;
        }

        /// <summary> 
        /// Вернёт элемент по заданному индексу.
        /// </summary>
        internal T At(in int index) => list[AtList(index)];
        /// <summary>
        /// Вернёт по номеру добавления элемента его индекс в массиве.
        /// </summary>
        private int AtList(in int index) {
            if (index < 0 || index >= Length) {
                throw new ArgumentOutOfRangeException();
            }

            int itemIndex = top;
            for (int i = 0; i < index; i++) {
                itemIndex = next[itemIndex];
            }

            return itemIndex;
        }

        /// <summary>
        /// Удалит элемент.
        /// </summary>
        internal void RemoveAt(in int index) {
            if (index < 0 || index >= Length) {
                throw new ArgumentOutOfRangeException();
            }

            if (Last == 0) {
                Length--;
                return;
            }

            int removedIndex = AtList(index);
            if (prew[removedIndex] != -1) {
                next[prew[removedIndex]] = next[removedIndex];
            }
            if (next[removedIndex] != -1) {
                prew[next[removedIndex]] = prew[removedIndex];
            }

            if (removedIndex == last) {
                last = prew[removedIndex];
            }
            else
            if (removedIndex == top) {
                top = next[removedIndex];
            }
            RemoveAtList(removedIndex);
            Length--;
        }
        /// <summary>
        /// Пометит элемент из массива как удалённый.
        /// </summary>
        private void RemoveAtList(in int index) => next[index] = prew[index] = -1;

        internal void Clear() {
            next = Enumerable.Repeat(-1, Capability).ToArray();
            prew = Enumerable.Repeat(-1, Capability).ToArray();
            Length = 0;
        }

        /// <summary>
        /// Копирует элементы списка в новый массив.
        /// </summary>
        internal T[] ToArray() {
            var out_array = new T[Length];
            int nextElement = top;
            for (int i = 0; i < Length; i++) {
                out_array[i] = list[nextElement];
                nextElement = next[nextElement];
            }
            return out_array;
        }

        /// <summary>
        /// Возвращает первый найденный в списке элемент.
        /// </summary>
        /// <returns> Массив <see cref="T"/>. Пуст, если элемент найден не был. </returns>
        internal T[] Find(T target) {
            int index = FindAtList(target);
            return index == -1 ? (new T[0]) : (new T[] { list[index] });
        }

        /// <summary>
        /// Возвращает наименьший индекс эквивалентного заданному элемента в списке.
        /// </summary>
        /// <returns> -1, если элемент не найден, индекс. </returns>
        internal int FindAt(T target) {
            int nextIndex = top;
            for (int i = 0; i < Length; i++) {
                if (list[nextIndex].Equals(target)) {
                    return i;
                }
                else {
                    nextIndex = next[nextIndex];
                }
            }
            return -1;
        }
        /// <summary>
        /// Возвращает индекс элемента массива, содержащий первый эквивалентный заданному элемент в списке.
        /// </summary>
        /// <returns> -1, если элемент не найден, индекс. </returns>
        private int FindAtList(T target) {
            int nextIndex = top;
            for (int i = 0; i < Length; i++) {
                if (list[nextIndex].Equals(target)) {
                    return nextIndex;
                }
                else {
                    nextIndex = next[nextIndex];
                }
            }
            return -1;
        }

        /// <summary>
        /// Удаляет элемент из списка.
        /// </summary>
        /// <returns> True, если элемент был найден и удалён. </returns>
        internal bool Remove(T target) {
            int nextIndex = top;
            for (int i = 0; i < Length; i++) {
                if (list[nextIndex].Equals(target)) {
                    RemoveAt(nextIndex);
                    return true;
                }
                else {
                    nextIndex = next[nextIndex];
                }
            }
            return false;
        }

        internal void Sort() {
            bool sorted;
            while (true) {
                sorted = true;
                for (int i = 0; i < Last; i++) {
                    int first = AtList(i);
                    int second = AtList(i + 1);
                    if (list[first].CompareTo(list[second]) > 0) {
                        sorted = false;
                        Swap(first, second);
                    }
                }
                if (sorted) {
                    break;
                }
            }
        }
        private void Swap(in int first, in int second) {
            if (prew[first] != -1) {
                next[prew[first]] = second;
            }
            prew[second] = prew[first];

            if (next[second] != -1) {
                prew[next[second]] = first;
            }
            next[first] = next[second];

            next[second] = first;
            prew[first] = second;

            if (top == first) {
                top = second;
            }
            else
            if (top == second) {
                top = first;
            }

            if (first == last) {
                last = second;
            }
            else
            if (second == last) {
                last = first;
            }
        }

    }
}
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SAOD_List {
//    internal sealed class MyList<T> {
//        private MyListNode<T>[] list;
//        /// <summary> Первый добавленный элемент. </summary>
//        private int top = -1;
//        /// <summary> Последний добавленный элемент. </summary>
//        private int last = -1;
//        internal bool Empty { get; private set; } = true;
//        internal int Length { get; private set; }
//        internal int Capability => list.Length;



//        internal MyList() => list = new MyListNode<T>[10];



//        internal T this[int index] {
//            get => At(index);
//            set {
//                // !!!!
//            }
//        }



//        internal void Append(T item) {
//            if (Empty) {
//                AddFirstItem(item);
//            }
//            else {
//                int newItemIndex = FindEmptySlot();
//                list[last].IndexNext = newItemIndex;
//                list[newItemIndex] = new MyListNode<T>(item, last, -1);
//                last = newItemIndex;
//            }
//            Length++;
//        }
//        internal void Prepend(T item) {
//            if (Empty) {
//                AddFirstItem(item);
//            }
//            else {
//                int newItemIndex = FindEmptySlot();
//                list[top].IndexLast = newItemIndex;
//                list[newItemIndex] = new MyListNode<T>(item, -1, top);
//                top = newItemIndex;
//            }
//        }
//        private void AddFirstItem(T item) {
//            top = last = 0;
//            list[0] = new MyListNode<T>(item, -1, -1);
//            Empty = false;
//        }
//        private int FindEmptySlot() {
//            if (Length == 1) {
//                return (top + 1) % Capability;
//            }
//            else {
//                for (int i = 0; i < list.Length; i++) {
//                    if (list[i].Empty) {
//                        return i;
//                    }
//                }
//            }

//            int firstIndexInNewArray = list.Length;
//            AllocateMemory();
//            return firstIndexInNewArray;
//        }
//        private void AllocateMemory() {
//            var newList = new MyListNode<T>[list.Length * 2];
//            list.CopyTo(newList, 0);
//            list = newList;
//        }

//        internal T At(int index) {
//            if (Empty) {
//                throw new ArgumentOutOfRangeException();
//            }

//            int nextItemIndex = top;
//            for (int i = 0; i < index; i++) {
//                nextItemIndex = list[nextItemIndex].IndexNext;
//            }
//            return list[nextItemIndex].Value;
//        }
//        internal void Clear() {

//        }


//    }
//}
