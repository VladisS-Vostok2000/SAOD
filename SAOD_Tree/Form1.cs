using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAOD_Tree {
    public partial class Form1 : Form {



        public Form1() {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e) {
            var tree = new MyTree<int>();
            tree.Add(50);
            tree.Add(25);
            tree.Add(75);
            tree.Add(35);
            tree.Add(45);
            tree.Add(55);
            tree.Add(65);
            var c = tree.ToArray();
            foreach (var value in c) {
                MessageBox.Show(value.ToString());
            }
            MessageBox.Show(tree.Contains(50).ToString() + tree.Contains(51).ToString() + tree.Contains(66).ToString());

            tree.Clear();
            MessageBox.Show(tree.Contains(50).ToString() + tree.Contains(51).ToString() + tree.Contains(66).ToString());

            tree.Add(100, 150, 200, 50, 0, 125, 175, 75, 25);
            tree.Remove(100);
            tree.Remove(150);
            tree.Remove(200);
            c = tree.ToArray();
            foreach (var item in c) {
                MessageBox.Show(item.ToString());
            }

            tree.Clear();
            tree.Remove(5);
            tree.Add(5);
            tree.Remove(5);

        }

    }
}
