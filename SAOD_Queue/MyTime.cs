using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAOD_Queue {
    internal sealed class MyTime {
        private int secundes;
        internal int Secundes {
            get => secundes;
            set {
                if (value < 0) {
                    secundes = 0;
                    TimerExpired?.Invoke(this, EventArgs.Empty);
                }
                else {
                    secundes = value;
                    SecundesChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }
        internal int Minute => Secundes / 60;
        internal int Secunde => Secundes % 60;
        public event EventHandler TimerExpired;
        public event EventHandler SecundesChanged;



        internal MyTime(int minute, int secunde) {
            Secundes = minute * 60 + secunde;
        }
        internal MyTime(int secundes) {
            Secundes = secundes;
        }
        internal MyTime() { }



        /// <summary>
        /// Отнимает секунду.
        /// </summary>
        internal void Tick() => --Secundes;


        public override string ToString() => $"{Minute}:{Secunde: 00}";

    }
}
