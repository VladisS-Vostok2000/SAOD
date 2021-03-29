using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAOD_Hash {
    internal sealed class MyHashTable<T> {
        internal int Capability => hashTable.Length;
        
        private List<T>[] hashTable;
        
        internal int length;
        internal int Length {
            get => length;
            set {
                length = value;
                Changed?.Invoke(this, EventArgs.Empty);
            }
        }

        internal event EventHandler Changed;



        internal MyHashTable(int capability) {
            if (capability < 1) {
                throw new Exception();
            }

            hashTable = new List<T>[capability];
            Clear();
        }



        internal void Add(T target) {
            List<T> list = GetList(target);
            list.Add(target);
            Length++;
        }
        private List<T> GetList(T target) {
            int rawIndex = target.GetHashCode();
            int hash = Math.Abs(rawIndex % Capability);
            return hashTable[hash];
        }

        internal void Remove(T target) {
            var list = GetList(target);
            bool deleted = list.Remove(target);
            if (deleted) {
                Length--;
            }
        }
        
        internal T[] ToArray() {
            var out_array = new T[length];
            int i = 0;
            foreach (var list in hashTable) {
                for (int j = 0; j < list.Count; i++, j++) {
                    out_array[i] = list[j];
                }
            }

            return out_array;
        }

        internal void Clear() {
            for (int i = 0; i < Capability; i++) {
                hashTable[i] = new List<T>();
            }
        }

        internal bool Contains(T target) {
            List<T> list = GetList(target);
            return list.Contains(target);
        }

    }
}
