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
    internal sealed partial class MainForm : Form {
        private readonly MyQueue<string> talonQueue = new MyQueue<string>(20);
        private int talonFreeNumber = 2560;
        private readonly List<MyWindow> myWindows = new List<MyWindow>();



        internal MainForm() {
            InitializeComponent();
            myWindows.Add(new MyWindow(MainFormTmrWindow1, MainFormLblWindow1Timer, 1));
            myWindows.Add(new MyWindow(MainFormTmrWindow2, MainFormLblWindow2Timer, 2));
            myWindows.Add(new MyWindow(MainFormTmrWindow3, MainFormLblWindow3Timer, 3));
            foreach (var window in myWindows) {
                window.WindowOpened += Window_WindowOpened;
            }
        }



        private void MainForm_Load(object sender, EventArgs e) { }


        private void Window_WindowOpened(object sender, EventArgs e) {
            if (!talonQueue.IsEmpty) {
                FindFreeWindow();
            }
        }


        private void MainFormBttnGetTalon_Click(object sender, EventArgs e) {
            try {
                string nextTalon = $"{talonFreeNumber:X}";
                talonQueue.Push(nextTalon);
                talonFreeNumber++;
                FindFreeWindow();
                MessageBox.Show($"Талон {nextTalon} зарегестрирован в очереди.");
            }
            catch (StackOverflowException) {
                MessageBox.Show("Очередь заполнена!");
            }
        }
        private void FindFreeWindow() {
            foreach (var window in myWindows) {
                if (!window.Busy) {
                    MainFormTxtbxNewTalon.Text = $"Талон {talonQueue.Pop} - окно {window.Number}";
                    window.DoTask(new Random().Next(60, 180));
                    break;
                }
            }
        }
        private void MainFormTxtbxNewTalon_TextChanged(object sender, EventArgs e) => Console.Beep();


        private void MainFormTrckbrSpeed_Scroll(object sender, EventArgs e) {
            foreach (var window in myWindows) {
                window.IntervalCoefficient = (float)((sender as TrackBar).Value * 1.0 / 100);
            }
        }


        internal void Test() {
            MyQueue<string> queue = new MyQueue<string>(5);
            try {
                var a = queue.Pop;
                a = queue.Top;
            }
            catch (Exception) { }

            queue.Push("a");
            queue.Push("b");
            queue.Push("c");
            queue.Push("d");
            queue.Push("e");

            try {
                queue.Push("f");
            }
            catch (Exception) { }

            try {
                while (true) {
                    MessageBox.Show(queue.Pop);
                }
            }
            catch (Exception) { }

            MessageBox.Show("Вторая волна.");
            queue.Push("a");
            queue.Push("b");
            queue.Push("c");
            MessageBox.Show(queue.Pop);
            queue.Push("d");
            queue.Push("e");
            MessageBox.Show(queue.Pop);
            queue.Push("f");
            queue.Push("g");
            MessageBox.Show(queue.Pop);
            queue.Push("h");

            try {
                while (true) {
                    MessageBox.Show(queue.Pop);
                }
            }
            catch (Exception) { }
        }

    }
}
