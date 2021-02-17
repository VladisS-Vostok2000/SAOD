using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAOD_Queue {
    internal sealed class MyWindow {
        private float speedCoefficient = 1;
        internal float IntervalCoefficient {
            get => speedCoefficient;
            set {
                if (value <= 0) {
                    throw new ArgumentOutOfRangeException("SpeedCoefficient", value.ToString(), "Недопустимая скорость времени.");
                }
                speedCoefficient = value;
                timer.Interval = (int)Math.Round(1000 * value);
            }
        }

        internal int Number { get; set; }
        internal bool Busy => timer.Enabled;

        /// <summary>  Окно освободилось. </summary>
        internal event EventHandler WindowOpened;


        private readonly Timer timer;
        private readonly MyTime myTime = new MyTime();
        private readonly Label status;


        private readonly string openedWindowStatus = "Свободно";



        internal MyWindow(Timer timer, Label timerLabel, int windowNumber) :this(timer, timerLabel) {
            Number = windowNumber;
        }
        internal MyWindow(Timer timer, Label timerLabel) {
            this.timer = timer;
            timer.Tick += Timer_Tick;
            status = timerLabel;
            status.Text = openedWindowStatus;
            myTime.TimerExpired += MyTime_TimerExpired;
            myTime.SecundesChanged += MyTime_SecundesChanged;
        }



        internal void DoTask(int seconds) {
            myTime.Secundes = seconds;
            timer.Enabled = true;
        }

        private void Timer_Tick(object sender, EventArgs e) => myTime.Tick();
        private void MyTime_TimerExpired(object sender, EventArgs e) {
            timer.Enabled = false;
            status.Text = openedWindowStatus;
            WindowOpened?.Invoke(this, EventArgs.Empty);
        }
        private void MyTime_SecundesChanged(object sender, EventArgs e) => status.Text = sender.ToString();

    }
}
