using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAOD_List {
    internal sealed partial class MainForm : Form {



        internal MainForm() {
            InitializeComponent();
            Test();
        }



        private void MainForm_Load(object sender, EventArgs e) { }


        internal void Test() {
            //var a = new MyList<string>();
            //try {
            //    MessageBox.Show(a[0]);
            //}
            //catch (Exception) { }

            //a.Append("0");
            //MessageBox.Show(a[0]);
            //try {
            //    MessageBox.Show(a[1]);
            //}
            //catch (Exception) { }

            //a.Prepend("1");
            //MessageBox.Show(a[0] + " " + a[1]);
            //try {
            //    MessageBox.Show(a[2]);
            //}
            //catch (Exception) { }

            //a.Clear();
            //try {
            //    MessageBox.Show(a[0]);
            //}
            //catch (Exception) { }

            //a.Prepend("0");
            //MessageBox.Show(a[0]);
            //try {
            //    MessageBox.Show(a[1]);
            //}
            //catch (Exception) { }

            //a.Append("1");
            //MessageBox.Show(a[0] + " " + a[1]);
            //try {
            //    MessageBox.Show(a[2]);
            //}
            //catch (Exception) { }

            //a.Clear();
            //try {
            //    MessageBox.Show(a[0]);
            //}
            //catch (Exception) { }

            //a.Append("0");
            //a.Append("1");
            //a.Append("2");
            //a.Prepend("-1");
            //a.Prepend("-2");
            //a.Prepend("-3");
            //MessageBox.Show(a[3]);
            //a.RemoveAt(3);
            //MessageBox.Show(a[3]);
            //a[3] = "0";
            //MessageBox.Show(a[3]);

            //a.Clear();

            var b = new MyList<int>() { 8, 9, 1, 4, 9, 6, 8, 6, 5, 1, 9 };
            var c = b.ToArray().ToList();
            c.Sort();
            var d = c.ToArray();
            b.MergeSort();
            for (int i = 0; i < d.Length; i++) {
                if (b[i] != d[i]) {
                    throw new Exception();
                }
            }
            var s = 5;


        }

    }
}
