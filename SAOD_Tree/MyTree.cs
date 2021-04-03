﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAOD_Tree {
    internal sealed class MyTree<T> where T : IComparable, IEquatable<T> {
        bool Empty => Length == 0;
        int Length = 0;
        private MyTreeNode<T> first;



        internal MyTree() { }



        /// <summary>
        /// Добавит элемент в дерево.
        /// </summary>
        internal void Add(T value) {
            if (Length == 0) {
                first = new MyTreeNode<T>(value, null, null);
            }
            else {
                MyTreeNode<T> node = first;
                var newNode = new MyTreeNode<T>(value, null, null);
                while (true) {
                    if (value.CompareTo(node.Value) == -1) {
                        if (node.Left != null) {
                            // Нужно вставить слева, но элемент слева уже есть.
                            node = node.Left;
                        }
                        else {
                            node.Left = newNode;
                            break;
                        }
                    }
                    else {
                        if (node.Right != null) {
                            // Нужно вставить справа, но элемент справа уже есть.
                            node = node.Right;
                        }
                        else {
                            node.Right = newNode;
                            break;
                        }
                    }
                }
            }

            Length++;
        }
        internal void Add(params T[] values) {
            foreach (var value in values) {
                Add(value);
            }
        }

        /// <summary>
        /// Очистит дерево.
        /// </summary>
        internal void Clear() {
            first = null;
            Length = 0;
        }

        /// <summary>
        /// True, если заданное значение содержится в дереве.
        /// </summary>
        internal bool Contains(T target) {
            MyTreeNode<T> node = first;
            while (node != null) {
                int compareResult = target.CompareTo(node.Value);
                if (compareResult == 0) {
                    return true;
                }
                else
                if (compareResult == -1) {
                    node = node.Left;
                }
                else {
                    node = node.Right;
                }
            }
            return false;
        }

        internal T[] ToArray() {
            T[] out_array = new T[Length];
            int index = new int();
            AddValueToArray(out_array, ref index, first);
            return out_array;
        }
        private void AddValueToArray(T[] array, ref int arrayIndexToAdd, MyTreeNode<T> nodeToAdd) {
            array[arrayIndexToAdd++] = nodeToAdd.Value;
            if (nodeToAdd.Left != null) {
                AddValueToArray(array, ref arrayIndexToAdd, nodeToAdd.Left);
            }
            if (nodeToAdd.Right != null) {
                AddValueToArray(array, ref arrayIndexToAdd, nodeToAdd.Right);
            }
        }

        /// <summary>
        /// Возвращает массив текущих элементов дерева в порядке возрастания.
        /// </summary>
        internal T[] ToSortedArray() {
            T[] outArray = new T[Length];
            int arrayIndexToAdd = 0;
            AddValueToSortedArray(outArray, ref arrayIndexToAdd, first);
            return outArray;
        }
        private void AddValueToSortedArray(T[] array, ref int arrayIndexToAdd, MyTreeNode<T> nodeToAdd) {
            if (nodeToAdd.Left != null) {
                AddValueToSortedArray(array, ref arrayIndexToAdd, nodeToAdd.Left);
            }

            array[arrayIndexToAdd++] = nodeToAdd.Value;

            if (nodeToAdd.Right != null) {
                AddValueToSortedArray(array, ref arrayIndexToAdd, nodeToAdd.Right);
            }
        }


        /// <summary>
        /// Удалит заданный элемент из дерева, если он есть.
        /// </summary>
        internal void Remove(T target) {
            MyTreeNode<T> nodeForDelete = first;
            // prewNodeForDelete устаналивается с самим объектом,
            // чтобы избежать излишних проверок при частных случаях.
            MyTreeNode<T> prewNodeForDelete = first;
            // Ищем элемент, который нужно удалить, и к нему предыдущий.
            try {
                do {
                    int compareResult = target.CompareTo(nodeForDelete.Value);
                    if (compareResult == -1) {
                        prewNodeForDelete = nodeForDelete;
                        nodeForDelete = nodeForDelete.Left;
                    }
                    else
                    if (compareResult == 1) {
                        prewNodeForDelete = nodeForDelete;
                        nodeForDelete = nodeForDelete.Right;
                    }
                    else {
                        break;
                    }
                } while (true);
            }
            catch (NullReferenceException) {
                return;
            }

            // Будем искать наибольший элемент.
            if (nodeForDelete.Left != null) {
                // Наибольший элемент у порога.
                if (nodeForDelete.Left.Right == null) {
                    nodeForDelete.Value = nodeForDelete.Left.Value;
                    nodeForDelete.Left = nodeForDelete.Left.Left;
                }
                // Спускаемся по дереву.
                else {
                    MyTreeNode<T> nodeForSwap = nodeForDelete.Left;
                    MyTreeNode<T> prewNodeForSwap;
                    do {
                        prewNodeForSwap = nodeForSwap;
                        nodeForSwap = nodeForSwap.Right;
                    } while (nodeForSwap.Right != null);

                    nodeForDelete.Value = nodeForSwap.Value;
                    prewNodeForSwap.Right = nodeForSwap.Left;
                }
            }
            else
            // Будем искать наименьший элемент.
            if (nodeForDelete.Right != null) {
                // Наименьший элемент у порога
                if (nodeForDelete.Right.Left == null) {
                    nodeForDelete.Value = nodeForDelete.Right.Value;
                    nodeForDelete.Right = nodeForDelete.Right.Right;
                }
                else {
                    MyTreeNode<T> nodeForSwap = nodeForDelete.Right;
                    MyTreeNode<T> prewNodeForSwap;
                    do {
                        prewNodeForSwap = nodeForSwap;
                        nodeForSwap = nodeForSwap.Left;
                    } while (nodeForSwap.Left != null);

                    nodeForDelete.Value = nodeForSwap.Value;
                    prewNodeForSwap.Left = nodeForSwap.Right;
                }
            }
            // Если найденный элемент - конечный в дереве.
            else {
                int compareResult = nodeForDelete.Value.CompareTo(prewNodeForDelete.Value);
                // Если элемент стоит справа от предыдущего. 
                if (compareResult == 1) {
                    prewNodeForDelete.Right = null;
                }
                else
                // Если элемент стоит слева от предыдщуего.
                if (compareResult == -1) {
                    prewNodeForDelete.Left = null;
                }
                // Элемент в дереве единственный.
                else {
                    first = null;
                }
            }

            Length--;
        }

    }
}
